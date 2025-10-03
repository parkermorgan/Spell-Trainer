using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

// Esatablish SpellInstruction namespace.
namespace SpellInstruction;

using System.Security;
using GameData;

public class Instruction
{
    // Function to display Spell Instruction program.
    public static void Display(User player)
    {
        // Create loop for user to practice spells.
        bool spellLoop = true;

        while (spellLoop)
        {
            Console.WriteLine("\nPull out your wand and put your books away, it's time to practice!\n");
            var spells = player.LearnedSpells;

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
                Console.Write($"Type \"{selected.Name}!\" ");
                string _correctName = Console.ReadLine();

                if (_correctName == $"{selected.Name}!")
                {
                    Console.WriteLine($"Well done! You have increased {selected.Name}'s power by {increase}");
                    selected.Value += increase;
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                }
               
            }
        }
    }

    

}