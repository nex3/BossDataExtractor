public class Game
{
    public static readonly Game DS1 = new Game(
        "Dark Souls",
        "https://darksouls.wiki.fextralife.com/Dark+Souls+Wiki"
    );

    public static readonly Game DS2 = new Game(
        "Dark Souls II",
        "https://darksouls2.wiki.fextralife.com/Dark+Souls+2+Wiki"
    );

    public static readonly Game DS3 = new Game(
        "Dark Souls III",
        "https://darksouls3.wiki.fextralife.com/Dark+Souls+3+Wiki"
    );

    public static readonly Game ER = new Game(
        "Elden Ring",
        "https://eldenring.wiki.fextralife.com/Elden+Ring+Wiki"
    );

    public static readonly Game NR = new Game(
        "Elden Ring: Nightreign",
        "https://eldenringnightreign.wiki.fextralife.com/Elden+Ring+Nightreign+Wiki"
    );

    private Game(string name, string href)
    {
        this.Name = name;
        this.Href = href;
    }

    public string Name { get; init; }
    public string Href { get; init; }

    public override string ToString()
    {
        return Name;
    }
}
