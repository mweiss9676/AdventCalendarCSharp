using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

//This code "works" but produces an answer that is consistently off by 10 for an undetermined reason.
namespace Day14
{
    public class Part2
    {
        static Queue<char> Regions = new Queue<char>(new char[] { '2', '3', '4', '5', '6', '7', '8', '9' });
        static char letter;
        static char[][] inputArray = new char[127][];

        static int count = 0;


        public static void Run()
        {
            WebClient client = new WebClient();

            Stream stream = client.OpenRead("https://raw.githubusercontent.com/mweiss9676/AdventCalendarCSharp/master/inputs/knothash_input_day14_2.txt");
            //Stream streamTEST = client.OpenRead("https://raw.githubusercontent.com/mweiss9676/AdventCalendarCSharp/master/inputs/knothash_input_day14_2_TEST.txt");

            StreamReader file = new StreamReader(stream);

            //this assignment in the if statement is a major pain in the ass, don't forget it!!!
            if ((inputArray[0] = file.ReadLine().ToArray()) != null)
            {
                for (int i = 1; i < 127; i++)
                {
                    inputArray[i] = file.ReadLine().ToArray();
                }
            }
            file.Close();

            for (int verticalPosition = 0; verticalPosition < inputArray.Length; verticalPosition++)
            {
                for (int horizontalPosition = 0; horizontalPosition < inputArray[verticalPosition].Length; horizontalPosition++)
                {
                    if (Regions.Contains(inputArray[verticalPosition][horizontalPosition]) || inputArray[verticalPosition][horizontalPosition] == '0')
                    {
                        continue;
                    }
                    if (inputArray[verticalPosition][horizontalPosition] == '1')
                    {
                        count++;
                        letter = Regions.Dequeue();
                        FloodFill(verticalPosition, horizontalPosition);
                    }

                    if (!Regions.Contains(letter))
                    {
                        Regions.Enqueue(letter);
                    }
                }
            }

            Console.SetWindowSize(130, 35);//sets the appropriate width to display the regions

            //colors the regions and prints them to console.
            foreach (char[] ch in inputArray)
            {
                foreach (char c in ch)
                {
                    if (c == '0')
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (c == '2')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (c == '3')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '4')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '5')
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '6')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '7')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '8')
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    if (c == '9')
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(c);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            Console.WriteLine($"And the total number of regions is {count}.");

        }

        //checks the array for 1's and changes the 1's
        public static void FloodFill(int i, int j)
        {
            //current position in the input array is defined by int a and b
            //if c is equal to '1' then great
            //else move on to the next one

            int verticalPosition = i;
            int horizontalPosition = j;


            characterChanger(ref inputArray[verticalPosition][horizontalPosition]);


            if (horizontalPosition - 1 >= 0 && inputArray[verticalPosition][horizontalPosition - 1] == '1')
            {
                FloodFill(verticalPosition, horizontalPosition - 1);
            }
            if (horizontalPosition + 1 < inputArray[verticalPosition].Length && inputArray[verticalPosition][horizontalPosition + 1] == '1')
            {
                FloodFill(verticalPosition, horizontalPosition + 1);
            }
            if (verticalPosition + 1 < inputArray.Length && inputArray[verticalPosition + 1][horizontalPosition] == '1')
            {
                FloodFill(verticalPosition + 1, horizontalPosition);
            }
            if (verticalPosition - 1 >= 0 && inputArray[verticalPosition - 1][horizontalPosition] == '1')
            {
                FloodFill(verticalPosition - 1, horizontalPosition);
            }

        }

        public static void characterChanger(ref char c)
        {
            c = letter;
        }
    }
}
