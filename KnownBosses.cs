using System;
using static System.Net.WebRequestMethods;

public partial class Boss
{
    public static readonly List<Boss> KnownERBosses = [
        new(47601050, "Fire Giant") {
            GameAreaID = 1052520800,
            Location = "Mountaintops of the Giants",
            Optional = false,
        },
        new(
            21900078, "Radagon of the Golden Order"
        ) {
            Location = "Erdtree",
            ClosestGrace = "Elden Throne",
            Optional = false,
            Parriable = true,
            ParriesPerCrit = 3,
        },
        new(22000078, "Elden Beast") {
            GameAreaID = 19000800,
            Location = "Erdtree",
            ClosestGrace = "Elden Throne",
            Optional = false,
            Drops = ["Elden Remembrance"],
        },
        new(21200056, "Malenia, Blade of Miquella") {
            GameAreaID = 15000800,
            Location = "Elphael, Brace of the Haligtree",
            ClosestGrace = "Haligtree Roots",
            Drops = ["Malenia's Great Rune", "Remembrance of the Rot Goddess"],
            Parriable = true,
            ParriesPerCrit = 3,
            StatusTypes = [StatusType.ScarletRot],
        },

        /// NPCs
        new(523090010, "Patches") {
            GameAreaID = 31000800,
            Location = "Murkwater Cave",
            IsNPC = true,
            Parriable = true,
            DamageTypes = [DamageType.Strike, DamageType.Pierce],
        },
        new(
            523560020, "Adan, Thief of Fire",
            multiplayerAllowed: false,
            summonsAllowed: false
        ) {
            GameAreaID = 1038410800,
            Location = "Malefactor's Evergaol",
            ClosestGrace = "Scenic Isle",
            IsNPC = true,
            Drops = ["Flame of the Fell God"],
            Parriable = false,
            DamageTypes = [DamageType.Strike, DamageType.Fire],
        },
        new(523760930, "Necromancer Garris") {
            GameAreaID = 31190850,
            Location = "Sage's Cave",
            IsNPC = true,
            Drops = ["Family Heads"],
            Parriable = false,
            DamageTypes = [DamageType.Strike, DamageType.Magic],
        },
        new(523860000, "Esgar, Priest of Blood") {
            GameAreaID = 35000850,
            Location = "Leyndell Catacombs",
            IsNPC = true,
            Drops = ["Lord of Blood's Exultation"],
            Parriable = true,
            DamageTypes = [
                DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Magic,
                DamageType.Fire
            ],
            StatusTypes = [StatusType.Hemorrhage],
        },
        new(
            523040050, "Roundtable Knight Vyke",
            multiplayerAllowed: false,
            summonsAllowed: false
        ) {
            GameAreaID = 1053560800,
            Location = "Lord Contender's Evergaol",
            ClosestGrace = "Whiteridge Road",
            IsNPC = true,
            Drops = ["Fingerprint Set", "Vyke's Dragonbolt"],
            Parriable = true,
            DamageTypes = [DamageType.Standard, DamageType.Pierce, DamageType.Lightning],
        },
        new(
            523610066, "First Champion",
            multiplayerAllowed: true,
            summonsAllowed: true
        ) {
            Location = "Deeproot Depths",
            ClosestGrace = "Across the Roots",
            IsNPC = true,
            Parriable = true,
        },
        new(
            523250066, "Sorcerer Rogier", // Fia's Champions
            multiplayerAllowed: true,
            summonsAllowed: true
        ) {
            CharaInitID = 23252,
            Location = "Deeproot Depths",
            ClosestGrace = "Across the Roots",
            IsNPC = true,
            Parriable = true,
        },
        new(
            523290066, "Lionel the Lionhearted", // Fia's Champions
            multiplayerAllowed: true,
            summonsAllowed: true
        ) {
            Location = "Deeproot Depths",
            ClosestGrace = "Across the Roots",
            IsNPC = true,
            Parriable = true,
            StatusTypes = [StatusType.DeathBlight],
        },
        new(
            523610066, "Fourth Champion",
            multiplayerAllowed: true,
            summonsAllowed: true
        ) {
            CharaInitID = 23701,
            Location = "Deeproot Depths",
            ClosestGrace = "Across the Roots",
            IsNPC = true,
            Parriable = true,
        },
        new(
            523610066, "Fifth Champion",
            multiplayerAllowed: true,
            summonsAllowed: true
        ) {
            CharaInitID = 23711,
            Location = "Deeproot Depths",
            ClosestGrace = "Across the Roots",
            IsNPC = true,
            Parriable = true,
        },
        new(
            523240070, "Sir Gideon Ofnir, the All-Knowing",
            multiplayerAllowed: true,
            summonsAllowed: true
        ) {
            GameAreaID = 11050850,
            CharaInitID = 23248,
            Location = "Leyndell, Ashen Capital",
            Optional = false,
            IsNPC = true,
            Drops = ["All-Knowing Set", "Scepter of the All-Knowing"],
            Parriable = true,
            DamageTypes = [
                DamageType.Standard, DamageType.Strike, DamageType.Magic, DamageType.Fire,
                DamageType.Holy
            ],
            StatusTypes = [StatusType.ScarletRot, StatusType.Hemorrhage],
        },

        /// DLC
        new(58100980, "Demi-Human Swordmaster Onze") {
            GameAreaID = 41000800,
            Location = "Belurat Gaol",
            Drops = ["Demi-Human Swordsman Yosh"],
            Parriable = true,
            StatusTypes = [StatusType.Frostbite],
        },
        new(
            52100088, "Divine Beast Dancing Lion",
            summonableNPCs: ["Redmane Freyja"]
        ) {
            GameAreaID = 20000800,
            Location = "Belurat, Tower Settlement",
            Optional = false,
            Drops = ["Remembrance of the Dancing Lion", "Divine Beast Head"],
            StatusTypes = [StatusType.Frostbite],
        },
        new(52100094, "Divine Beast Dancing Lion") {
            GameAreaID = 2046460800,
            Location = "Ancient Ruins of Rauh",
            ClosestGrace = "Temple Town Ruins",
            Drops = ["Divine Beast Tornado"],
            StatusTypes = [StatusType.DeathBlight],
        },
        new(58600080, "Ghostflame Dragon") {
            GameAreaID = 2045440800,
            Location = "Gravesite Plain",
            ClosestGrace = "Greatbridge, North",
            Drops = ["Dragon Heart", "Somber Ancient Dragon Smithing Stone"],
            StatusTypes = [StatusType.Frostbite],
            WeakPoint = "head",
        },
        new(58600083, "Ghostflame Dragon") {
            GameAreaID = 2048380850,
            Location = "Cerulean Coast",
            Drops = ["Dragon Heart", "Somber Ancient Dragon Smithing Stone"],
            StatusTypes = [StatusType.Frostbite],
            WeakPoint = "head",
        },
        new(58600090, "Ghostflame Dragon") {
            GameAreaID = 2049430800,
            Location = "Moorth Highway",
            ClosestGrace = "Moorth Highway, South",
            Drops = ["Dragon Heart", "Somber Ancient Dragon Smithing Stone"],
            StatusTypes = [StatusType.Frostbite],
            WeakPoint = "head",
        },
        new(50000092, "Commander Gaius") {
            GameAreaID = 2049480800,
            Location = "Scaduview",
            ClosestGrace = "Shadow Keep, Back Gate",
            Drops = ["Remembrance of the Wild Boar Rider"],
        },
        new(
            50100098, "Golden Hippopotamus",
            summonableNPCs: ["Redmane Freya", "Hornsent"]
        ) {
            GameAreaID = 21000850,
            Location = "Shadow Keep",
            ClosestGrace = "Shadow Keep Main Gate",
            Drops = ["Aspects of the Crucible: Thorns", "Scadutree Fragment x2"],
        },
        new(
            50110084, "Hippopotamus",
            summonsAllowed: false
        ) {
            Location = "Charo's Hidden Grave",
            IsBoss = false,
            Drops = ["Scadutree Fragment"],
        },
        new(50110091, "Hippopotamus") {
            Location = "Recluses' River",
            ClosestGrace = "Recluses' River Downstream",
            IsBoss = false,
            Drops = ["Scadutree Fragment"]
        },
        new(50110094, "Hippopotamus") {
            Location = "Ancient Ruins of Rauh",
            ClosestGrace = "Viaduct Minor Tower",
            IsBoss = false,
            Drops = ["Scadutree Fragment"]
        },
        new(50200087, "Putrescent Knight") {
            GameAreaID = 22000800,
            Location = "Stone Coffin Fissure",
            ClosestGrace = "Fissure Depths",
            Drops = ["Remembrance of Putrescence"],
            StatusTypes = [StatusType.Frostbite],
        },
        new(50300094, "Romina, Saint of the Bud") {
            GameAreaID = 2044450800,
            Location = "Church of the Bud",
            ClosestGrace = "Church of the Bud, Main Entrance",
            Optional = false,
            Drops = ["Remembrance of the Saint of the Bud"],
            Parriable = true,
            StatusTypes = [StatusType.ScarletRot],
        },
        new(50400190, "Curseblade Labirith") {
            GameAreaID = 41010800,
            Location = "Bonny Gaol",
            Drops = ["Curseblade Meera"],
            Parriable = true,
        },
        new(50510086, "Midra, Lord of Frienzied Flame") {
            GameAreaID = 28000800,
            Location = "Midra's Manse",
            ClosestGrace = "Second Floor Chamber",
            Drops = ["Remembrance of the Lord of Frenzied Flame"],
            Parriable = true,
            ParriesPerCrit = 3,
            StatusTypes = [StatusType.Madness],
        },
        new(50500086, "Midra (Human Form)") {
            Location = "Midra's Manse",
            StatusTypes = [StatusType.Madness],
        },
        new(50700081, "Death Knight") {
            GameAreaID = 40000800,
            Location = "Fog Rift Catacombs",
            Drops = ["Death Knight's Twin Axes", "Crimson Amber Medallion +3"],
            Parriable = true
        },
        new(50701095, "Death Knight") {
            GameAreaID = 40010800,
            Location = "Scorpion River Catacombs",
            Drops = ["Death Knight's Longhaft Axe", "Cerulean Amber Medallion +3"],
            Parriable = true,
            Backstabbable = true,
        },
        new(50810990, "Chief Bloodfiend") {
            GameAreaID = 43000800,
            Location = "Rivermouth Cave",
            Drops = ["Bloodfiend Hexer's Ashes "],
            Parriable = true,
            StatusTypes = [StatusType.Hemorrhage],
        },
        new(
            51200085, "Bayle the Dread",
            summonableNPCs: ["Igon"]
        ) {
            GameAreaID = 2054390800,
            Location = "Jagged Peak",
            ClosestGrace = "Jagged Peak Summit",
            Drops = ["Heart of Bayle"],
            WeakPoint = "Head, Leg Stump",
        },
        new(
            51301099, "Messmer the Impaler",
            summonableNPCs: ["Hornsent", "Jolan"]
        ) {
            GameAreaID = 21010800,
            Location = "Shadow Keep",
            ClosestGrace = "Dark Chamber Entrance",
            Optional = false,
            Drops = ["Remembrance of the Impaler", "Messmer's Kindling"],
            Parriable = true,
            ParriesPerCrit = 3,
        },
        new(52000097, "Metyr, Mother of Fingers") {
            GameAreaID = 25000800,
            Location = "Finger Ruins of Miyr",
            ClosestGrace = "Cathedral of Manus Metyr",
            Drops = ["Remembrance of the Mother of Fingers"],
            WeakPoint = "Belly",
        },
        new(
            52200089, "Promised Consort Radahn",
            summonableNPCs: ["Thiollier", "Sir Ansbach"]
        ) {
            GameAreaID = 20010800,
            Location = "Enir-Elim",
            ClosestGrace = "Divine Gatefront Staircase",
            Optional = false,
            Drops = ["Remembrance of a God and a Lord"],
            Parriable = true,
            ParriesPerCrit = 3,
            DamageTypes = [DamageType.Fire, DamageType.Standard, DamageType.Pierce, DamageType.Holy],
        },
        new(
            52201089, "Radahn, Consort of Miquella",
            summonableNPCs: ["Thiollier", "Sir Ansbach"]
        ) {
            GameAreaID = 20010800,
            Location = "Enir-Elim",
            ClosestGrace = "Divine Gatefront Staircase",
            Optional = false,
            Drops = ["Remembrance of a God and a Lord"],
            Parriable = true,
            ParriesPerCrit = 3,
            DamageTypes = [DamageType.Fire, DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Holy],
        },
        new(52200089, "Promised Consort Radahn") {
            GameAreaID = 2050480800,
            Location = "Scadutree Base",
            AdditionalPhaseIDs = [52201089],
            Drops = ["Remembrance of the Shadow Sunflower", "Miquella's Great Rune"],
            StatusTypes = [StatusType.Hemorrhage],
            WeakPoint = "Flower",
        },
        new(52300096, "Scadutree Avatar") {
            GameAreaID = 2050480800,
            Location = "Scadutree Base",
            AdditionalPhaseIDs = [52300296, 52300296],
            Drops = ["Remembrance of the Shadow Sunflower", "Miquella's Great Rune"],
            StatusTypes = [StatusType.Hemorrhage],
            WeakPoint = "Flower",
        },
        new(53000082, "Rellana, Twin Moon Knight") {
            GameAreaID = 2048440800,
            Location = "Castle Ensis",
            ClosestGrace = "Castle Lord's Chamber",
            Drops = ["Remembrance of the Twin Moon Knight"],
            Parriable = true,
            ParriesPerCrit = 2
        },
        new(53120086, "Jori, Elder Inquisitor") {
            GameAreaID = 2052430800,
            Location = "Abyssal Woods",
            ClosestGrace = "Darklight Catacombs",
            Drops = ["Barbed Staff-Spear"],
            Parriable = true,
            Backstabbable = true,
        },
        new(
            53701185, "Ancient Dragon Senessax",
            multiplayerAllowed: false
        ) {
            GameAreaID = 2054390850,
            Location = "Jagged Peak",
            ClosestGrace = "Jagged Peak Summit",
            Drops = ["Ancient Dragon Smithing Stone", "Somber Ancient Dragon Smithing Stone"],
            WeakPoint = "Head",
        },
        new(
            55800084, "Jagged Peak Drake", // Solo
            multiplayerAllowed: false
        ) {
            GameAreaID = 2049410800,
            Location = "Jagged Peak Foothills",
            ClosestGrace = "Dragon's Pit Terminus",
            Drops = ["Dragon Heart", "Dragonscale Flesh"],
            WeakPoint = "Head",
        },
        new(
            55800985, "Jagged Peak Drake", // Duo
            multiplayerAllowed: false,
            summonsAllowed: false
        ) {
            GameAreaID = 2052400800,
            Location = "Jagged Peak",
            ClosestGrace = "Foot of the Jagged Peak",
            Drops = ["Dragon Heart", "Dragonscale Flesh"],
            WeakPoint = "Head",
        },
        new(55800085, "Lesser Dragon") {
            Location = "Jagged Peak",
            ClosestGrace = "Foot of the Jagged Peak",
            IsBoss = false,
            WeakPoint = "Head",
        },
        new(57300083, "Demi-Human Queen Marigga") {
            GameAreaID = 2046400800,
            Location = "Cerulean Coast",
            ClosestGrace = "Cerulean Coast West",
            Drops = ["Star-Lined Sword"],
        },
        new(58200990, "Ralva the Great Red Bear") {
            GameAreaID = 2049450800,
            Location = "Scadu Altus",
            ClosestGrace = "Highroad Cross",
            Drops = ["Pelt of Ralva"],
        },
        new(58200095, "Rugalea the Great Red Bear") {
            GameAreaID = 2044470800,
            Location = "Rauh Base",
            ClosestGrace = "Ravine North",
            Drops = ["Roar of Rugalea"],
        },
        new(58400590, "Black Knight Garrew") {
            GameAreaID = 2047450800,
            Location = "Fog Rift Fort",
            ClosestGrace = "Scadu Altus, West",
            Drops = ["Black Steel Greatshield"],
            Parriable = true,
        },
        new(58400690, "Black Knight Edredd") {
            GameAreaID = 2049430850,
            Location = "Fort of Reprimand",
            Drops = ["Ash of War: Aspects of the Crucible: Wings"],
            Parriable = true,
        },
        new(59200181, "Magma Wyrm") {
            Location = "Dragon's Pit",
            IsBoss = false,
            Drops = ["Dragon Heart", "Ancient Dragon Smithing Stone"],
            WeakPoint = "Head",
        },
        new(59600088, "Ulcerated Tree Spirit") {
            Location = "Belurat, Tower Settlement",
            ClosestGrace = "Main Gate Cross",
            IsBoss = false,
            Drops = ["Immunizing Horn Charm +2"],
        },
        new(59600081, "Ulcerated Tree Spirit") {
            Location = "Ellac River",
            ClosestGrace = "Ellac River Cave",
            IsBoss = false,
            Drops = ["Horned Bairn"],
        },
        new(59600098, "Ulcerated Tree Spirit") {
            Location = "Church District",
            ClosestGrace = "Sunken Chapel",
            IsBoss = false,
            Drops = ["Mantle of Thorns", "Iris of Occulation"],
        },
        new(62511093, "Tree Sentinel") { // Torch
            GameAreaID = 2050470800,
            Location = "Hinterland",
            ClosestGrace = "Hinterland Bridge",
            Drops = ["Blessing of Marika"],
            Parriable = true,
            Critable = false,
        },
        new(62510093, "Tree Sentinel") { // Shield
            GameAreaID = 2050480860,
            Location = "Hinterland",
            ClosestGrace = "Hinterland Bridge",
            Drops = ["Blessing of Marika"],
            Parriable = true,
            Critable = false,
        },
        new(62601084, "Death Rite Bird") {
            GameAreaID = 2047390800,
            Location = "Charo's Hidden Grave",
            Drops = ["Ash of War: Ghostflame Call"],
        },
        new(63101093, "Fallingstar Beast") {
            GameAreaID = 2052480800,
            Location = "Finger Ruins of Dheo",
            ClosestGrace = "Fingerstone Hill",
            Drops = ["Gravitational Missile"],
            WeakPoint = "Face and Rump",
        },
        new(56200084, "Tibia Mariner") {
            Location = "Charo's Hidden Grave",
            IsBoss = false,
            Drops = ["Tibia's Cookbook"],
            Critable = false,
        },
        // Note: humanoid boss, unclear how to handle it. Madness resist is definitely wrong, other
        // stuff might be as well.
        new(524070081, "Ancient Dragon-Man") {
            GameAreaID = 43010800,
            Location = "Dragon's Pit",
            IsNPC = true,
            Drops = ["Dragon-Hunter's Great Katana"],
            Parriable = true,
            DamageTypes = [
                DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Fire
            ],
        },
        new(
            524200190, "Count Ymir, Mother of Fingers",
            multiplayerAllowed: false,
            summonsAllowed: false
        ) {
            GameAreaID = 2051450800,
            Location = "Cathedral of Manus Meyr",
            IsNPC = true,
            Drops = ["Ymir's Bell Bearing", "Maternal Staff", "High Priest Set"],
        },
        new(
            524090190, "Swordhand of Night Jolan",
            multiplayerAllowed: false,
            summonsAllowed: false
        ) {
            CharaInitID = 2024091,
            Location = "Cathedral of Manus Meyr",
            IsNPC = true,
        },
        new(
            524210095, "Red Bear",
            summonsAllowed: false
        ) {
            GameAreaID = 2046450800,
            Location = "Northern Nameless Mausoleum",
            ClosestGrace = "Temple Town Ruins",
            IsNPC = true,
            Drops = ["Red Bear's Claw", "Iron Rivet Set"],
            Parriable = true,
            DamageTypes = [DamageType.Standard, DamageType.Slash],
            StatusTypes = [StatusType.Hemorrhage],
        },
        new(
            524220083, "Dancer of Ranah",
            summonsAllowed: false
        ) {
            GameAreaID = 2046380800,
            Location = "Southern Nameless Mausoluem",
            ClosestGrace = "Cerulean Coast West",
            IsNPC = true,
            Drops = ["Dancing Blade of Ranah", "Dancer's Set"],
            Parriable = true,
        },
        new(
            524230091, "Rakshasa",
            summonsAllowed: false
        ) {
            GameAreaID = 2051440800,
            Location = "Eastern Namelss Mausoleum",
            ClosestGrace = "Recluses' River Downstream",
            IsNPC = true,
            Drops = ["Rakshasa's Great Katana", "Rakshasa's Set"],
            Parriable = true,
        },
        new(
            524240080, "Blackgaol Knight",
            summonsAllowed: false
        ) {
            GameAreaID = 2046410800,
            Location = "Western Nameless Mausoleum",
            ClosestGrace = "Scorched Ruins",
            IsNPC = true,
            Drops = ["Greatsword of Solitude", "Solitude Set"],
            Parriable = true,
        },
        new(524250190, "Dryleaf Dane") {
            Location = "Moorth Ruins",
            IsNPC = true,
            Drops = ["Dane's Hat", "Dryleaf Arts"],
            Parriable = true,
        },
        new(524270084, "Lamenter") {
            GameAreaID = 41020800,
            Location = "Lamenter's Gaol",
            IsNPC = true,
            Drops = ["Lamenter's Mask"],
            Parriable = true,
        },
        new(524170289, "Redmane Freyja") {
            Location = "Enir-Ilim",
            IsNPC = true,
            Parriable = true,
        },
        new(524140289, "Hornsent") {
            Location = "Enir-Ilim",
            IsNPC = true,
            Parriable = true,
        },
        new(524150289, "Moore") {
            Location = "Enir-Ilim",
            IsNPC = true
        },
        new(524250289, "Dryleaf Dane") {
            Location = "Enir-Ilim",
            IsNPC = true,
            Parriable = true,
        },
        new(
            524180289, "Needle Knight Leda",
            summonableNPCs: ["Thiollier", "Sir Ansbach", "Sanguine Noble Nalaan"]
        ) {
            Location = "Enir-Ilim",
            Optional = false,
            IsNPC = true,
            Drops = ["Leda's Sword"],
            Parriable = true,
        }
    ];

