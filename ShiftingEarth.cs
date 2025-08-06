public class ShiftingEarth : IconLink
{
    public static readonly ShiftingEarth Crater = new ShiftingEarth(
        600,
        "Crater",
        "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nightreign-the-crater-icon-fixed-40px.png",
        "https://eldenringnightreign.wiki.fextralife.com/The+Crater"
    );

    public static readonly ShiftingEarth Mountaintops = new ShiftingEarth(
        601,
        "Mountaintop",
        "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nightreign-the-mountaintops-icon-fixed-40px.png",
        "https://eldenringnightreign.wiki.fextralife.com/The+Mountaintops"
    );

    public static readonly ShiftingEarth Woods = new ShiftingEarth(
        602,
        "Rotted Woods",
        "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nightreign-the-rotted-woods-icon-40px.png",
        "https://eldenringnightreign.wiki.fextralife.com/The+Rotted+Woods"
    );

    public static readonly ShiftingEarth Noklateo = new ShiftingEarth(
        603,
        "Noklateo, the Shrouded City",
        "https://eldenringnightreign.wiki.fextralife.com/file/Elden-Ring-Nightreign/nightreign-noklateo-icon-40px.png",
        "https://eldenringnightreign.wiki.fextralife.com/Noklateo,+The+Shrouded+City"
    );

    private ShiftingEarth(int order, string name, string src, string href) : base(order, name, src, href) { }

    public override string ToString()
    {
        return Name;
    }
}
