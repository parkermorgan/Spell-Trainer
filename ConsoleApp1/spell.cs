namespace GameData;
public class Spell
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Text { get; set; }
    public double Value { get; set; }

    public Spell(string name, string type, string text, double value)
    {
        Name = name;
        Type = type;
        Value = value;
        Text = text;
    }
}