    public static readonly List<List<Boss>> KnownNRBossGroups = [
        [
            new(
                40210020, "Royal Revenant",
                damageBaseline: 40210010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Night Boss",
                TopLevelImage = Image.Crop1080p("royal-revenant-basement-2"),
                NightBossState = NightBossState.Day1,
                Expeditions = ["Equilibrious Beast", "Darkdrift Knight", "Night Aspect"],
                FirstAppearance = Game.ER,
                Drops = ["Night 1 Boss Reward"],
                StatusTypes = [StatusType.Poison],
                StrongerVS = [DamageType.Holy],
                WeakerVS = [DamageType.Slash],
            },
            new(40210010, "Royal Revenant") {
                Location = "Field Boss",
                Image = Image.Full4K("royal-revenant-field-2-nightreign"),
                Drops = ["Weak Field Boss Reward"],
                StatusTypes = [StatusType.Poison]
            },
            new(
                40210030, "Royal Revenant",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 40210010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Castle Basement",
                Image = Image.Crop1080p("royal-revenant-basement"),
                Drops = ["Strong Field Boss Reward"],
                StatusTypes = [StatusType.Poison],
            },
            new(
                40200030, "Royal Revenant",
                inShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 40210010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Noklateo",
                Drops = ["Noklateo Reward"],
                StatusTypes = [StatusType.Poison],
                SPEffectIDs = [7790],
            },
        ],
        [
            new(
                31500020, "Night's Cavalry",
                damageBaseline: 31500010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Night Boss",
                TopLevelImage = Image.Full4K("nights-cavalry-night-boss-2-nightreign"),
                Image = Image.Full4K("nights-cavalry-night-boss-1-nightreign"),
                NightBossState = NightBossState.Day1,
                Count = 2,
                Expeditions = ["Gaping Jaw", "Darkdrift Knight", "Night Aspect"],
                FirstAppearance = Game.ER,
                Drops = ["Night 1 Boss Reward"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Magic, DamageType.Fire, DamageType.Holy],
                WeakerVS = [DamageType.Pierce],
            },
            new(31500010, "Night's Cavalry") { // Glaive
                Location = "Field Boss",
                Drops = ["Weak Field Boss Reward"],
                Parriable = true,
                Backstabbable = true,
            },
        ],
        [
            new(31810010, "Red Wolf of the King Consort") {
                Location = "Field Boss",
                TopLevelImage = Image.Full4K("red-wolf-field-2-nightreign"),
                Image = Image.Full4K("red-wolf-field-nightreign"),
                Drops = ["Weak Field Boss Reward"],
                StrongerVS = [DamageType.Magic],
                WeakerVS = [DamageType.Slash],
            },
            new(
                31810020, "Red Wolf of the King Consort",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 31810010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Castle Basement",
                Image = Image.Full4K("red-dog-basement-nightreign"),
                Drops = ["Strong Field Boss Reward"],
                StrongerVS = [DamageType.Magic],
                WeakerVS = [DamageType.Slash],
                SPEffectIDs = [7790],
            },
        ],
        [
            new(21000020, "Black Knife Assassin") {
                Location = "Field Boss",
                Image = Image.Full4K("black-knife-assassin-field-1-nightreign"),
                Drops = ["Weak Field Boss Reward"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Pierce, DamageType.Holy],
                WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike],
            },
            new(
                21000030, "Black Knife Assassin",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 21000020,
                damageBaselineName: "the field boss"
            ) {
                Location = "Castle Basement",
                Image = Image.Full1080p("black-knife-assassin-basement"),
                Drops = ["Strong Field Boss Reward"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Pierce, DamageType.Holy],
                WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike],
                SPEffectIDs = [7790],
            },
            new(
                21000040, "Black Knife Assassin",
                inShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 21000020,
                damageBaselineName: "the field boss"
            ) {
                Location = "Noklateo",
                Drops = ["Noklateo Reward"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Pierce, DamageType.Holy],
                WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike],
            },
        ],
        [
            new(46900010, "Grafted Scion") {
                Location = "Field Boss",
                TopLevelImage = Image.Full1080p("grafted-scion-1"),
                Image = Image.Crop1080p("grafted-scion-field-2-nightreign"),
                Drops = ["Weak Field Boss Reward"],
                Parriable = true,
                StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Fire, DamageType.Holy],
                WeakerVS = [DamageType.Slash],
            },
            new(
                46900020, "Grafted Scion",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 46900010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Castle Basement",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/grafted-scion-boss-nightreign-wiki-guide-min.jpg",
                Drops = ["Strong Field Boss Reward"],
                Parriable = true,
                StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Fire, DamageType.Holy],
                WeakerVS = [DamageType.Slash],
                SPEffectIDs = [7790],
            },
        ],
        [
            new(46300210, "Runebear (Silver)") {
                Location = "Ruins",
                Drops = ["Strong Affinity Reward"],
                WeakerVS = [DamageType.Fire],
            },
            new(
                46300210, "Runebear (Brown)",
                damageBaseline: 46300210,
                damageBaselineName: "the silver Runebear"
            ) {
                Location = "Ruins",
                Drops = ["Dormant Power"],
                WeakerVS = [DamageType.Fire],
            },
        ],
        [
            new(
                46801020, "Fallingstar Beast",
                inShiftingEarth: [ShiftingEarth.Crater]
            ) {
                Location = "Crater",
                Drops = ["Strong Crater Reward"],
                StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
                WeakerVS = [DamageType.Fire, DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            },
            new(
                46801010, "Fallingstar Beast",
                damageBaseline: 46801020,
                damageBaselineName: "the boss in The Crater"
            ) {
                Location = "Meteor Strike",
                Expeditions = ["Tricephalos", "Gaping Jaw", "Fissure in the Fog"],
                Drops = ["Strong Field Boss Reward"],
                StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
                WeakerVS = [DamageType.Fire, DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            },
        ],
        [
            new(37010030, "Perfumer") {
                Location = "Ruins",
                Drops = ["Strong Affinity Reward"],
                Backstabbable = true,
                StatusTypes = [StatusType.Poison],
                StrongerVS = [DamageType.Magic, DamageType.Fire, DamageType.Lightning],
                WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Holy],
            },
            new(
                37011020, "Perfumer",
                damageBaseline: 37010030,
                damageBaselineName: "the Ruins boss"
            ) {
                Location = "Night Boss Entourage",
                Expeditions = ["Tricephalos", "Sentient Pest", "Augur", "Night Aspect"],
                IsBoss = false,
                Backstabbable = true,
                StatusTypes = [StatusType.Poison],
                StrongerVS = [DamageType.Magic, DamageType.Fire, DamageType.Lightning],
                WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Holy],
            },
        ],
        [
            new(71000110, "Ancient Hero of Zamor") {
                Location = "Ruins",
                TopLevelImage = Image.Crop4K("ancient-hero-of-zamor-field-2-nightreign"),
                Image = Image.Crop4K("ancient-hero-ruins-2-nightreign"),
                Drops = ["Strong Affinity Reward"],
                CataclysmSpEffectID = 7630,
                Parriable = true,
                WeakerVS = [DamageType.Fire, DamageType.Lightning],
                StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Pierce],
            },
            new(
                71000010, "Ancient Hero of Zamor",
                damageBaseline: 71000110,
                damageBaselineName: "the Ruins boss"
            ) {
                Location = "Field Boss",
                Image = Image.Full4K("ancient-hero-of-zamor-field-1-nightreign"),
                Drops = ["Weak Field Boss Reward"],
                Parriable = true,
                WeakerVS = [DamageType.Fire, DamageType.Lightning],
                StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Pierce],
            },
            new(
                71000020, "Ancient Hero of Zamor",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 71000110,
                damageBaselineName: "the Ruins boss"
            ) {
                Location = "Castle Basement",
                Image = Image.Full4K("ancient-hero-basement-nightreign"),
                Drops = ["Strong Field Boss Reward"],
                Parriable = true,
                WeakerVS = [DamageType.Fire, DamageType.Lightning],
                StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Pierce],
                SPEffectIDs = [7790],
            },
        ],
        [
            new(34600010, "Leonine Misbegotten") {
                Location = "Encampment",
                TopLevelImage = Image.Crop4K("leonine-misbegotten-basement-2-nightreign"),
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/leonine_misbegotten_bosses_elden_ring__night_reign_wiki-300px.png",
                Drops = ["Strong Standard Reward"],
                CataclysmSpEffectID = 7630,
                Parriable = true,
                WeakerVS = [DamageType.Slash, DamageType.Fire],
                StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            },
            new(
                34600020, "Leonine Misbegotten",
                damageBaseline: 34600010,
                damageBaselineName: "the Encampment boss"
            ) {
                Location = "Field Boss",
                Drops = ["Weak Field Boss Reward"],
                Parriable = true,
                WeakerVS = [DamageType.Slash, DamageType.Fire],
                StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            },
            new(
                34600040, "Leonine Misbegotten",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 34600010,
                damageBaselineName: "the Encampment boss"
            ) {
                Location = "Castle Basement",
                Image = Image.Crop4K("leonine-misbegotten-basement-3-nightreign"),
                Drops = ["Strong Field Boss Reward"],
                Parriable = true,
                WeakerVS = [DamageType.Slash, DamageType.Fire],
                StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
                SPEffectIDs = [7790],
            },
        ],
        [
            new(42700030, "Elder Lion") {
                Location = "Encampment",
                TopLevelImage = Image.Full4K("elder-lion-ruins-1-nightreign"),
                Image = Image.Full4K("elder-lion-ruins-2-nightreign"),
                Drops = ["Strong Standard Reward"],
                WeakerVS = [DamageType.Fire],
            },
            new(
                42700020, "Elder Lion",
                damageBaseline: 42700030,
                damageBaselineName: "the Encampment boss"
            ) {
                Location = "Field Boss",
                Image = Image.Full4K("elder-lion-field-1-nightreign"),
                Drops = ["Weak Field Boss Reward"],
                WeakerVS = [DamageType.Fire],
            },
            new(
                42700040, "Elder Lion",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 42700030,
                damageBaselineName: "the Encampment boss"
            ) {
                Location = "Castle Courtyard",
                Image = Image.Full4K("elder-lion-castle-nightreign"),
                Drops = ["Castle Miniboss Reward"],
                WeakerVS = [DamageType.Fire],
            },
        ],
        [
            new(41300020, "Demi-Human Queen") {
                Location = "Field Boss",
                TopLevelImage = Image.Full4K("demi-human-queen-field-1-nightreign"),
                Image = Image.Full4K("demi-human-queen-field-2-nightreign"),
                Drops = ["Weak Field Boss Reward"],
                WeakerVS = [DamageType.Fire, StatusType.Poison, StatusType.ScarletRot],
            },
            new(
                41300030, "Demi-Human Queen",
                inShiftingEarth: [ShiftingEarth.Crater],
                damageBaseline: 41300020,
                damageBaselineName: "the field boss"
            ) {
                Location = "Crater",
                Drops = ["Weak Crater Reward"],
                WeakerVS = [DamageType.Fire, StatusType.Poison, StatusType.ScarletRot],
            },
        ],
        [
            new(
                44800410, "Miranda Blossom",
                damageBaseline: 44800020,
                damageBaselineName: "the field boss"
            ) {
                Location = "Poison Ruins",
                Affinity = StatusType.Poison,
                DamageTypes = [DamageType.Standard, DamageType.Strike, DamageType.Holy],
                StatusTypes = [StatusType.Poison],
                StrongerVS = [DamageType.Strike, DamageType.Lightning, DamageType.Holy],
                WeakerVS = [DamageType.Slash, DamageType.Fire],
            },
            new(44800020, "Miranda Blossom") {
                Location = "Field Boss",
                Image = Image.Full4K("miranda-blossom-field-nightreign"),
                Drops = ["Weak Field Boss Reward"],
                DamageTypes = [DamageType.Standard, DamageType.Strike, DamageType.Holy],
                StatusTypes = [StatusType.Poison],
                StrongerVS = [DamageType.Strike, DamageType.Lightning, DamageType.Holy],
                WeakerVS = [DamageType.Slash, DamageType.Fire],
            },
        ],
        [
            new(45000010, "Flying Dragon") {
                Location = "Field Boss",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/flying_dragon-boss-nightreign-wiki-guide-min.jpg",
                Drops = ["Strong Field Boss Reward"],
                WeakerVS = [DamageType.Pierce],
                WeakPoint = "Head",
            },
            new(
                45050020, "Flying Dragon",
                damageBaseline: 45000010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Night Boss Entourage",
                WeakerVS = [DamageType.Pierce],
                WeakPoint = "Head",
            },
            new(
                45050040, "Flying Dragon",
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                damageBaseline: 45000010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Mountaintop",
                Drops = ["Mountaintops Reward"],
                WeakerVS = [DamageType.Pierce],
                WeakPoint = "Head",
            },
        ],
        [
            new(48100010, "Erdtree Avatar") {
                Location = "Field Boss",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/erdtree-avatar-bosses-nightreign-wiki-guide_(1)-min.png",
                Drops = ["Strong Field Boss Reward"],
                StrongerVS = [DamageType.Holy],
                WeakerVS = [DamageType.Fire],
            },
            new(
                48100010, "Erdtree Avatar",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 48100010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Castle Rooftop",
                Drops = ["Strong Field Boss Reward"],
                StrongerVS = [DamageType.Holy],
                WeakerVS = [DamageType.Fire],
                SPEffectIDs = [7791],
            },
        ],
        [
            new(46700010, "Ancestor Spirit") {
                Location = "Field Boss",
                Drops = ["Strong Field Boss Reward"],
                StrongerVS = [DamageType.Magic],
                WeakerVS = [DamageType.Fire, DamageType.Holy],
            },
            new(
                46700010, "Ancestor Spirit",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 48100010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Castle Rooftop",
                Drops = ["Strong Field Boss Reward"],
                StrongerVS = [DamageType.Magic],
                WeakerVS = [DamageType.Fire, DamageType.Holy],
                SPEffectIDs = [7791],
            },
        ],
        [
            new(49100190, "Magma Wyrm") {
                Location = "Field Boss",
                Drops = ["Strong Field Boss Reward"],
                WeakPoint = "Head",
            },
            new(
                49100190, "Magma Wyrm",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 49100190,
                damageBaselineName: "the field boss"
            ) {
                Location = "Castle Rooftop",
                Drops = ["Strong Field Boss Reward"],
                SPEffectIDs = [7791],
                WeakPoint = "Head",
            },
            new(
                49100120, "Magma Wyrm",
                inShiftingEarth: [ShiftingEarth.Crater],
                damageBaseline: 49100190,
                damageBaselineName: "the field boss"
            ) {
                Location = "Crater",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/magma-wyrm-nightreign-bosses-wiki-guide.png",
                Drops = ["Dormant Power", "Special Armament Strenghtening"],
                WeakerVS = [DamageType.Standard, DamageType.Strike, DamageType.Pierce],
                StrongerVS = [DamageType.Fire],
                WeakPoint = "Head",
            },
        ],
        [
            new(32520010, "Royal Carian Knight") {
                Location = "Field Boss",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/royal-carian-knight-boss-nightreign-wiki-guide_(1)-min.png",
                Drops = ["Strong Field Boss Reward"],
                Parriable = true,
                Critable = false,
                StrongerVS = [DamageType.Magic, DamageType.Fire],
                WeakerVS = [DamageType.Lightning],
            },
            new(
                32520010, "Royal Carian Knight",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 32520010,
                damageBaselineName: "the field boss"
            ) {
                Location = "Castle Rooftop",
                Drops = ["Strong Field Boss Reward"],
                Parriable = true,
                Critable = false,
                StrongerVS = [DamageType.Magic, DamageType.Fire],
                WeakerVS = [DamageType.Lightning],
                SPEffectIDs = [7791],
            },
        ],
        [
            new(47701210, "Black Blade Kindred") {
                Location = "Field Boss",
                Drops = ["Strong Field Boss Reward"],
                StrongerVS = [DamageType.Holy],
                WeakerVS = [DamageType.Strike],
                WeakPoint = "Head",
            },
            new(
                47701210, "Black Blade Kindred",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 47701210,
                damageBaselineName: "the field boss"
            ) {
                Location = "Castle Rooftop",
                Drops = ["Strong Field Boss Reward"],
                StrongerVS = [DamageType.Holy],
                WeakerVS = [DamageType.Strike],
                SPEffectIDs = [7791],
                WeakPoint = "Head",
            },
        ],
        [
            new(46600030, "Guardian Golem") {
                Location = "Great Church",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/guardian-golem-boss-nightreign-wiki-guide_(1)-min.png",
                Drops = ["Weak Standard Reward"],
                StrongerVS = [DamageType.Fire, DamageType.Lightning, DamageType.Holy],
                WeakerVS = [DamageType.Strike],
            },
            new(
                46601010, "Guardian Golem",
                damageBaseline: 46600030,
                damageBaselineName: "the Great Church boss"
            ) {
                Location = "Fort",
                Drops = ["Dormant Power"],
                StrongerVS = [DamageType.Fire, DamageType.Lightning, DamageType.Holy],
                WeakerVS = [DamageType.Strike],
            },
        ],
        [
            new(43550020, "Mausoleum Knight") {
                Location = "Great Church",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/mausoleum-knight-nightreign-bosses-wiki-guide_(1)-min.png",
                Drops = ["Weak Standard Reward"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Slash],
                WeakerVS = [DamageType.Pierce, DamageType.Lightning, DamageType.Holy],
            },
            new(
                43550010, "Mausoleum Knight", // Normal
                inShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 43550020,
                damageBaselineName: "the Great Church boss"
            ) {
                Location = "Noklateo",
                IsBoss = false,
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Slash],
                WeakerVS = [DamageType.Pierce, DamageType.Lightning, DamageType.Holy],
            },
            new(
                43551020, "Mausoleum Knight", // Flaming Sword
                inShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 43550020,
                damageBaselineName: "the Great Church boss"
            ) {
                Location = "Noklateo",
                Drops = ["Dormant Power"],
                Parriable = true,
                Backstabbable = true,
                StatusTypes = [StatusType.DeathBlight],
                StrongerVS = [DamageType.Slash],
                WeakerVS = [DamageType.Pierce, DamageType.Lightning, DamageType.Holy],
            },
        ],
        [
            new(39000020, "Fire Monk") {
                Location = "Great Church",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/fire-monk-location-boss-elden-ring-nightreign-wiki-guide-300px.jpg",
                Drops = ["Weak Affinity Reward"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Fire],
                WeakerVS = [DamageType.Holy],
            },
            new(
                39001010, "Fire Monk",
                inShiftingEarth: [ShiftingEarth.Crater],
                damageBaseline: 39000020,
                damageBaselineName: "the Great Church boss"
            ) {
                Location = "Crater",
                IsBoss = false,
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Fire],
                WeakerVS = [DamageType.Holy],
            },
        ],
        [
            new(43510020, "Lordsworn Captain") {
                Location = "Fort",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/lordsworn-captain-boss-nightreign-wiki-guide_(1)-min.png",
                Drops = ["Weak Standard Reward"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Slash],
                WeakerVS = [DamageType.Pierce, DamageType.Lightning],
            },
            new(
                43511120, "Lordsworn Captain",
                damageBaseline: 43511120,
                damageBaselineName: "the Fort boss"
            ) {
                Location = "Tunnel",
                Drops = ["Tunnel Reward"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Slash],
                WeakerVS = [DamageType.Pierce, DamageType.Lightning],
            },
            new(
                43510030, "Lordsworn Captain",
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                damageBaseline: 43511120,
                damageBaselineName: "the Fort boss"
            ) {
                Location = "Mountaintop",
                Drops = ["Dormant Power"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Slash],
                WeakerVS = [DamageType.Pierce, DamageType.Lightning],
            },
            new(
                43510040, "Lordsworn Captain",
                inShiftingEarth: [ShiftingEarth.Woods],
                damageBaseline: 43511120,
                damageBaselineName: "the Fort boss"
            ) {
                Location = "Rotted Woods",
                Drops = ["Dormant Power"],
                Parriable = true,
                Backstabbable = true,
                StrongerVS = [DamageType.Slash],
                WeakerVS = [DamageType.Pierce, DamageType.Lightning],
            },
        ],
        [
            new(
                46000110, "Troll",
                notInShiftingEarth: [ShiftingEarth.Woods]
            ) {
                Location = "Tunnel",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/troll_enemies_elden_ring_nightreign_wiki_600px.jpg",
                Drops = ["Tunnel Reward"],
                WeakerVS = [DamageType.Slash],
            },
            new(
                46000030, "Troll",
                notInShiftingEarth: [ShiftingEarth.Noklateo],
                damageBaseline: 46000110,
                damageBaselineName: "the Tunnel boss"
            ) {
                Location = "Castle",
                Drops = ["Castle Miniboss Reward"],
                WeakerVS = [DamageType.Slash],
            }
        ],
        [
            new(43401120, "Mad Pumpkin Head") {
                Location = "Tunnel",
                Drops = ["Tunnel Reward"],
                WeakerVS = [DamageType.Lightning],
                StrongerVS = [DamageType.Strike],
            },
            new(
                43401010, "Mad Pumpkin Head",
                damageBaseline: 43401120,
                damageBaselineName: "the Tunnel boss"
            ) {
                Location = "Encampment",
                IsBoss = false,
                WeakerVS = [DamageType.Lightning],
                StrongerVS = [DamageType.Strike],
            }
        ],
        [
            new(42600610, "Erdtree Burial Watchdogs") { // sword, staff is 42601610
                Location = "Ruins",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/burial-watchdog-boss-nightreign-wiki-guide_(1)-min.png",
                Drops = ["Strong Standard Reward"],
                Parriable = true,
                WeakerVS = [DamageType.Strike],
            },
            new(
                42600110, "Erdtree Burial Watchdogs",
                damageBaseline: 42600610,
                damageBaselineName: "the Ruins boss"
            ) {
                Location = "Night Boss Entourage",
                Expeditions = ["Sentient Pest", "Augur", "Fissure in the Fog", "Night Aspect"],
                Parriable = true,
                WeakerVS = [DamageType.Strike],
            },
        ],
        [
            new(31700040, "Albinauric Archers") {
                Location = "Ruins",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/albinauric_archer-boss-nightreign-wiki-guide-min.jpg",
                Drops = ["Strong Standard Reward"],
                StrongerVS = [DamageType.Magic],
                WeakerVS = [DamageType.Holy],
            },
            new(
                31700020, "Albinauric Archers",
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                damageBaseline: 31700040,
                damageBaselineName: "the Ruins boss"
            ) {
                Location = "Mountaintop",
                Drops = ["Dormant Power"],
                StrongerVS = [DamageType.Magic],
                WeakerVS = [DamageType.Holy],
            },
        ],
        [
            new(
                39101120, "Fire Prelate",
                inShiftingEarth: [ShiftingEarth.Crater]
            ) {
                Location = "Crater West",
                Drops = ["Dormant Power"],
                StrongerVS = [DamageType.Fire],
                WeakerVS = [DamageType.Holy],
            },
            new(
                39100130, "Fire Prelates",
                inShiftingEarth: [ShiftingEarth.Crater],
                damageBaseline: 39101120,
                damageBaselineName: "the previous enemies"
            ) {
                Location = "Crater North",
                Drops = ["Weak Crater Reward"],
                StrongerVS = [DamageType.Fire],
                WeakerVS = [DamageType.Holy],
            },
        ],
        [
            new(
                46020050, "Snowfield Troll",
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                damageBaseline: 46000110,
                damageBaselineName: "the Tunnel boss"
            ) {
                Location = "Mountaintops South",
                Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/snowfield-trolls-boss-nightreign-wiki-guide_(1)-min.jpg",
                Drops = ["Dormant Power"],
                WeakerVS = [DamageType.Fire],
            },
            new(
                46020030, "Snowfield Trolls",
                inShiftingEarth: [ShiftingEarth.Mountaintops],
                damageBaseline: 46000110,
                damageBaselineName: "the Tunnel boss"
            ) {
                Location = "Mountaintops East",
                Drops = ["Mountaintops Reward"],
                WeakerVS = [DamageType.Fire],
            },
        ],
    ];

    public static readonly List<Boss> KnownNRBosses = [
        ..KnownNRBossGroups.SelectMany(group => group),
        new(75000020, "Gladius, Beast of Night") {
            Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/gladius-beast-of-night-nightlord-elden-ring-nightreign-wiki-guide.png",
            Nightlord = true,
            Expeditions = ["Tricephalos"],
            Drops = ["Old Pocketwatch", "Night of the Beast", "Relics"],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Holy, StatusType.Sleep],
        },
        new(75100020, "Adel, Baron of Night") {
            Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/adel-baron-of-night-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
            Nightlord = true,
            Expeditions = ["Gaping Jaw"],
            Drops = ["Night of the Baron", "Relics"],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [StatusType.Poison, StatusType.ScarletRot, StatusType.Frostbite, StatusType.Sleep],
        },
        new(
            75110010, "Adel, Baron of Night (Everdark Sovereign)",
            damageBaseline: 75100020,
            damageBaselineName: "the standard version"
        ) {
            Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/adel-baron-of-night-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
            Nightlord = true,
            Expeditions = ["Gaping Jaw Everdark Sovereign"],
            Drops = ["Relics", "Sovereign Sigils"],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [StatusType.Poison, StatusType.ScarletRot, StatusType.Frostbite, StatusType.Sleep],
        },
        new(76000010, "Fulghor, Champion of Nightglow") {
            Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/fulghor-champion-of-nightglow-darkdrift-knight-nightlord-boss-elden-ring-nightreign-wiki-guide.jpg",
            Nightlord = true,
            Expeditions = ["Darkdrift Knight"],
            Drops = ["Night of the Champion", "Relics"],
            StrongerVS = [DamageType.Holy],
            WeakerVS = [DamageType.Lightning],
        },
        new(75200020, "Gnoster, Wisdom of Night (Moth)") {
            Nightlord = true,
            Expeditions = ["Sentient Pest"],
            Drops = ["Night of the Wise", "Relics"],
            StatusTypes = [StatusType.Poison],
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Fire, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite],
        },
        new(75300010, "Faurtis Stoneshield (Scorpion)") { // healthbar
            Nightlord = true,
            Expeditions = ["Sentient Pest"],
            Drops = ["Night of the Wise", "Relics"],
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Fire, DamageType.Strike, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite, StatusType.Sleep],
        },
        new(
            75200120, "Gnoster, Wisdom of Night (Everdark Sovereign, Phase 1)",
            damageBaseline: 75200020,
            damageBaselineName: "the standard version"
        ) {
            Nightlord = true,
            Expeditions = ["Sentient Pest Everdark Sovereign"],
            StatusTypes = [StatusType.Poison],
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Fire, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite],
        },
        new(
            75200030, "Gnoster, Wisdom of Night (Everdark Sovereign, Phase 2)",
            damageBaseline: 75200020,
            damageBaselineName: "the standard version"
        ) {
            Nightlord = true,
            Expeditions = ["Sentient Pest Everdark Sovereign"],
            StatusTypes = [StatusType.Poison],
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Fire, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite],
        },
        new(
            75300120, "Faurtis Stoneshield (Scorpion, Everdark Sovereign, Phase 1)",
            damageBaseline: 75200010,
            damageBaselineName: "the standard version"
        ) {
            Nightlord = true,
            Expeditions = ["Sentient Pest Everdark Sovereign"],
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Fire, DamageType.Strike, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite, StatusType.Sleep],
        },
        new(21500310, "Gnoster, Wisdom of Night (Everdark Sovereign, Phase 1, Healthbar)") {
            Nightlord = true,
            Expeditions = ["Sentient Pest Everdark Sovereign"],
        },
        new(
            75300020, "Faurtis Stoneshield (Scorpion, Everdark Sovereign, Phase 2)",
            damageBaseline: 75200010,
            damageBaselineName: "the standard version"
        ) {
            Nightlord = true,
            Expeditions = ["Sentient Pest Everdark Sovereign"],
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Fire, DamageType.Strike, StatusType.ScarletRot, StatusType.BloodLoss, StatusType.Frostbite, StatusType.Sleep],
        },
        new(75210010, "Animus, Ascendant Light") {
            Nightlord = true,
            Expeditions = ["Sentient Pest Everdark Sovereign"],
            Drops = ["Relics", "Sovereign Sigils"]
        },
        new(75400020, "Maris, Fathom of Night") {
            Nightlord = true,
            Expeditions = ["Augur"],
            Drops = ["Night of the Fathom", "Relics"],
            StatusTypes = [StatusType.Sleep],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Lightning],
        },
        new(75600020, "Libra, Creature of Night") {
            Nightlord = true,
            Expeditions = ["Equilibrious Beast"],
            Drops = ["Night of the Demon", "Relics"],
            StatusTypes = [StatusType.Madness],
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Holy, StatusType.Poison, StatusType.ScarletRot, StatusType.Madness],
        },
        new(49000010, "Caligo, Miasma of Night") {
            Image = Image.Full1080p("caligo-nightreign"),
            Nightlord = true,
            Expeditions = ["Fissure in the Fog"],
            Drops = ["Night of the Miasma", "Relics"],
            StatusTypes = [StatusType.Frostbite],
            StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            WeakerVS = [DamageType.Fire],
        },
        new(49010010, "Caligo, Miasma of Night") {
            Nightlord = true,
            Expeditions = ["Fissure in the Fog Everdark Sovereign"],
            Drops = ["Relics", "Sovereign Sigils"],
            StatusTypes = [StatusType.Frostbite],
            StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            WeakerVS = [DamageType.Fire],
        },
        new(75800010, "The Shape of Night") {
            Nightlord = true,
            Expeditions = ["Night Aspect"],
            StrongerVS = [DamageType.Strike],
            WeakerVS = [DamageType.Holy],
        },
        new(75802010, "Heolstor the Nightlord") {
            Nightlord = true,
            Drops = ["Night of the Lord", "Primordial Nightlord's Rune", "Relics"],
            Expeditions = ["Night Aspect"],
            StatusTypes = [StatusType.BloodLoss, StatusType.Sleep, StatusType.DeathBlight, StatusType.Poison, StatusType.ScarletRot, StatusType.Madness],
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Holy, DamageType.Lightning],
        },
        new(
            21300520, "Fell Omen",
            damageBaseline: 21300510,
            damageBaselineName: "the night boss"
        ) {
            Location = "Tutorial",
            Drops = ["Fell Omen Fetish"],
            Parriable = true,
            SPEffectSetIDs = [99001],
        },
        new(
            21300010, "Fell Omen",
            damageBaseline: 21300510,
            damageBaselineName: "the night boss"
        ) {
            Location = "Event",
            Drops = ["Traces of Grace-Given Lord"],
            Parriable = true,
            SPEffectSetIDs = [13910],
        },
        new(21300510, "Fell Omen") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Tricephalos", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            Parriable = true,
            SPEffectSetIDs = [15000],
        },
        new(77100010, "Centipede Demon") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Sentient Pest", "Equilibrious Beast", "Darkdrift Knight", "Night Aspect"],
            FirstAppearance = Game.DS1,
            Drops = ["Night 1 Boss Reward"],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Strike, DamageType.Lightning, DamageType.Holy],
            SPEffectSetIDs = [15000],
        },
        new(77110010, "Centipede Grub") {
            Location = "Night Boss",
            SPEffectSetIDs = [15000],
        },
        new(
            41301010, "Demi-Human Queen",
            damageBaseline: 41300020,
            damageBaselineName: "the field boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Tricephalos", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 1 Boss Reward"],
        },
        new(
            58100910, "Demi-Human Swordmaster",
            damageBaseline: 58100920,
            damageBaselineName: "the boss in The Mountaintops"
        ) {
            Location = "Night Boss",
            NightBossState =  NightBossState.Day1,
            Expeditions = ["Tricephalos", "Night Aspect"],
            FirstAppearance = Game.ER,
            Parriable = true,
        },
        new(
            32500110, "Draconic Tree Sentinel",
            damageBaseline: 32500090,
            damageBaselineName: "the field boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Sentient Pest", "Fissure in the Fog", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            Parriable = true,
            Critable = false,
        },
        new(43531110, "Leyndell Knight") {
            Location = "Night Boss",
            FirstAppearance = Game.ER,
        },
        new(43630010, "Leyndell Knight's Horse") {
            Location = "Night Boss",
            FirstAppearance = Game.ER,
            Critable = false,
        },
        new(32500090, "Draconic Tree Sentinel") {
            Location = "Field Boss",
            Formidable = true,
            Drops = ["Strong Field Boss Reward"],
            Parriable = true,
            Critable = false,
        },
        new(
            32500090, "Draconic Tree Sentinel",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 32500090,
            damageBaselineName: "the field boss"
        ) {
            Location = "Castle Rooftop",
            Drops = ["Strong Field Boss Reward"],
            Parriable = true,
            Critable = false,
            SPEffectIDs = [7791],
        },
        new(
            46400020, "Ulcerated Tree Spirit",
            damageBaseline: 46400010,
            damageBaselineName: "the field boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Sentient Pest", "Fissure in the Fog", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 1 Boss Reward"],
        },
        new(46400010, "Ulcerated Tree Spirit") {
            Location = "Field Boss",
            Formidable = true,
            Drops = ["Strong Field Boss Reward"]
        },
        new(
            46400010, "Ulcerated Tree Spirit",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 46400010,
            damageBaselineName: "the field boss"
        ) {
            Location = "Castle Rooftop",
            Drops = ["Strong Field Boss Reward"],
            SPEffectIDs = [7791],
        },
        new(30500010, "Outland Commander") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Gaping Jaw", "Darkdrift Knight", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            Parriable = true,
            StatusTypes = [StatusType.Frostbite],
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Pierce],
        },
        new(49500010, "Tibia Mariner") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Sentient Pest", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 1 Boss Reward"],
            Critable = false,
            StrongerVS = [DamageType.Lightning, DamageType.Pierce],
            WeakerVS = [DamageType.Holy, DamageType.Strike],
        },
        new(
            31000020, "Bell Bearing Hunter",
            damageBaseline: 31000010,
            damageBaselineName: "the field boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Tricephalos", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 1 Boss Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Magic, DamageType.Fire, DamageType.Holy],
            WeakerVS = [DamageType.Pierce],
        },
        new(31000010, "Bell Bearing Hunter") {
            Location = "Field Boss",
            Formidable = true,
            Drops = ["Strong Field Boss Reward"],
            Parriable = true
        },
        new(
            31000030, "Bell Bearing Hunter",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 31000010,
            damageBaselineName: "the field boss"
        ) {
            Location = "Castle Basement",
            Drops = ["Strong Field Boss Reward"],
            Parriable = true,
            SPEffectIDs = [7790],
        },
        new(
            31000010, "Bell Bearing Hunter",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 31000010,
            damageBaselineName: "the field boss"
        ) {
            Location = "Castle Rooftop",
            Drops = ["Strong Field Boss Reward"],
            Parriable = true,
            SPEffectIDs = [7791],
        },
        new(31600020,  "Funeral Steed") {
            Location = "Night Boss",
            Critable = false,
        },
        new(31600010,  "Funeral Steed") {
            Location = "Field Boss",
            Critable = false,
        },
        new(78200010,  "Smelter Demon") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Sentient Pest", "Augur", "Fissure in the Fog", "Night Aspect"],
            FirstAppearance = Game.DS2,
            Drops = ["Night 1 Boss Reward"],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Strike, DamageType.Standard],
        },
        new(79200010,  "Dancer of the Boreal Valley") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Fissure in the Fog", "Night Aspect"],
            FirstAppearance = Game.DS3,
            Drops = ["Night 2 Boss Reward"],
            WeakerVS = [DamageType.Holy],
        },
        new(78000010,  "The Duke's Dear Freya") {
            Location = "Night Boss",
            Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/duke's-dear-freja-night-boss-nightreign-wiki-guide.jpg",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Gaping Jaw", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            FirstAppearance = Game.DS2,
            Drops = ["Night 1 Boss Reward"],
            StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
            WeakerVS = [DamageType.Strike],
        },
        new(47509010, "Grafted Monarch") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Augur", "Fissure in the Fog", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 1 Boss Reward"],
            StrongerVS = [DamageType.Holy],
            WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
        },
        new(
            46809010, "Full-Grown Fallingstar Beast",
            damageBaseline: 46801020,
            damageBaselineName: "the boss in The Crater"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Augur", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
            WeakerVS = [DamageType.Fire, DamageType.Magic, DamageType.Lightning, DamageType.Holy],
        },
        new(
            46500010, "Nox Dragonkin Soldier",
            damageBaseline: 46500210,
            damageBaselineName: "the evergaol boss"
        ) {
            Location = "Night Boss",
            Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nox-dragonskin-soldier-nightreign-bosses-wiki-guide_(1)-min.png",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Sentient Pest", "Darkdrift Knight", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            StrongerVS = [DamageType.Lightning],
            WeakerVS = [DamageType.Slash],
        },
        new(79100010, "Nameless King (Phase 1)") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Darkdrift Knight", "Night Aspect"],
            FirstAppearance = Game.DS3,
            AdditionalPhaseIDs = [79000010],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Lightning],
        },
        new(79000010, "Nameless King (Phase 2)") {
            Drops = ["Night 2 Boss Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Lightning],
            WeakerVS = [DamageType.Holy],
        },
        new(77000010, "Gaping Dragon") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Gaping Jaw", "Augur", "Darkdrift Knight", "Night Aspect"],
            FirstAppearance = Game.DS1,
            Drops = ["Night 1 Boss Reward"],
            StrongerVS = [DamageType.Standard, DamageType.Strike, DamageType.Pierce, DamageType.Slash],
            WeakerVS = [DamageType.Lightning],
        },
        new(30500110, "Battlefield Commander") {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Sentient Pest", "Equilibrious Beast", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 1 Boss Reward"],
            Parriable = true,
            StatusTypes = [StatusType.ScarletRot],
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Pierce],
        },
        new(
            32510110, "Tree Sentinel",
            damageBaseline: 32510020,
            damageBaselineName: "the field boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Tricephalos", "Sentient Pest", "Augur", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            Parriable = true,
            Critable = false,
        },
        new(32510020, "Tree Sentinel") {
            Location = "Field Boss",
            Formidable = true,
            Drops = ["Strong Field Boss Reward"],
            Parriable = true,
            Critable = false,
        },
        new(
            32510020, "Tree Sentinel",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 32510020,
            damageBaselineName: "the field boss"
        ) {
            Location = "Castle Rooftop",
            Drops = ["Strong Field Boss Reward"],
            Parriable = true,
            Critable = false,
            SPEffectIDs = [7791],
        },
        new(
            47700020, "Valiant Gargoyle",
            damageBaseline: 47701030,
            damageBaselineName: "the boss in The Crater"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Gaping Jaw", "Augur", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 1 Boss Reward"],
        },
        new(
            47701030, "Valiant Gargoyle",
            inShiftingEarth: [ShiftingEarth.Crater]
        ) {
            Location = "Crater",
            Drops = ["Strong Crater Reward"]
        },
        new(
            45803010, "Wormface",
            damageBaseline: 45803020,
            damageBaselineName: "the Ruins boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day1,
            Expeditions = ["Gaping Jaw", "Augur", "Darkdrift Knight", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 1 Boss Reward"],
            StatusTypes = [StatusType.DeathBlight],
        },
        new(45803020, "Wormface") {
            Location = "Ruins",
            Drops = ["Strong Standard Boss Reward"],
            StatusTypes = [StatusType.DeathBlight]
        },
        new(
            45101110, "Ancient Dragon",
            damageBaseline: 45102010,
            damageBaselineName: "the evergaol boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Gaping Jaw", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
        },
        new(45102010, "Ancient Dragon") {
            Location = "Evergaol",
            Drops = ["Strong Evergaol Reward"],
        },
        new(
            25000020, "Crucible Knight",
            damageBaseline: 25000030,
            damageBaselineName: "the evergaol boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Gaping Jaw", "Equilibrious Beast", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Magic, DamageType.Holy],
            WeakerVS = [DamageType.Fire, DamageType.Lightning],
        },
        new(
            50110020, "Golden Hippopotamus",
            damageBaseline: 50110010,
            damageBaselineName: "the field boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Gaping Jaw", "Equilibrious Beast", "Night Aspect"],
            FirstAppearance = Game.ER,
            StrongerVS = [DamageType.Standard, DamageType.Strike, DamageType.Pierce, DamageType.Magic, DamageType.Holy],
            WeakerVS = [DamageType.Fire, DamageType.Lightning],
        },
        new(
            49801010, "Death Rite Bird",
            damageBaseline: 49801020,
            damageBaselineName: "the field boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Equilibrious Beast", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            StatusTypes = [StatusType.Frostbite, StatusType.DeathBlight],
            WeakerVS = [DamageType.Strike, DamageType.Holy],
            StrongerVS = [DamageType.Pierce, DamageType.Lightning],
            WeakPoint = "Head",
        },
        new(49801020, "Death Rite Bird") {
            Location = "Field Boss",
            Formidable = true,
            Drops = ["Dormant Power"],
            StatusTypes = [StatusType.Frostbite, StatusType.DeathBlight],
            WeakerVS = [DamageType.Strike, DamageType.Holy],
            StrongerVS = [DamageType.Pierce, DamageType.Lightning],
            WeakPoint = "Head",
        },
        new(
            49801030, "Death Rite Bird",
            damageBaseline: 49801020,
            damageBaselineName: "the field boss"
        ) {
            Location = "Evergaol",
            Drops = ["Strong Evergaol Reward"],
            StatusTypes = [StatusType.Frostbite, StatusType.DeathBlight],
            WeakerVS = [DamageType.Strike, DamageType.Holy],
            StrongerVS = [DamageType.Pierce, DamageType.Lightning],
            WeakPoint = "Head",
        },
        new(
            49801020, "Death Rite Bird",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 49801020,
            damageBaselineName: "the field boss"
        ) {
            Location = "Castle Rooftop",
            Drops = ["Dormant Power"],
            StatusTypes = [StatusType.Frostbite, StatusType.DeathBlight],
            WeakerVS = [DamageType.Strike, DamageType.Holy],
            StrongerVS = [DamageType.Pierce, DamageType.Lightning],
            SPEffectIDs = [7791],
            WeakPoint = "Head",
        },
        new(
            35600010, "Godskin Apostle",
            damageBaseline: 35600020,
            damageBaselineName: "the solo evergaol boss"
        ) {
            Location = "Night Boss",
            Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/godskin-duo-evergaol-boss-elden-ring-nightreign-wiki-guide.jpg",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Augur", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Fire, DamageType.Holy],
            WeakerVS = [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
        },
        new(
            35700010, "Godskin Noble",
            damageBaseline: 35700020,
            damageBaselineName: "the solo evergaol boss"
        ) {
            Location = "Night Boss",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Augur", "Equilibrious Beast", "Fissure in the Fog", "Night Aspect"],
            FirstAppearance = Game.ER,
            Parriable = true,
            StrongerVS = [DamageType.Strike, DamageType.Fire, DamageType.Holy],
            WeakerVS = [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
        },
        new(
            35600110, "Godskin Apostle",
            damageBaseline: 35600020,
            damageBaselineName: "the solo evergaol boss"
        ) {
            Location = "Evergaol", // The Oldest Gaol
            Drops = ["Strong Evergaol Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Fire, DamageType.Holy],
            WeakerVS = [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
        },
        new(
            35700110, "Godskin Noble",
            damageBaseline: 35700020,
            damageBaselineName: "the solo evergaol boss"
        ) {
            Location = "Evergaol", // The Oldest Gaol
            Parriable = true,
            StrongerVS = [DamageType.Strike, DamageType.Fire, DamageType.Holy],
            WeakerVS = [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
        },
        new(
            49110010, "Great Wyrm",
            damageBaseline: 49100190,
            damageBaselineName: "the field boss"
        ) {
            Location = "Night Boss",
            Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/great-wyrm-night-boss-nightreign-wiki-guide.jpg",
            NightBossState = NightBossState.Day2,
            Expeditions = ["Sentient Pest", "Night Aspect"],
            FirstAppearance = Game.ER,
            Drops = ["Night 2 Boss Reward"],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Standard, DamageType.Strike, DamageType.Pierce],
        },
        new(25000030, "Crucible Knight") { // sword
            Location = "Evergaol",
            Drops = ["Strong Evergaol Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Magic, DamageType.Holy],
            WeakerVS = [DamageType.Fire, DamageType.Lightning],
        },
        new(25001020, "Crucible Knight") { // spear
            Location = "Evergaol",
            Drops = ["Strong Evergaol Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Magic, DamageType.Holy],
            WeakerVS = [DamageType.Fire, DamageType.Lightning],
        },
        new(
            25000040, "Crucible Knight", // sword
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 25000030,
            damageBaselineName: "the evergaol boss"
        ) {
            Location = "Castle",
            IsBoss = false,
            Parriable = true,
            StrongerVS = [DamageType.Magic, DamageType.Holy],
            WeakerVS = [DamageType.Fire, DamageType.Lightning],
        },
        new(
            25001030, "Crucible Knight", // spear
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 25001020,
            damageBaselineName: "the evergaol boss"
        ) {
            Location = "Castle",
            Drops = ["Dormant Power"],
            Parriable = true,
            StrongerVS = [DamageType.Magic, DamageType.Holy],
            WeakerVS = [DamageType.Fire, DamageType.Lightning],
        },
        new(35600020, "Godskin Apostle") {
            Location = "Evergaol",
            Drops = ["Strong Evergaol Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Fire, DamageType.Holy],
            WeakerVS = [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
        },
        new(35700020, "Godskin Noble") {
            Location = "Evergaol",
            Drops = ["Strong Evergaol Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Strike, DamageType.Fire, DamageType.Holy],
            WeakerVS = [DamageType.Slash, StatusType.BloodLoss, StatusType.Sleep],
        },
        new(46500210, "Dragonkin Soldier") {
            Location = "Evergaol",
            Drops = ["Strong Evergaol Reward"],
            StrongerVS = [DamageType.Lightning],
            WeakerVS = [DamageType.Slash],
        },
        new(
            46500230, "Dragonkin Soldier",
            damageBaseline: 46500210,
            damageBaselineName: "the evergaol boss"
        ) {
            Location = "Noklateo",
            Drops = ["Dormant Power"],
            StrongerVS = [DamageType.Lightning],
            WeakerVS = [DamageType.Slash],
        },
        new(
            30100190, "Banished Knight",
            damageBaseline: 30100270,
            damageBaselineName: "the Encampment boss"
        ) {
            Location = "Evergaol",
            Drops = ["Weak Evergaol Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Lightning],
        },
        new(30100270, "Banished Knight") {
            Location = "Encampment",
            Drops = ["Strong Standard Boss Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Lightning],
        },
        new(
            30100280, "Banished Knight (Red Eyes)",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 30100270,
            damageBaselineName: "the Encampment boss"
        ) {
            Location = "Castle",
            Drops = ["Castle Miniboss Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Lightning],
        },
        new(
            30100010, "Banished Knight",
            notInShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 30100270,
            damageBaselineName: "the Encampment boss"
        ) {
            Location = "Castle",
            IsBoss = false,
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Lightning],
        },
        new(
            33500010, "Crystalian",
            damageBaseline: 33500020,
            damageBaselineName: "the Fort boss"
        ) {
            Location = "Evergaol",
            Drops = ["Weak Evergaol Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Standard, DamageType.Strike],
        },
        new(33500020, "Crystalian") {
            Location = "Fort",
            Drops = ["Weak Affinity Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Standard, DamageType.Strike],
        },
        new(37020030, "Glintstone Sorcerer") {
            Location = "Fort",
            Backstabbable = true
        },
        new(39701120, "Beastmen of Farum Azula") {
            Location = "Ruins",
            Drops = ["Strong Affinity Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Lightning],
            WeakerVS = [DamageType.Fire],
        },
        new(
            39701110, "Beastmen of Farum Azula",
            damageBaseline: 39701120,
            damageBaselineName: "the Ruins boss"
        ) {
            Location = "Evergaol",
            Drops = ["Weak Evergaol Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Lightning],
            WeakerVS = [DamageType.Fire],
        },
        new(39703010, "Azula Beastman (Curved Sword)") {
            Location = "Evergaol",
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Lightning],
            WeakerVS = [DamageType.Fire],
        },
        new(39702310, "Azula Beastman (Shield)") {
            Location = "Evergaol",
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Lightning],
            WeakerVS = [DamageType.Fire],
        },
        new(34510040, "Scaly Misbegotten") {
            Location = "Evergaol",
            Drops = ["Weak Evergaol Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Fire],
        },
        new(34500040, "Misbegotten") {
            Location = "Evergaol",
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Fire],
        },
        new(34501040, "Misbegotten (Winged)") {
            Location = "Evergaol",
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Fire],
        },
        new(33000020, "Nox Warriors") { // Monk
            Location = "Evergaol",
            Image = "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nox-warriors-bosses-elden-ring-nightrein-wiki-guide.jpg",
            Drops = ["Weak Evergaol Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Holy],
        },
        new(33001020, "Nox Swordstress") {
            Location = "Evergaol",
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Holy],
        },
        new(36000020, "Stoneskin Lords") { // Alabaster
            Location = "Evergaol",
            Drops = ["Weak Evergaol Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Magic, DamageType.Fire, DamageType.Holy, DamageType.Lightning],
            WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
        },
        new(36001020, "Onyx Lord") {
            Location = "Evergaol",
            Parriable = true,
            StrongerVS = [DamageType.Magic, DamageType.Fire, DamageType.Holy, DamageType.Lightning],
            WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Pierce],
        },
        new(42900010, "Bloodhound Knight") {
            Location = "Evergaol",
            Drops = ["Weak Evergaol Reward"],
            Parriable = true,
            StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike],
            WeakerVS = [DamageType.Lightning],
        },
        new(34001010, "Grave Warden Duelist") {
            Location = "Evergaol",
            Drops = ["Weak Evergaol Reward"],
            Parriable = true,
            Backstabbable = true,
            WeakerVS = [DamageType.Slash, StatusType.BloodLoss],
        },
        new(21400210, "Omen") {
            Location = "Evergaol",
            Drops = ["Weak Evergaol Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Holy],
            WeakerVS = [DamageType.Slash],
        },
        new(50110010, "Golden Hippopotamus") {
            Location = "Field Boss",
            Drops = ["Weak Field Boss Reward"],
            WeakerVS = [DamageType.Fire, DamageType.Lightning],
        },
        new(44810020, "Miranda Sprout") {
            Location = "Field Boss",
            Critable = false,
        },
        new(36200010, "Oracle Envoy") {
            Location = "Great Church",
            Drops = ["Weak Affinity Reward"],
            Backstabbable = true,
            StrongerVS = [DamageType.Fire, DamageType.Lightning, DamageType.Holy],
            WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Pierce],
        },
        new(44700010, "Abductor Virgin") {
            Location = "Fort",
            Drops = ["Weak Standard Reward"],
            Critable = false,
            WeakerVS = [DamageType.Lightning],
            StrongerVS = [DamageType.Fire, DamageType.Holy],
            WeakPoint = "Interior",
        },
        new(37040020, "Battlemages") {
            Location = "Ruins",
            Drops = ["Dormant Power"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Pierce, DamageType.Holy],
        },
        new(34715310, "Albinaurics") {
            Location = "Ruins",
            Drops = ["Strong Affinity Reward"],
            Parriable = true,
            Backstabbable = true,
            WeakerVS = [DamageType.Holy],
            StrongerVS = [DamageType.Fire],
        },
        new(35500010, "Sanguine Noble") {
            Location = "Ruins",
            Drops = ["Strong Affinity Reward"],
            Parriable = true,
            Backstabbable = true,
            StatusTypes = [StatusType.BloodLoss],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Slash],
        },
        new(31800030, "Albinauric Archer's Wolf") {
            Location = "Ruins",
            Critable = false,
            WeakerVS = [DamageType.Fire],
        },
        new(
            31800020, "Albinauric Archer's Wolf",
            damageBaseline: 31800030,
            damageBaselineName: "the Ruins boss"
        ) {
            Location = "Mountaintop",
            Critable = false,
            WeakerVS = [DamageType.Fire],
        },
        new(37000010, "Depraved Perfumer") {
            Location = "Ruins",
            Drops = ["Strong Affinity Reward"],
            Backstabbable = true,
            StatusTypes = [StatusType.Poison],
            StrongerVS = [DamageType.Magic, DamageType.Fire, DamageType.Lightning, DamageType.Holy],
            WeakerVS = [DamageType.Standard, DamageType.Slash, DamageType.Pierce],
        },
        new(
            43541010, "Redmane Knights",
            damageBaseline: 43511120,
            damageBaselineName: "the Fort boss Lordsworn Captain"
        ) {
            Location = "Encampment",
            Drops = ["Strong Affinity Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Slash, DamageType.Fire],
            WeakerVS = [DamageType.Pierce, DamageType.Lightning],
        },
        new(44600010, "Flame Chariots") {
            Location = "Encampment",
            Drops = ["Strong Affinity Reward"],
            Backstabbable = true,
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Strike],
        },
        new(
            43530030, "Royal Army Knights",
            damageBaseline: 43511120,
            damageBaselineName: "the Fort boss Lordsworn Captain"
        ) {
            Location = "Encampment",
            Drops = ["Strong Affinity Reward"],
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Slash, DamageType.Lightning],
            WeakerVS = [DamageType.Pierce],
        },
        new(
            46004010, "Frenzied Flame Troll",
            damageBaseline: 46000110,
            damageBaselineName: "the Tunnel boss"
        ) {
            Location = "Encampment",
            Drops = ["Dormant Power"],
            WeakerVS = [DamageType.Slash],
        },
        new(
            39000030, "Fire Monk",
            damageBaseline: 39000020,
            damageBaselineName: "the Great Church boss"
        ) {
            Location = "Crater",
            IsBoss = false,
            Parriable = true,
            Backstabbable = true,
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Holy],
        },
        new(
            58100920, "Demi-Human Swordmaster",
            inShiftingEarth: [ShiftingEarth.Mountaintops],
            damageBaseline: 58100910,
            damageBaselineName: "the Night Boss"
        ) {
            Location = "Mountaintop",
            Drops = ["Mountaintops Reward"],
            Parriable = true,
            WeakerVS = [DamageType.Slash, DamageType.Fire],
        },
        new(
            45601020, "Giant Crows",
            inShiftingEarth: [ShiftingEarth.Mountaintops]
        ) {
            Location = "Mountaintop",
            Drops = ["Mountaintops Reward"],
            WeakerVS = [DamageType.Slash, DamageType.Fire],
            StrongerVS = [DamageType.Standard, DamageType.Strike, DamageType.Pierce],
        },
        new(
            45030010, "Mountaintop Ice Dragon",
            inShiftingEarth: [ShiftingEarth.Mountaintops],
            damageBaseline: 45000010,
            damageBaselineName: "the Flying Dragon field boss"
        ) {
            Location = "Mountaintop",
            Drops = ["Dormant Power"],
            WeakerVS = [DamageType.Strike],
            StrongerVS = [DamageType.Slash, DamageType.Pierce],
            WeakPoint = "Head",
        },
        new(
            46000230, "Headless Troll",
            inShiftingEarth: [ShiftingEarth.Noklateo],
            damageBaseline: 46000110,
            damageBaselineName: "the Tunnel boss"
        ) {
            Location = "Noklateo, the Shrouded City",
            Drops = ["Noklateo Reward"],
            WeakerVS = [DamageType.Slash],
        },
        new(
            46200010, "Naturalborn of the Void",
            inShiftingEarth: [ShiftingEarth.Noklateo]
        ) {
            Location = "Noklateo, the Shrouded City",
            Drops = ["Dormant Power"],
            StrongerVS = [DamageType.Magic, DamageType.Fire, DamageType.Lightning, DamageType.Holy],
            WeakerVS = [DamageType.Slash, DamageType.Strike, DamageType.Standard, DamageType.Pierce],
        },
        new(
            46600010, "Golem Horde",
            damageBaseline: 46600030,
            damageBaselineName: "the Great Church boss"
        ) {
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Drops = ["Favor of the Night"],
            StrongerVS = [DamageType.Fire, DamageType.Lightning, DamageType.Holy],
            WeakerVS = [DamageType.Strike],
        },
        new(42410010, "Colossal Fingercreeper") {
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Drops = ["Favor of the Night"],
            WeakerVS = [DamageType.Slash, DamageType.Fire],
            StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
        },
        new(42400030, "Large Fingercreeper") {
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            WeakerVS = [DamageType.Slash, DamageType.Fire],
            StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
        },
        new(42500030, "Small Fingercreeper") {
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            WeakerVS = [DamageType.Slash, DamageType.Fire],
            StrongerVS = [DamageType.Magic, DamageType.Lightning, DamageType.Holy],
        },

        /// NPCs
        new(600030010, "Night Assassin") {
            IsNPC = true,
            Drops = ["Condemned Nightfarer Drop"],
            Parriable = true,
            SPEffectSetIDs = [110980],
        },
        new(600030110, "Night Fallen") {
            IsNPC = true,
            Drops = ["Condemned Nightfarer Drop"],
            Parriable = true,
            WeakerVS = [DamageType.Fire, DamageType.Lightning],
            StrongerVS = [DamageType.Standard, DamageType.Strike, DamageType.Pierce],
            SPEffectSetIDs = [110980],
        },
        new(600030210, "Night Hunter") {
            IsNPC = true,
            Drops = ["Condemned Nightfarer Drop"],
            Parriable = true,
            WeakerVS = [DamageType.Slash, DamageType.Strike, DamageType.Pierce, DamageType.Fire],
            StrongerVS = [DamageType.Standard, DamageType.Magic, DamageType.Lightning],
            SPEffectSetIDs = [110980],
        },
        new(600030310, "Night Thief") {
            IsNPC = true,
            Drops = ["Condemned Nightfarer Drop"],
            Parriable = true,
            WeakerVS = [DamageType.Slash, DamageType.Strike, DamageType.Pierce],
            StrongerVS = [DamageType.Magic],
            SPEffectSetIDs = [110980],
        },
        new(600030410, "Night Raider") {
            IsNPC = true,
            Drops = ["Condemned Nightfarer Drop"],
            Parriable = true,
            WeakerVS = [DamageType.Pierce, DamageType.Magic, DamageType.Lightning],
            StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike, DamageType.Fire],
            SPEffectSetIDs = [110980],
        },
        new(600030610, "Night Witch") {
            IsNPC = true,
            Drops = ["Condemned Nightfarer Drop"],
            Parriable = true,
            WeakerVS = [DamageType.Slash, DamageType.Pierce],
            StrongerVS = [DamageType.Magic],
            SPEffectSetIDs = [110980],
        },
        new(600030710, "Night Executor") {
            IsNPC = true,
            Drops = ["Condemned Nightfarer Drop"],
            Parriable = true,
            WeakerVS = [DamageType.Magic, DamageType.Lightning],
            StrongerVS = [DamageType.Standard, DamageType.Slash, DamageType.Strike],
            SPEffectSetIDs = [110980],
        },

        new(
            75400100, "Maris, Fathom of Night (Everdark Sovereign, Phase 1)",
            damageBaseline: 75400020,
            damageBaselineName: "the standard version"
        ) {
            Nightlord = true,
            Expeditions = ["Augur Everdark Sovereign"],
            StatusTypes = [StatusType.Sleep],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Lightning],
        },
        new(
            75410000, "Maris, Fathom of Night (Everdark Sovereign, Phase 2)",
            damageBaseline: 75400020,
            damageBaselineName: "the standard version"
        ) {
            Nightlord = true,
            Expeditions = ["Augur Everdark Sovereign"],
            Drops = ["Relics", "Sovereign Sigils"],
            Critable = false,
        },
        new(
            75400010, "Augur", // Event Boss
            damageBaseline: 75400020,
            damageBaselineName: "Maris, Fathom of Night"
        ) {
            Location = "Event",
            Expeditions = ["Sentient Pest", "Fissure in the Fog", "Night Aspect"],
            Drops = ["Unifying Fate"],
            StrongerVS = [DamageType.Fire],
            WeakerVS = [DamageType.Lightning],
        },
        new(
            75200010, "Sentient Pest", // Event Boss
            damageBaseline: 75200020,
            damageBaselineName: "Gnoster, Wisdom of Night"
        ) {
            Location = "Event",
            Expeditions = ["Augur", "Equilibrious Beast", "Night Aspect"],
            Drops = ["Integration of Intelligence"],
            StatusTypes = [StatusType.Poison],
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Fire],
        },
        new(
            75600110, "Equilibrious Beast",
            damageBaseline: 75600020,
            damageBaselineName: "Libra, Creature of Night"
        ) {
            Location = "Event",
            Expeditions = ["Darkdrift Knight", "Fissure in the Fog", "Night Aspect"],
            Drops = ["Demon's Plating"],
            StatusTypes = [StatusType.Madness],
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Holy, StatusType.Madness],
        },
        new(
            46004080, "Frenzied Horde", // night horde
            damageBaseline: 46000110,
            damageBaselineName: "the Tunnel boss"
        ) {
            Location = "Event",
            Image = Image.Full4K("frenzied-horde-nightreign-full"),
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 2,
            Drops = ["Favor of the Night"],
            DamageTypes = [DamageType.Standard, DamageType.Strike, DamageType.Fire],
            StatusTypes = [StatusType.Madness],
            WeakerVS = [DamageType.Slash],
        },
        new(
            43530130, "Knight", // night horde
            damageBaseline: 43511120,
            damageBaselineName: "the Fort boss Lordsworn Captain"
        ) {
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Parriable = true,
            Backstabbable = true,
            DamageTypes = [DamageType.Standard, DamageType.Strike, DamageType.Fire],
            StatusTypes = [StatusType.Madness],
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Pierce],
        },
        new(43134030, "Soldier") { // night horde
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 4,
            Parriable = true,
            Backstabbable = true,
            StatusTypes = [StatusType.Madness],
            StrongerVS = [DamageType.Holy],
            WeakerVS = [DamageType.Pierce],
        },
        new(43738030, "Foot Soldier") { // night horde
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 7,
            Parriable = true,
            Backstabbable = true,
            StatusTypes = [StatusType.Madness],
        },
        new(
            45600030, "Giant Crow", // night horde
            damageBaseline: 45601020,
            damageBaselineName: "the Mountaintop boss Giant Crows"
        ) {
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 2,
            Drops = ["Favor of the Night"],
        },
        new(45500030, "Giant Dog") { // night horde
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 5,
        },
        new(42810010, "Shield-Headed Ant") { // night horde
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 2,
            Drops = ["Favor of the Night"],
            StrongerVS = [DamageType.Standard, DamageType.Strike, DamageType.Slash, DamageType.Pierce],
            WeakerVS = [DamageType.Lightning],
        },
        new(42800520, "Winged Ant") { // night horde
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 4,
            StrongerVS = [DamageType.Slash],
            WeakerVS = [DamageType.Fire],
        },
        new(42800020, "Worker Ant") { // night horde
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 6,
        },
        new(
            45050010, "Dragon Horde",
            damageBaseline: 45000010,
            damageBaselineName: "the Flying Dragon of the Hills field boss"
        ) {
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 2,
            Drops = ["Favor of the Night"],
            WeakerVS = [DamageType.Pierce],
        },
        new(40001020, "Wraith Horde") {
            Location = "Event",
            Expeditions = ["Tricephalos", "Augur", "Darkdrift Knight"],
            Count = 9,
            Drops = ["Favor of the Night"],
            StrongerVS = [DamageType.Holy],
            WeakerVS = [DamageType.Slash],
        },
        new(
            75610010, "Libra, Creature of Night",
            damageBaseline: 75600020,
            damageBaselineName: "the standard version"
        ) {
            Location = "Everdark Sovereign",
            Image = Image.Full4K("libra-3-nightreign"),
            Nightlord = true,
            Expeditions = ["Equilibrious Beast Everdark Sovereign"],
            Drops = ["Relics", "Sovereign Sigils"],
            StatusTypes = [StatusType.Madness],
            StrongerVS = [DamageType.Magic],
            WeakerVS = [DamageType.Holy, StatusType.Poison, StatusType.ScarletRot, StatusType.Madness],
        },
    ];
}
