using DotNext.Collections.Generic;

public partial class Boss
{
    public Boss(
        int id,
        string name,
        string location,
        IEnumerable<int>? additionalPhases = null,
        bool boss = true,
        bool npc = false,
        int? gameAreaID = null,
        int? charaInitID = null,
        string? closestGrace = null,
        bool optional = true,
        bool multiplayerAllowed = true,
        bool summonsAllowed = true,
        bool parriable = false,
        bool backstabbable = false,
        int parriesPerCrit = 1,
        bool critable = true,
        IEnumerable<DamageType>? damageTypes = null,
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
        IsNPC = npc;
        Optional = optional;
        MultiplayerAllowed = multiplayerAllowed;
        SummonsAllowed = summonsAllowed;
        GameAreaID = gameAreaID;
        CharaInitID = charaInitID;
        if (damageTypes != null) DamageTypes.AddAll(damageTypes);
        if (statusTypes != null) StatusTypes.AddAll(statusTypes);
        WeakPoint = weakPoint;
        if (drops != null) Drops.AddAll(drops);
        Backstabbable = backstabbable || npc;
        Parriable = parriable;
        ParriesPerCrit = parriesPerCrit;
        Critable = critable && (!npc || parriable);
        if (summonableNPCs != null) SummonableNPCs.AddAll(summonableNPCs);

        if (additionalPhases != null)
        {
            foreach (var phaseID in additionalPhases)
            { 
                AdditionalPhases.Add(new Boss(phaseID, name, location));
            }
        }
    }

    public int ID { get; init; }
    public List<Boss> AdditionalPhases { get; } = [];
    public string Name { get; init; }
    public string Location { get; init; }
    public string ClosestGrace { get; init; }
    public bool IsBoss { get; }
    public bool IsNPC { get; }
    public bool Optional { get; init; }
    public bool MultiplayerAllowed { get; init; }
    public bool SummonsAllowed { get; init; }
    public int? GameAreaID { get; init; }
    public int? CharaInitID { get; init; }
    public int Stance { get; set; }
    public bool Parriable { get; init; }
    public bool Backstabbable { get; init; }
    public int ParriesPerCrit{ get; init; }
    public bool Critable { get; init; }
    public SortedSet<DamageType> DamageTypes { get; } = [];
    public SortedSet<StatusType> StatusTypes { get; } = [];
    public SortedDictionary<DamageType, int> Negations { get; } = [];
    public List<List<int>> HP { get; } = [];
    public List<int> Defense { get; } = [];
    public List<int> Runes { get; } = [];
    public List<string> Drops { get; } = [];
    public SortedDictionary<StatusType, List<List<int>>?> Resistance { get; } = [];
    public SortedSet<WeaknessType> Weaknesses { get; } = [];
    public string? WeakPoint { get; }
    public int? WeakPointExtraDamage { get; set; }
    public List<string> SummonableNPCs { get; } = [];
    public List<(DamageType, int)> TypeNegationPairs
    {
        get { return Negations.Select((pair) => (pair.Key, pair.Value)).ToList(); }
    }

    // NPC-exclusive stuff
    public List<ArmorPiece> Armor { get; set; } = [];
    public List<ArmorPiece> NamedArmor
    {
        get { return Armor.Where((armor) => armor.Name != null).ToList(); }
    }
    public List<Weapon> RightHand { get; } = [];
    public List<Weapon> LeftHand { get; } = [];
    public List<string> Spells { get; } = [];
    public int? FlaskCharges { get; set;  }
    public Dictionary<DamageType, List<int>> TypeDefense { get; } = [];
    public List<(DamageType, List<int>)> TypeDefensePairs
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