using DotNext.Collections.Generic;

public partial class Boss
{
    public Boss(
        int id,
        string name,
        string? location = null,
        string? imageUrl = null,
        IEnumerable<int>? additionalPhases = null,
        bool boss = true,
        bool npc = false,
        int? gameAreaID = null,
        int? charaInitID = null,
        IEnumerable<int>? spEffectSetIDs = null,
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
        IEnumerable<IconLink>? strongerVS = null,
        IEnumerable<IconLink>? weakerVS = null,
        IEnumerable<string>? drops = null,
        string? weakPoint = null,
        IEnumerable<string>? summonableNPCs = null,

        // Nightreign-specific attributes
        bool nightlord = false,
        bool everdarkSovereign = false,
        NightBossState nightBoss = NightBossState.No,
        IEnumerable<string>? expeditions = null,
        Game? firstAppearance = null
    ) {
        ID = id;
        Name = name;
        Location = location;
        ImageUrl = imageUrl;
        ClosestGrace = closestGrace ?? location;
        IsBoss = boss;
        IsNPC = npc;
        Optional = optional;
        MultiplayerAllowed = multiplayerAllowed;
        SummonsAllowed = summonsAllowed;
        GameAreaID = gameAreaID;
        CharaInitID = charaInitID;
        if (spEffectSetIDs != null) SPEffectSetIDs.AddAll(spEffectSetIDs);
        if (damageTypes != null) DamageTypes.AddAll(damageTypes);
        if (statusTypes != null) StatusTypes.AddAll(statusTypes);
        if (strongerVS != null) StrongerVS.AddAll(strongerVS);
        if (weakerVS != null) WeakerVS.AddAll(weakerVS);
        WeakPoint = weakPoint;
        if (drops != null) Drops.AddAll(drops);
        Backstabbable = backstabbable || npc;
        Parriable = parriable;
        ParriesPerCrit = parriesPerCrit;
        Critable = critable && (!npc || parriable);
        if (summonableNPCs != null) SummonableNPCs.AddAll(summonableNPCs);
        Nightlord = nightlord;
        if (expeditions != null) Expeditions.AddAll(expeditions);
        if (firstAppearance != null) FirstAppearance = firstAppearance;

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
    public string? Location { get; init; }
    public string? ClosestGrace { get; init; }
    public bool IsBoss { get; }
    public bool IsNPC { get; }
    public bool Optional { get; init; }
    public bool MultiplayerAllowed { get; init; }
    public bool SummonsAllowed { get; init; }
    public int? GameAreaID { get; init; }
    public int? CharaInitID { get; init; }
    public SortedSet<int> SPEffectSetIDs { get; } = [];
    public int Stance { get; set; }
    public bool Parriable { get; init; }
    public bool Backstabbable { get; init; }
    public int ParriesPerCrit{ get; init; }
    public bool Critable { get; init; }
    public SortedSet<DamageType> DamageTypes { get; } = [];
    public SortedSet<StatusType> StatusTypes { get; } = [];
    public SortedSet<IconLink> StrongerVS { get; } = [];
    public SortedSet<IconLink> WeakerVS { get; } = [];
    public SortedDictionary<DamageType, int> Negations { get; } = [];
    public List<List<int>> HP { get; } = [];
    public List<List<int>> DlcPlusHP { get; } = [];
    public List<int> Defense { get; } = [];
    public List<int> Runes { get; } = [];
    // Solo Nightreign runs get 12x base runes for unclear reasons
    public int SoloRunes => Runes[0] * 12;
    // Trio Nightreign runs get 8x base runes because everyone is wearing pants with a rune buff
    public int TrioRunes => Runes[0] * 8;
    public List<string> Drops { get; } = [];
    public SortedDictionary<StatusType, List<List<int>>?> Resistance { get; } = [];
    public SortedSet<WeaknessType> Weaknesses { get; } = [];
    public string? WeakPoint { get; }
    public int? WeakPointExtraDamage { get; set; }
    public List<string> SummonableNPCs { get; } = [];
    public (float, float) MultiplayerHPScaling { get; set; } = (1, 1);
    public bool Nightlord { get; init; }
    public NightBossState NightBossState { get; init; }
    public bool IsNightBoss => NightBossState != NightBossState.No;
    public int? NightBossDayNumber => NightBossState switch
    {
        NightBossState.Day1 => 1,
        NightBossState.Day2 => 2,
        _ => null
    };
    public string? ImageUrl { get; init; }
    public List<string> Expeditions { get; } = [];
    public Game? FirstAppearance { get; init; }
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

    public List<List<int>> DuoHP
    {
        get
        {
            var (scaling, _) = MultiplayerHPScaling;
            return HPWithScaling(scaling);
        }
    }
    public List<List<int>> TrioHP
    {
        get
        {
            var (_, scaling) = MultiplayerHPScaling;
            return HPWithScaling(scaling);
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

    private List<List<int>> HPWithScaling(float scaling)
    {
        return [..(
            from hps in HP
            select (from hp in hps select (int)Math.Round(hp * scaling)).ToList()
        )];
    }

    public override string ToString()
    {
        return $"Boss: {Name}";
    }
}