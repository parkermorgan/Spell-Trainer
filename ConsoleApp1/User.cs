using System.Dynamic;

namespace GameData;

public class User
{
    public string Name { get; set; }
    public int Defeated { get; set; }
    public List<Spell> LearnedSpells { get; set; }

    public User(string name)
    {
        Name = name;
        Defeated = 0;
        LearnedSpells = new List<Spell>();
    }

    public void LearnSpell(Spell spell)
    {
        LearnedSpells.Add(spell);
    }
}