public enum Display
{
    Full, CrossEnemy, EnemySpecific
}

public class Context
{
    private Display displayEnum;

    public Context(Display display, Boss boss)
    {
        displayEnum = display;
        Boss = boss;;
    }

    public IconLink RuneIcon
    {
        get { return IconLink.Runes; }
    }

    public Boss Boss { get; init; }

    public string Display
    {
        get { return displayEnum.ToString(); }
    }

    public bool ShowEnemySpecific
    {
        get { return displayEnum != global::Display.CrossEnemy; }
    }

    public bool ShowCrossEnemy
    {
        get { return displayEnum != global::Display.EnemySpecific; }
    }

    public override string ToString()
    {
        return displayEnum.ToString();
    }
}