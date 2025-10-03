using System.Dynamic;
using System.Text.Json;
using System.Xml.Serialization;
using GameData;

using SpellInstruction;
public class Statistics
{
    // Display user statistics.
    public static void DisplayStats(User player)
    {
        Console.WriteLine($"\nStatistics for {player.Name}: ");
        for (int i = 0; i < player.LearnedSpells.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {player.LearnedSpells[i].Name} Power: {player.LearnedSpells[i].Value}");
        }
    }

    public static void SaveUser(User player, string fileName)
    {
        var playerData = new
        {
            Name = player.Name,
            Defeated = player.Defeated,
            Spells = player.LearnedSpells.Select(s => new { s.Name, s.Value }).ToList()
        };

        string jsonString = JsonSerializer.Serialize(playerData, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine($"User saved to {fileName}");
    }

    public static User LoadUser(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return null;
        }

        string jsonString = File.ReadAllText(fileName);

        var playerData = JsonSerializer.Deserialize<TempPlayerData>(jsonString);

        if (playerData == null)
            return null;

        User player = new User(playerData.Name)
        {
            Defeated = playerData.Defeated
        };

        foreach (var spell in playerData.Spells)
        {
            player.LearnedSpells.Add(new Spell(spell.Name, "", "", spell.Value));
        }

        return player;
    }

    private class TempPlayerData
    {
        public string Name { get; set; }
        public int Defeated { get; set; }
        public List<TempSpell> Spells { get; set; }
    }

    private class TempSpell
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
