public enum Display
{
    Full, Infobox, CrossEnemy, OneEnemyOfMany, ExtraEnemy, NewGamePlus, NewPage
}

public class Context
{
    private Display displayEnum;

    public Context(Display display, Boss boss, bool eldenRing)
    {
        displayEnum = display;
        Boss = boss;
        EldenRing = eldenRing;
    }

    public IconLink RuneIcon
    {
        get { return IconLink.Runes; }
    }

    public Boss Boss { get; init; }

    public bool EldenRing { get; init; }

    public bool Nightreign {
        get { return !EldenRing; }
    }

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
                displayEnum == global::Display.Infobox ||
                displayEnum == global::Display.OneEnemyOfMany ||
                displayEnum == global::Display.NewGamePlus;
        }
    }

    public int InfoboxColspan {
        get { return Boss.Nightlord ? 4 : 2; }
    }

    public override string ToString()
    {
        return displayEnum.ToString();
    }
}