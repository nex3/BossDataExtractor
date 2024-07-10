public class DamageType : IconLink, IComparable<DamageType>
{
    public static readonly DamageType Physical = new DamageType(
        "Physical",
        "/file/Elden-Ring/standard_upgrade_affinity_elden_ring_wiki_guide_60px.jpg",
        "/Physical+Damage",
        0
    );

    public static readonly DamageType Standard = new DamageType(
        "Standard", "/file/Elden-Ring/standard-damage-57px.png", "/Standard+Damage", 1
    );

    public static readonly DamageType Slash = new DamageType(
        "Slash", "/file/Elden-Ring/slash-damage-57px-hookclaw.png", "/Slash+Damage", 2
    );

    public static readonly DamageType Strike = new DamageType(
        "Strike", "/file/Elden-Ring/strike-damage-57px.png", "/Strike+Damage", 3
    );

    public static readonly DamageType Pierce = new DamageType(
        "Pierce", "/file/Elden-Ring/pierce-damage-57px.png", "/Pierce+Damage", 4
    );

    public static readonly DamageType Magic = new DamageType(
        "Magic", "/file/Elden-Ring/magic_upgrade_affinity_elden_ring_wiki_guide_60px.jpg", "/Magic+Damage", 5,
        color: "#3fbddd"
    );

    public static readonly DamageType Fire = new DamageType(
        "Fire", "/file/Elden-Ring/fire_upgrade_affinity_elden_ring_wiki_guide_60px.jpg", "/Fire+Damage", 6,
        color: "#cc9d57"
    );

    public static readonly DamageType Lightning = new DamageType(
        "Lightning",
        "/file/Elden-Ring/lightning_upgrade_affinity_elden_ring_wiki_guide_60px.jpg",
        "/Lightning+Damage",
        7,
        color: "#d5d559"
    );

    public static readonly DamageType Holy = new DamageType(
        "Holy",
        "/file/Elden-Ring/holy_upgrade_affinity_elden_ring_wiki_guide_60px.jpg",
        "/Holy+Damage",
        8,
        color: "#ffcc99"
    );

    private readonly int order;

    private DamageType(string name, string src, string href, int order, string? color = null) : base(name, src, href, color)
    {
        this.order = order;
    }

    public int CompareTo(DamageType? other)
    {
        return order.CompareTo(other?.order ?? -1);
    }

    public override string ToString()
    {
        return Name;
    }
}
