using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    public class Part1
    {
        static int totalSteps = 0;//keeps track of the total "steps" taken in the path      
        static int lineCount;//how "tall" the file is
        static char[][] input;
        static List<char> pathTaken = new List<char>();//a list holding the order in which Letters are encountered on the optimal path
        static char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public static void Run()
        {
            //To use test input, need to add "TEST" to the end of file path, and change 'N' to 'F'
            StreamReader sr = new StreamReader(@"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day19.txt");
            lineCount = File.ReadLines(@"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day19.txt").Count();

            //read each line into the char[][] input
            input = new char[lineCount][];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = sr.ReadLine().ToCharArray();
            }


            //the puzzle gurantees that the entry point will be at the top so this scans the puzzle
            //starting at the top for the entry point which will be "|" and initiates a Down method on that char
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

        //Four methods to handle the y and x coordinates of the current position in the map
        //each method continues along collecting any letters that show up and checking for the final letter of the puzzle
        //when a "+" is encountered we pass along to the NewDirection method which takes the y and x coordinates and the direction
        //that passed those coordinates to it in the form of a char. This is so we don't turn around an go backwards while deciding 
        //a new direction. (note: only one space surround the "+" along the opposite axis from the one passed in
        //will have a viable direction to travel in. That's why this works)
        static void Down(int y, int x)
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

        //We decide what direction to go in. The puzzle eliminates the possibility of travelling along the same axis
        //as a "+" always indicates a corner and only has one viable (within the index of the array) direction to travel in.
        static void NewDirection(int y, int x, char lastDirection)
        {
            totalSteps++;//a plus sign is still a step and must be counted

            //Determine whether going in any direction will throw an out of bounds exception
            bool canGoDown = y + 1 < input.Length;
            bool canGoUp = y - 1 >= 0;
            bool canGoLeft = x - 1 >= 0;
            bool canGoRight = x + 1 < input[y].Length;


            //figure out the new direction based on eliminating the old one and it's opposite
            //only one viable direction is available to call, so whichever direction contains a non-space char is that direction
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

        //called only when the final letter is found. Ends the program and prints out the total number of steps taken and the 
        //full path of letters in the order they were encountered. 
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
