using DotNext.Collections.Generic;
using SoulsFormats;
using System.IO;
using System.Numerics;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;

// Elden Ring or Nightreign
var eldenRing = false;

var gamePath = eldenRing
    ? "D:\\Natalie\\Steam\\steamapps\\common\\ELDEN RING\\Game\\"
    : "C:\\Users\\Natalie\\SteamLibrary\\steamapps\\common\\ELDEN RING NIGHTREIGN\\Game\\";
var gameAbbrev = eldenRing ? "ER" : "NR";
var smithboxAssetPath = "D:\\Natalie\\Code\\smithbox\\src\\Smithbox.Data\\Assets";

var bossName = "Crucible Knight";
int? bossID = 40210020;
string? location = null;
var displayType = Display.OneEnemyOfMany;
var multipleEnemiesOfMany = true;
var minify = true;

var knownBosses = eldenRing ? Boss.KnownERBosses : Boss.KnownNRBosses;
var boss = bossID == null
    ? knownBosses.Find((boss) => boss.Name.Contains(bossName) && (location == null || boss.Location == location))
    : knownBosses.Find((boss) => boss.ID == bossID && (location == null || boss.Location == location));
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

var knownBossGroups = eldenRing ? [] : Boss.KnownNRBossGroups;
var bossGroup = knownBossGroups.Find(group => group.Contains(boss));

var paramsWeCareAbout = new HashSet<string>([
    "NpcParam", "GameAreaParam", "MultiPlayCorrectionParam", "ResistCorrectParam", "SpEffectParam",
    "SpEffectSetParam", "AtkParam_Npc", "ClearCountCorrectParam", "CharaInitParam",
    "EquipParamProtector", "EquipParamWeapon", "EquipParamCustomWeapon", "EquipParamGem",
    "EquipParamAccessory", "Magic"
]);

Console.WriteLine("Loading params...");

var paramdefs = new Dictionary<string, PARAMDEF>();
foreach (var file in Directory.GetFiles(
    Path.Join(smithboxAssetPath, $"PARAM\\{gameAbbrev}\\Defs"),
    "*.xml"
))
{
    var paramdef = PARAMDEF.XmlDeserialize(file)!;
    paramdefs[paramdef.ParamType] = paramdef;
}

var bnd = eldenRing
    ? SFUtil.DecryptERRegulation($"{gamePath}\\regulation.bin")
    : SFUtil.DecryptNightreignRegulation($"{gamePath}\\regulation.bin");
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
using (var communityRowNames = JsonDocument.Parse(
    File.ReadAllText(
        Path.Join(smithboxAssetPath, $"PARAM\\{gameAbbrev}\\Community Row Names.json")
    )
))
{
    foreach (var param in communityRowNames.RootElement.GetProperty("Params").EnumerateArray())
    {
        var name = param.GetProperty("Name").GetString()!;
        if (!paramsWeCareAbout.Contains(name)) continue;
        var names = new Dictionary<int, string>();
        foreach (var entry in param.GetProperty("Entries")!.EnumerateArray())
        {
            names[entry.GetProperty("ID").GetInt32()!] = entry.GetProperty("Entries")[0].GetString();
        }
        paramNames[name] = names;
    }
}

Console.WriteLine("Params loaded!");

var npcs = paramDict["NpcParam"];
var spEffects = paramDict["SpEffectParam"];
var spEffectSets = paramDict["SpEffectSetParam"];
var attacks = paramDict["AtkParam_Npc"];
var clearCountParams = paramDict["ClearCountCorrectParam"];
var gameAreaParam = eldenRing ? paramDict["GameAreaParam"] : new PARAM();
var resistCorrectParam = paramDict["ResistCorrectParam"];
var charaInitParam = paramDict["CharaInitParam"];
var equipParamProtector = paramDict["EquipParamProtector"];
var equipParamWeapon = paramDict["EquipParamWeapon"];
var equipParamCustomWeapon = paramDict["EquipParamCustomWeapon"];
var equipParamAccessory = paramDict["EquipParamAccessory"];
var multiPlayCorrectionParam = paramDict["MultiPlayCorrectionParam"];

