using System.Reflection;

namespace GameData;

public class Enemy
{
    public string Name { get; set; }
    private double health;
    public double Health
    {
        get { return health; }
        set { health = (value < 0) ? 0 : value; } // clamp automatically
    }
    public double Damage { get; set; }


    public Enemy(string name, double health, double damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

}
