using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//used to solve http://adventofcode.com/2017/day/16 Part 2 detailed in the commented block below
namespace Day16
{
    public class Part2
    {
        static string stringOfDancingPrograms = "abcdefghijklmnop"; //our string of "programs" which will "dance" by being shuffled per instructions
        static string stringOfDancingProgramsCopy = "abcdefghijklmnop";//cbolhmkgfpenidaj

        public static void Run()
        {
            StreamReader sr = new StreamReader(@"C:\Users\Michael Weiss\repo-ster\AdventCalendarCSharp\inputs\Day16input.txt");

            //put the entire file into a string then separate that string into arrays of strings
            //based on their commas
            string text = sr.ReadToEnd();
            string[] danceInstructions = text.Split(',');

            //
            // ------------------------------Day 16 Part 2 code here---------------------------------------
            //
            // This code asks us to find the result after 1 BILLION dances or hashes
            // The key realization is that the code cycles after 60 (in my case) dances
            // So the anwer to the question is to divide 1 billion by 60 and then using the 
            // modulo of that same division as the number of extra times you need to
            // run your hash or dance to find the proper order of program-dancers ("abcd...")

            int count = 0;

            //Console.WriteLine(1_000_000_000 / 60 + " " + 1_000_000_000 % 60); this is used for the above obviously
            //                          returns 16_666_666 and 40

            for (int i = 0; i < 40; i++)
            {
                if (stringOfDancingPrograms == stringOfDancingProgramsCopy)
                {
                    //Console.WriteLine(i); was used to figure out the "cycle"
                    count++;
                }
                Dancing(danceInstructions);

            }
            //Console.WriteLine(count - 1); was used to figure out the "cycle"


            //
            //
            //--------------------------------End of the Part 2 code---------------------------------------
            //
            //




            Console.WriteLine(stringOfDancingPrograms);//print the result of the "dance"
        }
        static void Dancing(string[] danceInstructions)
        {
            for (int i = 0; i < danceInstructions.Length; i++)//for every index of the array that hold the dance instructions
            {
                if (danceInstructions[i][0] == 's')//we check every index for it's dance instruction char, it will always be the first char
                {
                    string temp = danceInstructions[i];
                    temp = temp.Remove(0, 1);//get rid of the dance instruction char, leaving us with only the number 
                    int numberOfProgramsToMove = int.Parse(temp);

                    //replace the string of programs with a concatenation of the last x number of programs 
                    //(determined by the previous steps number) followed by the first group up to that number
                    stringOfDancingPrograms = stringOfDancingPrograms.Substring(stringOfDancingPrograms.Length - numberOfProgramsToMove)
                                    + stringOfDancingPrograms.Substring(0, stringOfDancingPrograms.Length - numberOfProgramsToMove);
                }
                else if (danceInstructions[i][0] == 'x')
                {
                    string temp = danceInstructions[i];
                    string[] instructions = temp.Remove(0, 1).Split('/');//remove the first instruction, leaving us with an array of numbers
                    int firstIndexToSwap = int.Parse(instructions[0]);//  which indicate which indexes to swap
                    int secondIndexToSwap = int.Parse(instructions[1]);
                    char firstCharToSwap = stringOfDancingPrograms[firstIndexToSwap];
                    char secondCharToSwap = stringOfDancingPrograms[secondIndexToSwap];

                    //remove the index indicated above and replace with the other index's char
                    stringOfDancingPrograms = stringOfDancingPrograms.Remove(firstIndexToSwap, 1);
                    stringOfDancingPrograms = stringOfDancingPrograms.Insert(firstIndexToSwap, secondCharToSwap.ToString());
                    //rinse, repeat
                    stringOfDancingPrograms = stringOfDancingPrograms.Remove(secondIndexToSwap, 1);
                    stringOfDancingPrograms = stringOfDancingPrograms.Insert(secondIndexToSwap, firstCharToSwap.ToString());
                }

                //basically the same as above with different rules for which indexes to grab 
                //(this time based on the index of the char indicated by the rules)
                else if (danceInstructions[i][0] == 'p')
                {
                    string temp = danceInstructions[i];
                    string[] instructions = temp.Remove(0, 1).Split('/');
                    int firstIndexToSwap = stringOfDancingPrograms.IndexOf(instructions[0]);
                    int secondIndexToSwap = stringOfDancingPrograms.IndexOf(instructions[1]);
                    char firstCharToSwap = stringOfDancingPrograms[firstIndexToSwap];
                    char secondCharToSwap = stringOfDancingPrograms[secondIndexToSwap];
                    stringOfDancingPrograms = stringOfDancingPrograms.Remove(firstIndexToSwap, 1);
                    stringOfDancingPrograms = stringOfDancingPrograms.Insert(firstIndexToSwap, secondCharToSwap.ToString());
                    stringOfDancingPrograms = stringOfDancingPrograms.Remove(secondIndexToSwap, 1);
                    stringOfDancingPrograms = stringOfDancingPrograms.Insert(secondIndexToSwap, firstCharToSwap.ToString());

                }
            }
        }
    }
}