var equipParamProtectorNames = paramNames["EquipParamProtector"];
var equipParamWeaponNames = paramNames["EquipParamWeapon"];
var equipParamGemNames = eldenRing ? paramNames["EquipParamGem"] : [];
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
    id = id / 1000 * 1000;
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

Dictionary<int, string> armorNamesByModel = [];
foreach (var armor in equipParamProtector.Rows)
{
    var modelID = (ushort)armor["equipModelId"].Value;
    if (!armorNamesByModel.ContainsKey(modelID) &&
        equipParamProtectorNames.TryGetValue(armor.ID, out var armorName) &&
        armorName != "")
    {
        armorNamesByModel[modelID] = armorName;
    }
}

string? getArmorName(int id)
{
    id = id / 100 * 100;
    if (equipParamProtectorNames.TryGetValue(id, out var armorName))
    {
        return armorName;
    }
    else if (
        equipParamProtector[id] is PARAM.Row armorRow &&
        armorNamesByModel.TryGetValue(
            (ushort)armorRow["equipModelId"].Value,
            out var armorNameByModel
    ))
    {
        return armorNameByModel;
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

    var ngScaling = new List<PARAM.Row>();
    for (var i = 0; i <= 31; i++)
    {
        var id = (int)bossParams["spEffectID" + i].Value;
        if (id > 0)
        {
            var spEffect = spEffects[id];
            if (spEffect != null) ngScaling.Add(spEffect);
        }
    }
    ngScaling.AddAll(boss.SPEffectIDs.Select(id => spEffects[id]));
    foreach (var setID in boss.SPEffectSetIDs)
    {
        var row = spEffectSets[setID];
        for (var i = 1; i <= 4; i++)
        {
            var id = (int)row["spEffectId" + i].Value;
            if (id > 0) ngScaling.Add(spEffects[id]);
        }
    }
    var ngpScaling = eldenRing ? spEffects[(int)bossParams["GameClearSpEffectID"].Value] : null;
    var dlcpId = (int?)bossParams["dlcGameClearSpEffectID"]?.Value ?? -1;
    var dlcpScaling = dlcpId == -1 ? null : spEffects[dlcpId];

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
        PARAM.Row? npc;
        if (boss.CharaInitID is int charaInitID)
        {
            npc = charaInitParam[charaInitID];
        }
        else if (eldenRing)
        {
            npc = charaInitParam[shortID] ?? charaInitParam[2000000 + shortID];
        } else {
            npc = charaInitParam[boss.ID - 600000010];
        }

        List<string> armorFields = ["equip_Helm", "equip_Armer", "equip_Gaunt", "equip_Leg"];
        foreach (var field in armorFields)
        {
            if (npc[field].Value is int id && id != -1)
            {
                // PC armor isn't upgradable, but NPC armor can be!
                id = id / 100 * 100;
                boss.Armor.Add(new ArmorPiece(
                    getArmorName(id),
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
                boss.Spells.Add(Regex.Replace(spellName, @"^\[NPC: [^\]]+\] (.*?)( \d+)?$", "$1"));
            }
        }

        List<PARAM.Row> talismanEffects = [];
        for (var i = 1; i <= 4; i++)
        {
            var talismanID = (int)npc[$"equip_Accessory0{i}"].Value;
            if (talismanID == -1) continue;
            var talisman = equipParamAccessory[talismanID];
            var talismanEffect = spEffects[(int)talisman["refId"].Value];
            if (talismanEffect != null) talismanEffects.Add(talismanEffect);
        }

        IEnumerable<T> talismanValues<T>(string field) where T : INumber<T>
        {
            foreach (var effect in talismanEffects)
            {
                yield return (T)effect[field].Value;
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
        boss.Stance = (int)Math.Round(
            1000
                * sumArmor<float>("toughnessCorrectRate")
                / talismanValues<float>("toughnessDamageCutRate").Aggregate(1.0, (x, y) => x * y)
        );

        for (var i = 1; i <= 10; i++)
        {
            var suffix = "_" + i.ToString().PadLeft(2, '0');
            if (npc[$"item{suffix}"].Value is 50201 or 50203)
            {
                boss.FlaskCharges = (boss.FlaskCharges ?? 0) + (byte)npc[$"itemNum{suffix}"].Value;
            }
        }

        int getNegation(string field, string spEffectField)
        {
            var combinedVulnerability = 1.0;
            foreach (var piece in boss.Armor)
            {
                if (piece == null) continue;
                combinedVulnerability *= (float)piece.Row[field].Value;
            }

            combinedVulnerability *=
                talismanValues<float>(spEffectField).Aggregate(1.0, (x, y) => x * y);
            return (int)Math.Round(100 * (1 - combinedVulnerability));
        }
        boss.Negations[DamageType.Standard] =
            getNegation("neutralDamageCutRate", "defEnemyDmgCorrectRate_Physics");
        boss.Negations[DamageType.Slash] =
            getNegation("slashDamageCutRate", "defEnemyDmgCorrectRate_Physics");
        boss.Negations[DamageType.Pierce] =
            getNegation("thrustDamageCutRate", "defEnemyDmgCorrectRate_Physics");
        boss.Negations[DamageType.Strike] =
            getNegation("blowDamageCutRate", "defEnemyDmgCorrectRate_Physics");
        boss.Negations[DamageType.Magic] =
            getNegation("magicDamageCutRate", "defEnemyDmgCorrectRate_Magic");
        boss.Negations[DamageType.Fire] =
            getNegation("fireDamageCutRate", "defEnemyDmgCorrectRate_Fire");
        boss.Negations[DamageType.Lightning] =
            getNegation("thunderDamageCutRate", "defEnemyDmgCorrectRate_Thunder");
        boss.Negations[DamageType.Holy] =
            getNegation("darkDamageCutRate", "defEnemyDmgCorrectRate_Dark");

        // We need to run further calculations, so we break the rules a bit and edit the params
        // directly.
        var level = (ushort)npc["soulLv"].Value;
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

        void setResistanceValue(string bossField, string armorField, string spEffectField)
        {
            bossParams[bossField].Value =
                baseResistance +
                sumArmor<ushort>(armorField) +
                talismanValues<int>(spEffectField).Aggregate(0, (x, y) => x + y);
        }

        setResistanceValue("resist_poison", "resistPoison", "changePoisonResistPoint");
        setResistanceValue("resist_desease", "resistDisease", "changeDiseaseResistPoint");
        setResistanceValue("resist_blood", "resistBlood", "changeBloodResistPoint");
        setResistanceValue("resist_curse", "resistCurse", "changeCurseResistPoint");
        setResistanceValue("resist_freeze", "resistFreeze", "changeFreezeResistPoint");
        setResistanceValue("resist_sleep", "resistSleep", "changeSleepResistPoint");
        setResistanceValue("resist_madness", "resistMadness", "changeMadnessResistPoint");

        double baseDefense = level switch
        {
            < 72 => 40 + (level + 78) / 2.483,
            < 92 => 29 + level,
            < 161 => 120 + (level - 91) / 4.667,
            _ => 135 + (level - 161) / 27.6
        };

        List<int> ngDefenses(double statDefense)
        {
            var ngDefense = ngScaling.Aggregate(
                baseDefense + statDefense,
                (value, row) => value * (float)row["physicsDiffenceRate"].Value
            );
            List<int> defense = [];
            defense.Add((int)Math.Floor(ngDefense));

            if (eldenRing)
            {
                var ngpDefense = ngDefense * (float)ngpScaling["physicsDiffenceRate"].Value;
                defense.Add((int)Math.Floor(ngpDefense));
                for (var i = 2; i < 8; i++)
                {
                    defense.Add((int)Math.Floor(
                        ngpDefense * (float)clearCountParams[i]["PhysicsDefenseRate"].Value
                    ));
                }
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

        baseHP = (uint)Math.Floor((
            eldenRing
            ? vigor switch
            {
                < 26 => 300 + 4.25259 * Math.Pow(vigor - 1, 1.5),
                < 41 => 800 + 33.0532 * Math.Pow(vigor - 25, 1.1),
                < 61 => 1900 - 12.3588 * Math.Pow(60 - vigor, 1.2),
                _ => 2100 - 2.46463 * Math.Pow(99 - vigor, 1.2)
            }
            : (uint)bossParams["hp"].Value
        ) * talismanValues<float>("maxHpRate").Aggregate(1.0, (x, y) => x * y));
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

    var ngHP = ngScaling.Aggregate(
        (float)baseHP,
        (value, row) => value * (float)row["maxHpRate"].Value
    );
    boss.HP.Add([(int)Math.Floor(ngHP)]);

    float? ngpHP = ngpScaling == null ? null : ngHP * (float)ngpScaling["maxHpRate"].Value;
    if (ngpHP is not null)
    {
        boss.HP.Add([(int)Math.Floor((float)ngpHP)]);
        for (var i = 2; i < 8; i++)
        {
            boss.HP.Add([(int)Math.Floor((float)ngpHP * (float)clearCountParams[i]["MaxHpRate"].Value)]);
        }
    }

    if (dlcpScaling != null)
    {
        var dlcpModifier = (float)dlcpScaling["maxHpRate"].Value;
        var dlcpHp = (float)ngpHP! * dlcpModifier;
        boss.DlcPlusHP.Add([(int)Math.Floor(dlcpHp)]);
        for (var i = 2; i < 8; i++)
        {
            boss.DlcPlusHP.Add([(int)Math.Floor(
                (float)ngpHP *
                    (float)clearCountParams[i]["MaxHpRate"].Value *
                    (float)dlcpScaling["maxHpRate"].Value
            )]);
        }
    }

    // Base defense for all stats seems to be 100, and defense scaling seems to be consistent across
    // all damage types. Phil's data doesn't have defense as multiplicative between NG and NG+, but
    // that's inconsistent with other stats and leads to a bunch of bosses having less defense in NG+
    // so I think it's wrong.
    var ngDefense = ngScaling.Aggregate(
        100.0,
        (value, row) => value * (float)row["physicsDiffenceRate"].Value
    );
    boss.Defense.Add((int)Math.Floor(ngDefense));

    if (boss.DamageBaselineBoss is { } baselineBoss)
    {
        loadBossData(baselineBoss);
        boss.DamageBaseline = baselineBoss.DamageMultiplier;
    }
    boss.DamageMultiplier = ngScaling.Aggregate(
        1.0,
        (value, row) =>
        {
            return value * (float)row["physicsAttackPowerRate"].Value;
        }
    );

    if (!eldenRing)
    {
        var day2SpEffect = spEffects[(int)bossParams["day2SpEffectID"].Value];
        boss.Day2HPMult = (float)day2SpEffect["maxHpRate"].Value;
        boss.Day2DamageMult = (float)day2SpEffect["physicsAttackPowerRate"].Value;

        if (boss.CataclysmSpEffectID is int id)
        {
            var cataclysmSpEffect = spEffects[id];
            boss.CataclysmHPMult = (float)cataclysmSpEffect["maxHpRate"].Value;
            boss.CataclysmDamageMult = (float)cataclysmSpEffect["physicsAttackPowerRate"].Value;
        }
    }

    if (ngpScaling is not null)
    {
        var ngpDefense = ngDefense * (float)ngpScaling["physicsDiffenceRate"].Value;
        boss.Defense.Add((int)Math.Floor(ngpDefense));
        for (var i = 2; i < 8; i++)
        {
            boss.Defense.Add(
                (int)Math.Floor(ngpDefense * (float)clearCountParams[i]["PhysicsDefenseRate"].Value)
            );
        }
    }

    if (!boss.Nightlord)
    {
        var ngRunes = boss.GameAreaID == null
            ? (uint)bossParams["getSoul"].Value
            : (uint)gameAreaParam[(int)boss.GameAreaID]["bonusSoul_single"].Value;
        ngRunes = (uint)Math.Round(ngScaling.Aggregate(
            (float)ngRunes,
            (value, row) => value * (float)row["haveSoulRate"].Value
        ));
        ngRunes = ngScaling.Aggregate(
            ngRunes,
            (value, row) => value + (uint)(int)row["soul"].Value
        );

        boss.Runes.Add((int)ngRunes);

        if (ngpScaling is not null)
        {
            var ngpRunes = ngRunes * (float)ngpScaling["haveSoulRate"].Value;
            boss.Runes.Add((int)Math.Round(ngpRunes));
            for (var i = 2; i < 8; i++)
            {
                boss.Runes.Add((int)Math.Round(ngpRunes * (float)clearCountParams[i]["SoulRate"].Value));
            }
        }
    }
    else
    {
        boss.Runes.Add(0);
    }

    List<List<int>>? resistances(
        String baseCell,
        String correctCell,
        String rateCell,
        String clearCountCell,
        String disableCell
    )
    {
        var baseValue = (ushort)bossParams[baseCell].Value;
        if (baseValue == 999) return [];
        if (ngScaling.Any((row) => row.ID != 9642 && (byte)row[disableCell].Value == 1))
        {
            return [];
        }

        var correct = resistCorrectParam[(int)bossParams[correctCell].Value];
        var ngProc1 = ngScaling.Aggregate(
            (float)baseValue,
            (value, row) => value * (float)row[rateCell].Value
        );
        List<float> firstProcs = [ngProc1];

        if (ngpScaling is not null)
        {
            var ngpProc1 = ngProc1 * (float)ngpScaling[rateCell].Value;
            firstProcs.Add(ngProc1);
            for (var i = 2; i < 8; i++)
            {
                firstProcs.Add(ngpProc1 * (float)clearCountParams[i][clearCountCell].Value);
            }
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
        "PoisionResistRate",
        "disablePoison"
    );
    boss.Resistance[StatusType.ScarletRot] = resistances(
        "resist_desease",
        "resistCorrectId_disease",
        "registDiseaseChangeRate",
        "DiseaseResistRate",
        "disableDisease"
    );
    boss.Resistance[eldenRing ? StatusType.Hemorrhage : StatusType.BloodLoss] = resistances(
        "resist_blood",
        "resistCorrectId_blood",
        "registBloodChangeRate",
        "BloodResistRate",
        "disableBlood"
    );
    boss.Resistance[StatusType.Frostbite] = resistances(
        "resist_freeze",
        "resistCorrectId_freeze",
        "registFreezeChangeRate",
        "FreezeResistRate",
        "disableFreeze"
    );
    boss.Resistance[StatusType.Sleep] = resistances(
        "resist_sleep",
        "resistCorrectId_sleep",
        "registSleepChangeRate",
        "SleepResistRate",
        "disableSleep"
    );
    boss.Resistance[StatusType.Madness] = resistances(
        "resist_madness",
        "resistCorrectId_madness",
        "registMadnessChangeRate",
        "MadnessResistRate",
        "disableMadness"
    );

    foreach (var phase in boss.AdditionalPhases)
    {
        loadBossData(phase);
        if (boss.HP[0][0] != phase.HP[0][0])
        {
            for (int i = 0; i < Math.Min(8, phase.HP.Count); i++)
            {
                boss.HP[i].Add(phase.HP[i][0]);
                if (i < phase.DlcPlusHP.Count) boss.DlcPlusHP[i].Add(phase.DlcPlusHP[i][0]);
            }
        }
    }

    var multiPlayerParamId = (int)bossParams["multiPlayCorrectionParamId"].Value;
    if (multiPlayerParamId != 0)
    {
        var multiPlayerParam = multiPlayCorrectionParam[multiPlayerParamId];
        var duoSpEffect = spEffects[(int)multiPlayerParam["client1SpEffectId"].Value];
        var trioSpEffect = spEffects[(int)multiPlayerParam["client2SpEffectId"].Value];
        boss.MultiplayerHPScaling = (
            (float)duoSpEffect["maxHpRate"].Value,
            (float)trioSpEffect["maxHpRate"].Value
        );
    }
}

if (bossGroup != null)
{
    foreach (var groupBoss in bossGroup) loadBossData(groupBoss);
}
else
{
    loadBossData(boss);
}

string renderBoss(Boss boss) =>
    FluidRenderer.RenderBoss(displayType, boss, bossGroup, minify: minify, eldenRing: eldenRing);

var html =
    displayType == Display.OneEnemyOfMany && bossGroup != null && multipleEnemiesOfMany
    ? String.Join("", bossGroup.Select(renderBoss))
    : renderBoss(boss);

Thread thread = new Thread(() => Clipboard.SetText(html));
thread.SetApartmentState(ApartmentState.STA);
thread.Start();
thread.Join();
