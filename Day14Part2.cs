using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar2017
{
    class Day14Part2
    {
        static Queue<char> Regions = new Queue<char>(new char[] { '2', '3', '4', '5' });
        static List<char> position = new List<char>();


        static void Main(string[] args)
        {
            char[][] inputArray = new char[127][];
            StreamReader file = new StreamReader(@"C:\Users\Michael\Desktop\knothash_input_day14_2_TEST.txt");

            //this assignment in the if statement is a major pain in the ass, don't forget it!!!
            if ((inputArray[0] = file.ReadLine().ToArray()) != null)
            {
                for (int i = 1; i < 127; i++)
                {
                    inputArray[i] = file.ReadLine().ToArray();
                }
            }
            file.Close();

            FindOnes(inputArray);

            //Console.WriteLine(inputArray[1][4]);
            //Console.WriteLine();
            //Console.WriteLine();
            //used for testing the input
            //
            foreach (char[] ch in inputArray)
            {
                foreach (char c in ch) { Console.Write(c); }
                Console.WriteLine();
            }
            foreach (int i in position) { Console.WriteLine(i + " "); }
        }

        static void FindOnes(char[][] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    char letter;
                    if (i + 1 < inputArray.Length && Regions.Contains(inputArray[i + 1][j])) { letter = inputArray[i + 1][j]; }
                    else if (i - 1 >= 0 && Regions.Contains(inputArray[i - 1][j])) { letter = inputArray[i - 1][j]; }
                    else if (j + 1 < inputArray[i].Length && Regions.Contains(inputArray[i][j + 1])) { letter = inputArray[i][j + 1]; }
                    else if (j - 1 >= 0 && Regions.Contains(inputArray[i][j - 1])) { letter = inputArray[i][j - 1]; }
                    else if (Regions.Contains(inputArray[i][j])) { letter = inputArray[i][j]; }
                    else
                    {
                        letter = Regions.Dequeue();
                    }

                    if (inputArray[i][j] == '1' || inputArray[i][j] == '2' || inputArray[i][j] == '3' || inputArray[i][j] == '4' || inputArray[i][j] == '5')
                    {
                        FloodFill(ref inputArray[i][j], letter);
                        int count = 0;

                        while (i + 1 < inputArray.Length && inputArray[i + 1][j] == '1')
                        {
                            count++;
                            i++;
                            FloodFill(ref inputArray[i][j], letter);
                        }
                        i -= count;
                        count = 0;
                        while (i - 1 >= 0 && inputArray[i - 1][j] == '1')
                        {
                            count++;
                            i--;
                            FloodFill(ref inputArray[i][j], letter);
                        }
                        i += count;
                        count = 0;
                        while (j + 1 < inputArray[i].Length && inputArray[i][j + 1] == '1')
                        {
                            count++;
                            j++;
                            FloodFill(ref inputArray[i][j], letter);
                        }
                        j -= count;
                        count = 0;
                        while (j - 1 >= 0 && inputArray[i][j - 1] == '1')
                        {
                            count++;
                            j--;
                            FloodFill(ref inputArray[i][j], letter);
                        }
                        j += count;
                    }

                    Regions.Enqueue(letter);
                }
            }
        }

        static void FloodFill(ref char c, char letter)
        {
            char temp = letter;
            c = temp;
        }
    }
}
