using Fluid;
using SoulsFormats;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Fluid.Values;
using WebMarkupMin.Core;
using System.IO;
using System.Windows;
using System.Text.RegularExpressions;
using System.Numerics;

var gamePath = "D:\\Natalie\\Steam\\steamapps\\common\\ELDEN RING\\Game\\";
var smithboxAssetPath = "F:\\Mods\\Smithbox_1_0_14_4\\Smithbox\\Assets";

var bossName = "Patches";
int? bossID = null;
var displayType = Display.Full;
var minify = true;

var boss = bossID == null
    ? Boss.KnownBosses.Find((boss) => boss.Name.Contains(bossName))
    : Boss.KnownBosses.Find((boss) => boss.ID == bossID);
if (boss == null)
{
    if (bossID == null)
    {
        throw new Exception($"No boss found named {bossName}");
    }
    else
    {
        throw new Exception($"No boss found with ID {bossID}");
    }
}

var paramsWeCareAbout = new HashSet<string>([
    "NpcParam", "GameAreaParam", "MultiPlayCorrectionParam", "ResistCorrectParam", "SpEffectParam",
    "AtkParam_Npc", "ClearCountCorrectParam", "CharaInitParam", "EquipParamProtector",
    "EquipParamWeapon", "EquipParamCustomWeapon", "EquipParamGem", "Magic"
]);

Console.WriteLine("Loading params...");

var paramdefs = new Dictionary<string, PARAMDEF>();
foreach (var file in Directory.GetFiles(
    Path.Join(smithboxAssetPath, "Paramdex\\ER\\Defs"),
    "*.xml"
))
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

var paramNames = new Dictionary<string, Dictionary<int, string>>();
foreach (var file in Directory.GetFiles(
    Path.Join(smithboxAssetPath, "Paramdex\\ER\\Names"),
    "*.txt"
))
{
    var name = Path.GetFileNameWithoutExtension(file);
    if (paramsWeCareAbout.Contains(name))
    {
        var names = new Dictionary<int, string>();
        foreach (var line in File.ReadAllLines(file))
        {
            var split = line.Split(' ', 2);
            names[int.Parse(split[0])] = split[1];
        }
        paramNames[name] = names;
    }
}

Console.WriteLine("Params loaded!");

var npcs = paramDict["NpcParam"];
var spEffects = paramDict["SpEffectParam"];
var attacks = paramDict["AtkParam_Npc"];
var clearCountParams = paramDict["ClearCountCorrectParam"];
var gameAreaParam = paramDict["GameAreaParam"];
var resistCorrectParam = paramDict["ResistCorrectParam"];
var charaInitParam = paramDict["CharaInitParam"];
var equipParamProtector = paramDict["EquipParamProtector"];
var equipParamWeapon = paramDict["EquipParamWeapon"];
var equipParamCustomWeapon = paramDict["EquipParamCustomWeapon"];

var equipParamProtectorNames = paramNames["EquipParamProtector"];
var equipParamWeaponNames = paramNames["EquipParamWeapon"];
var equipParamGemNames = paramNames["EquipParamGem"];
var magicNames = paramNames["Magic"];

Dictionary<int, string> weaponNamesByModel = [];
foreach (var weapon in equipParamWeapon.Rows)
{
    var modelID = (ushort)weapon["equipModelId"].Value;
    if (!weaponNamesByModel.ContainsKey(modelID) &&
        equipParamWeaponNames.TryGetValue(weapon.ID, out var weaponName))
    {
        weaponNamesByModel[modelID] = weaponName;
    }
}

string? getWeaponName(int id)
{
    if (equipParamWeaponNames.TryGetValue(id, out var weaponName))
    {
        return weaponName;
    }
    else if (
        equipParamWeapon[id] is PARAM.Row weaponRow &&
        weaponNamesByModel.TryGetValue(
            (ushort)weaponRow["equipModelId"].Value,
            out var weaponNameByModel
    ))
    {
        return weaponNameByModel;
    }
    else
    {
        return null;
    }
}

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

