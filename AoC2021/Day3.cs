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
            if (this.completed() == Status.none)
            {
                GetPath();
                solve(this.ConvertValues(ReadFile()));
            }
            else if (this.completed() == Status.simple)
            {
                GetPath();
                solveAdvanced(this.ConvertValues(ReadFile()));
            }
        }

        private void solveAdvanced(int[,] bits)
        {
            /* Verify life support rating = oxygenRating * CO2 scubber rating
             */
            //int[,] test = new int[3, bits.GetLength(1)];
            //for (int row = 0; row < 3; row++)
            //{
            //    for (int column = 0; column < bits.GetLength(1); column++)
            //    {
            //        test[row, column] = bits[row, column];
            //    }
            //}

            int oxy = selectionProcces(bits, true);//most common, take 1
            int Co2 = selectionProcces(bits, false); //least common, take 0

            Console.WriteLine($"Oxygen: {oxy}, CO2: {Co2}");
            Console.WriteLine($"Result is {oxy * Co2}");
            Clipboard.SetText((oxy * Co2).ToString());
        }

        private int selectionProcces(int[,] bits, bool leastMmost) {
            int count = 0;
            List<int[]> BitList = bits.Cast<int>()
                                .GroupBy(x => count++ / bits.GetLength(1))
                                .Select(g => g.ToArray())
                                .ToList();
            count = 0;
            do
            {
                int x = GetLeastMostBit(BitList, leastMmost, count);
                BitList.RemoveAll(row => row[count] != x);
                count++;
            } while (BitList.Count() > 1 && count < bits.GetLength(1));

            string binary = "";
            foreach (int item in BitList.ElementAt(0))
            {
                binary += item;
            }

            return Convert.ToInt32(binary, 2);
        }

        private int GetLeastMostBit(List<int[]> bits, bool leastMost, int column) {
            int common = 0;
            int zero =0; int one = 0;
            foreach (int[] item in bits)
            {
                if (item[column] == 1) one++;
                if (item[column] == 0) zero++;
            }
            if (leastMost) { common = one >= zero ? 1 : 0; }
            else { common = one >= zero ? 0 : 1; }
            return common;
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

        public override Status completed()
        {
            return Status.completed;
        }

        public override string name()
        {
            return "Day3";
        }

        
    }
}
