using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace AoC2021
{
    class Day1 : Day
    {
        public Day1()
        {
            if (this.completed() != "advanced")
            {
                GetPath();
                //solve(this.ConvertValues(ReadFile()));
                solveAdvanced(this.ConvertValues(ReadFile())); 
            }
        }

        public override string completed()
        {
            return "advanced";
        }

        public List<int> ConvertValues(string[] x)
        {
            List<int> aa = new List<int>();
            foreach (string i in x)
            {
                aa.Add(Convert.ToInt32(i));
            }
            return aa;
        }

        public override string name()
        {
            return "Day1";
        }

        public void solve(List<int> input)
        {
            List<string> states = new List<string>();
            int prevValue = -1;
            foreach (int currValue in input)
            {
                if (prevValue == -1)
                {
                    prevValue = currValue;
                    states.Add("(N/A - no previous measurement)");
                }
                else
                {
                    if (currValue > prevValue)
                    {
                        states.Add("(increased)");
                    }
                    else
                    {
                        states.Add("(decreased)");
                    }

                    prevValue = currValue;
                }
            }

            int count = states.Count(x => x == "(increased)");
            Console.WriteLine($"Result is {count} - coppied to clipboard");
            Clipboard.SetText(count.ToString());
        }

        private void solveAdvanced(List<int> list)
        {
            int sumCurr = -1;
            int sumLast = -1;
            List<string> states = new List<string>();
            List<Tuple<int, int, int>> trios = new List<Tuple<int, int, int>>();

            for (int i = 0; i < list.Count() - 2; i++)
            {
                trios.Add(new Tuple<int, int, int>(list[i], list[i + 1], list[i + 2]));
            }

            foreach (Tuple<int, int, int> trio in trios)
            {
                sumCurr = trio.Item1 + trio.Item2 + trio.Item3;
                if (sumLast == -1)
                {
                    sumLast = sumCurr;
                    states.Add("N/A");
                }
                else
                {
                    if (sumCurr > sumLast)
                    {
                        states.Add("inc");
                    }
                    else if(sumCurr == sumLast)
                    {
                        states.Add("eq");
                    }
                    else
                    {
                        states.Add("dec");
                    }
                    sumLast = sumCurr;
                }
            }

            int count = states.Count(x => x == "inc");
            Console.WriteLine($"Result is {count} - coppied to clipboard");
            Clipboard.SetText(count.ToString());
        }
    }
}