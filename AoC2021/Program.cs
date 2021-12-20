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
            
            Day1 day1 = new Day1();
            days.Add(day1);

            foreach (Day day in days)
            {
                Console.WriteLine(day.name() + " - " + day.completed());
            }
            Console.ReadLine();
        }
    }
}