void loadBossData(Boss boss)
{
    var bossParams = npcs[boss.ID];

    var ngScaling = spEffects[(int)bossParams["spEffectID3"].Value];
    var ngpScaling = spEffects[(int)bossParams["GameClearSpEffectID"].Value];

    uint baseHP;
    if (!boss.IsNPC)
    {
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

        List<(DamageType, string)> negationParams = [
            (DamageType.Standard, "neutralDamageCutRate"),
            (DamageType.Slash, "slashDamageCutRate"),
            (DamageType.Strike, "blowDamageCutRate"),
            (DamageType.Pierce, "thrustDamageCutRate"),
            (DamageType.Magic, "magicDamageCutRate"),
            (DamageType.Fire, "fireDamageCutRate"),
            (DamageType.Lightning, "thunderDamageCutRate"),
            (DamageType.Holy, "darkDamageCutRate"),
        ];
        foreach (var (name, param) in negationParams)
        {
            var value = 1 - (float)bossParams[param].Value;
            boss.Negations[name] = (int)Math.Round(100 * value);
        }

        baseHP = (uint)bossParams["hp"].Value;
    }
    else
    {
        var shortID = boss.ID / 1000 % 100000;
        var npc = charaInitParam[shortID] ?? charaInitParam[2000000 + shortID];
        List<string> armorFields = ["equip_Helm", "equip_Armer", "equip_Gaunt", "equip_Leg"];
        foreach (var field in armorFields)
        {
            if (npc[field].Value is int id && id != -1)
            {
                boss.Armor.Add(new ArmorPiece(
                    equipParamProtectorNames.GetValueOrDefault(id),
                    equipParamProtector[id]
                ));
            }
        }

        List<string> subweaponNames = ["equip_Wep_{}", "equip_Subwep_{}", "equip_Subwep_{}3"];
        foreach (var name in subweaponNames)
        {
            Weapon? getWeapon(string cellName)
            {
                if (npc[cellName].Value is int weaponID && weaponID != -1)
                {
                    if (getWeaponName(weaponID) is string weaponName)
                    {
                        return new Weapon(weaponName);
                    }

                    var customWeapon = equipParamCustomWeapon[weaponID];
                    if (getWeaponName((int)customWeapon["baseWepId"].Value) is string baseWeaponName)
                    {
                        return new Weapon(
                            baseWeaponName,
                            customWeapon["gemId"].Value is int gemID && gemID != 0
                                ? equipParamGemNames[gemID].Replace("Ash of War: ", "")
                                : null);
                    }

                    return null;
                }
                else
                {
                    return null;
                }
            }

            if (getWeapon(name.Replace("{}", "Right")) is Weapon right) boss.RightHand.Add(right);
            if (getWeapon(name.Replace("{}", "Left")) is Weapon left) boss.LeftHand.Add(left);
        }

        for (var i = 1; i <= 7; i++)
        {
            if (magicNames.TryGetValue((int)npc[$"equip_Spell_0{i}"].Value, out var spellName))
            {
                boss.Spells.Add(Regex.Replace(spellName, @"\[NPC: [^\]]+\] ", ""));
            }
        }

        T sumArmor<T>(string field) where T : INumber<T>
        {
            T total = T.Zero;
            foreach (var piece in boss.Armor)
            {
                if (piece == null) continue;
                total += (T)piece.Row[field].Value;
            }
            return total;
        }
        boss.Stance = (int)Math.Round(1000 * sumArmor<float>("toughnessCorrectRate"));

        if (npc["item_01"].Value is 50201 or 50203)
        {
            boss.FlaskCharges = (byte)npc["itemNum_01"].Value;
        }

        int getNegation(string field)
        {
            var combinedVulnerability = 1.0;
            foreach (var piece in boss.Armor)
            {
                if (piece == null) continue;
                combinedVulnerability *= (float)piece.Row[field].Value;
            }
            return (int)Math.Round(100 * (1 - combinedVulnerability));
        }
        boss.Negations[DamageType.Standard] = getNegation("neutralDamageCutRate");
        boss.Negations[DamageType.Slash] = getNegation("slashDamageCutRate");
        boss.Negations[DamageType.Pierce] = getNegation("thrustDamageCutRate");
        boss.Negations[DamageType.Strike] = getNegation("blowDamageCutRate");
        boss.Negations[DamageType.Magic] = getNegation("magicDamageCutRate");
        boss.Negations[DamageType.Fire] = getNegation("fireDamageCutRate");
        boss.Negations[DamageType.Lightning] = getNegation("thunderDamageCutRate");
        boss.Negations[DamageType.Holy] = getNegation("darkDamageCutRate");

        // We need to run further calculations, so we break the rules a bit and edit the params
        // directly.
        var level = (short)npc["soulLv"].Value;
        var vigor = (byte)npc["baseVit"].Value;
        double baseResistance = level switch
        {
            < 72 => 75 + 30 * ((level + 79 - 1) / 149.0),
            < 112 => 105 + 40 * ((level + 79 - 150) / 40.0),
            < 162 => 145 + 15 * ((level + 79 - 190) / 50.0),
            _ => 160 + 20 * ((level + 79 - 240) / 552.0)
        } + vigor switch
        {
            < 31 => 0,
            < 41 => 30 * ((vigor - 30) / 10.0),
            < 61 => 30 + 10 * ((vigor - 40) / 20.0),
            _ => 40 + 10 * ((vigor - 60) / 39.0)
        };

        bossParams["resist_poison"].Value = baseResistance + sumArmor<ushort>("resistPoison");
        bossParams["resist_desease"].Value = baseResistance + sumArmor<ushort>("resistDisease");
        bossParams["resist_blood"].Value = baseResistance + sumArmor<ushort>("resistBlood");
        bossParams["resist_curse"].Value = baseResistance + sumArmor<ushort>("resistCurse");
        bossParams["resist_freeze"].Value = baseResistance + sumArmor<ushort>("resistFreeze");
        bossParams["resist_sleep"].Value = baseResistance + sumArmor<ushort>("resistSleep");
        bossParams["resist_madness"].Value = baseResistance + sumArmor<ushort>("resistMadness");

        double baseDefense = level switch
        {
            < 72 => 40 + (level + 78) / 2.483,
            < 92 => 29 + level,
            < 161 => 120 + (level - 91) / 4.667,
            _ => 135 + (level - 161) / 27.6
        };

        List<int> ngDefenses(double statDefense)
        {
            var ngDefense = (baseDefense + statDefense) * (float)ngScaling["physicsDiffenceRate"].Value;
            var ngpDefense = ngDefense * (float)ngpScaling["physicsDiffenceRate"].Value;
            List<int> defense = [];
            defense.Add((int)Math.Floor(ngDefense));
            defense.Add((int)Math.Floor(ngpDefense));
            for (var i = 2; i < 8; i++)
            {
                defense.Add((int)Math.Floor(
                    ngpDefense * (float)clearCountParams[i]["PhysicsDefenseRate"].Value
                ));
            }
            return defense;
        }
        boss.TypeDefense[DamageType.Physical] = ngDefenses((byte)npc["baseStr"].Value switch
        {
            < 30 and var stat => stat / 3.0,
            < 40 and var stat => 10 + (stat - 30) / 2.0,
            < 60 and var stat => 15 + (stat - 40) / 1.333,
            var stat => 30 + (stat - 60) / 3.9
        });
        boss.TypeDefense[DamageType.Magic] = ngDefenses((byte)npc["baseMag"].Value switch
        {
            < 20 and var stat => stat * 2.0,
            < 35 and var stat => 40 + (stat - 20) / 1.5,
            < 60 and var stat => 50 + (stat - 35) / 2.5,
            var stat => 60 + (stat - 60) / 3.9
        });
        boss.TypeDefense[DamageType.Fire] = ngDefenses(vigor switch
        {
            < 30 => vigor / 1.5,
            < 40 => 20 + (vigor - 30) * 2.0,
            < 60 => vigor,
            _ => 60 + (vigor - 60) / 3.9
        });
        boss.TypeDefense[DamageType.Lightning] = ngDefenses(0);
        boss.TypeDefense[DamageType.Holy] = ngDefenses((byte)npc["baseLuc"].Value switch
        {
            < 20 and var stat => stat * 2.0,
            < 35 and var stat => 40 + (stat - 20) / 1.5,
            < 60 and var stat => 50 + (stat - 35) / 2.5,
            var stat => 60 + (stat - 60) / 3.9
        });

        baseHP = (uint)Math.Floor(vigor switch
        {
            < 26 => 300 + 4.25259 * Math.Pow(vigor - 1, 1.5),
            < 41 => 800 + 33.0532 * Math.Pow(vigor - 25, 1.1),
            < 61 => 1900 - 12.3588 * Math.Pow(60 - vigor, 1.2),
            _ => 2100 - 2.46463 * Math.Pow(99 - vigor, 1.2)
        });
    }

    List<(WeaknessType, string)> weaknessParams = [
        (WeaknessType.Gravity, "isWeakA"),
        (WeaknessType.Undead, "isWeakB"),
        (WeaknessType.AncientDragon, "isWeakC"),
        (WeaknessType.Dragon, "isWeakD")
    ];
    foreach (var (weakness, field) in weaknessParams)
    {
        if (((byte)bossParams[field].Value) > 0) boss.Weaknesses.Add(weakness);
    }

    if ((byte)bossParams["partsDamageType"].Value == 1)
    {
        boss.WeakPointExtraDamage = (int)Math.Round(
            100 * (((float)bossParams["weakPartsDamageRate"].Value) - 1)
        );
    }

    var ngHP = baseHP * (float)ngScaling["maxHpRate"].Value;
    var ngpHP = ngHP * (float)ngpScaling["maxHpRate"].Value;
    boss.HP.Add([(int)Math.Floor(ngHP)]);
    boss.HP.Add([(int)Math.Floor(ngpHP)]);
    for (var i = 2; i < 8; i++)
    {
        boss.HP.Add([(int)Math.Floor(ngpHP * (float)clearCountParams[i]["MaxHpRate"].Value)]);
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

    var ngRunes = boss.GameAreaID == null
        ? (uint)bossParams["getSoul"].Value
        : (uint)gameAreaParam[(int)boss.GameAreaID]["bonusSoul_single"].Value;
    var ngpRunes = ngRunes * (float)ngpScaling["haveSoulRate"].Value;
    boss.Runes.Add((int)ngRunes);
    boss.Runes.Add((int)Math.Round(ngpRunes));
    for (var i = 2; i < 8; i++)
    {
        boss.Runes.Add((int)Math.Round(ngpRunes * (float)clearCountParams[i]["SoulRate"].Value));
    }

    List<List<int>>? resistances(
        String baseCell, String correctCell, String rateCell, String clearCountCell
    )
    {
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

        var resistances = firstProcs.Select((proc1) =>
        {
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

    foreach (var phase in boss.AdditionalPhases)
    {
        loadBossData(phase);
        if (boss.HP[0][0] != phase.HP[0][0])
        {
            for (int i = 0; i < 8; i++)
            {
                boss.HP[i].Add(phase.HP[i][0]);
            }
        }
    }
}

loadBossData(boss);

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
    new StringValue(Regex.Replace(
        input.ToStringValue().ToLower().Replace("'s", "s"),
        @"[^a-z0-9]+", "-")
    ));
options.Filters.AddFilter("noXCount", (input, args, context) =>
    new StringValue(Regex.Replace(input.ToStringValue(), @" x[0-9]+$", "")));
options.Filters.AddFilter("onlyXCount", (input, args, context) =>
    new StringValue(Regex.Replace(input.ToStringValue(), @"(.*?)( x[0-9]+)?$", "$2")));
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
