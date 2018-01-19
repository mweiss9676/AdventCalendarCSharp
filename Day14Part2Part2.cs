using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar2017
{
    class Day14Part2Part2
    {
        static Queue<char> Regions = new Queue<char>(new char[] { '2', '3', '4', '5', '6', '7', '8'});
        static char letter;
        static char[][] inputArray = new char[127][];
        static char compare;


        static void Main(string[] args)
        {
            StreamReader file = new StreamReader(@"C: \Users\Michael Weiss\Desktop\knothash_input_day14_2_TEST.txt");

            //this assignment in the if statement is a major pain in the ass, don't forget it!!!
            if ((inputArray[0] = file.ReadLine().ToArray()) != null)
            {
                for (int i = 1; i < 127; i++)
                {
                    inputArray[i] = file.ReadLine().ToArray();
                }
            }
            file.Close();

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    if (Regions.Contains(inputArray[i][j]))
                    {
                        continue;
                    }
                    if (inputArray[i][j] == '1')
                    {
                        letter = Regions.Dequeue();
                        FloodFill(i, j);
                    }
                    compare = letter;
                    if (compare != Regions.Peek())
                    {

                        Regions.Enqueue(letter);
                    }
                }
            }

            //colors the regions and prints them to console.
            foreach (char[] ch in inputArray)
            {
                foreach (char c in ch)
                {
                    //Console.Write(c);
                    if (c == '0')
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (c == '2')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (c == '3')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '4')
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '5')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '6')
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '7')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '8')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                }
                Console.WriteLine();
            }
        }

        //checks the array for 1's and changes the 1's
        public static void FloodFill(int a, int b)
        {
            //current position in the input array is defined by int a and b
            //if c is equal to '1' then great
            //else move on to the next one

            int horizontalPosition = a;
            int verticalPosition = b;


            characterChanger(ref inputArray[horizontalPosition][verticalPosition]);


            if (verticalPosition - 1 >= 0 && inputArray[horizontalPosition][verticalPosition - 1] == '1')
            {
                FloodFill(horizontalPosition, verticalPosition - 1);
            }
            if (verticalPosition + 1 < inputArray[horizontalPosition].Length && inputArray[horizontalPosition][verticalPosition + 1] == '1')
            {
                FloodFill(horizontalPosition, verticalPosition + 1);
            }
            if (horizontalPosition + 1 < inputArray.Length && inputArray[horizontalPosition + 1][verticalPosition] == '1')
            {
                FloodFill(horizontalPosition + 1, verticalPosition);
            }
            if (horizontalPosition - 1 >= 0 && inputArray[horizontalPosition - 1][verticalPosition] == '1')
            {
                FloodFill(horizontalPosition - 1, verticalPosition);
            }

        }

        public static void characterChanger(ref char c)
        {
            c = letter;            
        }
    }
}




