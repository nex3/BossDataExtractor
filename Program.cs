using Fluid;
using SoulsFormats;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Fluid.Values;
using WebMarkupMin.Core;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;

var gamePath = "D:\\Natalie\\Steam\\steamapps\\common\\ELDEN RING\\Game\\";
var paramdefPath = "F:\\Mods\\Smithbox_1_0_13\\Smithbox\\Assets\\Paramdex\\ER\\Defs";

var bossName = "Lion";
int? bossId = 52100088;
var displayType = Display.Full;
var minify = true;

var boss = bossId == null
    ? Boss.KnownBosses.Find((boss) => boss.Name.Contains(bossName))
    : Boss.KnownBosses.Find((boss) => boss.ID == bossId);
if (boss == null)
{
    throw new Exception($"No boss found named {bossName}");
}

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

var attacksForEnemy = new Dictionary<int, List<PARAM.Row>>();
foreach (var attack in attacks.Rows)
{
    var behaviorID = attack.ID / 1000;
    if (attacksForEnemy.TryGetValue(behaviorID, out var attackList))
    {
        attackList.Add(attack);
    }
    else
    {
        attacksForEnemy[behaviorID] = [];
        attacksForEnemy[behaviorID].Add(attack);
    }
}

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

List<(DamageType, string)> defenseParams = [
    (DamageType.Standard, "neutralDamageCutRate"),
    (DamageType.Slash, "slashDamageCutRate"),
    (DamageType.Strike, "blowDamageCutRate"),
    (DamageType.Pierce, "thrustDamageCutRate"),
    (DamageType.Magic, "magicDamageCutRate"),
    (DamageType.Fire, "fireDamageCutRate"),
    (DamageType.Lightning, "thunderDamageCutRate"),
    (DamageType.Holy, "darkDamageCutRate"),
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
// all damage types. Phil's data doesn't have defense as multiplicative between NG and NG+, but
// that's inconsistent with other stats and leads to a bunch of bosses having less defense in NG+
// so I think it's wrong.
var ngDefense = 100 * (float)ngScaling["physicsDiffenceRate"].Value;
var ngpDefense = ngDefense * (float)ngpScaling["physicsDiffenceRate"].Value;
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

List<List<int>>? resistances(
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

boss.Resistance[StatusType.Poison] = resistances(
    "resist_poison",
    "resistCorrectId_poison",
    "registPoizonChangeRate",
    "PoisionResistRate"
);
boss.Resistance[StatusType.ScarletRot] = resistances(
    "resist_desease",
    "resistCorrectId_disease",
    "registDiseaseChangeRate",
    "DiseaseResistRate"
);
boss.Resistance[StatusType.Hemorrhage] = resistances(
    "resist_blood",
    "resistCorrectId_blood",
    "registBloodChangeRate",
    "BloodResistRate"
);
boss.Resistance[StatusType.Frostbite] = resistances(
    "resist_freeze",
    "resistCorrectId_freeze",
    "registFreezeChangeRate",
    "FreezeResistRate"
);
boss.Resistance[StatusType.Sleep] = resistances(
    "resist_sleep",
    "resistCorrectId_sleep",
    "registSleepChangeRate",
    "SleepResistRate"
);
boss.Resistance[StatusType.Madness] = resistances(
    "resist_madness",
    "resistCorrectId_madness",
    "registMadnessChangeRate",
    "MadnessResistRate"
);

var fluid = new FluidParser();

var templateRoot = Path.Combine(
    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
    @"Template"
);
var options = new TemplateOptions();
options.MemberAccessStrategy = UnsafeMemberAccessStrategy.Instance;
options.Filters.AddFilter("spaceToPlus", (input, args, context) =>
    new StringValue(input.ToStringValue().Replace(' ', '+')));
options.Filters.AddFilter("number", (input, args, context) =>
    new StringValue($"{input.ToNumberValue():n0}"));
options.Filters.AddFilter("slugify", (input, args, context) =>
    new StringValue(Regex.Replace(input.ToStringValue(), "[^a-z0-9]+", "-")));
options.FileProvider = new PhysicalFileProvider(templateRoot);

string path = options.FileProvider.GetFileInfo(
    Enum.GetName(typeof(Display), displayType) + ".liquid"
).PhysicalPath!;
var template = fluid.Parse(File.ReadAllText(path));
var context = new TemplateContext(new Context(displayType, boss), options);
var html = template.Render(context);
if (minify) html = new HtmlMinifier().Minify(html).MinifiedContent;

Thread thread = new Thread(() => Clipboard.SetText(html));
thread.SetApartmentState(ApartmentState.STA);
thread.Start();
thread.Join();
