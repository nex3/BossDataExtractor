using System;
using static System.Net.WebRequestMethods;

public partial class Boss
{
    public static readonly List<Boss> KnownERBosses = [
        new Boss(
            47601050, "Fire Giant",
            gameAreaID: 1052520800,
            location: "Mountaintops of the Giants",
            optional: false
        ),
        new Boss(
            21900078, "Radagon of the Golden Order",
            location: "Erdtree",
            closestGrace: "Elden Throne",
            optional: false,
            parriable: true,
            parriesPerCrit: 3
        ),
        new Boss(
            22000078, "Elden Beast",
            gameAreaID: 19000800,
            location: "Erdtree",
            closestGrace: "Elden Throne",
            optional: false,
            drops: ["Elden Remembrance"]
        ),
        new Boss(
            21200056, "Malenia, Blade of Miquella",
            gameAreaID: 15000800,
            location: "Elphael, Brace of the Haligtree",
            closestGrace: "Haligtree Roots",
            parriable: true,
            parriesPerCrit: 3,
            statusTypes: [StatusType.ScarletRot],
            drops: ["Malenia's Great Rune", "Remembrance of the Rot Goddess"]
        ),

        /// NPCs
        new Boss(
            523090010, "Patches",
            gameAreaID: 31000800,
            location: "Murkwater Cave",
            npc: true,
            parriable: true,
            damageTypes: [DamageType.Strike, DamageType.Pierce]
        ),
        new Boss(
            523560020, "Adan, Thief of Fire",
            gameAreaID: 1038410800,
            location: "Malefactor's Evergaol",
            closestGrace: "Scenic Isle",
            npc: true,
            parriable: false,
            multiplayerAllowed: false,
            summonsAllowed: false,
            damageTypes: [DamageType.Strike, DamageType.Fire],
            drops: ["Flame of the Fell God"]
        ),
        new Boss(
            523760930, "Necromancer Garris",
            gameAreaID: 31190850,
            location: "Sage's Cave",
            npc: true,
            parriable: false,
            damageTypes: [DamageType.Strike, DamageType.Magic],
            drops: ["Family Heads"]
        ),
        new Boss(
            523860000, "Esgar, Priest of Blood",
            gameAreaID: 35000850,
            location: "Leyndell Catacombs",
            npc: true,
            parriable: true,
            damageTypes: [
                DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Magic,
                DamageType.Fire
            ],
            statusTypes: [StatusType.Hemorrhage],
            drops: ["Lord of Blood's Exultation"]
        ),
        new Boss(
            523040050, "Roundtable Knight Vyke",
            gameAreaID: 1053560800,
            location: "Lord Contender's Evergaol",
            closestGrace: "Whiteridge Road",
            npc: true,
            parriable: true,
            multiplayerAllowed: false,
            summonsAllowed: false,
            damageTypes: [DamageType.Standard, DamageType.Pierce, DamageType.Lightning],
            drops: ["Fingerprint Set", "Vyke's Dragonbolt"]
        ),
        new Boss(
            523610066, "First Champion",
            location: "Deeproot Depths",
            closestGrace: "Across the Roots",
            npc: true,
            parriable: true,
            multiplayerAllowed: true,
            summonsAllowed: true
        ),
        new Boss(
            523250066, "Sorcerer Rogier", // Fia's Champions
            charaInitID: 23252,
            location: "Deeproot Depths",
            closestGrace: "Across the Roots",
            npc: true,
            parriable: true,
            multiplayerAllowed: true,
            summonsAllowed: true
        ),
        new Boss(
            523290066, "Lionel the Lionhearted", // Fia's Champions
            location: "Deeproot Depths",
            closestGrace: "Across the Roots",
            npc: true,
            parriable: true,
            multiplayerAllowed: true,
            summonsAllowed: true,
            statusTypes: [StatusType.DeathBlight]
        ),
        new Boss(
            523610066, "Fourth Champion",
            location: "Deeproot Depths",
            charaInitID: 23701,
            closestGrace: "Across the Roots",
            npc: true,
            parriable: true,
            multiplayerAllowed: true,
            summonsAllowed: true
        ),
        new Boss(
            523610066, "Fifth Champion",
            charaInitID: 23711,
            location: "Deeproot Depths",
            closestGrace: "Across the Roots",
            npc: true,
            parriable: true,
            multiplayerAllowed: true,
            summonsAllowed: true
        ),
        new Boss(
            523240070, "Sir Gideon Ofnir, the All-Knowing",
            gameAreaID: 11050850,
            charaInitID: 23248,
            location: "Leyndell, Ashen Capital",
            npc: true,
            parriable: true,
            optional: false,
            multiplayerAllowed: true,
            summonsAllowed: true,
            damageTypes: [
                DamageType.Standard, DamageType.Strike, DamageType.Magic, DamageType.Fire,
                DamageType.Holy
            ],
            statusTypes: [StatusType.ScarletRot, StatusType.Hemorrhage],
            drops: ["All-Knowing Set", "Scepter of the All-Knowing"]
        ),

        /// DLC
        new Boss(
            58100980, "Demi-Human Swordmaster Onze",
            gameAreaID: 41000800,
            location: "Belurat Gaol",
            parriable: true,
            statusTypes: [StatusType.Frostbite],
            drops: ["Demi-Human Swordsman Yosh"]
        ),
        new Boss(
            52100088, "Divine Beast Dancing Lion",
            gameAreaID: 20000800,
            location: "Belurat, Tower Settlement",
            optional: false,
            statusTypes: [StatusType.Frostbite],
            summonableNPCs: ["Redmane Freyja"],
            drops: ["Remembrance of the Dancing Lion", "Divine Beast Head"]
        ),
        new Boss(
            52100094, "Divine Beast Dancing Lion",
            gameAreaID: 2046460800,
            location: "Ancient Ruins of Rauh",
            closestGrace: "Temple Town Ruins",
            statusTypes: [StatusType.DeathBlight],
            drops: ["Divine Beast Tornado"]
        ),
        new Boss(
            58600080, "Ghostflame Dragon",
            gameAreaID: 2045440800,
            location: "Gravesite Plain",
            closestGrace: "Greatbridge, North",
            weakPoint: "head",
            statusTypes: [StatusType.Frostbite],
            drops: ["Dragon Heart", "Somber Ancient Dragon Smithing Stone"]
        ),
        new Boss(
            58600083, "Ghostflame Dragon",
            gameAreaID: 2048380850,
            location: "Cerulean Coast",
            weakPoint: "head",
            statusTypes: [StatusType.Frostbite],
            drops: ["Dragon Heart", "Somber Ancient Dragon Smithing Stone"]
        ),
        new Boss(
            58600090, "Ghostflame Dragon",
            gameAreaID: 2049430800,
            location: "Moorth Highway",
            closestGrace: "Moorth Highway, South",
            weakPoint: "head",
            statusTypes: [StatusType.Frostbite],
            drops: ["Dragon Heart", "Somber Ancient Dragon Smithing Stone"]
        ),
        new Boss(
            50000092, "Commander Gaius",
            gameAreaID: 2049480800,
            location: "Scaduview",
            closestGrace: "Shadow Keep, Back Gate",
            drops: ["Remembrance of the Wild Boar Rider"]
        ),
        new Boss(
            50100098, "Golden Hippopotamus",
            gameAreaID: 21000850,
            location: "Shadow Keep",
            closestGrace: "Shadow Keep Main Gate",
            drops: ["Aspects of the Crucible: Thorns", "Scadutree Fragment x2"],
            summonableNPCs: ["Redmane Freya", "Hornsent"]
        ),
        new Boss(
            50110084, "Hippopotamus",
            boss: false,
            location: "Charo's Hidden Grave",
            drops: ["Scadutree Fragment"],
            summonsAllowed: false
        ),
        new Boss(
            50110091, "Hippopotamus",
            boss: false,
            location: "Recluses' River",
            closestGrace: "Recluses' River Downstream",
            drops: ["Scadutree Fragment"]
        ),
        new Boss(
            50110094, "Hippopotamus",
            boss: false,
            location: "Ancient Ruins of Rauh",
            closestGrace: "Viaduct Minor Tower",
            drops: ["Scadutree Fragment"]
        ),
        new Boss(
            50200087, "Putrescent Knight",
            gameAreaID: 22000800,
            location: "Stone Coffin Fissure",
            closestGrace: "Fissure Depths",
            statusTypes: [StatusType.Frostbite],
            drops: ["Remembrance of Putrescence"]
        ),
        new Boss(
            50300094, "Romina, Saint of the Bud",
            gameAreaID: 2044450800,
            optional: false,
            location: "Church of the Bud",
            closestGrace: "Church of the Bud, Main Entrance",
            parriable: true,
            statusTypes: [StatusType.ScarletRot],
            drops: ["Remembrance of the Saint of the Bud"]
        ),
        new Boss(
            50400190, "Curseblade Labirith",
            gameAreaID: 41010800,
            location: "Bonny Gaol",
            parriable: true,
            drops: ["Curseblade Meera"]
        ),
        new Boss(
            50510086, "Midra, Lord of Frienzied Flame",
            gameAreaID: 28000800,
            location: "Midra's Manse",
            closestGrace: "Second Floor Chamber",
            parriable: true,
            parriesPerCrit: 3,
            statusTypes: [StatusType.Madness],
            drops: ["Remembrance of the Lord of Frenzied Flame"]
        ),
        new Boss(
            50500086, "Midra (Human Form)",
            location: "Midra's Manse",
            statusTypes: [StatusType.Madness]
        ),
        new Boss(
            50700081, "Death Knight",
            gameAreaID: 40000800,
            location: "Fog Rift Catacombs",
            parriable: true,
            drops: ["Death Knight's Twin Axes", "Crimson Amber Medallion +3"]
        ),
        new Boss(
            50701095, "Death Knight",
            gameAreaID: 40010800,
            location: "Scorpion River Catacombs",
            parriable: true,
            backstabbable: true,
            drops: ["Death Knight's Longhaft Axe", "Cerulean Amber Medallion +3"]
        ),
        new Boss(
            50810990, "Chief Bloodfiend",
            gameAreaID: 43000800,
            location: "Rivermouth Cave",
            parriable: true,
            statusTypes: [StatusType.Hemorrhage],
            drops: ["Bloodfiend Hexer's Ashes "]
        ),
        new Boss(
            51200085, "Bayle the Dread",
            gameAreaID: 2054390800,
            location: "Jagged Peak",
            closestGrace: "Jagged Peak Summit",
            weakPoint: "Head, Leg Stump",
            drops: ["Heart of Bayle"],
            summonableNPCs: ["Igon"]
        ),
        new Boss(
            51301099, "Messmer the Impaler",
            gameAreaID: 21010800,
            optional: false,
            location: "Shadow Keep",
            closestGrace: "Dark Chamber Entrance",
            parriable: true,
            parriesPerCrit: 3,
            drops: ["Remembrance of the Impaler", "Messmer's Kindling"],
            summonableNPCs: ["Hornsent", "Jolan"]
        ),
        new Boss(
            52000097, "Metyr, Mother of Fingers",
            gameAreaID: 25000800,
            location: "Finger Ruins of Miyr",
            closestGrace: "Cathedral of Manus Metyr",
            weakPoint: "Belly",
            drops: ["Remembrance of the Mother of Fingers"]
        ),
        new Boss(
            52200089, "Promised Consort Radahn",
            location: "Enir-Elim",
            closestGrace: "Divine Gatefront Staircase",
            gameAreaID: 20010800,
            parriable: true,
            parriesPerCrit: 3,
            optional: false,
            damageTypes: [DamageType.Fire, DamageType.Standard, DamageType.Pierce, DamageType.Holy],
            drops: ["Remembrance of a God and a Lord"],
            summonableNPCs: ["Thiollier", "Sir Ansbach"]
        ),
        new Boss(
            52201089, "Radahn, Consort of Miquella",
            location: "Enir-Elim",
            closestGrace: "Divine Gatefront Staircase",
            gameAreaID: 20010800,
            parriable: true,
            parriesPerCrit: 3,
            optional: false,
            damageTypes: [DamageType.Fire, DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Holy],
            drops: ["Remembrance of a God and a Lord"],
            summonableNPCs: ["Thiollier", "Sir Ansbach"]
        ),
        new Boss(
            52200089, "Promised Consort Radahn",
            gameAreaID: 2050480800,
            additionalPhases: [52201089],
            location: "Scadutree Base",
            statusTypes: [StatusType.Hemorrhage],
            weakPoint: "Flower",
            drops: ["Remembrance of the Shadow Sunflower", "Miquella's Great Rune"]
        ),
        new Boss(
            52300096, "Scadutree Avatar",
            gameAreaID: 2050480800,
            additionalPhases: [52300296, 52300296],
            location: "Scadutree Base",
            statusTypes: [StatusType.Hemorrhage],
            weakPoint: "Flower",
            drops: ["Remembrance of the Shadow Sunflower", "Miquella's Great Rune"]
        ),
        new Boss(
            53000082, "Rellana, Twin Moon Knight",
            gameAreaID: 2048440800,
            location: "Castle Ensis",
            closestGrace: "Castle Lord's Chamber",
            parriable: true,
            parriesPerCrit: 2,
            drops: ["Remembrance of the Twin Moon Knight"]
        ),
        new Boss(
            53120086, "Jori, Elder Inquisitor",
            gameAreaID: 2052430800,
            location: "Abyssal Woods",
            closestGrace: "Darklight Catacombs",
            parriable: true,
            backstabbable: true,
            drops: ["Barbed Staff-Spear"]
        ),
        new Boss(
            53701185, "Ancient Dragon Senessax",
            gameAreaID: 2054390850,
            location: "Jagged Peak",
            closestGrace: "Jagged Peak Summit",
            multiplayerAllowed: false,
            weakPoint: "Head",
            drops: ["Ancient Dragon Smithing Stone", "Somber Ancient Dragon Smithing Stone"]
        ),
        new Boss(
            55800084, "Jagged Peak Drake", // Solo
            gameAreaID: 2049410800,
            location: "Jagged Peak Foothills",
            closestGrace: "Dragon's Pit Terminus",
            multiplayerAllowed: false,
            weakPoint: "Head",
            drops: ["Dragon Heart", "Dragonscale Flesh"]
        ),
        new Boss(
            55800985, "Jagged Peak Drake", // Duo
            gameAreaID: 2052400800,
            location: "Jagged Peak",
            closestGrace: "Foot of the Jagged Peak",
            multiplayerAllowed: false,
            summonsAllowed: false,
            weakPoint: "Head",
            drops: ["Dragon Heart", "Dragonscale Flesh"]
        ),
        new Boss(
            55800085, "Lesser Dragon",
            boss: false,
            location: "Jagged Peak",
            closestGrace: "Foot of the Jagged Peak",
            weakPoint: "Head"
        ),
        new Boss(
            57300083, "Demi-Human Queen Marigga",
            gameAreaID: 2046400800,
            location: "Cerulean Coast",
            closestGrace: "Cerulean Coast West",
            drops: ["Star-Lined Sword"]
        ),
        new Boss(
            58200990, "Ralva the Great Red Bear",
            gameAreaID: 2049450800,
            location: "Scadu Altus",
            closestGrace: "Highroad Cross",
            drops: ["Pelt of Ralva"]
        ),
        new Boss(
            58200095, "Rugalea the Great Red Bear",
            gameAreaID: 2044470800,
            location: "Rauh Base",
            closestGrace: "Ravine North",
            drops: ["Roar of Rugalea"]
        ),
        new Boss(
            58400590, "Black Knight Garrew",
            gameAreaID: 2047450800,
            location: "Fog Rift Fort",
            closestGrace: "Scadu Altus, West",
            parriable: true,
            drops: ["Black Steel Greatshield"]
        ),
        new Boss(
            58400690, "Black Knight Edredd",
            gameAreaID: 2049430850,
            location: "Fort of Reprimand",
            parriable: true,
            drops: ["Ash of War: Aspects of the Crucible: Wings"]
        ),
        new Boss(
            59200181, "Magma Wyrm",
            boss: false,
            location: "Dragon's Pit",
            weakPoint: "Head",
            drops: ["Dragon Heart", "Ancient Dragon Smithing Stone"]
        ),
        new Boss(
            59600088, "Ulcerated Tree Spirit",
            boss: false,
            location: "Belurat, Tower Settlement",
            closestGrace: "Main Gate Cross",
            drops: ["Immunizing Horn Charm +2"]
        ),
        new Boss(
            59600081, "Ulcerated Tree Spirit",
            boss: false,
            location: "Ellac River",
            closestGrace: "Ellac River Cave",
            drops: ["Horned Bairn"]
        ),
        new Boss(
            59600098, "Ulcerated Tree Spirit",
            boss: false,
            location: "Church District",
            closestGrace: "Sunken Chapel",
            drops: ["Mantle of Thorns", "Iris of Occulation"]
        ),
        new Boss(
            62511093, "Tree Sentinel", // Torch
            gameAreaID: 2050470800,
            location: "Hinterland",
            closestGrace: "Hinterland Bridge",
            parriable: true,
            critable: false,
            drops: ["Blessing of Marika"]
        ),
        new Boss(
            62510093, "Tree Sentinel", // Shield
            gameAreaID: 2050480860,
            location: "Hinterland",
            closestGrace: "Hinterland Bridge",
            parriable: true,
            critable: false,
            drops: ["Blessing of Marika"]
        ),
        new Boss(
            62601084, "Death Rite Bird",
            gameAreaID: 2047390800,
            location: "Charo's Hidden Grave",
            drops: ["Ash of War: Ghostflame Call"]
        ),
        new Boss(
            63101093, "Fallingstar Beast",
            gameAreaID: 2052480800,
            location: "Finger Ruins of Dheo",
            closestGrace: "Fingerstone Hill",
            weakPoint: "Face and Rump",
            drops: ["Gravitational Missile"]
        ),
        new Boss(
            56200084, "Tibia Mariner",
            location: "Charo's Hidden Grave",
            critable: false,
            boss: false,
            drops: ["Tibia's Cookbook"]
        ),
        // Note: humanoid boss, unclear how to handle it. Madness resist is definitely wrong, other
        // stuff might be as well.
        new Boss(
            524070081, "Ancient Dragon-Man",
            gameAreaID: 43010800,
            location: "Dragon's Pit",
            npc: true,
            parriable: true,
            damageTypes: [
                DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Fire
            ],
            drops: ["Dragon-Hunter's Great Katana"]
        ),
        new Boss(
            524200190, "Count Ymir, Mother of Fingers",
            gameAreaID: 2051450800,
            location: "Cathedral of Manus Meyr",
            npc: true,
            multiplayerAllowed: false,
            summonsAllowed: false,
            drops: ["Ymir's Bell Bearing", "Maternal Staff", "High Priest Set"]
        ),
        new Boss(
            524090190, "Swordhand of Night Jolan",
            charaInitID: 2024091,
            location: "Cathedral of Manus Meyr",
            npc: true,
            multiplayerAllowed: false,
            summonsAllowed: false
        ),
        new Boss(
            524210095, "Red Bear",
            gameAreaID: 2046450800,
            location: "Northern Nameless Mausoleum",
            closestGrace: "Temple Town Ruins",
            npc: true,
            parriable: true,
            summonsAllowed: false,
            damageTypes: [DamageType.Standard, DamageType.Slash],
            statusTypes: [StatusType.Hemorrhage],
            drops: ["Red Bear's Claw", "Iron Rivet Set"]
        ),
        new Boss(
            524220083, "Dancer of Ranah",
            gameAreaID: 2046380800,
            location: "Southern Nameless Mausoluem",
            closestGrace: "Cerulean Coast West",
            npc: true,
            parriable: true,
            summonsAllowed: false,
            drops: ["Dancing Blade of Ranah", "Dancer's Set"]
        ),
        new Boss(
            524230091, "Rakshasa",
            gameAreaID: 2051440800,
            location: "Eastern Namelss Mausoleum",
            closestGrace: "Recluses' River Downstream",
            npc: true,
            parriable: true,
            summonsAllowed: false,
            drops: ["Rakshasa's Great Katana", "Rakshasa's Set"]
        ),
        new Boss(
            524240080, "Blackgaol Knight",
            gameAreaID: 2046410800,
            location: "Western Nameless Mausoleum",
            closestGrace: "Scorched Ruins",
            npc: true,
            parriable: true,
            summonsAllowed: false,
            drops: ["Greatsword of Solitude", "Solitude Set"]
        ),
        new Boss(
            524250190, "Dryleaf Dane",
            location: "Moorth Ruins",
            npc: true,
            parriable: true,
            drops: ["Dane's Hat", "Dryleaf Arts"]
        ),
        new Boss(
            524270084, "Lamenter",
            gameAreaID: 41020800,
            location: "Lamenter's Gaol",
            npc: true,
            parriable: true,
            drops: ["Lamenter's Mask"]
        ),
        new Boss(
            524170289, "Redmane Freyja",
            location: "Enir-Ilim",
            npc: true,
            parriable: true
        ),
        new Boss(
            524140289, "Hornsent",
            location: "Enir-Ilim",
            npc: true,
            parriable: true
        ),
        new Boss(
            524150289, "Moore",
            location: "Enir-Ilim",
            npc: true
        ),
        new Boss(
            524250289, "Dryleaf Dane",
            location: "Enir-Ilim",
            npc: true,
            parriable: true
        ),
        new Boss(
            524180289, "Needle Knight Leda",
            location: "Enir-Ilim",
            npc: true,
            optional: false,
            parriable: true,
            summonableNPCs: ["Thiollier", "Sir Ansbach", "Sanguine Noble Nalaan"],
            drops: ["Leda's Sword"]
        )
    ];

