public class WeaknessType : IconLink, IComparable<WeaknessType>
{
    public static readonly WeaknessType Gravity = new WeaknessType(
        "Gravity",
        "/file/Elden-Ring/gravity-icon-40px.png",
        "/Special+Weaknesses#gravity",
        1
    );

    public static readonly WeaknessType Undead = new WeaknessType(
        "Undead",
        "/file/Elden-Ring/undead-icon-40px.png",
        "/Special+Weaknesses#undead",
        2
    );

    public static readonly WeaknessType Dragon = new WeaknessType(
        "Dragon",
        "/file/Elden-Ring/dragon-icon-40px.png",
        "/Special+Weaknesses#dragon",
        3
    );

    public static readonly WeaknessType AncientDragon = new WeaknessType(
        "Ancient Dragon",
        "/file/Elden-Ring/ancient-dragon-icon-40px.png",
        "/Special+Weaknesses#ancient-dragon",
        4
    );

    private WeaknessType(string name, string src, string href, int order) : base(name, src, href) {
        this.order = order;
    }

    private int order;

    public int CompareTo(WeaknessType? other)
    {
        return order.CompareTo(other?.order ?? -1);
    }

    public override string ToString()
    {
        return Name;
    }
}
