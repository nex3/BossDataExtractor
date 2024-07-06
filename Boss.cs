using DotNext.Collections.Generic;

public class Boss
{
    public static readonly List<Boss> KnownBosses = [
        new Boss(
            47601050, "Fire Giant",
            gameAreaID: 1052520800,
            location: "Mountaintops of the Giants",
            optional: false
        ),
        new Boss(
            58100980, "Demi-Human Swordmaster Onze",
            gameAreaID: 41000800,
            location: "Belurat Gaol",
            parriable: true,
            statusTypes: [StatusType.Frostbite],
            drops: ["Demi-Human Swordsman Yosh"]
        ),
        // Note: humanoid boss, unclear how to handle it. Madness resist is definitely wrong, other
        // stuff might be as well.
        new Boss(
            524070081, "Ancient Dragon-Man",
            gameAreaID: 43010800,
            location: "Dragon's Pit",
            parriable: true,
            drops: ["Dragon-Hunter's Great Katana"]
        ),
        new Boss(
            52100088, "Divine Beast Dancing Lion",
            gameAreaID: 20000800,
            location: "Belurat, Tower Settlement",
            optional: false,
            statusTypes: [StatusType.Frostbite],
            summonableNPCs: ["Redmane Freyja"]
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
    ];

    public Boss(
        int id,
        string name,
        string location,
        bool boss = true,
        int? gameAreaID = null,
        string? closestGrace = null,
        bool optional = true,
        bool multiplayerAllowed = true,
        bool summonsAllowed = true,
        bool parriable = false,
        int parriesPerCrit = 1,
        bool critable = true,
        IEnumerable<StatusType>? statusTypes = null,
        IEnumerable<string>? drops = null,
        string? weakPoint = null,
        IEnumerable<string>? summonableNPCs = null
    ) {
        ID = id;
        Name = name;
        Location = location;
        ClosestGrace = closestGrace ?? location;
        IsBoss = boss;
        Optional = optional;
        MultiplayerAllowed = multiplayerAllowed;
        SummonsAllowed = summonsAllowed;
        GameAreaID = gameAreaID;
        DamageTypes = [];
        StatusTypes = [];
        if (statusTypes != null) StatusTypes.AddAll(statusTypes);
        TypeDefense = [];
        Weaknesses = [];
        WeakPoint = weakPoint;
        HP = [];
        Defense = [];
        Runes = [];
        Drops = [];
        if (drops != null) Drops.AddAll(drops);
        Resistance = [];
        Parriable = parriable;
        ParriesPerCrit = parriesPerCrit;
        Critable = critable;
        SummonableNPCs = [];
        if (summonableNPCs != null) SummonableNPCs.AddAll(summonableNPCs);
    }

    public int ID { get; init; }
    public string Name { get; init; }
    public string Location { get; init; }
    public string ClosestGrace { get; init; }
    public bool IsBoss { get; }
    public bool Optional { get; init; }
    public bool MultiplayerAllowed { get; init; }
    public bool SummonsAllowed { get; init; }
    public int? GameAreaID { get; init; }
    public int Stance { get; set; }
    public bool Parriable { get; init; }
    public int ParriesPerCrit{ get; init; }
    public bool Critable { get; init; }
    public SortedSet<DamageType> DamageTypes { get; }
    public SortedSet<StatusType> StatusTypes { get; }
    public SortedDictionary<DamageType, int> TypeDefense { get; }
    public List<int> HP { get; }
    public List<int> Defense { get; }
    public List<int> Runes { get; }
    public List<string> Drops { get; }
    public SortedDictionary<StatusType, List<List<int>>?> Resistance { get; }
    public SortedSet<WeaknessType> Weaknesses { get; }
    public string? WeakPoint { get; }
    public int? WeakPointExtraDamage { get; set; }
    public List<string> SummonableNPCs { get; }
    public List<(DamageType, int)> TypeDefensePairs
    {
        get { return TypeDefense.Select((pair) => (pair.Key, pair.Value)).ToList(); }
    }

    public List<(StatusType, List<List<int>>?)> ResistancePairs
    {
        get {
            return Resistance.Select<KeyValuePair<StatusType, List<List<int>>?>, (StatusType, List<List<int>>?)>((pair) =>
            {
                var ngs = pair.Value?.ToList();
                if (ngs == null) return (pair.Key, null);
                return (pair.Key, ngs.Select((procs) =>
                {
                    procs = procs.ToList();
                    while (procs.Count > 1 && procs.Last() == procs[procs.Count - 2])
                    {
                        procs.RemoveAt(procs.Count - 1);
                    }
                    return procs;
                }).ToList());
            }).ToList();
        }
    }

    public bool HasMultipleResistanceProcs
    {
        get {
            return Resistance.Values.Any((ngs) => ngs?.Any((procs) => procs.Count > 1) ?? false);
        }
    }
    public bool HasNewGameResistances
    {
        get { return Resistance.Values.Any((ngs) => (ngs?.Count ?? 0) > 1); }
    }

    public override string ToString()
    {
        return $"Boss: {Name}";
    }
}