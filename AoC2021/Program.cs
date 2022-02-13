using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            List<Day> days = new List<Day>();
            
            Day1 day1 = new Day1(); days.Add(day1);
            Day2 day2 = new Day2(); days.Add(day2);
            Day3 day3 = new Day3(); days.Add(day3);
            Day4 day4 = new Day4(); days.Add(day4);
            //Day5 day5 = new Day5(); days.Add(day5);
            //Day6 day6 = new Day6(); days.Add(day6);
            //Day7 day7 = new Day7(); days.Add(day7);
            //Day8 day8 = new Day8(); days.Add(day8);
            //Day9 day9 = new Day9(); days.Add(day9);
            


            Console.WriteLine("\n");
            foreach (Day day in days)
            {
                Console.WriteLine(day.name() + " - " + day.completed());
            }
            Console.ReadLine();
        }
    }

    public enum Status {
        none,
        simple,
        completed
    }
}
