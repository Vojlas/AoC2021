using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC2021
{
    class Day2 : Day
    {
        public Day2()
        {
            if (this.completed() != "advanced")
            {
                GetPath();
                solve(this.ConvertValues(ReadFile()));
            }
            else if (this.completed() == "simple")
            {
                solveAdvanced(this.ConvertValues(ReadFile()));
            }
        }

        public override string completed()
        {
            return "simple";
        }

        public override string name()
        {
            return "Day2";
        }

        private List<Tuple<string, int>> ConvertValues(string[] vs)
        {
            List<Tuple<string, int>> instructions = new List<Tuple<string, int>>();
            foreach (string item in vs)
            {
                string[] x = item.Split(' ');
                instructions.Add(new Tuple<string, int>(x[0], Convert.ToInt32(x[1])));
            }
            return instructions;
        }

        private void solve(List<Tuple<string, int>> instructions)
        {
            /*Commands:
             * forward X - increse horizontal position
             * down X - increse depth
             * up X - decrese depth
             * 
             * Input: planned course (set of instructions)
             * 
             * Init:
             * Horizontal position = 0
             * Depth = 0
             * 
             * Output follow instruction than multiple horizontalPos and depth
             */
            int horizontalPosiotion = 0;
            int depth = 0;

            foreach (Tuple<string, int> inst in instructions)
            {
                switch (inst.Item1)
                {
                    case "forward":
                        horizontalPosiotion += inst.Item2;
                        break;
                    case "down":
                        depth += inst.Item2;
                        break;
                    case "up":
                        depth -= inst.Item2;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Reached distance of {horizontalPosiotion} and current depth {depth}");
            Console.WriteLine($"output is {horizontalPosiotion * depth}");
            Clipboard.SetText((horizontalPosiotion * depth).ToString());
        }
        private void solveAdvanced(object v)
        {
            throw new NotImplementedException();
        }
    }
}
