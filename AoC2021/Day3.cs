using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC2021
{
    class Day3 : Day
    {
        public Day3()
        {
            if (this.completed() == "none")
            {
                GetPath();
                solve(this.ConvertValues(ReadFile()));
            }
            else if (this.completed() == "simple")
            {
                GetPath();
                solveAdvanced(this.ConvertValues(ReadFile()));
            }
        }

        private void solveAdvanced(object v)
        {
            throw new NotImplementedException();
        }

        private void solve(int[,] bits)
        {
            /* Input: Binary numbers
             * Gamma rate?
             * Epsilon rate?
             * Output powerConsumption (=> gamma * Epsilon)
             * 
             * gamma = most common bits in all positions
             * Epsilon least common bits in all position 
             * 
             * a.k.a. épsilon = NOT gamma
             */
            string x = "";

            for (int column = 0; column < bits.GetLength(1); column++)
            {
                int ones = 0;
                for (int row = 0; row < bits.GetLength(0); row++)
                {
                    if (bits[row, column] == 1)
                    {
                        ones++;
                    }
                }
                if (ones > (bits.GetLength(0) / 2))
                {
                    x += 1;
                }
                else
                {
                    x += 0;
                }
            }
            int gamma = Convert.ToInt32(x, 2);
            int epsilon = (gamma ^ ((int)Math.Pow(2, bits.GetLength(1))-1));

            Console.WriteLine($"output is {gamma * epsilon}");
            Clipboard.SetText((gamma * epsilon).ToString());
        }

        private int[,] ConvertValues(string[] vs)
        {
            int[,] BitsArray = new int[vs.Length, vs[0].Length];

            for (int row = 0; row < vs.Length; row++)
            {
                char[] parts = vs[row].ToCharArray();
                for (int column = 0; column < vs[0].Length; column++)
                {
                    BitsArray[row, column] = Convert.ToInt32((parts[column].ToString()));
                }
            }
            return BitsArray;
        }

        public override string completed()
        {
            return "simple";
        }

        public override string name()
        {
            return "Day3";
        }

        
    }
}
