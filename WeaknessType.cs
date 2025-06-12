public class WeaknessType : IconLink
{
    public static readonly WeaknessType Gravity = new WeaknessType(
        500,
        "Gravity",
        "https://eldenring.wiki.fextralife.com/file/Elden-Ring/gravity-icon-40px.png",
        "https://eldenring.wiki.fextralife.com/Special+Weaknesses#gravity"
    );

    public static readonly WeaknessType Undead = new WeaknessType(
        501,
        "Undead",
        "https://eldenring.wiki.fextralife.com/file/Elden-Ring/undead-icon-40px.png",
        "https://eldenring.wiki.fextralife.com/Special+Weaknesses#undead"
    );

    public static readonly WeaknessType Dragon = new WeaknessType(
        502,
        "Dragon",
        "https://eldenring.wiki.fextralife.com/file/Elden-Ring/dragon-icon-40px.png",
        "https://eldenring.wiki.fextralife.com/Special+Weaknesses#dragon"
    );

    public static readonly WeaknessType AncientDragon = new WeaknessType(
        503,
        "Ancient Dragon",
        "https://eldenring.wiki.fextralife.com/file/Elden-Ring/ancient-dragon-icon-40px.png",
        "https://eldenring.wiki.fextralife.com/Special+Weaknesses#ancient-dragon"
    );

    private WeaknessType(int order, string name, string src, string href) : base(order, name, src, href) {}

    public override string ToString()
    {
        return Name;
    }
}
