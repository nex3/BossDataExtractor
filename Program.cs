using Fluid;
using Fluid.Parser;
using SoulsFormats;
using System.Reflection;

var gamePath = "D:\\Natalie\\Steam\\steamapps\\common\\ELDEN RING\\Game\\";
var paramdefPath = "F:\\Mods\\Smithbox_1_0_13\\Smithbox\\Assets\\Paramdex\\ER\\Defs";

var paramsWeCareAbout = new HashSet<string>([
    "NpcParam", "GameAreaParam", "MultiPlayCorrectionParam", "ResistCorrectParam", "SpEffectParam",
    "AtkParam_Npc", "ClearCountCorrectParam"
]);

Console.WriteLine("Loading params...");

var paramdefs = new Dictionary<string, PARAMDEF>();
foreach (var file in Directory.GetFiles(paramdefPath, "*.xml"))
{
    var paramdef = PARAMDEF.XmlDeserialize(file)!;
    paramdefs[paramdef.ParamType] = paramdef;
}

var bnd = SFUtil.DecryptERRegulation($"{gamePath}\\regulation.bin");
var paramDict = new Dictionary<string, PARAM>();
foreach (var file in bnd.Files)
{
    if (!file.Name.ToUpper().EndsWith(".PARAM")) continue;

    var paramName = Path.GetFileNameWithoutExtension(file.Name);
    if (!paramsWeCareAbout.Contains(paramName)) continue;

    var param = PARAM.ReadIgnoreCompression(file.Bytes);

    param.ApplyParamdef(paramdefs[param.ParamType]);
    paramDict[paramName] = param;
}

Console.WriteLine("Params loaded!");

var npcs = paramDict["NpcParam"];
var spEffects = paramDict["SpEffectParam"];
var attacks = paramDict["AtkParam_Npc"];
var clearCountParams = paramDict["ClearCountCorrectParam"];
var gameAreaParam = paramDict["GameAreaParam"];
var resistCorrectParam = paramDict["ResistCorrectParam"];

List<Boss> bosses = [
    new Boss(21300014, "Margit, the Fell Omen", 10000850),
    new Boss(49110052, "Great Wyrm Theodorix", 1050560800),
    new Boss(58100980, "Demi-Human Swordmaster Onze", 41000800),
];

var attacksForEnemy = new Dictionary<int, List<PARAM.Row>>();
foreach (var attack in attacks.Rows)
{
    var behavior = attack.ID / 1000;
    if (attacksForEnemy.TryGetValue(behavior, out var attackList))
    {
        attackList.Add(attack);
    }
    else
    {
        attacksForEnemy[behavior] = [];
        attacksForEnemy[behavior].Add(attack);
    }
}

