public class IconLink
{
    public static readonly IconLink Runes = new IconLink(
        "Runes",
        "/file/Elden-Ring/runes-currency-elden-ring-wiki-guide-18.png",
        "/Runes"
    );

    protected IconLink(string name, string src, string href, string? color = null)
    {
        Name = name;
        Src = src;
        Href = href;
        Color = color;
    }

    public string Name { get; init; }
    public string Src { get; init; }
    public string Href { get; init; }
    public string? Color { get; init; }

    public override string ToString()
    {
        return Name;
    }
}
