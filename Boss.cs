using DotNext.Collections.Generic;

public class Boss
{
    public static readonly List<Boss> KnownBosses = [
        new Boss(
            58100980, "Demi-Human Swordmaster Onze",
            gameAreaID: 41000800,
            location: "Belurat Gaol",
            parriable: true
        )
    ];

    public Boss(
        int id,
        string name,
        int gameAreaID,
        string? location = null,
        bool parriable = false,
        int parriesPerCrit = 1,
        bool critable = true,
        IEnumerable<StatusType>? statusTypes = null
    ) {
        ID = id;
        Name = name;
        Location = location;
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
    public string? Location { get; init; }
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