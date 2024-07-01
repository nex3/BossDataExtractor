public enum DamageType
{
    Standard, Slash, Strike, Pierce, Magic, Fire, Lightning, Holy
}

public class Boss
{
    public Boss(int id, string name, int gameAreaID)
    {
        ID = id;
        Name = name;
        GameAreaID = gameAreaID;
        DamageTypes = [];
        TypeDefense = [];
        HP = [];
        Defense = [];
        Runes = [];
        Resistance = [];
    }

    public int ID { get; init; }
    public string Name { get; init; }
    public int GameAreaID { get; init; }
    public int Stance { get; set; }
    public SortedSet<DamageType> DamageTypes { get; }
    public Dictionary<string, int> TypeDefense { get; }
    public List<int> HP { get; }
    public List<int> Defense { get; }
    public List<int> Runes { get; }
    public Dictionary<string, List<List<int>>> Resistance { get; }
}