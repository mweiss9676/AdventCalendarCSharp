using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar2017
{
    public class Day19
    {
        static int totalSteps = 0;
        static int lineCount;
        static char[][] input;
        static List<char> pathTaken = new List<char>();
        static char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        static void Main(string[] args)
        {
            //To use test input, need to add "TEST" to the end of file path, and change 'N' to 'F'
            StreamReader sr = new StreamReader(@"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day19.txt");
            lineCount = File.ReadLines(@"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day19.txt").Count();


            input = new char[lineCount][];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = sr.ReadLine().ToCharArray();
            }

            for (int y = 0; y < lineCount; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    if (input[y][x] == '|')
                    {
                        Down(y, x);
                        break;
                    }
                }
            }
        }

        static void Down(int y, int x)
        {
            while (input[y][x] != '+')
            {
                if(letters.Contains(input[y][x]))
                {
                    pathTaken.Add(input[y][x]);
                    if (input[y][x] == 'N')
                    {
                        PrintPath();
                    }
                }
                totalSteps++;
                y++;
            }
            NewDirection(y, x, 'd');
        }
        static void Up(int y, int x)
        {
            while (input[y][x] != '+')
            {
                if (letters.Contains(input[y][x]))
                {
                    pathTaken.Add(input[y][x]);
                    if (input[y][x] == 'N')
                    {
                        PrintPath();
                    }
                }
                totalSteps++;
                y--;
            }
            NewDirection(y, x, 'u');
        }
        static void Left(int y, int x)
        {
            while (input[y][x] != '+')
            {
                if (letters.Contains(input[y][x]))
                {
                    pathTaken.Add(input[y][x]);
                    if (input[y][x] == 'N')
                    {
                        PrintPath();
                    }
                }
                totalSteps++;
                x--;
            }
            NewDirection(y, x, 'l');
        }
        static void Right(int y, int x)
        {
            while (input[y][x] != '+')
            {
                if (letters.Contains(input[y][x]))
                {
                    pathTaken.Add(input[y][x]);
                    if (input[y][x] == 'N')
                    {
                        PrintPath();
                    }
                }
                totalSteps++;
                x++;
            }
            NewDirection(y, x, 'r');
        }
        static void NewDirection(int y, int x, char lastDirection)
        {
            totalSteps++;
            bool canGoDown = y + 1 < input.Length;
            bool canGoUp = y - 1 >= 0;
            bool canGoLeft = x - 1 >= 0;
            bool canGoRight = x + 1 < input[y].Length;

            if (lastDirection == 'd' || lastDirection == 'u')
            {
                if (canGoLeft && input[y][x - 1] != ' ')
                {
                    Left(y, x - 1);
                }
                if (canGoRight && input[y][x + 1] != ' ')
                {
                    Right(y, x + 1);
                }
            }
            else 
            {
                if (canGoUp && input[y - 1][x] != ' ')
                {
                    Up(y - 1, x);
                }
                if (canGoDown && input[y + 1][x] != ' ')
                {
                    Down(y + 1, x);
                }
            }
 
        }

        static void PrintPath()
        {
            totalSteps++;
            foreach (char c in pathTaken)
            {
                Console.Write(c);
            }
            Console.WriteLine();
            Console.WriteLine(totalSteps);
            Console.WriteLine();
            Environment.Exit(0);
        }
    }
}
