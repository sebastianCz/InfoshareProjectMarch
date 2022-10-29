using OstreC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OstreC.ManageInput
{
    internal class FightInput
    {
        public static string SolveFight(List<Enemy> enemies, Player player)
        {
            //List<bool> priorityFight = new List<bool>();public override string ToString()

            Console.Clear();
            Helpers.WriteLineColorText("The fight has started! Roll for initiative!\n");
            int initiativePlayer = TestOnDex(player.ModDexterity, true);
            int initiativeEnemy = TestOnDex(enemies[0].ModDexterity, false);
            bool isPlayerTurn = initiativePlayer >= initiativeEnemy;
            if (isPlayerTurn)
                Helpers.WriteLineColorText($"\nYou've won initiative roll with {initiativePlayer - player.ModDexterity} on K20 dice with {player.ModDexterity} modificator", ConsoleColor.Green);
            else
                Helpers.WriteLineColorText($"\nYou've lost initative roll with {initiativePlayer - player.ModDexterity} on K20 dice with {player.ModDexterity} modificator", ConsoleColor.Red);

            Helpers.WriteLineColorText("Do you want to continue fight or go back to menu ?\nPress 'Y' - yes or 'N' - no");
            if (!Helpers.YesOrNoKey(true))
            {
                return "0";
            }
            bool specialAttack = true;
            do
            {
                InfoRefresh(player, enemies);


                if (isPlayerTurn)
                {
                    Console.WriteLine($"\nIt is your turn:");
                    Console.WriteLine($"Choose action");
                    Console.WriteLine($"1.Attack");
                    Console.WriteLine($"2.Heal");

                    if (specialAttack)
                    {
                        Console.WriteLine("3.Special Attack");
                    }
                    ConsoleKey key;
                    int idEnemy = 0;
                    int attack = 0;
                    do
                    {
                        key = Console.ReadKey().Key;

                        switch (key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                idEnemy = ChooseOpponent(enemies);
                                attack = StandardAttack(player.ModDexterity, player.ModStrength, true, enemies[idEnemy].Armor_Class, 12);
                                if (attack == 0)
                                    Helpers.WriteLineColorText("You've missed!", ConsoleColor.Red);
                                else
                                {
                                    enemies[idEnemy].HealthPoints -= attack;
                                    Helpers.WriteLineColorText($"You hit enemy for {attack} damage\n{enemies[idEnemy].Name} have now {enemies[idEnemy].HealthPoints} HP");
                                }
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                int heal = Heal(player.ModConstitution, true, 6);
                                Helpers.WriteLineColorText($"You've restored {heal} points");
                                player.HealthPoints += heal;
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                if (specialAttack)
                                {
                                    idEnemy = ChooseOpponent(enemies);
                                    attack = StandardAttack(player.ModDexterity * 2, player.ModStrength, true, enemies[idEnemy].Armor_Class, 12) * 2;
                                    if (attack == 0)
                                        Helpers.WriteLineColorText("You've missed!", ConsoleColor.Red);
                                    else
                                    {
                                        enemies[idEnemy].HealthPoints -= attack;
                                        Helpers.WriteLineColorText($"You hit enemy for {attack} damage\n{enemies[idEnemy].Name} have now {enemies[idEnemy].HealthPoints} HP");
                                    }
                                    specialAttack = false;
                                }
                                else
                                {
                                    Helpers.WriteLineColorText($"Wrong action selected", ConsoleColor.Red);
                                }
                                break;
                            //case ConsoleKey.D4:
                            //case ConsoleKey.NumPad4:
                            //    break;
                            default:
                                Helpers.WriteLineColorText($"Wrong action selected", ConsoleColor.Red);

                                break;
                        }

                    } while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3);
                    if (enemies[idEnemy].HealthPoints <= 0)
                    {
                        Helpers.WriteLineColorText($"You've killed an enemy\n{enemies[idEnemy].Name}");
                        enemies.Remove(enemies[idEnemy]);
                    }
                    Helpers.WriteLineColorText("Press anything to continue");
                    Console.ReadKey();

                    if (enemies.Count() <= 0)
                    {
                        Helpers.WriteLineColorText($"You beat all enemies\nGood Job!\nPress anything to move on", ConsoleColor.Green);
                        Console.Beep(440, 500);
                        Console.Beep(440, 500);
                        Console.Beep(440, 500);
                        Console.Beep(349, 350);
                        Console.Beep(523, 150);
                        Console.Beep(440, 500);
                        Console.Beep(349, 350);
                        Console.Beep(440, 1000);
                        Console.Beep(659, 500);
                        Console.Beep(659, 500);
                        Console.Beep(659, 500);
                        Console.Beep(698, 350);
                        Console.Beep(523, 150);
                        Console.Beep(415, 500);
                        Console.Beep(349, 350);
                        Console.Beep(523, 150);
                        Console.Beep(440, 1000);
                        return "2";
                    }
                    isPlayerTurn = false;
                }
                else
                {
                    for (int i = 0; i < enemies.Count(); i++)
                    {
                        InfoRefresh(player, enemies);
                        Random enemyOperation = new Random();
                        int operation = enemyOperation.Next(0, 4);
                        switch (operation)
                        {
                            case 1:
                                int heal = Heal(enemies[i].ModConstitution, false, 4);
                                Helpers.WriteLineColorText($"Enemy healed for {heal} points");
                                enemies[i].HealthPoints += heal;
                                break;
                            default:
                                int attack = StandardAttack(enemies[i].ModDexterity, enemies[i].ModStrength, false, player.ModDexterity + 10, 6);
                                if (attack == 0)
                                    Helpers.WriteLineColorText("Enemy missed", ConsoleColor.Green);
                                else
                                {
                                    player.HealthPoints -= attack;
                                    Helpers.WriteLineColorText($"Enemy hit you for {attack} damage\nYou have now {player.HealthPoints} HP");
                                }
                                break;
                        }
                        Helpers.WriteLineColorText("Press anything to continue");
                        Console.ReadKey();
                        if (player.HealthPoints <= 0)
                        {
                            Helpers.WriteLineColorText($"You are dead,{enemies[i].Name} will feast on your dead body now", ConsoleColor.DarkRed);
                            Helpers.WriteLineColorText("Press anything to continue", ConsoleColor.DarkRed);
                            Console.ReadKey();
                            return "1";
                        }
                    }
                    isPlayerTurn = true;
                }



            } while (true);
        }

        public static int TestOnDex(int modDexterity, bool player)
        {
            return modDexterity + Helpers.ThrowDice(20, player);

        }

        public static int TestOn(int modificator, bool player, int diceNumber)
        {
            return modificator + Helpers.ThrowDice(diceNumber, player);
        }

        public static int StandardAttack(int modDex, int modStr, bool player, int armor, int diceNumber)
        {
            if (player)
                Helpers.WriteColorText("\nTry to break enemies armor!\nroll for hit\n");
            if (armor > TestOnDex(modDex, player))
            {
                return 0;
            }
            if (player)
                Helpers.WriteColorText("\nYou broke enemy armor\nlet the rampage begin\nroll for the damage\n");
            return TestOn(modStr, player, diceNumber);


        }
        public static int Heal(int modConst, bool player, int diceNumber)
        {
            if (player)
                Helpers.WriteLineColorText("\nYou are short on health!\nroll to heal!\n");
            return TestOn(modConst, player, diceNumber);
        }

        public static int ChooseOpponent(List<Enemy> enemies)
        {
            ConsoleKeyInfo keyinfo;
            int index = 0;
            Helpers.WriteLineColorText("Choose which enemy you want to attack.\nUse the left or right arrow on the keyboard and press ENTER to confirm.");
            do
            {
                Helpers.WriteColorText($"Enemy {index + 1}/{enemies.Count()}: ", ConsoleColor.Magenta);
                Console.WriteLine(enemies[index].Name);

                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    if (index + 1 >= enemies.Count()) index = 0;
                    else index++;
                }
                else if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    if (index <= 0) index = enemies.Count() - 1;
                    else index--;
                }
                else if (keyinfo.Key == ConsoleKey.Enter) break;
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                Console.WriteLine("                                                                                   ");
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            } while (true);
            return index;
        }

        public static void InfoRefresh(Player player, List<Enemy> enemies)
        {
            Console.Clear();
            Helpers.WriteLineColorText($"{player.Name}", ConsoleColor.Cyan);
            Helpers.WriteLineColorText($"HP: {player.HealthPoints}", ConsoleColor.Cyan);
            for (int o = 0; o < enemies.Count(); o++)
            {
                Console.CursorTop = 0;
                Console.CursorLeft = 25 * (o + 1);
                Helpers.WriteLineColorText($"{o + 1}. " + enemies[o].Name, ConsoleColor.Red);
                Console.CursorTop = 1;
                Console.CursorLeft = 25 * (o + 1);
                Helpers.WriteLineColorText($"HP: {enemies[o].HealthPoints}", ConsoleColor.Red);

            }
        }
    }
}
