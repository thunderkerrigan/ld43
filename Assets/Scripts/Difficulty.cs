public interface Difficulty
{
    string name { get; }
    int spawnRate { get; }
    int enemyDifficulty { get; }
    int lootAmount { get; }
    int levelTimeout { get; }
    int fallVelocity { get; }
}

public struct Easy : Difficulty
{
    public string name
    {
        get
        {
            return "EASY";
        }
    }
    public int spawnRate
    {
        get
        {
            return 3;
        }
    }

    public int enemyDifficulty
    {
        get
        {
            return 0;
        }
    }

    public int lootAmount
    {
        get
        {
            return 10;
        }
    }

    public int levelTimeout
    {
        get
        {
            return 20;
        }
    }

    public int fallVelocity
    {
        get
        {
            return 6;
        }
    }
}

public struct Normal : Difficulty
{
    public string name
    {
        get
        {
            return "NORMAL";
        }
    }
    public int spawnRate
    {
        get
        {
            return 3;
        }
    }

    public int enemyDifficulty
    {
        get
        {
            return 1;
        }
    }

    public int lootAmount
    {
        get
        {
            return 8;
        }
    }

    public int levelTimeout
    {
        get
        {
            return 10;
        }
    }

    public int fallVelocity
    {
        get
        {
            return 10;
        }
    }
}

public struct Hard : Difficulty
{
    public string name
    {
        get
        {
            return "HARD";
        }
    }
    public int spawnRate
    {
        get
        {
            return 2;
        }
    }

    public int enemyDifficulty
    {
        get
        {
            return 2;
        }
    }

    public int lootAmount
    {
        get
        {
            return 5;
        }
    }

    public int levelTimeout
    {
        get
        {
            return 40;
        }
    }

    public int fallVelocity
    {
        get
        {
            return 16;
        }
    }
}