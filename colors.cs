using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar2017
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // This program demonstrates all colors and backgrounds.
            //
            Type type = typeof(ConsoleColor);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var name in Enum.GetNames(type))
            {
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(type, name);
                Console.WriteLine(name);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("We all float down here");
            }
            //Console.BackgroundColor = ConsoleColor.Black;
            //foreach (var name in Enum.GetNames(type))
            //{
            //    Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);
            //    Console.WriteLine(name);
            //}
        }
    }

}
