public enum Display
{
    Full, CrossEnemy, OneEnemyOfMany, ExtraEnemy
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
        get { return displayEnum != global::Display.OneEnemyOfMany; }
    }
    public bool UniqueFight
    {
        get {
            return displayEnum == global::Display.Full ||
                displayEnum == global::Display.OneEnemyOfMany;
        }
    }

    public override string ToString()
    {
        return displayEnum.ToString();
    }
}