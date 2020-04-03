using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace A2_DiceeGame_Dabrowski
{
    class DiceGame
    {
        public List<Dice> Dices { get; set; }
        public List<Player> Players { get; set; }
        public Player ActivePlayer { get; private set; }
        public bool IsGameOver = true;

        public DiceGame(int numberOfDice)
        {
            Players = new List<Player>();
            Dices = new List<Dice>();
            Dice dice = new Dice(6);
            for (int i = 0; i < numberOfDice; i++)
            {
                Dices.Add(dice);
            }
        }

        public void AddPlayer(Player player)
        {
            if (!IsGameOver)
                throw new Exception("AddPlayer Cannot be called while a game is in progress.");

            Players.Add(player);
            Console.WriteLine("Player Added!");
            Console.ReadLine();

        }

        public void Start()
        {
            if(Players.Count < 2)
                throw new Exception("You need AT LEAST 2 players to start the game!");

            IsGameOver = false;
            ActivePlayer = Players[0]; 
            PlayTurn(ActivePlayer);
        }

        public void PlayTurn(Player player)
        {
            if (player.History.Count == 5)
                TheWinner();
            Console.Clear();
            Console.WriteLine("You Roll your Dice!:");
            foreach (Dice dice in Dices)
            {
                RollDice(dice);
                Console.WriteLine(dice.Face);
                Console.ReadLine();
            }

            RollResult result = ComputeTurnResult();
            UpdatePlayerStat(result, player);

            SetNextPlayer(player);

        }

        public void RollDice(Dice dice)
        {
            dice.Roll();
        }

        public RollResult ComputeTurnResult()
        {
            if (Dices.Distinct().Skip(1).Any())
            {
                if (Dices[0].Face == 6)
                {
                    Console.WriteLine("Jackpot!!");
                    Console.ReadLine();
                    return RollResult.Jackpot;
                }
                else
                {
                    Console.WriteLine("Win!");
                    Console.ReadLine();
                    return RollResult.Win;
                }
            }
            Console.WriteLine("Lose");
            Console.ReadLine();
            return RollResult.Lose;
        }

        public void UpdatePlayerStat(RollResult result, Player player)
        {
            if (result == RollResult.Jackpot)
            {
                player.Score += Dices.Count * 10;
                if (player.History.Contains(RollResult.Jackpot))
                {
                    player.History.Add(result);
                    TheWinner();
                }
            }
            else if (result == RollResult.Win)
                player.Score += Dices.Count * 5;

            player.History.Add(result);
        }

        public void SetNextPlayer(Player player)
        {
            ActivePlayer = player;
            PlayTurn(player);
        }

        public Player TheWinner()
        {
            Player winner = ActivePlayer;
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Score > Players[i - 1].Score)
                    winner = Players[i];
            }

            return winner;
        }


    }
}
