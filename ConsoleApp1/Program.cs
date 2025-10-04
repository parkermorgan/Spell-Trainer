// Bring in SpellInstruction namespace.
using System.IO.Enumeration;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using EnemyCombat;
using GameData;
using SpellInstruction;

class Program
{
    static void Main(string[] args)
    {
        // Establish loop
        bool menuLoop = true;

        // Ask for user information.
        Console.Write("What is your name? ");
        string _name = Console.ReadLine();
        User player = new User(_name);
        
        // Add spells to user information.
        player.LearnSpell(new Spell("Protego", "Defensive", "You raise your wand quickly, whispering \"Protego\" to block the incoming spell.", 3));
        player.LearnSpell(new Spell("Stupefy", "Offensive", "You aim at your opponent and shout \"Stupefy!\", stunning it and launching it backwards.", 3));
        player.LearnSpell(new Spell("Expelliarmus", "Disarming", "With a sharp flick, you cast \"Expelliarmus!\" and the opponent's wand flew from their hand.", 3));

        // Add enemies to user information.
        player.AddEnemy(new Enemy("Dementor", 20, 5));
        player.AddEnemy(new Enemy("Troll", 30, 7));
        player.AddEnemy(new Enemy("Spider", 10, 2));
        player.AddEnemy(new Enemy("Death Eater", 50, 9));

        // Establish loop for menu.
        while (menuLoop)
        {
            // Display menu options.
            Console.WriteLine("\nWelcome to the Spell Trainer! Please select an option below:\n\n1. Practice Spells\n2. Defend against the Dark Arts\n3. View Statistics\n4. Save/Load User Data\n0. Quit\n");
            Console.Write("> ");
            string input = Console.ReadLine();
            int choice;
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Returning to menu.");
                continue; // go back to the start of the while loop
            }

            // Move to spell instruction.
            if (choice == 1)
            {
                Instruction.Display(player);
            }

            // Run Dark Arts program.
            else if (choice == 2)
            {


                int total = player.Enemies.Count();

                if (total > 0)
                {
                    // run dark arts program
                    Combat.Display(player);
                }

                else
                {
                    Console.WriteLine("You have defeated all enemies!");
                }
            }

            // Display User Statistics.
            else if (choice == 3)
            {
                Statistics.DisplayStats(player);
            }

            // Prompt user for saving/loading.
            else if (choice == 4)
            {
                Console.Write("Would you like to save your user information or load from a file? (save/load) ");
                string dataChoice = Console.ReadLine();

                // Call SaveUser function.
                if (dataChoice == "save")
                {
                    Console.WriteLine("Enter a file name (e.g. userInfo.json): ");
                    string saveFile = Console.ReadLine();
                    Statistics.SaveUser(player, saveFile);
                }

                // Call LoadUser function.
                else if (dataChoice == "load")
                {
                    Console.WriteLine("Enter a file name (e.g. userInfo.json): ");
                    string loadFile = Console.ReadLine();
                    User loadedPlayer = Statistics.LoadUser(loadFile);

                    if (loadedPlayer != null)
                    {
                        player = loadedPlayer;
                        Console.WriteLine("User data loaded successfully!");
                    }
                }

                // Fallback for invalid input.
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            // Terminate program.
            else if (choice == 0)
            {
                Console.WriteLine("Thank you for using the Spell Trainer!");
                menuLoop = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }

            if (player.Health == 0)
            {
                menuLoop = false;
            }
        }
    }
}
