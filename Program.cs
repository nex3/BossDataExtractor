using SoulsFormats;

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
    Console.WriteLine();
    Console.WriteLine($"# {boss.Name}");
    var bossParams = npcs[boss.ID];

    Console.WriteLine($"Stance: {bossParams["superArmorDurability"].Value}");

    var behavior = bossParams["behaviorVariationId"];
    if (attacksForEnemy.TryGetValue((int)behavior.Value / 10, out var bossAttacks))
    {
        var types = new SortedSet<DamageType>();
        foreach (var attack in bossAttacks)
        {
            if ((ushort)attack["atkPhys"].Value > 0)
            {
                switch ((byte)attack["atkAttribute"].Value)
                {
                    case 0:
                        types.Add(DamageType.Slash);
                        break;
                    case 1:
                        types.Add(DamageType.Strike);
                        break;
                    case 2:
                        types.Add(DamageType.Pierce);
                        break;
                    default:
                        types.Add(DamageType.Standard);
                        break;
                }
            }

            if ((ushort)attack["atkMag"].Value > 0) types.Add(DamageType.Magic);
            if ((ushort)attack["atkFire"].Value > 0) types.Add(DamageType.Fire);
            if ((ushort)attack["atkThun"].Value > 0)
            {
                types.Add(DamageType.Lightning);
            }
            if ((ushort)attack["atkDark"].Value > 0) types.Add(DamageType.Holy);
        }

        Console.WriteLine($"Damage Types: {String.Join(", ", types)}");
    }

    Console.WriteLine("## Defenses");
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
        Console.WriteLine($"{name}: {Math.Round(100 * value)}");
    }

    var ngScaling = spEffects[(int)bossParams["spEffectID3"].Value];
    var ngpScaling = spEffects[(int)bossParams["GameClearSpEffectID"].Value];

    Console.WriteLine("##");

    var baseHP = (uint)bossParams["hp"].Value;
    var ngHp = baseHP * (float)ngScaling["maxHpRate"].Value;
    var ngpHP = ngHp * (float)ngpScaling["maxHpRate"].Value;
    List<float> hps = [ngHp, ngpHP];
    for (var i = 2; i < 8; i++)
    {
        hps.Add(ngpHP * (float)clearCountParams[i]["MaxHpRate"].Value);
    }
    Console.WriteLine($"HP: {String.Join("/", hps.Select((def) => Math.Floor(def)))}");

    // Base defense for all stats seems to be 100, and defense scaling seems to be consistent across
    // all damage types. Defense is also not multiplicative between NG and NG+ according to Phil.
    var ngDefense = 100 * (float)ngScaling["physicsDiffenceRate"].Value;
    var ngpDefense = 100 * (float)ngpScaling["physicsDiffenceRate"].Value;
    List<float> defences = [ngDefense, ngpDefense];
    for (var i = 2; i < 8; i++)
    {
        defences.Add(ngpDefense * (float)clearCountParams[i]["PhysicsDefenseRate"].Value);
    }
    Console.WriteLine($"Defense: {String.Join("/", defences.Select((hp) => Math.Floor(hp)))}");

    var ngRunes = (uint)gameAreaParam[boss.GameAreaID]["bonusSoul_single"].Value;
    var ngpRunes = ngRunes * (float)ngpScaling["haveSoulRate"].Value;
    List<float> runes = [ngRunes, ngpRunes];
    for (var i = 2; i < 8; i++)
    {
        runes.Add(ngpRunes * (float)clearCountParams[i]["SoulRate"].Value);
    }
    Console.WriteLine($"Runes: {String.Join("/", runes.Select((runes) => Math.Floor(runes)))}");

    Console.WriteLine("## Resistances");

    List<List<int>> resistances(
        String baseCell, String correctCell, String rateCell, String clearCountCell
    ) {
        var baseValue = (ushort)bossParams[baseCell].Value;
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

    writeResistances(
        "Poison",
        resistances(
            "resist_poison",
            "resistCorrectId_poison",
            "registPoizonChangeRate",
            "PoisionResistRate"
        )
    );
}

void writeResistances(string name, List<List<int>> resistances)
{
    Console.WriteLine($"{name}: {
        String.Join(';', resistances.Select((procs) => String.Join('/', procs)))
    }");
}

enum DamageType
{
    Standard, Slash, Strike, Pierce, Magic, Fire, Lightning, Holy
}

readonly struct Boss
{
    public Boss(int id, string name, int gameAreaID)
    {
        ID = id;
        Name = name;
        GameAreaID = gameAreaID;
    }

    public int ID { get; init; }
    public string Name { get; init; }
    public int GameAreaID { get; init; }
}