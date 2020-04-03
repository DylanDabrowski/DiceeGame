using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2_DiceeGame_Dabrowski
{
    class Dice
    {
        public int Face { get; private set; }
        public int Max { get; set; }

        public Dice(int max)
        {
            Max = max;
        }

        public void Roll()
        {
            Random randomNumberGenerator = new Random();
            Face = randomNumberGenerator.Next(1, 7);
        }

    }
}
