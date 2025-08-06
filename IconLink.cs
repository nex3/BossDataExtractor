public class IconLink : IComparable<IconLink>
{
    public static readonly IconLink Runes = new(
        1000,
        "Runes",
        "/file/Elden-Ring/runes-currency-elden-ring-wiki-guide-18.png",
        "/Runes"
    );

    private readonly int order;

    protected IconLink(int order, string name, string src, string href, string? color = null)
    {
        this.order = order;
        Name = name;
        Src = src;
        Href = href;
        Color = color;
    }

    public string Name { get; init; }
    public string Src { get; init; }
    public string Href { get; init; }
    public string? Color { get; init; }
    public int CompareTo(IconLink? other)
    {
        return order.CompareTo(other?.order ?? -1);
    }

    public override string ToString()
    {
        return Name;
    }

    public string Image => FluidRenderer.RenderTemplate("IconImage", new { type = this });
}
