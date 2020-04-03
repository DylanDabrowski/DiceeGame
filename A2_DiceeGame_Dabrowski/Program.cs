using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_DiceeGame_Dabrowski
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceGame game = new DiceGame(2);


            while (1 == 1)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine(" 1: Add Player");
                Console.WriteLine(" 2: Start Game");
                Console.WriteLine("--------------------");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    Console.WriteLine("What is the players Name?");
                    string name = Console.ReadLine();
                    Player player = new Player();
                    player.Name = name;
                    game.AddPlayer(player);
                }
                else if (input == "2")
                {
                    game.Start();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not a Proper Input");
                    Console.ReadLine();
                }
                    
            }

        }
    }
}
