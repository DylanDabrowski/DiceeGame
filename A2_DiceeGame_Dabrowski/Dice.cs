using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_DiceeGame_Dabrowski
{
    enum RollResult
    {
        Jackpot,
        Win,
        Lose
    }
    class Dice
    {
        public int Face { get; }
        public int Max { get; set; }

        public Dice()
        {
            Max = 6;
        }

        public void Roll()
        {

        }

    }
}
