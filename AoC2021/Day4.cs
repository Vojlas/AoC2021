using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoC2021
{
    class Day4 : Day
    {
        public override Status completed()
        {
            return Status.simple;
        }

        public override string name()
        {
            return "day4";
        }

        public Day4()
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

        private BingoManager ConvertValues(string[] vs)
        {
            /* First line is drawn numbers
             * Boards 5x5 devided by empty line
             */
            BingoManager bm = new BingoManager();

            string[] s = vs[0].Split(',');
            foreach (string ss in s)
            {
                bm.numbers.Add(Convert.ToInt32(ss));
            }

            BingoBoard[] bingoBoards = new BingoBoard[(int)Math.Ceiling((vs.Length - 1) / 6.0)];
            bingoBoards[0] = new BingoBoard();
            int boardCounter = 0;
            for (int i = 2; i < vs.Length; i++)
            {

                vs[i] = vs[i].Replace("  ", " ");

                string[] Snums = vs[i].Trim().Split(' ');
                if (Snums[0] != "")
                {
                    int[] nums = new int[Snums.Length];
                    for (int g = 0; g < Snums.Length; g++)
                    {
                        nums[g] = Convert.ToInt32(Snums[g]);
                    }
                    bingoBoards[boardCounter].numBoardRows.Add(nums);
                }
                else
                {
                    boardCounter++;
                    if ((int)Math.Ceiling((vs.Length - 1) / 6.0) == boardCounter) break;
                    bingoBoards[boardCounter-1].assembleBoard();
                    bingoBoards[boardCounter] = new BingoBoard();
                }
            }
            bm.bg = bingoBoards.ToList();

            return bm;
        }

        private void solve(BingoManager bm)
        {
            /* Bingo 5x5 grid
             */
            foreach (int num in bm.numbers)
            {
                foreach (BingoBoard bb in bm.bg)
                {
                    int x = -1;
                    x = bb.markNumber(num);
                    if (x != -1 && x != 0)
                    {
                        //Console.WriteLine($"XXX is {}");
                        Console.WriteLine($"Result is {x}");
                        Clipboard.SetText((x).ToString());
                        break;
                    }
                }
            }
           
        }

        private void solveAdvanced(object x)
        {
            /*
             */

            //Console.WriteLine($"XXX is {}");
            //Console.WriteLine($"Result is {}");
            //Clipboard.SetText((xxx).ToString());
        }

        class BingoManager
        {
            public List<BingoBoard> bg { get; set; }
            public List<int> numbers { get; set; }

            public BingoManager()
            {
                this.bg = new List<BingoBoard>();
                this.numbers = new List<int>();
            }
        }
        class BingoBoard
        {
            //5x5 ints
            public int[,] NumBoard = new int[5, 5];
            private int[,] MarkBoard = new int[5, 5];
            public List<int[]> numBoardRows = new List<int[]>();

            public int markNumber(int number)
            {
                for (int row = 0; row < NumBoard.GetLength(0); row++)
                {
                    for (int column = 0; column < NumBoard.GetLength(1); column++)
                    {
                        if (NumBoard[row, column] == number) { MarkBoard[row, column] = 1; }
                    }
                }

                if (checkForBingo())
                {
                    int sum = 0;

                    for (int row = 0; row < NumBoard.GetLength(0); row++)
                    {
                        for (int column = 0; column < NumBoard.GetLength(1); column++)
                        {
                            if (MarkBoard[row, column] != 1)
                            {
                                sum += NumBoard[row, column];
                            }
                        }
                    }

                    return sum * number;
                }
                return -1;
            }

            private bool checkForBingo()
            {
                //Check column
                for (int row = 0; row < NumBoard.GetLength(0); row++)
                {
                    int sum = 0;
                    for (int column = 0; column < NumBoard.GetLength(1); column++)
                    {
                        sum += MarkBoard[row, column];
                    }
                    if (sum == 5)
                    {
                        return true;
                    }
                }

                //Check row
                for (int row = 0; row < NumBoard.GetLength(1); row++)
                {
                    int sum = 0;
                    for (int column = 0; column < NumBoard.GetLength(0); column++)
                    {
                        sum += MarkBoard[column, row];
                    }
                    if (sum == 5)
                    {
                        return true;
                    }
                }

                return false;
            }

            internal void assembleBoard()
            {
                for (int row = 0; row < this.numBoardRows.Count(); row++)
                {
                    for (int num = 0; num < this.numBoardRows.ElementAt(row).Length; num++)
                    {
                        this.NumBoard[row, num] = this.numBoardRows.ElementAt(row).ElementAt(num);
                    }
                }
            }
        }
    }
}
