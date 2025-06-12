public class StatusType : IconLink
{
    public static readonly StatusType Poison = new(
        100,
        "Poison",
        "/file/Elden-Ring/poison_status_effect_elden_ring_wiki_guide_25px.png",
        "/Poison"
    );

    public static readonly StatusType ScarletRot = new(
        101,
        "Scarlet Rot",
        "/file/Elden-Ring/scarlet_rot_status_effect_elden_ring_wiki_guide_25px.png",
        "/Scarlet+Rot"
    );

    public static readonly StatusType Hemorrhage = new(
        102,
        "Hemorrhage",
        "/file/Elden-Ring/hemorrhage_status_effect_elden_ring_wiki_guide_25px.png",
        "/Hemorrhage"
    );

    public static readonly StatusType BloodLoss = new(
        102,
        "Blood Loss",
        "/file/Elden-Ring-Nightreign/hemorrhage-status-effect-elden-ring-nightreign-wiki-guide-100px.png",
        "/Blood+Loss"
    );

    public static readonly StatusType Frostbite = new(
        103,
        "Frostbite",
        "/file/Elden-Ring/frostbite_status_effect_elden_ring_wiki_guide_25px.png",
        "/Frostbite"
    );

    public static readonly StatusType Sleep = new(
        104,
        "Sleep",
        "/file/Elden-Ring/sleep_status_effect_elden_ring_wiki_guide_25px.png",
        "/Sleep"
    );

    public static readonly StatusType Madness = new(
        105,
        "Madness",
        "/file/Elden-Ring/madness_status_effect_elden_ring_wiki_guide_25px.png",
        "/Madness"
    );

    public static readonly StatusType DeathBlight = new StatusType(
        106,
        "Death Blight",
        "/file/Elden-Ring/blight_status_effect_elden_ring_wiki_guide_25px.png",
        "/Death+Blight"
    );

    private readonly int order;

    private StatusType(int order, string name, string src, string href, string? color = null)
        : base(order, name, src, href, color) {}

    public override string ToString()
    {
        return Name;
    }
}
