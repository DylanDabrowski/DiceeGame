using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_DiceeGame_Dabrowski
{
    class DiceGame
    {
        public List<Dice> Dices { get; set; }
        public List<Player> Players { get; set; }
        public Player ActivePlayer { get; }
        public bool IsGameOver { get; }

        public DiceGame(int numberOfDice)
        {
            Players = new List<Player>();
            for (int i = 0; i < numberOfDice; i++)
            {
                Dice dice = new Dice(6);
                Dices.Add(dice);
            }
        }

        public void AddPlayer(Player player)
        {

        }

        public void Start()
        {

        }

        public void PlayTurn()
        {

        }

        public void RollDice()
        {

        }

        public void ComputeTurnResult()
        {

        }

        public void UpdatePlayerStat()
        {

        }

        public void SetNextPlayer()
        {

        }

        public Player TheWinner()
        {
            return ActivePlayer; //temp, just to get rid of red line
        }


    }
}
