using System;

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


    public static readonly List<Boss> KnownNRBosses = [
        new Boss(
            75000020, "Gladius, Beast of Night",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/gladius-beast-of-night-nightlord-elden-ring-nightreign-wiki-guide.png",
            drops: ["Old Pocketwatch", "Night of the Beast", "Relics"],
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Holy, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Tricephalos"]
        ),
        new Boss(
            75100020, "Adel, Baron of Night",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/adel-baron-of-night-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
            drops: ["Night of the Baron", "Relics"],
            strongerVS: [DamageType.Fire],
            weakerVS: [StatusType.Poison, StatusType.ScarletRot, StatusType.Frostbite, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Gaping Jaw"]
        ),
        new Boss(
            75110010, "Adel, Baron of Night (Everdark Sovereign)",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/adel-baron-of-night-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
            drops: ["Relics", "Sovereign Sigils"],
            strongerVS: [DamageType.Fire],
            weakerVS: [StatusType.Poison, StatusType.ScarletRot, StatusType.Frostbite, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Gaping Jaw Everdark Sovereign"]
        ),
        new Boss(
            76000010, "Fulghor, Champion of Nightglow",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/fulghor-champion-of-nightglow-darkdrift-knight-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
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
            75300010, "Gnoster, Wisdom of Night (Scorpion)",
            drops: ["Night of the Wise", "Relics"],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Fire, DamageType.Strike, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite, StatusType.Sleep],
            nightlord: true,
            expeditions: ["Sentient Pest"]
        ),
        new Boss(
            75200010, "Sentient Pest",
            location: "Random Encounter",
            drops: ["Integration of Intelligence"],
            strongerVS: [DamageType.Magic],
            weakerVS: [DamageType.Fire, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite],
            critable: false
        ),
        new Boss(
            75400020, "Maris, Fathom of Night",
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
            spEffectSetIDs: [99001]
        ),
        new Boss(
            21300010, "Fell Omen",
            location: "Event",
            drops: ["Traces of Grace-Given Lord"],
            parriable: true,
            spEffectSetIDs: [13910]
        ),
        new Boss(
            21300510, "Fell Omen",
            location: "Night Boss",
            drops: ["Dormant Power"],
            parriable: true,
            spEffectSetIDs: [15000],
            nightBoss: NightBossState.Day2,
            expeditions: ["Tricephalos", "Night Aspect"],
            firstAppearance: Game.ER
        ),
        new Boss(
            77100010, "Centipede Demon",
            drops: ["Dormant Power"],
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/centipede_elden_ring_nightreign_bosses_wiki_guide300px.jpg",
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
            drops: ["Dormant Power"],
            nightBoss: NightBossState.Day1,
            expeditions: ["Tricephalos", "Night Aspect"],
            firstAppearance: Game.ER
        ),
        new Boss(
            58100910, "Demi-Human Swordmaster",
            nightBoss: NightBossState.Day1,
            expeditions: ["Tricephalos", "Night Aspect"],
            parriable: true,
            firstAppearance: Game.ER
        ),
        new Boss(
            32500110, "Draconic Tree Sentinel",
            location: "Night Boss",
            drops: ["Dormant Power"],
            nightBoss: NightBossState.Day2,
            expeditions: ["Sentient Pest", "Fissure in the Fog", "Night Aspect"],
            parriable: true,
            critable: false,
            firstAppearance: Game.ER
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
            drops: ["Dormant Power"],
            parriable: true,
            critable: false
        ),
        new Boss(
            46400020, "Ulcerated Tree Spirit",
            location: "Night Boss",
            drops: ["Dormant Power"],
            expeditions: ["Sentient Pest", "Fissure in the Fog", "Night Aspect"],
            nightBoss: NightBossState.Day1,
            firstAppearance: Game.ER
        ),
        new Boss(
            46400010, "Ulcerated Tree Spirit",
            location: "Field Boss",
            formidable: true,
            drops: ["Dormant Power"]
        ),
        new Boss(
            30500010, "Outland Commander",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/outland-commander-night-boss-nightreign-wiki-guide.jpg",
            drops: ["Dormant Power"],
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
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/tibia_mariner_bosses_elden_ring_nightreign_wiki_guide300px.jpg",
            drops: ["Dormant Power"],
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
            drops: ["Dormant Power"],
            expeditions: ["Tricephalos", "Night Aspect"],
            nightBoss: NightBossState.Day1,
            firstAppearance: Game.ER,
            parriable: true,
            strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Magic, DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Pierce]
        ),
        new Boss(
            31000010,  "Bell Bearing Hunter",
            location: "Field Boss",
            formidable: true,
            drops: ["Dormant Power"],
            parriable: true
        ),
        new Boss(
            31000030,  "Bell Bearing Hunter",
            location: "Castle Basement",
            drops: ["Dormant Power"],
            parriable: true
        ),
        new Boss(
            31500020,  "Night's Cavalry (Glaive)",
            location: "Night Boss",
            drops: ["Dormant Power"],
            parriable: true,
            backstabbable: true,
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Darkdrift Knight", "Night Aspect"],
            firstAppearance: Game.ER
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
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/smelter-demon-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Sentient Pest", "Augur", "Fissure in the Fog", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.DS2,
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Strike, DamageType.Standard]
        ),
        new Boss(
            79200010,  "Dancer of the Boreal Valley",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/dancer-of-the-boreal-valley-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Fissure in the Fog", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.DS3,
            weakerVS: [DamageType.Holy]
        ),
        new Boss(
            78000010,  "The Duke's Dear Freya",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/duke's-dear-freja-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.DS2,
            strongerVS: [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            weakerVS: [DamageType.Strike]
        ),
        new Boss(
            47509010, "Grafted Monarch",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/grafted-monarch-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Augur", "Fissure in the Fog", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Holy],
            weakerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce]
        ),
        new Boss(
            46809010, "Full-Grown Fallingstar Beast",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/full-grown-fallingstar-beast-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Augur", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
            weakerVS: [DamageType.Fire, DamageType.Magic, DamageType.Lightning, DamageType.Holy]
        ),
        new Boss(
            46500010, "Nox Dragonkin Soldier",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nox-dragonskin-soldier-nightreign-bosses-wiki-guide_(1)-min.png",
            nightBoss: NightBossState.Day2,
            expeditions: ["Sentient Pest", "Darkdrift Knight", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Slash]
        ),
        new Boss(
            79100010, "Nameless King (Phase 1)",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nameless_king_elden_ring_nightreign_bosses_wiki_guide300px.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Darkdrift Knight", "Night Aspect"],
            drops: ["Dormant Power"],
            strongerVS: [DamageType.Fire],
            weakerVS: [DamageType.Lightning],
            firstAppearance: Game.DS3,
            additionalPhases: [79000010]
        ),
        new Boss(
            79000010, "Nameless King (Phase 2)",
            parriable: true,
            drops: ["Dormant Power"],
            strongerVS: [DamageType.Lightning],
            weakerVS: [DamageType.Holy]
        ),
        new Boss(
            77000010, "Gaping Dragon",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/gaping-dragon-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Augur", "Darkdrift Knight", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.DS1,
            strongerVS: [DamageType.Standard, DamageType.Strike, DamageType.Pierce, DamageType.Slash],
            weakerVS: [DamageType.Lightning]
        ),
        new Boss(
            30500110, "Battlefield Commander",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/battlefield-commander-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Sentient Pest", "Equilibrious Beast", "Night Aspect"],
            drops: ["Dormant Power"],
            parriable: true,
            firstAppearance: Game.ER,
            statusTypes: [StatusType.ScarletRot],
            strongerVS: [DamageType.Slash],
            weakerVS: [DamageType.Pierce]
        ),
        new Boss(
            32510110, "Tree Sentinel",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/tree-sentinel-nightreign-bosses-wiki-guide_(1)-min.png",
            nightBoss: NightBossState.Day2,
            expeditions: ["Tricephalos", "Sentient Pest", "Augur", "Night Aspect"],
            drops: ["Dormant Power"],
            parriable: true,
            critable: false,
            firstAppearance: Game.ER
        ),
        new Boss(
            32510020, "Tree Sentinel",
            location: "Field Boss",
            drops: ["Dormant Power"],
            formidable: true,
            parriable: true,
            critable: false
        ),
        new Boss(
            40210020, "Royal Revenant",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/royal-revenant-boss-nightreign-wiki-guide-min.png",
            nightBoss: NightBossState.Day1,
            expeditions: ["Equilibrious Beast", "Darkdrift Knight", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.ER,
            statusTypes: [StatusType.Poison],
            strongerVS: [DamageType.Holy],
            weakerVS: [DamageType.Slash]
        ),
        new Boss(
            40210010, "Royal Revenant",
            location: "Field Boss",
            drops: ["Dormant Power"],
            statusTypes: [StatusType.Poison]
        ),
        new Boss(
            40210030, "Royal Revenant",
            location: "Castle Basement",
            drops: ["Dormant Power"],
            statusTypes: [StatusType.Poison]
        ),
        new Boss(
            47700020, "Valiant Gargoyle",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/valiant-gargoyle-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Augur", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.ER
        ),
        new Boss(
            47701030, "Valiant Gargoyle",
            location: "Crater",
            drops: ["Dormant Power"]
        ),
        new Boss(
            45803010, "Wormface",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/wormface-boss-nightreign-wiki-guide-min.png",
            nightBoss: NightBossState.Day1,
            expeditions: ["Gaping Jaw", "Augur", "Darkdrift Knight", "Night Aspect"],
            drops: ["Dormant Power"],
            statusTypes: [StatusType.DeathBlight],
            firstAppearance: Game.ER
        ),
        new Boss(
            45803020, "Wormface",
            location: "Ruins",
            drops: ["Dormant Power"],
            statusTypes: [StatusType.DeathBlight]
        ),
        new Boss(
            45101110, "Ancient Dragon",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/ancient-dragon-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Gaping Jaw", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.ER
        ),
        new Boss(
            45102010, "Ancient Dragon",
            location: "Evergaol",
            drops: ["Dormant Power"],
            spEffectIDs: [99150]
        ),
        new Boss(
            25000020, "Crucible Knight",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/crucible-knight-golden-hippopotamus-night-boss-nightreign-wiki-guide.jpg",
            nightBoss: NightBossState.Day2,
            expeditions: ["Gaping Jaw", "Equilibrious Beast", "Night Aspect"],
            drops: ["Dormant Power"],
            parriable: true,
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Magic, DamageType.Holy],
            weakerVS: [DamageType.Fire, DamageType.Lightning]
        ),
        new Boss(
            50110020, "Golden Hippopotamus",
            location: "Night Boss",
            nightBoss: NightBossState.Day2,
            expeditions: ["Gaping Jaw", "Equilibrious Beast", "Night Aspect"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Standard, DamageType.Strike, DamageType.Pierce, DamageType.Magic, DamageType.Holy],
            weakerVS: [DamageType.Fire, DamageType.Lightning]
        ),
        new Boss(
            49801010, "Death Rite Bird",
            location: "Night Boss",
            nightBoss: NightBossState.Day2,
            expeditions: ["Equilibrious Beast", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.ER,
            weakPoint: "Head",
            statusTypes: [StatusType.Frostbite, StatusType.DeathBlight],
            weakerVS: [DamageType.Strike, DamageType.Holy],
            strongerVS: [DamageType.Pierce, DamageType.Lightning]
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
            drops: ["Dormant Power"],
            weakPoint: "Head",
            statusTypes: [StatusType.Frostbite, StatusType.DeathBlight],
            weakerVS: [DamageType.Strike, DamageType.Holy],
            strongerVS: [DamageType.Pierce, DamageType.Lightning],
            spEffectIDs: [99152]
        ),
        new Boss(
            35600010, "Godskin Apostle",
            location: "Night Boss",
            imageUrl: "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/godskin-duo-evergaol-boss-elden-ring-nightreign-wiki-guide.jpg",
            parriable: true,
            nightBoss: NightBossState.Day2,
            expeditions: ["Augur", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            drops: ["Dormant Power"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep]
        ),
        new Boss(
            35700010, "Godskin Noble",
            location: "Night Boss",
            parriable: true,
            nightBoss: NightBossState.Day2,
            expeditions: ["Augur", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            firstAppearance: Game.ER,
            strongerVS: [DamageType.Strike, DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep]
        ),
        new Boss(
            35600110, "Godskin Apostle",
            location: "Evergaol", // The Oldest Gaol
            parriable: true,
            drops: ["Dormant Power"],
            spEffectIDs: [99150],
            strongerVS: [DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep]
        ),
        new Boss(
            35700110, "Godskin Noble",
            location: "Evergaol", // The Oldest Gaol
            parriable: true,
            spEffectIDs: [99150],
            strongerVS: [DamageType.Strike, DamageType.Fire, DamageType.Holy],
            weakerVS: [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep]
        ),
    ];
}
