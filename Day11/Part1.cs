using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Part1
    {
        //global variable to keep track of the furthest distance the "child program" wandered.
        static int furthestDistance = 0;

        public static void Run()
        {
            //grab the input from my file. Source @ http://adventofcode.com/2017/day/11
            try
            {
                //System.IO.StreamReader file = new System.IO.StreamReader(@"day13.txt");

                string input = System.IO.File.ReadAllText(@"day11.txt");
                someFunction(input);
            }
            catch (Exception e)
            {
                Console.WriteLine("that didn't work. See {0}:", e);
            }
        }
        static int someFunction(string input)
        {
            //split the string into an array of strings by their commas
            string[] array = input.Split(',').ToArray();

            //a hexagonal grid has 3 coordinates to keep track of in order to compute distances.
            //the source of this information is @https://www.redblobgames.com/grids/hexagons/
            int x = 0;
            int y = 0;
            int z = 0;

            foreach (string str in array)
            {
                switch (str)
                {
                    case "nw":
                        x++;
                        y--;
                        furthest(x, y, z);
                        break;
                    case "n":
                        x++;
                        z--;
                        furthest(x, y, z);
                        break;
                    case "ne":
                        y++;
                        z--;
                        furthest(x, y, z);
                        break;
                    case "sw":
                        y--;
                        z++;
                        furthest(x, y, z);
                        break;
                    case "s":
                        x--;
                        z++;
                        furthest(x, y, z);
                        break;
                    case "se":
                        x--;
                        y++;
                        furthest(x, y, z);
                        break;
                    default:
                        Console.WriteLine("something went wrong");
                        break;
                }
            }
            x = Math.Abs(x);
            y = Math.Abs(y);
            z = Math.Abs(z);

            //a clever way to return the max integer value between more than 2 values
            int result = new[] { x, y, z }.Max();

            Console.WriteLine("The absolute value of the largest coordinate, and therefore the distance along "
                + "a hexagonal grid is: {0}", result);
            return result;
        }
        //a method to update the global value 'furthestDisance' every time the largest of the absolute values of 
        //the three distances is larger than the previous.
        static void furthest(int x, int y, int z)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);
            z = Math.Abs(z);

            int max = new int[] { x, y, z }.Max();
            if (max > furthestDistance) { furthestDistance = max; Console.WriteLine(furthestDistance); }



        }
    }
}