    public static readonly List<List<Boss>> KnownNRBossGroups = [
        [
            new Boss(
                31810010, "Red Wolf of the King Consort",
                location: "Field Boss",
                drops: ["Weak Field Boss Reward"],
                topLevelImage: Image.Full4K("red-wolf-field-2-nightreign"),
                image: Image.Full4K("red-wolf-field-nightreign"),
                strongerVS: [DamageType.Magic],
                weakerVS: [DamageType.Slash]
            ),
            new Boss(
                31810020, "Red Wolf of the King Consort",
                image: Image.Full4K("red-dog-basement-nightreign"),
                location: "Castle Basement",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                drops: ["Strong Field Boss Reward"],
                strongerVS: [DamageType.Magic],
                weakerVS: [DamageType.Slash],
                damageBaseline: 31810010,
                damageBaselineName: "the field boss",
                spEffectIDs: [7790]
            ),
        ],
        [
            new Boss(
                21000020, "Black Knife Assassin",
                location: "Field Boss",
                drops: ["Weak Field Boss Reward"],
                image: Image.Full4K("black-knife-assassin-field-1-nightreign"),
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Pierce, DamageType.Holy],
                weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike]
            ),
            new Boss(
                21000030, "Black Knife Assassin",
                image: Image.Full1080p("black-knife-assassin-basement"),
                location: "Castle Basement",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                drops: ["Strong Field Boss Reward"],
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Pierce, DamageType.Holy],
                weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike],
                damageBaseline: 21000020,
                damageBaselineName: "the field boss",
                spEffectIDs: [7790]
            ),
            new Boss(
                21000040, "Black Knife Assassin",
                location: "Noklateo, the Shrouded City",
                inShiftingEarth: [ShiftingEarth.Noklateo],
                drops: ["Noklateo Reward"],
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Pierce, DamageType.Holy],
                weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike],
                damageBaseline: 21000020,
                damageBaselineName: "the field boss"
            ),
        ],
        [
            new Boss(
                46900010, "Grafted Scion",
                topLevelImage: Image.Full1080p("grafted-scion-1"),
                image: Image.Crop1080p("grafted-scion-field-2-nightreign"),
                location: "Field Boss",
                drops: ["Weak Field Boss Reward"],
                parriable: true,
                strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Fire, DamageType.Holy],
                weakerVS: [DamageType.Slash]
            ),
            new Boss(
                46900020, "Grafted Scion",
                location: "Castle Basement",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/grafted-scion-boss-nightreign-wiki-guide-min.jpg",
                drops: ["Strong Field Boss Reward"],
                parriable: true,
                strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Fire, DamageType.Holy],
                weakerVS: [DamageType.Slash],
                damageBaseline: 46900010,
                damageBaselineName: "the field boss",
                spEffectIDs: [7790]
            ),
        ],
        [
            new Boss(
                46300210, "Runebear (Silver)",
                location: "Ruins",
                drops: ["Strong Affinity Reward"],
                weakerVS: [DamageType.Fire]
            ),
            new Boss(
                46300210, "Runebear (Brown)",
                location: "Ruins",
                drops: ["Dormant Power"],
                weakerVS: [DamageType.Fire],
                damageBaseline: 46300210,
                damageBaselineName: "the silver Runebear"
            ),
        ],
        [
            new Boss(
                46801020, "Fallingstar Beast",
                location: "The Crater",
                inShiftingEarth: [ShiftingEarth.Crater],
                drops: ["Strong Crater Reward"],
                strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
                weakerVS: [DamageType.Fire, DamageType.Magic, DamageType.Lightning, DamageType.Holy]
            ),
            new Boss(
                46801010, "Fallingstar Beast",
                location: "Meteor Strike",
                expeditions: ["Tricephalos", "Gaping Jaw", "Fissure in the Fog"],
                drops: ["Strong Field Boss Reward"],
                strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
                weakerVS: [DamageType.Fire, DamageType.Magic, DamageType.Lightning, DamageType.Holy],
                damageBaseline: 46801020,
                damageBaselineName: "the boss in The Crater"
            ),
        ],
        [
            new Boss(
                37010030, "Perfumer",
                location: "Ruins",
                drops: ["Strong Affinity Reward"],
                backstabbable: true,
                statusTypes: [StatusType.Poison],
                strongerVS: [DamageType.Magic, DamageType.Fire, DamageType.Lightning],
                weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Holy]
            ),
            new Boss(
                37011020, "Perfumer",
                location: "Night Boss Entourage",
                backstabbable: true,
                expeditions: ["Tricephalos", "Sentient Pest", "Augur", "Night Aspect"],
                statusTypes: [StatusType.Poison],
                strongerVS: [DamageType.Magic, DamageType.Fire, DamageType.Lightning],
                weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Holy],
                damageBaseline: 37010030,
                damageBaselineName: "the Ruins boss"
            ),
        ],
        [
            new Boss(
                71000110, "Ancient Hero of Zamor",
                topLevelImage: Image.Crop4K("ancient-hero-of-zamor-field-2-nightreign"),
                image: Image.Crop4K("ancient-hero-ruins-2-nightreign"),
                location: "Ruins",
                drops: ["Strong Affinity Reward"],
                parriable: true,
                weakerVS: [DamageType.Fire, DamageType.Lightning],
                strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Pierce]
            ) {
                CataclysmSpEffectID = 7630
            },
            new Boss(
                71000010, "Ancient Hero of Zamor",
                image: Image.Full4K("ancient-hero-of-zamor-field-1-nightreign"),
                location: "Field Boss",
                drops: ["Weak Field Boss Reward"],
                parriable: true,
                weakerVS: [DamageType.Fire, DamageType.Lightning],
                strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Pierce],
                damageBaseline: 71000110,
                damageBaselineName: "the Ruins boss"
            ),
            new Boss(
                71000020, "Ancient Hero of Zamor",
                image: Image.Full4K("ancient-hero-basement-nightreign"),
                location: "Castle Basement",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                drops: ["Strong Field Boss Reward"],
                parriable: true,
                weakerVS: [DamageType.Fire, DamageType.Lightning],
                strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Pierce],
                damageBaseline: 71000110,
                damageBaselineName: "the Ruins boss",
                spEffectIDs: [7790]
            ),
        ],
        [
            new Boss(
                34600010, "Leonine Misbegotten",
                topLevelImage: Image.Crop4K("leonine-misbegotten-basement-2-nightreign"),
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/leonine_misbegotten_bosses_elden_ring__night_reign_wiki-300px.png",
                location: "Encampment",
                drops: ["Strong Standard Reward"],
                parriable: true,
                weakerVS: [DamageType.Slash, DamageType.Fire],
                strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Holy]
            ),
            new Boss(
                34600020, "Leonine Misbegotten",
                location: "Field Boss",
                drops: ["Weak Field Boss Reward"],
                parriable: true,
                weakerVS: [DamageType.Slash, DamageType.Fire],
                strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
                damageBaseline: 34600010,
                damageBaselineName: "the Encampment boss"
            ),
            new Boss(
                34600040, "Leonine Misbegotten",
                image: Image.Crop4K("leonine-misbegotten-basement-3-nightreign"),
                location: "Castle Basement",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                weakerVS: [DamageType.Slash, DamageType.Fire],
                strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
                drops: ["Strong Field Boss Reward"],
                parriable: true,
                damageBaseline: 34600010,
                damageBaselineName: "the Encampment boss",
                spEffectIDs: [7790]
            ),
        ],
        [
            new Boss(
                42700030, "Elder Lion",
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/elder_lion_boss_elden_ring_night_reign_wiki_300px.jpg",
                location: "Encampment",
                drops: ["Strong Standard Reward"],
                weakerVS: [DamageType.Fire]
            ),
            new Boss(
                42700020, "Elder Lion",
                location: "Field Boss",
                drops: ["Weak Field Boss Reward"],
                weakerVS: [DamageType.Fire],
                damageBaseline: 42700030,
                damageBaselineName: "the Encampment boss"
            ),
            new Boss(
                42700040, "Elder Lion",
                location: "Castle Courtyard",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                drops: ["Castle Miniboss Reward"],
                weakerVS: [DamageType.Fire],
                damageBaseline: 42700030,
                damageBaselineName: "the Encampment boss"
            ),
        ],
        [
            new Boss(
                41300020, "Demi-Human Queen",
                location: "Field Boss",
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/demi-human_queen-boss-nightreign-wiki-guide-min.jpg",
                drops: ["Weak Field Boss Reward"],
                weakerVS: [DamageType.Fire, StatusType.Poison, StatusType.ScarletRot],
                damageBaseline: 41300020,
                damageBaselineName: "the field boss"
            ),
            new Boss(
                41300030, "Demi-Human Queen",
                location: "The Crater",
                inShiftingEarth: [ShiftingEarth.Crater],
                drops: ["Weak Crater Reward"],
                weakerVS: [DamageType.Fire, StatusType.Poison, StatusType.ScarletRot],
                damageBaseline: 41300020,
                damageBaselineName: "the field boss"
            ),
        ],
        [
            new Boss(
                44800410, "Miranda Blossom",
                location: "Ruins",
                statusTypes: [StatusType.Poison],
                strongerVS: [DamageType.Strike, DamageType.Lightning, DamageType.Holy],
                weakerVS: [DamageType.Slash, DamageType.Fire],
                damageBaseline: 44800020,
                damageBaselineName: "the field boss"
            ),
            new Boss(
                44800020, "Miranda Blossom",
                location: "Field Boss",
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/miranda_blossom_boss_elden_ring_nightrein_wiki(1).jpg",
                statusTypes: [StatusType.Poison],
                strongerVS: [DamageType.Strike, DamageType.Lightning, DamageType.Holy],
                weakerVS: [DamageType.Slash, DamageType.Fire],
                drops: ["Weak Field Boss Reward"]
            ),
        ],
        [
            new Boss(
                45000010, "Flying Dragon",
                location: "Field Boss",
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/flying_dragon-boss-nightreign-wiki-guide-min.jpg",
                weakerVS: [DamageType.Pierce],
                drops: ["Strong Field Boss Reward"],
                weakPoint: "Head"
            ),
            new Boss(
                45050020, "Flying Dragon",
                location: "Night Boss Entourage",
                weakerVS: [DamageType.Pierce],
                weakPoint: "Head",
                damageBaseline: 45000010,
                damageBaselineName: "the field boss"
            ),
            new Boss(
                45050040, "Flying Dragon",
                location: "The Mountaintops",
                weakerVS: [DamageType.Pierce],
                drops: ["Mountaintops Reward"],
                weakPoint: "Head",
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                damageBaseline: 45000010,
                damageBaselineName: "the field boss"
            ),
        ],
        [
            new Boss(
                48100010, "Erdtree Avatar",
                location: "Field Boss",
                drops: ["Strong Field Boss Reward"],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/erdtree-avatar-bosses-nightreign-wiki-guide_(1)-min.png",
                strongerVS: [DamageType.Holy],
                weakerVS: [DamageType.Fire]
            ),
            new Boss(
                48100010, "Erdtree Avatar",
                location: "Castle Rooftop",
                drops: ["Strong Field Boss Reward"],
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                strongerVS: [DamageType.Holy],
                weakerVS: [DamageType.Fire],
                spEffectIDs: [7791],
                damageBaseline: 48100010,
                damageBaselineName: "the field boss"
            ),
        ],
        [
            new Boss(
                46700010, "Ancestor Spirit",
                location: "Field Boss",
                drops: ["Strong Field Boss Reward"],
                strongerVS: [DamageType.Magic],
                weakerVS: [DamageType.Fire, DamageType.Holy]
            ),
            new Boss(
                46700010, "Ancestor Spirit",
                location: "Castle Rooftop",
                drops: ["Strong Field Boss Reward"],
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                spEffectIDs: [7791],
                strongerVS: [DamageType.Magic],
                weakerVS: [DamageType.Fire, DamageType.Holy],
                damageBaseline: 48100010,
                damageBaselineName: "the field boss"
            ),
        ],
        [
            new Boss(
                49100190, "Magma Wyrm",
                location: "Field Boss",
                drops: ["Strong Field Boss Reward"],
                weakPoint: "Head"
            ),
            new Boss(
                49100190, "Magma Wyrm",
                location: "Castle Rooftop",
                drops: ["Strong Field Boss Reward"],
                weakPoint: "Head",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                spEffectIDs: [7791],
                damageBaseline: 49100190,
                damageBaselineName: "the field boss"
            ),
            new Boss(
                49100120, "Magma Wyrm",
                location: "The Crater",
                drops: ["Dormant Power", "Special Armament Strenghtening"],
                weakPoint: "Head",
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/magma-wyrm-nightreign-bosses-wiki-guide.png",
                inShiftingEarth: [ShiftingEarth.Crater],
                weakerVS: [DamageType.Standard, DamageType.Strike, DamageType.Pierce],
                strongerVS: [DamageType.Fire],
                damageBaseline: 49100190,
                damageBaselineName: "the field boss"
            ),
        ],
        [
            new Boss(
                32520010, "Royal Carian Knight",
                location: "Field Boss",
                drops: ["Strong Field Boss Reward"],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/royal-carian-knight-boss-nightreign-wiki-guide_(1)-min.png",
                parriable: true,
                critable: false,
                strongerVS: [DamageType.Magic, DamageType.Fire],
                weakerVS: [DamageType.Lightning]
            ),
            new Boss(
                32520010, "Royal Carian Knight",
                location: "Castle Rooftop",
                drops: ["Strong Field Boss Reward"],
                parriable: true,
                critable: false,
                strongerVS: [DamageType.Magic, DamageType.Fire],
                weakerVS: [DamageType.Lightning],
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                spEffectIDs: [7791],
                damageBaseline: 32520010,
                damageBaselineName: "the field boss"
            ),
        ],
        [
            new Boss(
                47701210, "Black Blade Kindred",
                location: "Field Boss",
                drops: ["Strong Field Boss Reward"],
                weakPoint: "Head",
                strongerVS: [DamageType.Holy],
                weakerVS: [DamageType.Strike]
            ),
            new Boss(
                47701210, "Black Blade Kindred",
                location: "Castle Rooftop",
                drops: ["Strong Field Boss Reward"],
                weakPoint: "Head",
                strongerVS: [DamageType.Holy],
                weakerVS: [DamageType.Strike],
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                spEffectIDs: [7791],
                damageBaseline: 47701210,
                damageBaselineName: "the field boss"
            ),
        ],
        [
            new Boss(
                46600030, "Guardian Golem",
                location: "Great Church",
                drops: ["Weak Standard Reward"],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/guardian-golem-boss-nightreign-wiki-guide_(1)-min.png",
                strongerVS: [DamageType.Fire, DamageType.Lightning, DamageType.Holy],
                weakerVS: [DamageType.Strike]
            ),
            new Boss(
                46601010, "Guardian Golem",
                location: "Fort",
                drops: ["Dormant Power"],
                damageBaseline: 46600030,
                damageBaselineName: "the Great Church boss",
                strongerVS: [DamageType.Fire, DamageType.Lightning, DamageType.Holy],
                weakerVS: [DamageType.Strike]
            ),
        ],
        [
            new Boss(
                43550020, "Mausoleum Knight",
                location: "Great Church",
                drops: ["Weak Standard Reward"],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/mausoleum-knight-nightreign-bosses-wiki-guide_(1)-min.png",
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Slash],
                weakerVS: [DamageType.Pierce, DamageType.Lightning, DamageType.Holy]
            ),
            new Boss(
                43550010, "Mausoleum Knight", // Normal
                location: "Noklateo, the Shifting City",
                inShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 43550020,
                damageBaselineName: "the Great Church boss",
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Slash],
                weakerVS: [DamageType.Pierce, DamageType.Lightning, DamageType.Holy]
            ),
            new Boss(
                43551020, "Mausoleum Knight", // Flaming Sword
                location: "Noklateo, the Shifting City",
                inShiftingEarth: [ShiftingEarth.Noklateo],
                drops: ["Dormant Power"],
                damageBaseline: 43550020,
                damageBaselineName: "the Great Church boss",
                parriable: true,
                backstabbable: true,
                statusTypes: [StatusType.DeathBlight],
                strongerVS: [DamageType.Slash],
                weakerVS: [DamageType.Pierce, DamageType.Lightning, DamageType.Holy]
            ),
        ],
        [
            new Boss(
                39000020, "Fire Monk",
                location: "Great Church",
                drops: ["Weak Affinity Reward"],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/fire-monk-location-boss-elden-ring-nightreign-wiki-guide-300px.jpg",
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Fire],
                weakerVS: [DamageType.Holy]
            ),
            new Boss(
                39001010, "Fire Monk",
                location: "The Crater",
                parriable: true,
                backstabbable: true,
                inShiftingEarth: [ShiftingEarth.Crater],
                strongerVS: [DamageType.Fire],
                weakerVS: [DamageType.Holy],
                damageBaseline: 39000020,
                damageBaselineName: "the Great Church boss"
            ),
        ],
        [
            new Boss(
                43510020, "Lordsworn Captain",
                location: "Fort",
                drops: ["Weak Standard Reward"],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/lordsworn-captain-boss-nightreign-wiki-guide_(1)-min.png",
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Slash],
                weakerVS: [DamageType.Pierce, DamageType.Lightning]
            ),
            new Boss(
                43511120, "Lordsworn Captain",
                location: "Tunnel",
                drops: ["Tunnel Reward"],
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Slash],
                weakerVS: [DamageType.Pierce, DamageType.Lightning],
                damageBaseline: 43511120,
                damageBaselineName: "the Fort boss"
            ),
            new Boss(
                43510030, "Lordsworn Captain",
                location: "The Mountaintops",
                drops: ["Dormant Power"],
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Slash],
                weakerVS: [DamageType.Pierce, DamageType.Lightning],
                damageBaseline: 43511120,
                damageBaselineName: "the Fort boss"
            ),
            new Boss(
                43510040, "Lordsworn Captain",
                location: "The Rotted Woods",
                drops: ["Dormant Power"],
                inShiftingEarth: [ShiftingEarth.Woods],
                parriable: true,
                backstabbable: true,
                strongerVS: [DamageType.Slash],
                weakerVS: [DamageType.Pierce, DamageType.Lightning],
                damageBaseline: 43511120,
                damageBaselineName: "the Fort boss"
            ),
        ],
        [
            new Boss(
                46000110, "Troll",
                location: "Tunnel",
                drops: ["Tunnel Reward"],
                notInShiftingEarth: [ShiftingEarth.Woods],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/troll_enemies_elden_ring_nightreign_wiki_600px.jpg",
                weakerVS: [DamageType.Slash]
            ),
            new Boss(
                46000030, "Troll",
                location: "Castle",
                drops: ["Castle Miniboss Reward"],
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                weakerVS: [DamageType.Slash],
                damageBaseline: 46000110,
                damageBaselineName: "the Tunnel boss"
            )
        ],
        [
            new Boss(
                43401120, "Mad Pumpkin Head",
                location: "Tunnel",
                drops: ["Tunnel Reward"],
                weakerVS: [DamageType.Lightning],
                strongerVS: [DamageType.Strike]
            ),
            new Boss(
                43401010, "Mad Pumpkin Head",
                location: "Encampment",
                weakerVS: [DamageType.Lightning],
                strongerVS: [DamageType.Strike],
                damageBaseline: 43401120,
                damageBaselineName: "the Tunnel boss"
            )
        ],
        [
            new Boss(
                42600610, "Erdtree Burial Watchdogs", // sword, staff is 42601610
                location: "Ruins",
                drops: ["Strong Standard Reward"],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/burial-watchdog-boss-nightreign-wiki-guide_(1)-min.png",
                parriable: true,
                weakerVS: [DamageType.Strike]
            ),
            new Boss(
                42600110, "Erdtree Burial Watchdogs",
                location: "Night Boss Entourage",
                expeditions: ["Sentient Pest", "Augur", "Fissure in the Fog", "Night Aspect"],
                parriable: true,
                weakerVS: [DamageType.Strike],
                damageBaseline: 42600610,
                damageBaselineName: "the Ruins boss"
            ),
        ],
        [
            new Boss(
                31700040, "Albinauric Archers",
                location: "Ruins",
                drops: ["Strong Standard Reward"],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/albinauric_archer-boss-nightreign-wiki-guide-min.jpg",
                strongerVS: [DamageType.Magic],
                weakerVS: [DamageType.Holy]
            ),
            new Boss(
                31700020, "Albinauric Archers",
                location: "The Mountaintops",
                drops: ["Dormant Power"],
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                damageBaseline: 31700040,
                damageBaselineName: "the Ruins boss",
                strongerVS: [DamageType.Magic],
                weakerVS: [DamageType.Holy]
            ),
        ],
        [
            new Boss(
                39101120, "Fire Prelate",
                location: "Crater West",
                drops: ["Dormant Power"],
                inShiftingEarth: [ShiftingEarth.Crater],
                strongerVS: [DamageType.Fire],
                weakerVS: [DamageType.Holy]
            ),
            new Boss(
                39100130, "Fire Prelates",
                location: "Crater North",
                drops: ["Weak Crater Reward"],
                inShiftingEarth: [ShiftingEarth.Crater],
                strongerVS: [DamageType.Fire],
                weakerVS: [DamageType.Holy],
                damageBaseline: 39101120,
                damageBaselineName: "the previous enemies"
            ),
        ],
        [
            new Boss(
                46020050, "Snowfield Troll",
                location: "Mountaintops South",
                drops: ["Dormant Power"],
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/snowfield-trolls-boss-nightreign-wiki-guide_(1)-min.jpg",
                weakerVS: [DamageType.Fire],
                damageBaseline: 46000110,
                damageBaselineName: "the Tunnel boss"
            ),
            new Boss(
                46020030, "Snowfield Trolls",
                location: "Mountaintops East",
                drops: ["Mountaintops Reward"],
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                weakerVS: [DamageType.Fire],
                damageBaseline: 46000110,
                damageBaselineName: "the Tunnel boss"
            ),
        ],
    ];

    public static readonly List<Boss> KnownNRBosses = [
        ..KnownNRBossGroups.SelectMany(group => group),
        new Boss(
            75000020, "Gladius, Beast of Night",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/gladius-beast-of-night-nightlord-elden-ring-nightreign-wiki-guide.png",
            drops: ["Old Pocketwatch", "Night of the Beast", "Relics"],
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Holy, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Tricephalos"]
        ),
        new Boss(
            75100020, "Adel, Baron of Night",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/adel-baron-of-night-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
            drops: ["Night of the Baron", "Relics"],
            strongerVS: [DamageType.Fire],
            weakerVS: [StatusType.Poison, StatusType.ScarletRot, StatusType.Frostbite, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Gaping Jaw"]
        ),
        new Boss(
            75110010, "Adel, Baron of Night (Everdark Sovereign)",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/adel-baron-of-night-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
            drops: ["Relics", "Sovereign Sigils"],
            strongerVS: [DamageType.Fire],
            weakerVS: [StatusType.Poison, StatusType.ScarletRot, StatusType.Frostbite, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Gaping Jaw Everdark Sovereign"],
            damageBaseline: 75100020,
            damageBaselineName: "the standard version"
        ),
        new Boss(
            76000010, "Fulghor, Champion of Nightglow",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/fulghor-champion-of-nightglow-darkdrift-knight-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
            drops: ["Night of the Champion", "Relics"],
            strongerVS: [DamageType.Holy],
            weakerVS: [DamageType.Lightning],
            nightlord: true,
            expeditions: ["Darkdrift Knight"]
        ),
        new Boss(
            75200020, "Gnoster, Wisdom of Night (Moth)",
            drops: ["Night of the Wise", "Relics"],
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Fire, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite],
            statusTypes: [StatusType.Poison],
            nightlord: true,
            expeditions: ["Sentient Pest"]
        ),
        new Boss(
            75300010, "Faurtis Stoneshield (Scorpion)", // healthbar
            drops: ["Night of the Wise", "Relics"],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Fire, DamageType.Strike, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Sentient Pest"]
        ),
        new Boss(
            75200120, "Gnoster, Wisdom of Night (Everdark Sovereign, Phase 1)",
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Fire, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite],
            statusTypes: [StatusType.Poison],
            nightlord: true,
            expeditions: ["Sentient Pest Everdark Sovereign"],
            damageBaseline: 75200020,
            damageBaselineName: "the standard version"
        ),
        new Boss(
            75200030, "Gnoster, Wisdom of Night (Everdark Sovereign, Phase 2)",
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Fire, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite],
            statusTypes: [StatusType.Poison],
            nightlord: true,
            expeditions: ["Sentient Pest Everdark Sovereign"],
            damageBaseline: 75200020,
            damageBaselineName: "the standard version"
        ),
        new Boss(
            75300120, "Faurtis Stoneshield (Scorpion, Everdark Sovereign, Phase 1)",
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Fire, DamageType.Strike, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Sentient Pest Everdark Sovereign"],
            damageBaseline: 75200010,
            damageBaselineName: "the standard version"
        ),
        new Boss(
            21500310, "Gnoster, Wisdom of Night (Everdark Sovereign, Phase 1, Healthbar)",
            nightlord: true,
            expeditions: ["Sentient Pest Everdark Sovereign"]
        ),
        new Boss(
            75300020, "Faurtis Stoneshield (Scorpion, Everdark Sovereign, Phase 2)",
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Fire, DamageType.Strike, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Sentient Pest Everdark Sovereign"],
            damageBaseline: 75200010,
            damageBaselineName: "the standard version"
        ),
        new Boss(
            75210010, "Animus, Ascendant Light",
            drops: ["Relics", "Sovereign Sigils"],
            nightlord: true,
            expeditions: ["Sentient Pest Everdark Sovereign"]
        ),
        new Boss(
            75400020, "Maris, Fathom of Night",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/maris-fathom-of-night-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
            drops: ["Night of the Fathom", "Relics"],
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Lightning],
            statusTypes: [StatusType.Sleep],
            nightlord: true,
            expeditions: ["Augur"]
        ),
        new Boss(
            75600020, "Libra, Creature of Night",
            drops: ["Night of the Demon", "Relics"],
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Holy, StatusType.Poison, StatusType.ScarletRot, StatusType.Madness],
            statusTypes: [StatusType.Madness],
            nightlord: true,
            expeditions: ["Equilibrious Beast"]
        ),
        new Boss(
            49000010, "Caligo, Miasma of Night",
            drops: ["Night of the Miasma", "Relics"],
            strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            weakerVS: [DamageType.Fire],
            statusTypes: [StatusType.Frostbite],
            nightlord: true,
            expeditions: ["Fissure in the Fog"]
        ),
        new Boss(
            75800010, "The Shape of Night",
            strongerVS: [DamageType.Strike],
            weakerVS: [DamageType.Holy],
            nightlord: true,
            expeditions: ["Night Aspect"]
        ),
        new Boss(
            75802010, "Heolstor the Nightlord",
            drops: ["Night of the Lord", "Primordial Nightlord's Rune", "Relics"],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Holy, DamageType.Lightning],
            statusTypes: [StatusType.BloodLoss, StatusType.Sleep, StatusType.DeathBlight, StatusType.Poison, StatusType.ScarletRot, StatusType.Madness],
            nightlord: true,
            expeditions: ["Night Aspect"]
        ),
        new Boss(
            21300520, "Fell Omen",
            location: "Tutorial",
            drops: ["Fell Omen Fetish"],
            parriable: true,
            spEffectSetIDs: [99001],
            damageBaseline: 21300510,
            damageBaselineName: "the night boss"
        ),
        new Boss(
            21300010, "Fell Omen",
            location: "Event",
            drops: ["Traces of Grace-Given Lord"],
            parriable: true,
            spEffectSetIDs: [13910],
            damageBaseline: 21300510,
            damageBaselineName: "the night boss"
        ),
        new Boss(
            21300510, "Fell Omen",
            location: "Night Boss",
            drops: ["Night 2 Boss Reward"],
            parriable: true,
            spEffectSetIDs: [15000],
            nightBoss: NightBossState.Day2,
            expeditions: ["Tricephalos", "Night Aspect"],
            firstAppearance: Game.ER
        ),
        new Boss(
            77100010, "Centipede Demon",
            drops: ["Night 1 Boss Reward"],
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/centipede_elden_ring_nightreign_bosses_wiki_guide300px.jpg",
            spEffectSetIDs: [15000],
            nightBoss: NightBossState.Day1,
            expeditions: ["Sentient Pest", "Equilibrious Beast", "Darkdrift Knight", "Night Aspect"],
            firstAppearance: Game.DS1,
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Strike, DamageType.Lightning, DamageType.Holy]
        ),
        new Boss(
            77110010, "Centipede Grub",
            spEffectSetIDs: [15000]
        ),
        new Boss(
            41301010, "Demi-Human Queen",
            drops: ["Night 1 Boss Reward"],
            nightBoss: NightBossState.Day1,
            expeditions: ["Tricephalos", "Night Aspect"],
            firstAppearance: Game.ER,
            damageBaseline: 41300020,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            58100910, "Demi-Human Swordmaster",
            nightBoss: NightBossState.Day1,
            expeditions: ["Tricephalos", "Night Aspect"],
            parriable: true,
            firstAppearance: Game.ER,
            damageBaseline: 58100920,
            damageBaselineName: "the boss in The Mountaintops"
        ),
        new Boss(
            32500110, "Draconic Tree Sentinel",
            location: "Night Boss",
            drops: ["Night 2 Boss Reward"],
            nightBoss: NightBossState.Day2,
            expeditions: ["Sentient Pest", "Fissure in the Fog", "Night Aspect"],
            parriable: true,
            critable: false,
            firstAppearance: Game.ER,
            damageBaseline: 32500090,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            43531110, "Leyndell Knight",
            location: "Night Boss",
            parriable: true,
            firstAppearance: Game.ER
        ),
        new Boss(
            43630010, "Leyndell Knight's Horse",
            location: "Night Boss",
            critable: false,
            firstAppearance: Game.ER
        ),
        new Boss(
            32500090, "Draconic Tree Sentinel",
            location: "Field Boss",
            formidable: true,
            drops: ["Strong Field Boss Reward"],
            parriable: true,
            critable: false
        ),
        new Boss(
            32500090, "Draconic Tree Sentinel",
            location: "Castle Rooftop",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Strong Field Boss Reward"],
            parriable: true,
            critable: false,
            spEffectIDs: [7791],
            damageBaseline: 32500090,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            46400020, "Ulcerated Tree Spirit",
            location: "Night Boss",
            drops: ["Night 1 Boss Reward"],
            expeditions: ["Sentient Pest", "Fissure in the Fog", "Night Aspect"],
            nightBoss: NightBossState.Day1,
            firstAppearance: Game.ER,
            damageBaseline: 46400010,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            46400010, "Ulcerated Tree Spirit",
            location: "Field Boss",
            formidable: true,
            drops: ["Strong Field Boss Reward"]
        ),
        new Boss(
            46400010, "Ulcerated Tree Spirit",
            location: "Castle Rooftop",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Strong Field Boss Reward"],
            spEffectIDs: [7791],
            damageBaseline: 46400010,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            30500010, "Outland Commander",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/outland-commander-night-boss-nightreign-wiki-guide.jpg",
            drops: ["Night 2 Boss Reward"],
            expeditions: ["Gaping Jaw", "Darkdrift Knight", "Night Aspect"],
            parriable: true,
            statusTypes: [StatusType.Frostbite],
            nightBoss: NightBossState.Day2,
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Pierce]
        ),
        new Boss(
            49500010, "Tibia Mariner",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/tibia_mariner_bosses_elden_ring_nightreign_wiki_guide300px.jpg",
            drops: ["Night 1 Boss Reward"],
            expeditions: ["Sentient Pest", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            nightBoss: NightBossState.Day1,
            firstAppearance: Game.ER,
            critable: false,
            strongerVS: [DamageType.Lightning, DamageType.Pierce],
            weakerVS: [DamageType.Holy, DamageType.Strike]
        ),
        new Boss(
            31000020, "Bell Bearing Hunter",
            location: "Night Boss",
            drops: ["Night 1 Boss Reward"],
            expeditions: ["Tricephalos", "Night Aspect"],
            nightBoss: NightBossState.Day1,
            firstAppearance: Game.ER,
            parriable: true,
            strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Magic, DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Pierce],
            damageBaseline: 31000010,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            31000010, "Bell Bearing Hunter",
            location: "Field Boss",
            formidable: true,
            drops: ["Strong Field Boss Reward"],
            parriable: true
        ),
        new Boss(
            31000030, "Bell Bearing Hunter",
            location: "Castle Basement",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Strong Field Boss Reward"],
            parriable: true,
            damageBaseline: 31000010,
            damageBaselineName: "the field boss",
            spEffectIDs: [7790]
        ),
        new Boss(
            31000010, "Bell Bearing Hunter",
            location: "Castle Rooftop",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Strong Field Boss Reward"],
            parriable: true,
            damageBaseline: 31000010,
            damageBaselineName: "the field boss",
            spEffectIDs: [7791]
        ),
        new Boss(
            31500020,  "Night's Cavalry (Glaive)",
            location: "Night Boss",
            drops: ["Night 1 Boss Reward"],
            parriable: true,
            backstabbable: true,
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Darkdrift Knight", "Night Aspect"],
            firstAppearance: Game.ER,
            damageBaseline: 31500010,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            31501020,  "Night's Cavalry (Flail)",
            location: "Night Boss",
            parriable: false,
            backstabbable: true,
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Darkdrift Knight", "Night Aspect"],
            firstAppearance: Game.ER
        ),
        new Boss(
            31500010,  "Night's Cavalry", // Glaive
            location: "Field Boss",
            drops: ["Weak Field Boss Reward"],
            parriable: true,
            backstabbable: true
        ),
        new Boss(
            31600020,  "Funeral Steed",
            location: "Night Boss",
            critable: false
        ),
        new Boss(
            31600010,  "Funeral Steed",
            location: "Field Boss",
            critable: false
        ),
        new Boss(
            78200010,  "Smelter Demon",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/smelter-demon-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Sentient Pest", "Augur", "Fissure in the Fog", "Night Aspect"],
            drops: ["Night 1 Boss Reward"],
            firstAppearance: Game.DS2,
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Strike, DamageType.Standard]
        ),
        new Boss(
            79200010,  "Dancer of the Boreal Valley",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/dancer-of-the-boreal-valley-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Fissure in the Fog", "Night Aspect"],
            drops: ["Night 2 Boss Reward"],
            firstAppearance: Game.DS3,
            weakerVS: [DamageType.Holy]
        ),
        new Boss(
            78000010,  "The Duke's Dear Freya",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/duke's-dear-freja-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            drops: ["Night 1 Boss Reward"],
            firstAppearance: Game.DS2,
            strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            weakerVS: [DamageType.Strike]
        ),
        new Boss(
            47509010, "Grafted Monarch",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/grafted-monarch-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Augur", "Fissure in the Fog", "Night Aspect"],
            drops: ["Night 1 Boss Reward"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Holy],
            weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce]
        ),
        new Boss(
            46809010, "Full-Grown Fallingstar Beast",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/full-grown-fallingstar-beast-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Augur", "Night Aspect"],
            drops: ["Night 2 Boss Reward"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
            weakerVS: [DamageType.Fire, DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            damageBaseline: 46801020,
            damageBaselineName: "the boss in The Crater"
        ),
        new Boss(
            46500010, "Nox Dragonkin Soldier",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nox-dragonskin-soldier-nightreign-bosses-wiki-guide_(1)-min.png",
            nightBoss: NightBossState.Day2,
            expeditions: ["Sentient Pest", "Darkdrift Knight", "Night Aspect"],
            drops: ["Night 2 Boss Reward"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Slash],
            damageBaseline: 46500210,
            damageBaselineName: "the evergaol boss"
        ),
        new Boss(
            79100010, "Nameless King (Phase 1)",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nameless_king_elden_ring_nightreign_bosses_wiki_guide300px.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Darkdrift Knight", "Night Aspect"],
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Lightning],
            firstAppearance: Game.DS3,
            additionalPhases: [79000010]
        ),
        new Boss(
            79000010, "Nameless King (Phase 2)",
            parriable: true,
            drops: ["Night 2 Boss Reward"],
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Holy]
        ),
        new Boss(
            77000010, "Gaping Dragon",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/gaping-dragon-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Augur", "Darkdrift Knight", "Night Aspect"],
            drops: ["Night 1 Boss Reward"],
            firstAppearance: Game.DS1,
            strongerVS: [DamageType.Standard, DamageType.Strike, DamageType.Pierce, DamageType.Slash],
            weakerVS: [DamageType.Lightning]
        ),
        new Boss(
            30500110, "Battlefield Commander",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/battlefield-commander-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Sentient Pest", "Equilibrious Beast", "Night Aspect"],
            drops: ["Night 1 Boss Reward"],
            parriable: true,
            firstAppearance: Game.ER,
            statusTypes: [StatusType.ScarletRot],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Pierce]
        ),
        new Boss(
            32510110, "Tree Sentinel",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/tree-sentinel-nightreign-bosses-wiki-guide_(1)-min.png",
            nightBoss: NightBossState.Day2,
            expeditions: ["Tricephalos", "Sentient Pest", "Augur", "Night Aspect"],
            drops: ["Night 2 Boss Reward"],
            damageBaseline: 32510020,
            damageBaselineName: "the field boss",
            parriable: true,
            critable: false,
            firstAppearance: Game.ER
        ),
        new Boss(
            32510020, "Tree Sentinel",
            location: "Field Boss",
            drops: ["Strong Field Boss Reward"],
            formidable: true,
            parriable: true,
            critable: false
        ),
        new Boss(
            32510020, "Tree Sentinel",
            location: "Castle Rooftop",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Strong Field Boss Reward"],
            spEffectIDs: [7791],
            damageBaseline: 32510020,
            damageBaselineName: "the field boss",
            parriable: true,
            critable: false
        ),
        new Boss(
            40210020, "Royal Revenant",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/royal-revenant-boss-nightreign-wiki-guide-min.png",
            nightBoss: NightBossState.Day1,
            expeditions: ["Equilibrious Beast", "Darkdrift Knight", "Night Aspect"],
            drops: ["Night 1 Boss Reward"],
            firstAppearance: Game.ER,
            statusTypes: [StatusType.Poison],
            strongerVS: [DamageType.Holy],
            weakerVS: [DamageType.Slash],
            damageBaseline: 40210010,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            40210010, "Royal Revenant",
            location: "Field Boss",
            drops: ["Weak Field Boss Reward"],
            statusTypes: [StatusType.Poison]
        ),
        new Boss(
            40210030, "Royal Revenant",
            location: "Castle Basement",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Strong Field Boss Reward"],
            statusTypes: [StatusType.Poison],
            spEffectIDs: [7790],
            damageBaseline: 40210010,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            40200030, "Royal Revenant",
            location: "Noklateo",
            inShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Dormant Power"],
            statusTypes: [StatusType.Poison],
            damageBaseline: 40210010,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            47700020, "Valiant Gargoyle",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/valiant-gargoyle-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Augur", "Night Aspect"],
            drops: ["Night 1 Boss Reward"],
            firstAppearance: Game.ER,
            damageBaseline: 47701030,
            damageBaselineName: "the boss in The Crater"
        ),
        new Boss(
            47701030, "Valiant Gargoyle",
            location: "Crater",
            drops: ["Dormant Power"]
        ),
        new Boss(
            45803010, "Wormface",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/wormface-boss-nightreign-wiki-guide-min.png",
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Augur", "Darkdrift Knight", "Night Aspect"],
            drops: ["Night 1 Boss Reward"],
            statusTypes: [StatusType.DeathBlight],
            firstAppearance: Game.ER,
            damageBaseline: 45803020,
            damageBaselineName: "the Ruins boss"
        ),
        new Boss(
            45803020, "Wormface",
            location: "Ruins",
            drops: ["Strong Standard Boss Reward"],
            statusTypes: [StatusType.DeathBlight]
        ),
        new Boss(
            45101110, "Ancient Dragon",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/ancient-dragon-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Gaping Jaw", "Night Aspect"],
            drops: ["Night 2 Boss Reward"],
            firstAppearance: Game.ER,
            damageBaseline: 45102010,
            damageBaselineName: "the evergaol boss"
        ),
        new Boss(
            45102010, "Ancient Dragon",
            location: "Evergaol",
            drops: ["Strong Evergaol Reward"]
        ),
        new Boss(
            25000020, "Crucible Knight",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/crucible-knight-golden-hippopotamus-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Gaping Jaw", "Equilibrious Beast", "Night Aspect"],
            drops: ["Night 2 Boss Reward"],
            parriable: true,
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Magic, DamageType.Holy],
            weakerVS: [DamageType.Fire, DamageType.Lightning],
            damageBaseline: 25000030,
            damageBaselineName: "the evergaol boss"
        ),
        new Boss(
            50110020, "Golden Hippopotamus",
            location: "Night Boss",
            nightBoss: NightBossState.Day2,
            expeditions: ["Gaping Jaw", "Equilibrious Beast", "Night Aspect"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Standard, DamageType.Strike, DamageType.Pierce, DamageType.Magic, DamageType.Holy],
            weakerVS: [DamageType.Fire, DamageType.Lightning],
            damageBaseline: 50110010,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            49801010, "Death Rite Bird",
            location: "Night Boss",
            nightBoss: NightBossState.Day2,
            expeditions: ["Equilibrious Beast", "Night Aspect"],
            drops: ["Night 2 Boss Reward"],
            firstAppearance: Game.ER,
            weakPoint: "Head",
            statusTypes: [StatusType.Frostbite, StatusType.DeathBlight],
            weakerVS: [DamageType.Strike, DamageType.Holy],
            strongerVS: [DamageType.Pierce, DamageType.Lightning],
            damageBaseline: 49801020,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            49801020, "Death Rite Bird",
            location: "Field Boss",
            formidable: true,
            drops: ["Dormant Power"],
            weakPoint: "Head",
            statusTypes: [StatusType.Frostbite, StatusType.DeathBlight],
            weakerVS: [DamageType.Strike, DamageType.Holy],
            strongerVS: [DamageType.Pierce, DamageType.Lightning]
        ),
        new Boss(
            49801030, "Death Rite Bird",
            location: "Evergaol",
            drops: ["Strong Evergaol Reward"],
            weakPoint: "Head",
            statusTypes: [StatusType.Frostbite, StatusType.DeathBlight],
            weakerVS: [DamageType.Strike, DamageType.Holy],
            strongerVS: [DamageType.Pierce, DamageType.Lightning],
            damageBaseline: 49801020,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            49801020, "Death Rite Bird",
            location: "Castle Rooftop",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Dormant Power"],
            weakPoint: "Head",
            statusTypes: [StatusType.Frostbite, StatusType.DeathBlight],
            weakerVS: [DamageType.Strike, DamageType.Holy],
            strongerVS: [DamageType.Pierce, DamageType.Lightning],
            spEffectIDs: [7791],
            damageBaseline: 49801020,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            35600010, "Godskin Apostle",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/godskin-duo-evergaol-boss-elden-ring-nightreign-wiki-guide.jpg",
            parriable: true,
            nightBoss: NightBossState.Day2,
            expeditions: ["Augur", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            drops: ["Night 2 Boss Reward"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
            damageBaseline: 35600020,
            damageBaselineName: "the solo evergaol boss"
        ),
        new Boss(
            35700010, "Godskin Noble",
            location: "Night Boss",
            parriable: true,
            nightBoss: NightBossState.Day2,
            expeditions: ["Augur", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Strike, DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
            damageBaseline: 35700020,
            damageBaselineName: "the solo evergaol boss"
        ),
        new Boss(
            35600110, "Godskin Apostle",
            location: "Evergaol", // The Oldest Gaol
            parriable: true,
            drops: ["Strong Evergaol Reward"],
            strongerVS: [DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
            damageBaseline: 35600020,
            damageBaselineName: "the solo evergaol boss"
        ),
        new Boss(
            35700110, "Godskin Noble",
            location: "Evergaol", // The Oldest Gaol
            parriable: true,
            strongerVS: [DamageType.Strike, DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
            damageBaseline: 35700020,
            damageBaselineName: "the solo evergaol boss"
        ),
        new Boss(
            49110010, "Great Wyrm",
            location: "Night Boss",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/great-wyrm-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Sentient Pest", "Night Aspect"],
            drops: ["Night 2 Boss Reward"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Standard, DamageType.Strike, DamageType.Pierce],
            damageBaseline: 49100190,
            damageBaselineName: "the field boss"
        ),
        new Boss(
            25000030, "Crucible Knight", // sword
            location: "Evergaol",
            drops: ["Strong Evergaol Reward"],
            parriable: true,
            strongerVS: [DamageType.Magic, DamageType.Holy],
            weakerVS: [DamageType.Fire, DamageType.Lightning]
        ),
        new Boss(
            25001020, "Crucible Knight", // spear
            location: "Evergaol",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/crucible-knight-boss-elden-ring-nightreign-wiki-guide.png",
            drops: ["Strong Evergaol Reward"],
            parriable: true,
            strongerVS: [DamageType.Magic, DamageType.Holy],
            weakerVS: [DamageType.Fire, DamageType.Lightning]
        ),
        new Boss(
            25000040, "Crucible Knight", // sword
            location: "Castle",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            parriable: true,
            strongerVS: [DamageType.Magic, DamageType.Holy],
            weakerVS: [DamageType.Fire, DamageType.Lightning],
            damageBaseline: 25000030,
            damageBaselineName: "the evergaol boss"
        ),
        new Boss(
            25001030, "Crucible Knight", // spear
            location: "Castle",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Dormant Power"],
            parriable: true,
            strongerVS: [DamageType.Magic, DamageType.Holy],
            weakerVS: [DamageType.Fire, DamageType.Lightning],
            damageBaseline: 25001020,
            damageBaselineName: "the evergaol boss"
        ),
        new Boss(
            35600020, "Godskin Apostle",
            location: "Evergaol",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/godskin-apostle-boss-nightreign-wiki-guide_(1)-min.jpg",
            drops: ["Strong Evergaol Reward"],
            parriable: true,
            strongerVS: [DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep]
        ),
        new Boss(
            35700020, "Godskin Noble",
            location: "Evergaol",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/godskin-noble-boss-nightreign-wiki-guide_(1)-min.png",
            drops: ["Strong Evergaol Reward"],
            parriable: true,
            strongerVS: [DamageType.Strike, DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep]
        ),
        new Boss(
            46500210, "Dragonkin Soldier",
            location: "Evergaol",
            drops: ["Strong Evergaol Reward"],
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Slash]
        ),
        new Boss(
            46500230, "Dragonkin Soldier",
            location: "Noklateo",
            drops: ["Dormant Power"],
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Slash],
            damageBaseline: 46500210,
            damageBaselineName: "the evergaol boss"
        ),
        new Boss(
            30100190, "Banished Knight",
            location: "Evergaol",
            drops: ["Weak Evergaol Reward"],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Lightning],
            backstabbable: true,
            parriable: true,
            damageBaseline: 30100270,
            damageBaselineName: "the Encampment boss"
        ),
        new Boss(
            30100270, "Banished Knight",
            location: "Encampment",
            drops: ["Strong Standard Boss Reward"],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Lightning],
            backstabbable: true,
            parriable: true
        ),
        new Boss(
            30100280, "Banished Knight (Red Eyes)",
            location: "Castle",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            drops: ["Castle Miniboss Reward"],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Lightning],
            backstabbable: true,
            parriable: true,
            damageBaseline: 30100270,
            damageBaselineName: "the Encampment boss"
        ),
        new Boss(
            30100010, "Banished Knight",
            location: "Castle",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Lightning],
            backstabbable: true,
            parriable: true,
            damageBaseline: 30100270,
            damageBaselineName: "the Encampment boss"
        ),
        new Boss(
            33500010, "Crystalian",
            location: "Evergaol",
            drops: ["Weak Evergaol Reward"],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Standard, DamageType.Strike],
            parriable: true,
            damageBaseline: 33500020,
            damageBaselineName: "the Fort boss"
        ),
        new Boss(
            33500020, "Crystalian",
            location: "Fort",
            drops: ["Weak Affinity Reward"],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Standard, DamageType.Strike],
            backstabbable: true,
            parriable: true
        ),
        new Boss(
            37020030, "Glintstone Sorcerer",
            location: "Fort",
            backstabbable: true
        ),
        new Boss(
            39701120, "Beastmen of Farum Azula",
            location: "Ruins",
            drops: ["Strong Affinity Reward"],
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Fire]
        ),
        new Boss(
            39701110, "Beastmen of Farum Azula",
            location: "Evergaol",
            drops: ["Weak Evergaol Reward"],
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Fire],
            damageBaseline: 39701120,
            damageBaselineName: "the Ruins boss"
        ),
        new Boss(
            39703010, "Azula Beastman (Curved Sword)",
            location: "Evergaol",
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Fire]
        ),
        new Boss(
            39702310, "Azula Beastman (Shield)",
            location: "Evergaol",
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Fire]
        ),
        new Boss(
            34510040, "Scaly Misbegotten",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/beastly-brigade-boss-nightreign-wiki-guide_(1)-min.jpg",
            location: "Evergaol",
            drops: ["Weak Evergaol Reward"],
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Fire]
        ),
        new Boss(
            34500040, "Misbegotten",
            location: "Evergaol",
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Fire]
        ),
        new Boss(
            34501040, "Misbegotten (Winged)",
            location: "Evergaol",
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Fire]
        ),
        new Boss(
            33000020, "Nox Warriors", // Monk
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nox-warriors-bosses-elden-ring-nightrein-wiki-guide.jpg",
            location: "Evergaol",
            drops: ["Weak Evergaol Reward"],
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Holy]
        ),
        new Boss(
            33001020, "Nox Swordstress",
            location: "Evergaol",
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Holy]
        ),
        new Boss(
            36000020, "Stoneskin Lords", // Alabaster
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/stoneskin-lords-boss-nightreign-wiki-guide_(1)-min.jpg",
            location: "Evergaol",
            drops: ["Weak Evergaol Reward"],
            parriable: true,
            strongerVS: [DamageType.Magic, DamageType.Fire, DamageType.Holy, DamageType.Lightning],
            weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce]
        ),
        new Boss(
            36001020, "Onyx Lord",
            location: "Evergaol",
            parriable: true,
            strongerVS: [DamageType.Magic, DamageType.Fire, DamageType.Holy, DamageType.Lightning],
            weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce]
        ),
        new Boss(
            42900010, "Bloodhound Knight",
            location: "Evergaol",
            drops: ["Weak Evergaol Reward"],
            parriable: true,
            strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike],
            weakerVS: [DamageType.Lightning]
        ),
        new Boss(
            34001010, "Grave Warden Duelist",
            location: "Evergaol",
            drops: ["Weak Evergaol Reward"],
            parriable: true,
            backstabbable: true,
            weakerVS: [DamageType.Slash, StatusType.BloodLoss]
        ),
        new Boss(
            21400210, "Omen",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/omen-boss-nightreign-wiki-guide_(1)-min.png",
            location: "Evergaol",
            drops: ["Weak Evergaol Reward"],
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Holy],
            weakerVS: [DamageType.Slash]
        ),
        new Boss(
            50110010, "Golden Hippopotamus",
            location: "Field Boss",
            drops: ["Weak Field Boss Reward"],
            image: "https://eldenringnightreign.wiki.fextralife.com/file/XElden-Ring-Nightreign/golden-hippopotamus-boss-nightreign-wiki-guide_(1)-min.png",
            weakerVS: [DamageType.Fire, DamageType.Lightning]
        ),
        new Boss(
            44810020, "Miranda Sprout",
            location: "Field Boss",
            critable: false
        ),
        new Boss(
            36200010, "Oracle Envoy",
            location: "Great Church",
            drops: ["Weak Affinity Reward"],
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/oracle_envoy-boss-nightreign-wiki-guide-min.jpg",
            backstabbable: true,
            strongerVS: [DamageType.Fire, DamageType.Lightning, DamageType.Holy],
            weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Pierce]
        ),
        new Boss(
            44700010, "Abductor Virgin",
            location: "Fort",
            drops: ["Weak Standard Reward"],
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/abductor-virgin-boss-nightreign-wiki-guide-min.jpg",
            critable: false,
            weakPoint: "Interior",
            weakerVS: [DamageType.Lightning],
            strongerVS: [DamageType.Fire, DamageType.Holy]
        ),
        new Boss(
            37040020, "Battlemages",
            location: "Ruins",
            drops: ["Dormant Power"],
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/battlemage-boss-nightreign-wiki-guide-min.jpg",
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Holy]
        ),
        new Boss(
            34715310, "Albinaurics",
            location: "Ruins",
            drops: ["Strong Affinity Reward"],
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/albinaurics-field-boss-elden-ring-nightreign-wiki-guide.jpg",
            parriable: true,
            backstabbable: true,
            weakerVS: [DamageType.Holy],
            strongerVS: [DamageType.Fire]
        ),
        new Boss(
            35500010, "Sanguine Noble",
            location: "Ruins",
            drops: ["Strong Affinity Reward"],
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/sanguine-noble-boss-elden-ring-nightreign-wiki-guide-300px.jpg",
            parriable: true,
            backstabbable: true,
            statusTypes: [StatusType.BloodLoss],
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Slash]
        ),
        new Boss(
            31800030, "Albinauric Archer's Wolf",
            location: "Ruins",
            critable: false,
            weakerVS: [DamageType.Fire]
        ),
        new Boss(
            31800020, "Albinauric Archer's Wolf",
            location: "The Mountaintops",
            critable: false,
            weakerVS: [DamageType.Fire],
            damageBaseline: 31800030,
            damageBaselineName: "the Ruins boss"
        ),
        new Boss(
            37000010, "Depraved Perfumer",
            location: "Ruins",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/depraved-perfumer-boss-nightreign-wiki-guide_(1)-min.png",
            drops: ["Strong Affinity Reward"],
            backstabbable: true,
            statusTypes: [StatusType.Poison],
            strongerVS: [DamageType.Magic, DamageType.Fire, DamageType.Lightning, DamageType.Holy],
            weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Pierce]
        ),
        new Boss(
            43541010, "Redmane Knights",
            location: "Encampment",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/redmane-knight-boss-nightreign-wiki-guide-min.png",
            drops: ["Strong Affinity Reward"],
            parriable: true,
            backstabbable: true,
            damageBaseline: 43511120,
            damageBaselineName: "the Fort boss Lordsworn Captain",
            strongerVS: [DamageType.Slash, DamageType.Fire],
            weakerVS: [DamageType.Pierce, DamageType.Lightning]
        ),
        new Boss(
            44600010, "Flame Chariots",
            location: "Encampment",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/flame-chariots-boss-nightreign-wiki-guide_(1)-min.png",
            drops: ["Strong Affinity Reward"],
            backstabbable: true,
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Strike]
        ),
        new Boss(
            43530030, "Royal Army Knights",
            location: "Encampment",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/royal-army-knights-boss-nightreign-wiki-guide_(1)-min.png",
            drops: ["Strong Affinity Reward"],
            parriable: true,
            backstabbable: true,
            damageBaseline: 43511120,
            damageBaselineName: "the Fort boss Lordsworn Captain",
            strongerVS: [DamageType.Slash, DamageType.Lightning],
            weakerVS: [DamageType.Pierce]
        ),
        new Boss(
            46004010, "Frenzied Flame Troll",
            location: "Encampment",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/frenzied-flame-troll-boss-nightreign-wiki-guide_(1)-min.png",
            drops: ["Dormant Power"],
            damageBaseline: 46000110,
            damageBaselineName: "the Tunnel boss",
            weakerVS: [DamageType.Slash]
        ),
        new Boss(
            39000030, "Fire Monk",
            location: "Crater",
            damageBaseline: 39000020,
            damageBaselineName: "the Great Church boss",
            parriable: true,
            backstabbable: true,
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Holy]
        ),
        new Boss(
            58100920, "Demi-Human Swordmaster",
            location: "The Mountaintops",
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/demi-human-swordmaster-boss-nightreign-wiki-guide_(1)-min.jpg",
            inShiftingEarth: [ShiftingEarth.Mountaintops],
            damageBaseline: 58100910,
            damageBaselineName: "the Night Boss",
            parriable: true,
            drops: ["Mountaintops Reward"],
            weakerVS: [DamageType.Slash, DamageType.Fire]
        ),
        new Boss(
            45601020, "Giant Crows",
            location: "The Mountaintops",
            inShiftingEarth: [ShiftingEarth.Mountaintops],
            drops: ["Mountaintops Reward"],
            weakerVS: [DamageType.Slash, DamageType.Fire],
            strongerVS: [DamageType.Standard, DamageType.Strike, DamageType.Pierce]
        ),
        new Boss(
            45030010, "Mountaintop Ice Dragon",
            location: "The Mountaintops",
            weakPoint: "Head",
            drops: ["Dormant Power"],
            inShiftingEarth: [ShiftingEarth.Mountaintops],
            damageBaseline: 45000010,
            damageBaselineName: "the Flying Dragon field boss",
            weakerVS: [DamageType.Strike],
            strongerVS: [DamageType.Slash, DamageType.Pierce]
        ),
        new Boss(
            46000230, "Headless Troll",
            location: "Noklateo, the Shrouded City",
            drops: ["Noklateo Reward"],
            inShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 46000110,
            damageBaselineName: "the Tunnel boss",
            weakerVS: [DamageType.Slash]
        ),
        new Boss(
            46200010, "Naturalborn of the Void",
            location: "Noklateo, the Shrouded City",
            drops: ["Dormant Power"],
            inShiftingEarth: [ShiftingEarth.Noklateo],
            strongerVS: [DamageType.Magic, DamageType.Fire, DamageType.Lightning, DamageType.Holy],
            weakerVS: [DamageType.Slash, DamageType.Strike, DamageType.Standard, DamageType.Pierce]
        ),
        new Boss(
            46600010, "Golem Horde",
            location: "Event",
            expeditions: ["Tricephalos", "Augur", "Darkdrift Knight"],
            drops: ["Favor of the Night"],
            damageBaseline: 46600030,
            damageBaselineName: "the Great Church boss",
            strongerVS: [DamageType.Fire, DamageType.Lightning, DamageType.Holy],
            weakerVS: [DamageType.Strike]
        ),
        new Boss(
            42410010, "Colossal Fingercreeper",
            location: "Event",
            expeditions: ["Tricephalos", "Augur", "Darkdrift Knight"],
            drops: ["Favor of the Night"],
            weakerVS: [DamageType.Slash, DamageType.Fire],
            strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Holy]
        ),
        new Boss(
            42400030, "Large Fingercreeper",
            location: "Event",
            expeditions: ["Tricephalos", "Augur", "Darkdrift Knight"],
            weakerVS: [DamageType.Slash, DamageType.Fire],
            strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Holy]
        ),
        new Boss(
            42500030, "Small Fingercreeper",
            location: "Event",
            expeditions: ["Tricephalos", "Augur", "Darkdrift Knight"],
            weakerVS: [DamageType.Slash, DamageType.Fire],
            strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Holy]
        ),

        /// NPCs
        new Boss(
            600030010, "Night Assassin",
            npc: true,
            parriable: true,
            spEffectSetIDs: [110980],
            drops: ["Condemned Nightfarer Drop"]
        ),
        new Boss(
            600030110, "Night Fallen",
            npc: true,
            parriable: true,
            spEffectSetIDs: [110980],
            drops: ["Condemned Nightfarer Drop"],
            weakerVS: [DamageType.Fire, DamageType.Lightning],
            strongerVS: [DamageType.Standard, DamageType.Strike, DamageType.Pierce]
        ),
        new Boss(
            600030210, "Night Hunter",
            npc: true,
            parriable: true,
            spEffectSetIDs: [110980],
            drops: ["Condemned Nightfarer Drop"],
            weakerVS: [DamageType.Slash, DamageType.Strike, DamageType.Pierce, DamageType.Fire],
            strongerVS: [DamageType.Standard, DamageType.Magic, DamageType.Lightning]
        ),
        new Boss(
            600030310, "Night Thief",
            npc: true,
            parriable: true,
            spEffectSetIDs: [110980],
            drops: ["Condemned Nightfarer Drop"],
            weakerVS: [DamageType.Slash, DamageType.Strike, DamageType.Pierce],
            strongerVS: [DamageType.Magic]
        ),
        new Boss(
            600030410, "Night Raider",
            npc: true,
            parriable: true,
            spEffectSetIDs: [110980],
            drops: ["Condemned Nightfarer Drop"],
            weakerVS: [DamageType.Pierce, DamageType.Magic, DamageType.Lightning],
            strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Fire]
        ),
        new Boss(
            600030610, "Night Witch",
            npc: true,
            parriable: true,
            spEffectSetIDs: [110980],
            drops: ["Condemned Nightfarer Drop"],
            weakerVS: [DamageType.Slash, DamageType.Pierce],
            strongerVS: [DamageType.Magic]
        ),
        new Boss(
            600030710, "Night Executor",
            npc: true,
            parriable: true,
            spEffectSetIDs: [110980],
            drops: ["Condemned Nightfarer Drop"],
            weakerVS: [DamageType.Magic, DamageType.Lightning],
            strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike]
        ),
        new Boss(
            75400100, "Maris, Fathom of Night (Everdark Sovereign, Phase 1)",
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Lightning],
            statusTypes: [StatusType.Sleep],
            nightlord: true,
            expeditions: ["Augur Everdark Sovereign"],
            damageBaseline: 75400020,
            damageBaselineName: "the standard version"
        ),
        new Boss(
            75410000, "Maris, Fathom of Night (Everdark Sovereign, Phase 2)",
            expeditions: ["Augur Everdark Sovereign"],
            nightlord: true,
            critable: false,
            drops: ["Relics", "Sovereign Sigils"],
            damageBaseline: 75400020,
            damageBaselineName: "the standard version"
        ),
        new Boss(
            75400010, "Augur", // Event Boss
            expeditions: ["Sentient Pest", "Fissure in the Fog", "Night Aspect"],
            drops: ["Unifying Fate"],
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Lightning],
            damageBaseline: 75400020,
            damageBaselineName: "Maris, Fathom of Night"
        ),
        new Boss(
            75200010, "Sentient Pest", // Event Boss
            image: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/sentient-pest-boss-nightreign-wiki-guide_(1)-min.jpg",
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Fire],
            statusTypes: [StatusType.Poison],
            expeditions: ["Augur", "Equilibrious Beast", "Night Aspect"],
            drops: ["Integration of Intelligence"],
            damageBaseline: 75200020,
            damageBaselineName: "Gnoster, Wisdom of Night"
        ),
        new Boss(
            75600110, "Equilibrious Beast",
            drops: ["Demon's Plating"],
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Holy, StatusType.Madness],
            statusTypes: [StatusType.Madness],
            expeditions: ["Darkdrift Knight", "Fissure in the Fog", "Night Aspect"],
            damageBaseline: 75600020,
            damageBaselineName: "Libra, Creature of Night"
        ),
    ];
}
