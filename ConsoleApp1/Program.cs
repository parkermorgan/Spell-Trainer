// Bring in SpellInstruction namespace.
using SpellInstruction;

class Program
{
    static void Main(string[] args)
    {
        // Establish loop
        bool menuLoop = true;

        while (menuLoop)
        {
            Console.WriteLine("\nWelcome to the Spell Trainer! Please select an option below:\n\n1. Practice Spells\n2. Defend against the Dark Arts\n0. Quit\n");
            Console.Write("> ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Instruction.Display();
            }
            else if (choice == 0)
            {
                menuLoop = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}
