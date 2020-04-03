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

            Player player1 = new Player();
            player1.Name = "Dylan";
            Player player2 = new Player();
            player2.Name = "Calum";
            Player player3 = new Player();
            player3.Name = "Kate";

            game.AddPlayer(player1);
            game.AddPlayer(player2);
            game.AddPlayer(player3);


            Console.WriteLine("Player Names:");
            foreach (var player in game.Players)
            {
                Console.WriteLine(player.Name);
            }

        }
    }
}
