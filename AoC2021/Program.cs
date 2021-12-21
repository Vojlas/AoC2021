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


            Console.WriteLine("\n");
            foreach (Day day in days)
            {
                Console.WriteLine(day.name() + " - " + day.completed());
            }
            Console.ReadLine();
        }
    }
}
