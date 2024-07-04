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
            statusTypes: [StatusType.Frostbite]
        ),
        // Note: humanoid boss, unclear how to handle it. Madness resist is definitely wrong, other
        // stuff might be as well.
        new Boss(
            524070081, "Ancient Dragon-Man",
            gameAreaID: 43010800,
            location: "Dragon's Pit",
            parriable: true
        )
    ];

    public Boss(
        int id,
        string name,
        int gameAreaID,
        string location,
        string? closestGrace = null,
        bool optional = true,
        bool multiplayerAllowed = true,
        bool summonsAllowed = true,
        bool parriable = false,
        int parriesPerCrit = 1,
        bool critable = true,
        IEnumerable<StatusType>? statusTypes = null
    ) {
        ID = id;
        Name = name;
        Location = location;
        ClosestGrace = closestGrace ?? location;
        Optional = optional;
        MultiplayerAllowed = multiplayerAllowed;
        SummonsAllowed = summonsAllowed;
        GameAreaID = gameAreaID;
        DamageTypes = [];
        StatusTypes = [];
        if (statusTypes != null) StatusTypes.AddAll(statusTypes);
        TypeDefense = [];
        HP = [];
        Defense = [];
        Runes = [];
        Resistance = [];
        Parriable = parriable;
        ParriesPerCrit = parriesPerCrit;
        Critable = critable;
    }

    public int ID { get; init; }
    public string Name { get; init; }
    public string Location { get; init; }
    public string ClosestGrace { get; init; }
    public bool Optional { get; init; }
    public bool MultiplayerAllowed { get; init; }
    public bool SummonsAllowed { get; init; }
    public int GameAreaID { get; init; }
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
    public SortedDictionary<StatusType, List<List<int>>?> Resistance { get; }
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