public class StatusType : IconLink, IComparable<StatusType>
{
    public static readonly StatusType Poison = new StatusType(
        "Poison",
        "/file/Elden-Ring/poison_status_effect_elden_ring_wiki_guide_25px.png",
        "/Poison",
        1
    );

    public static readonly StatusType ScarletRot = new StatusType(
        "Scarlet Rot",
        "/file/Elden-Ring/scarlet_rot_status_effect_elden_ring_wiki_guide_25px.png",
        "/Scarlet+Rot",
        2
    );

    public static readonly StatusType Hemorrhage = new StatusType(
        "Hemorrhage",
        "/file/Elden-Ring/hemorrhage_status_effect_elden_ring_wiki_guide_25px.png",
        "/Hemorrhage",
        3
    );

    public static readonly StatusType Frostbite = new StatusType(
        "Frostbite",
        "/file/Elden-Ring/frostbite_status_effect_elden_ring_wiki_guide_25px.png",
        "/Frostbite",
        4
    );

    public static readonly StatusType Sleep = new StatusType(
        "Sleep",
        "/file/Elden-Ring/sleep_status_effect_elden_ring_wiki_guide_25px.png",
        "/Sleep",
        5
    );

    public static readonly StatusType Madness = new StatusType(
        "Madness",
        "/file/Elden-Ring/madness_status_effect_elden_ring_wiki_guide_25px.png",
        "/Madness",
        6
    );

    public static readonly StatusType DeathBlight = new StatusType(
        "Death Blight",
        "/file/Elden-Ring/blight_status_effect_elden_ring_wiki_guide_25px.png",
        "/Death+Blight",
        7
    );

    private readonly int order;

    private StatusType(string name, string src, string href, int order, string? color = null) : base(name, src, href, color)
    {
        this.order = order;
    }

    public int CompareTo(StatusType? other)
    {
        return order.CompareTo(other?.order ?? -1);
    }

    public override string ToString()
    {
        return Name;
    }
}
