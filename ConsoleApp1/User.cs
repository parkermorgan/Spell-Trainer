using System.Dynamic;

namespace GameData;

public class User
{
    public string Name { get; set; }
    public int Defeated { get; set; }
    public List<Spell> LearnedSpells { get; set; }
    public List<Enemy> Enemies { get; set; }

    public double Health { get; set; }

    public User(string name)
    {
        Name = name;
        Defeated = 0;
        LearnedSpells = new List<Spell>();
        Enemies = new List<Enemy>();
        Health = 20;
    }

    public void LearnSpell(Spell spell)
    {
        LearnedSpells.Add(spell);
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }
}