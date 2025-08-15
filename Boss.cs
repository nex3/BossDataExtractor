using DotNext.Collections.Generic;
using System.Xaml.Schema;

public partial class Boss
{
    public Boss(
        int id,
        string name,
        bool multiplayerAllowed = true,
        bool summonsAllowed = true,
        IEnumerable<string>? summonableNPCs = null,
        int? damageBaseline = null,
        string? damageBaselineName = null,

        // Nightreign-specific attributes
        IEnumerable<ShiftingEarth>? inShiftingEarth = null,
        IEnumerable<ShiftingEarth>? notInShiftingEarth = null
    ) {
        ID = id;
        Name = name;
        MultiplayerAllowed = multiplayerAllowed;
        SummonsAllowed = summonsAllowed;
        if (inShiftingEarth != null) InShiftingEarth.AddAll(inShiftingEarth);
        if (notInShiftingEarth != null) NotInShiftingEarth.AddAll(notInShiftingEarth);
        if (summonableNPCs != null) SummonableNPCs.AddAll(summonableNPCs);
        if (damageBaseline is { } baselineId)
        {
            DamageBaselineBoss = new Boss(baselineId, name);
            if (damageBaselineName is null)
            {
                throw new ArgumentException(
                    "damageBaseline must be passed with damageBaselineName"
                );
            }
            DamageBaselineName = damageBaselineName;
        }
    }

    public int ID { get; init; }
    public int Count { get; init; } = 1;
    public List<int> AdditionalPhaseIDs {
        init
        {
            field = value;
            _additionalPhases = [..
                value.Select((phaseID) => new Boss(phaseID, Name) { Location = Location })
            ];
        }
    } = [];
    public List<Boss> AdditionalPhases => _additionalPhases;
    private readonly List<Boss> _additionalPhases = [];
    public string Name { get; init; }
    public string? Location { get; init; }

    public string? LocationForLink
    {
        get
        {
            if (Location == "Field Boss") return null;
            if (Location == "Night Boss") return null;
            if (Location == "Night Boss Entourage") return null;
            if (Location == "Castle Basement") return "Castle";
            if (Location == "Encampment") return "Main Encampment";
            return Location;
        }
    }

    public IconLink? LocationIcon
    {
        get
        {
            return Location switch
            {
                "Crater" => ShiftingEarth.Crater,
                "Mountaintop" => ShiftingEarth.Mountaintops,
                "Rotted Woods" => ShiftingEarth.Woods,
                "Noklateo" => ShiftingEarth.Noklateo,
                _ => Affinity,
            };
        }
    }

    public IconLink? Affinity { get; init; }

    public string? ClosestGrace { get => field ?? Location; init; }
    public bool IsBoss { get; init; } = true;
    public bool IsNPC { get; init; } = false;
    public bool Optional { get; init; } = true;
    public bool MultiplayerAllowed { get; init; }
    public bool SummonsAllowed { get; init; }
    public int? GameAreaID { get; init; }
    public int? CharaInitID { get; init; }
    public SortedSet<int> SPEffectSetIDs { get; init; } = [];
    public SortedSet<int> SPEffectIDs { get; init; } = [];
    public float? Day2HPMult { get; set; }
    public float? Day2DamageMult { get; set; }

    public bool ShowDay2 =>
        (Day2HPMult != null || Day2DamageMult != null) &&
        !Nightlord &&
        NightBossState == NightBossState.No &&
        Location != "Night Boss Entourage";

    public int? CataclysmSpEffectID { get; set; }
    public float? CataclysmHPMult { get; set; }
    public float? CataclysmDamageMult { get; set; }

    public int Stance { get; set; }
    public bool Parriable { get; init; }
    public bool? Backstabbable {
        get => field ?? IsNPC;
        init;
    }
    public int ParriesPerCrit{ get; init; }
    public bool? Critable {
        get => field ?? (!IsNPC || Parriable);
        init;
    }
    public SortedSet<DamageType> DamageTypes { get; init; } = [];
    public SortedSet<StatusType> StatusTypes { get; init; } = [];
    public SortedSet<IconLink> StrongerVS { get; init; } = [];
    public SortedSet<IconLink> WeakerVS { get; init; } = [];
    public SortedDictionary<DamageType, int> Negations { get; } = [];
    public SortedSet<ShiftingEarth> InShiftingEarth { get; } = [];
    public SortedSet<ShiftingEarth> NotInShiftingEarth { get; } = [];
    public List<List<int>> HP { get; } = [];
    public List<List<int>> DlcPlusHP { get; } = [];
    public List<int> Defense { get; } = [];
    public List<int> Runes { get; } = [];
    // Solo/Duo Nightreign runs get 12x/10.4x base runes from an SpEffect that's applied probably in event code
    public int SoloRunes => Runes[0] * 12;

    public int DuoRunes => (int)Math.Round(Runes[0] * 10.4);
    // Trio Nightreign runs get 8x base runes because everyone is wearing pants with a rune buff
    public int TrioRunes => Runes[0] * 8;
    public int TotalSoloRunes => SoloRunes * Count;
    public int TotalDuoRunes => DuoRunes * Count;
    public int TotalTrioRunes => TrioRunes * Count;
    public List<string> Drops { get; init; } = [];
    public SortedDictionary<StatusType, List<List<int>>?> Resistance { get; } = [];
    public SortedSet<WeaknessType> Weaknesses { get; } = [];
    public string? WeakPoint { get; init; }
    public int? WeakPointExtraDamage { get; set; }
    public List<string> SummonableNPCs { get; } = [];
    public (float, float) MultiplayerHPScaling { get; set; } = (1, 1);
    public bool Nightlord { get; init; }
    public NightBossState NightBossState { get; init; } = NightBossState.No;
    public bool IsNightBoss => NightBossState != NightBossState.No;
    public int? NightBossDayNumber => NightBossState switch
    {
        NightBossState.Day1 => 1,
        NightBossState.Day2 => 2,
        _ => null
    };
    public bool Formidable { get; init; } = false;
    public Image Image { get; init; } = Image.None();
    public string ImageHtml => Image.ToHtml(this);
    public Image? TopLevelImage { get; init; }
    public string? TopLevelImageHtml => TopLevelImage?.ToHtml(this);
    public List<string> Expeditions { get; init; } = [];
    public Game? FirstAppearance { get; init; }
    public double DamageMultiplier { get; set; } = 1.0;
    public double? DamageBaseline { get; set; }
    public double RelativeDamage =>
        DamageBaseline is { } baseline ? (DamageMultiplier / baseline) : 1.0;
    public Boss? DamageBaselineBoss { get; init; }
    public string? DamageBaselineName { get; init; }
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