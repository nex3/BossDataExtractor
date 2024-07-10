﻿using System;

public partial class Boss
{
    public static readonly List<Boss> KnownBosses = [
        new Boss(
            47601050, "Fire Giant",
            gameAreaID: 1052520800,
            location: "Mountaintops of the Giants",
            optional: false
        ),

        /// NPCs
        new Boss(
            523090010, "Patches",
            gameAreaID: 31000800,
            location: "Murkwater Cave",
            npc: true,
            parriable: true
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
            52201089, "Promised Consort Radahn",
            gameAreaID: 20010800,
            optional: false,
            location: "Enir-Ilim",
            closestGrace: "Divine Gate Front Staircase",
            parriable: true,
            parriesPerCrit: 3
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
            weakPoint: "Head",
            drops: ["Dragon Heart", "Dragonscale Flesh"]
        ),
        new Boss(
            55800985, "Jagged Peak Drake", // Duo
            gameAreaID: 2052400800,
            location: "Jagged Peak",
            closestGrace: "Foot of the Jagged Peak",
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
        // Note: humanoid boss, unclear how to handle it. Madness resist is definitely wrong, other
        // stuff might be as well.
        new Boss(
            524070081, "Ancient Dragon-Man",
            gameAreaID: 43010800,
            location: "Dragon's Pit",
            npc: true,
            parriable: true,
            drops: ["Dragon-Hunter's Great Katana"]
        ),
        new Boss(
            524170289, "Redmane Freyja",
            location: "Enir-Ilim",
            npc: true,
            parriable: true,
            drops: [
                "Freyja's Greatsword", "Freyja's Helm", "Freyja's Armor", "Freyja's Gauntlets",
                "Freyja's Greaves"
            ]
        )
    ];
}