foreach (var boss in bosses)
{
    var bossParams = npcs[boss.ID];

    boss.Stance = (int)Math.Round((float)bossParams["superArmorDurability"].Value);

    var behavior = bossParams["behaviorVariationId"];
    if (attacksForEnemy.TryGetValue((int)behavior.Value / 10, out var bossAttacks))
    {
        foreach (var attack in bossAttacks)
        {
            if ((ushort)attack["atkPhys"].Value > 0)
            {
                switch ((byte)attack["atkAttribute"].Value)
                {
                    case 0:
                        boss.DamageTypes.Add(DamageType.Slash);
                        break;
                    case 1:
                        boss.DamageTypes.Add(DamageType.Strike);
                        break;
                    case 2:
                        boss.DamageTypes.Add(DamageType.Pierce);
                        break;
                    default:
                        boss.DamageTypes.Add(DamageType.Standard);
                        break;
                }
            }

            if ((ushort)attack["atkMag"].Value > 0)
            {
                boss.DamageTypes.Add(DamageType.Magic);
            }
            if ((ushort)attack["atkFire"].Value > 0)
            {
                boss.DamageTypes.Add(DamageType.Fire);
            }
            if ((ushort)attack["atkThun"].Value > 0)
            {
                boss.DamageTypes.Add(DamageType.Lightning);
            }
            if ((ushort)attack["atkDark"].Value > 0)
            {
                boss.DamageTypes.Add(DamageType.Holy);
            }
        }
    }

    List<(string, string)> defenseParams = [
        ("Standard", "neutralDamageCutRate"),
        ("Slash", "slashDamageCutRate"),
        ("Strike", "blowDamageCutRate"),
        ("Pierce", "thrustDamageCutRate"),
        ("Magic", "magicDamageCutRate"),
        ("Fire", "fireDamageCutRate"),
        ("Lightning", "thunderDamageCutRate"),
        ("Holy", "darkDamageCutRate"),
    ];
    foreach (var (name, param) in defenseParams)
    {
        var value = 1 - (float)bossParams[param].Value;
        boss.TypeDefense[name] = (int)Math.Round(100 * value);
    }

    var ngScaling = spEffects[(int)bossParams["spEffectID3"].Value];
    var ngpScaling = spEffects[(int)bossParams["GameClearSpEffectID"].Value];

    var baseHP = (uint)bossParams["hp"].Value;
    var ngHP = baseHP * (float)ngScaling["maxHpRate"].Value;
    var ngpHP = ngHP * (float)ngpScaling["maxHpRate"].Value;
    boss.HP.Add((int)Math.Floor(ngHP));
    boss.HP.Add((int)Math.Floor(ngpHP));
    for (var i = 2; i < 8; i++)
    {
        boss.HP.Add((int)Math.Floor(ngpHP * (float)clearCountParams[i]["MaxHpRate"].Value));
    }

    // Base defense for all stats seems to be 100, and defense scaling seems to be consistent across
    // all damage types. Defense is also not multiplicative between NG and NG+ according to Phil.
    var ngDefense = 100 * (float)ngScaling["physicsDiffenceRate"].Value;
    var ngpDefense = 100 * (float)ngpScaling["physicsDiffenceRate"].Value;
    boss.Defense.Add((int)Math.Floor(ngDefense));
    boss.Defense.Add((int)Math.Floor(ngpDefense));
    for (var i = 2; i < 8; i++)
    {
        boss.Defense.Add(
            (int)Math.Floor(ngpDefense * (float)clearCountParams[i]["PhysicsDefenseRate"].Value)
        );
    }

    var ngRunes = (uint)gameAreaParam[boss.GameAreaID]["bonusSoul_single"].Value;
    var ngpRunes = ngRunes * (float)ngpScaling["haveSoulRate"].Value;
    boss.Runes.Add((int)ngRunes);
    boss.Runes.Add((int)Math.Round(ngpRunes));
    for (var i = 2; i < 8; i++)
    {
        boss.Runes.Add((int)Math.Round(ngpRunes * (float)clearCountParams[i]["SoulRate"].Value));
    }

    List<List<int>> resistances(
        String baseCell, String correctCell, String rateCell, String clearCountCell
    ) {
        var baseValue = (ushort)bossParams[baseCell].Value;
        if (baseValue == 999) return [];

        var correct = resistCorrectParam[(int)bossParams[correctCell].Value];
        var ngProc1 = baseValue * (float)ngScaling[rateCell].Value;
        var ngpProc1 = ngProc1 * (float)ngpScaling[rateCell].Value;
        List<float> firstProcs = [ngProc1, ngpProc1];
        for (var i = 2; i < 8; i++)
        {
            firstProcs.Add(ngpProc1 * (float)clearCountParams[i][clearCountCell].Value);
        }

        var resistances = firstProcs.Select((proc1) => {
            List<float> procs = [proc1];
            for (var i = 1; i < 6; i++)
            {
                procs.Add(proc1 + (float)correct[$"addPoint{i}"].Value);
            }
            return procs;
        });

        return resistances.Select(
            (procs) => procs.Select((proc) => (int)Math.Round(proc)).ToList()
        ).ToList();
    }

    boss.Resistance["Poison"] = resistances(
        "resist_poison",
        "resistCorrectId_poison",
        "registPoizonChangeRate",
        "PoisionResistRate"
    );
    boss.Resistance["Scarlet Rot"] = resistances(
        "resist_desease",
        "resistCorrectId_disease",
        "registDiseaseChangeRate",
        "DiseaseResistRate"
    );
    boss.Resistance["Hemorrhage"] = resistances(
        "resist_blood",
        "resistCorrectId_blood",
        "registBloodChangeRate",
        "BloodResistRate"
    );
    boss.Resistance["Frostbite"] = resistances(
        "resist_freeze",
        "resistCorrectId_freeze",
        "registFreezeChangeRate",
        "FreezeResistRate"
    );
    boss.Resistance["Sleep"] = resistances(
        "resist_sleep",
        "resistCorrectId_sleep",
        "registSleepChangeRate",
        "SleepResistRate"
    );
    boss.Resistance["Madness"] = resistances(
        "resist_madness",
        "resistCorrectId_madness",
        "registMadnessChangeRate",
        "MadnessResistRate"
    );
}

var fluid = new FluidParser();

string path = Path.Combine(
    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
    @"Boss.liquid"
);
var template = fluid.Parse(File.ReadAllText(path));
var context = new TemplateContext(bosses[0]);
Console.WriteLine(template.Render(context));