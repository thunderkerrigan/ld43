public interface Sacrifice
{
    string name { get; }
    string description { get; }
    string bonus { get; }
    string malus { get; }
    float bonusAmount { get; }
    float malusAmount { get; }
}

public struct Speed : Sacrifice
{
    public string name
    {
        get
        {
            return "TANK";
        }
    }
    public string description
    {
        get
        {
            return "Now You're a tank baby!";
        }
    }

    public string bonus
    {
        get
        {
            return "speed";
        }
    }

    public string malus
    {
        get
        {
            return "jump";
        }
    }

    public float bonusAmount
    {
        get
        {
            return 20;
        }
    }

    public float malusAmount
    {
        get
        {
            return 6;
        }
    }
}
