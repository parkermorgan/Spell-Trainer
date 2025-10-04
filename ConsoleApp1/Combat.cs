namespace EnemyCombat;

using System.Collections.Concurrent;
using GameData;
using Microsoft.VisualBasic;

// Establish combat class.
public class Combat
{
    // Function to display Dark Arts Combat Program.

    public static void Display(User player)
    {
        bool combatLoop = true;
        var spells = player.LearnedSpells;
        if (player.Enemies.Count == 0)
        {
            player.AddEnemy(new Enemy("Dementor", 20, 5));
            player.AddEnemy(new Enemy("Troll", 30, 7));
            player.AddEnemy(new Enemy("Spider", 10, 2));
            player.AddEnemy(new Enemy("Death Eater", 50, 9));
        }


        while (combatLoop)
        {
            Console.Write("Will you fight? (yes/no): ");
            string choice = Console.ReadLine();

            if (choice == "yes")
            {
                // Establish randomization for enemy display.
                Random rand = new Random();

                Console.WriteLine("Prepare yourself...");
                int index = rand.Next(player.Enemies.Count);

                // Select enemy from list.
                var randomEnemy = player.Enemies[index];
                Console.WriteLine($"It's a {randomEnemy.Name}!\n{randomEnemy.Name}'s Health: {randomEnemy.Health}, Damage: {randomEnemy.Damage}");

                // Establish battle loop.
                bool battleLoop = true;

                while (battleLoop)
                {
                    double enemyDMG = randomEnemy.Damage;

                    Console.WriteLine("Select one of the following: attack / defend / disarm / run");
                    string battleChoice = Console.ReadLine();

                    // Find spells based on type and check if they exist.
                    Spell attackSpell = null;
                    Spell defendSpell = null;
                    Spell disarmSpell = null;

                    foreach (var spell in spells)
                    {
                        if (spell.Type.Equals("Offensive", StringComparison.OrdinalIgnoreCase) && attackSpell == null)
                            attackSpell = spell;
                        if (spell.Type.Equals("Defensive", StringComparison.OrdinalIgnoreCase) && defendSpell == null)
                            defendSpell = spell;
                        if (spell.Type.Equals("Disarming", StringComparison.OrdinalIgnoreCase) && disarmSpell == null)
                            disarmSpell = spell;
                    }

                    // Run attack scenario.
                    if (battleChoice == "attack")
                    {
                        // Damage enemy by spell power. 
                        if (attackSpell != null)
                        {
                            double heroDMG = attackSpell.Value;
                            randomEnemy.Health -= heroDMG;

                            Console.WriteLine($"You used {attackSpell.Name} and did {attackSpell.Value} damage!");

                            player.Health -= enemyDMG;
                            Console.WriteLine($"{randomEnemy.Name}'s health: {randomEnemy.Health}");
                            Console.WriteLine($"You took {enemyDMG} damage. Current health: {player.Health}");


                        }
                    }

                    // Run defend scenario.
                    else if (battleChoice == "defend")
                    {
                        // Reduce damage taken by spell power.
                        if (defendSpell != null)
                        {
                            double heroDef = defendSpell.Value;
                            // Calculate reduced damage.
                            double newDMG = enemyDMG - heroDef;
                            if (newDMG < 0)
                            {
                                newDMG = 0;
                            }

                            // Apply only the actual damage taken to player health.
                            player.Health -= newDMG;
                            randomEnemy.Health -= 1;

                            Console.WriteLine($"You used {defendSpell.Name} and blocked {defendSpell.Value} damage! The attack rebounded on the {randomEnemy.Name} for 1 damage!");
                            Console.WriteLine($"{randomEnemy.Name}'s health: {randomEnemy.Health}");
                            Console.WriteLine($"You took {newDMG} damage. Current health: {player.Health}");

                        }
                    }

                    // Run disarm scenario.
                    else if (battleChoice == "disarm")
                    {
                        if (disarmSpell != null)
                        {
                            double disarmPOW = disarmSpell.Value;

                            // Reduce enemy's damage permanently.
                            randomEnemy.Damage -= disarmPOW;
                            if (randomEnemy.Damage < 0)
                            {
                                randomEnemy.Damage = 0; // prevent negative damage.
                            }

                            player.Health -= randomEnemy.Damage;
                            Console.WriteLine($"You used {disarmSpell.Name}! {randomEnemy.Name}'s damage is permanently reduced by {disarmPOW}. Current enemy damage: {randomEnemy.Damage}");
                            Console.WriteLine($"{randomEnemy.Name}'s health: {randomEnemy.Health}");
                            Console.WriteLine($"You took {randomEnemy.Damage} damage. Current health: {player.Health}");
                        }
                        else
                        {
                            Console.WriteLine("You have no disarming spell available.");
                        }
                    }

                    else if (battleChoice == "run")
                    {
                        Console.WriteLine("You ran away!");
                        battleLoop = false;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }

                    if (randomEnemy.Health <= 0)
                    {
                        Console.WriteLine($"You defeated The {randomEnemy.Name}!");
                        player.Enemies.Remove(randomEnemy); // remove defeated enemy from the list
                        battleLoop = false;
                        player.Defeated += 1;
                    }

                    if (player.Health == 0)
                    {
                        Console.WriteLine("You have been beaten. Better luck next time.");
                        battleLoop = false;
                        combatLoop = false;
                    }

                    if (player.Defeated >= player.Enemies.Count)
                    {
                        Console.WriteLine("You have defeated all enemies!");
                        battleLoop = false;
                        combatLoop = false;
                    }

                }
            }

            else if (choice == "no")
            {
                Console.WriteLine("\nRemaining Enemies:");
                foreach (var enemy in player.Enemies)
                {
                    Console.WriteLine(enemy.Name);
                }
                combatLoop = false;
            }


        }
    }


}