using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

// Esatablish SpellInstruction namespace.
namespace SpellInstruction;

public class Instruction
{

    // From Spell class file, create new objects for different spells.
    static Spell protego = new Spell("Protego", "Defensive", "You raise your wand quickly, whispering \"Protego\" to block the incoming spell.", 3);
    static Spell stupefy = new Spell("Stupefy", "Offensive", "You aim at your opponent and shout \"Stupefy!\", stunning it and launching it backwards.", 3);
    static Spell expelliarmus = new Spell("Expelliarmus", "Disarming", "With a sharp flick, you cast \"Expelliarmus!\" and the opponent's want flew from their hand.", 3);

    // Store all Spell objects in a list for easy access.
    static List<Spell> spells = new List<Spell> { protego, stupefy, expelliarmus };

    // Function to display Spell Instruction program.
    public static void Display()
    {
        // Create loop for user to practice spells.
        bool spellLoop = true;

        while (spellLoop)
        {
             Console.WriteLine("\nPull out your wand and put your books away, it's time to practice!\n");

            //Display all spells in list
            for (int i = 0; i < spells.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {spells[i].Name} (Type: {spells[i].Type}, Value: {spells[i].Value})");
            }

            // Prompt the user to select a spell.
            Console.Write("\nChoose a spell to practice with or type \"0\" to quit: ");
            int choice = int.Parse(Console.ReadLine());

            // Conditional to determine whether or not to terminate the loop.
            if (choice == 0)
            {
                return; // exit Display and go back to menu
            }
            else
            {
                // Subtract the user input by 1 to pick correct index in list.
                Spell selected = spells[choice - 1];
                double increase = 0;

                // Change increase of value depending on the spell
                if (selected.Type == "Defensive")
                {
                    increase = 1.5;
                }
                else if (selected.Type == "Offensive")
                {
                    increase = 2;
                }
                else if (selected.Type == "Disarming")
                {
                    increase = 1;
                }
                
                Console.WriteLine($"\n{selected.Text}");
                Console.WriteLine($"Well done! You have increased {selected}'s power by  {increase}");
                selected.Value += increase;
            }
        }

    }

}