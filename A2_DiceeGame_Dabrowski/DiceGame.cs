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
            if(IsGameOver)
                Players.Add(player);
            throw new Exception("AddPlayer Cannot be called while a game is in progress.");
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
            foreach (Dice dice in Dices)
            {
                RollDice(dice);
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
                    return RollResult.Jackpot;
                else
                    return RollResult.Win;
            }
            else
                return RollResult.Lose;
        }

        public void UpdatePlayerStat(RollResult result, Player player)
        {
            if (result == RollResult.Jackpot)
                player.Score += Dices.Count * 10;
            else if (result == RollResult.Win)
                player.Score += Dices.Count * 5;

            player.History.Add(result);
        }

        public void SetNextPlayer(Player player)
        {
            int hcode = player.GetHashCode();
            ActivePlayer = Players[hcode];
        }

        public Player TheWinner()
        {
            return ActivePlayer; //temp, just to get rid of red line
        }


    }
}
