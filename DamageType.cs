public class DamageType : IconLink
{
    public static readonly DamageType Physical = new(
        0,
        "Physical",
        "/file/Elden-Ring/standard_upgrade_affinity_elden_ring_wiki_guide_60px.jpg",
        "/Physical+Damage"
    );

    public static readonly DamageType Standard = new(
        1,
        "Standard",
        "/file/Elden-Ring/standard-damage-57px.png",
        "/Standard+Damage"
    );

    public static readonly DamageType Slash = new(
        2,
        "Slash",
        "/file/Elden-Ring/slash-damage-57px-hookclaw.png",
        "/Slash+Damage"
    );

    public static readonly DamageType Strike = new(
        3,
        "Strike",
        "/file/Elden-Ring/strike-damage-57px.png",
        "/Strike+Damage"
    );

    public static readonly DamageType Pierce = new(
        4,
        "Pierce",
        "/file/Elden-Ring/pierce-damage-57px.png",
        "/Pierce+Damage"
    );

    public static readonly DamageType Magic = new(
        5,
        "Magic",
        "/file/Elden-Ring/magic_upgrade_affinity_elden_ring_wiki_guide_60px.jpg",
        "/Magic+Damage",
        color: "#3fbddd"
    );

    public static readonly DamageType Fire = new(
        6,
        "Fire",
        "/file/Elden-Ring/fire_upgrade_affinity_elden_ring_wiki_guide_60px.jpg",
        "/Fire+Damage",
        color: "#cc9d57"
    );

    public static readonly DamageType Lightning = new(
        7,
        "Lightning",
        "/file/Elden-Ring/lightning_upgrade_affinity_elden_ring_wiki_guide_60px.jpg",
        "/Lightning+Damage",
        color: "#d5d559"
    );

    public static readonly DamageType Holy = new(
        8,
        "Holy",
        "/file/Elden-Ring/holy_upgrade_affinity_elden_ring_wiki_guide_60px.jpg",
        "/Holy+Damage",
        color: "#ffcc99"
    );

    private DamageType(int order, string name, string src, string href, string? color = null)
        : base(order, name, src, href, color) {}

    public override string ToString()
    {
        return Name;
    }
}
