using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This class written to solve http://adventofcode.com/2017/day/18
namespace Day18
{
    public class Part1
    {
        //instantiate the variable names and associated values in dictionary form 
        //so that they can be accessed by their string equivalents in the input file
        //must be longs because of the chance of numbers too large created by the loop
        static Dictionary<string, long> registers = new Dictionary<string, long>
        {
            { "a", 0 },
            { "b", 0 },
            { "i", 0 },
            { "p", 0 },
            { "f", 0 },
        };


        static long lastSoundPlayed = 0; //class level storage of the last long stored
        static long finalAnswer = 0;//when rcv finally executes this grabs the last value stored in lastSoundPlayed

        static int temporaryJ;//the third piece of the string must often be parsed to an int. This is where
        static string temporaryLetter;//it's information is temporarily stored so that on the next iteration
        static bool hasLetterChanged = false;//it can be restored. hasLetterChanged just lets me know if I need to change it back
        
        public static void Run()
        {
            //Actual input below
            StreamReader sr = new StreamReader(@"day18.txt");

            //Below is the testing input. Above the actual input.
            //StreamReader sr = new StreamReader(@"day18TEST.txt");


            //The next 15 lines just read the input and store it in a 2D array of strings
            string temp = sr.ReadToEnd();

            string[] temporaryArray = temp.Split(
                                      new[] { "\r\n", "\r", "\n" },
                                      StringSplitOptions.None);

            string[][] instructions = new string[temporaryArray.Length][];


            for (int j = 0; j < temporaryArray.Length; j++)
            {
                instructions[j] = temporaryArray[j].Split(
                                  new[] { " " },
                                  StringSplitOptions.None);
            }



            //A dictionary of strings with actions as the values
            //setup to automatically check the input for keywords and apply the associated function
            Dictionary<string, Action<string, long>> ActionDictionary = new Dictionary<string, Action<string, long>>
            {
                { "set", Set },
                { "add", Add },
                { "mul", Mul },
                { "mod", Mod },
            };



            for (int j = 0; j < instructions.Length; j++)
            {
                if (hasLetterChanged)// reset the instructions line, after having changed it in the last iteration
                {
                    instructions[temporaryJ][2] = temporaryLetter;
                    hasLetterChanged = false;
                }


                //The next 15 lines handle the two functions which have no third "argument" which would otherwise
                //cause the associated action to create an exception

                if (instructions[j][0] == "snd")//stores the latest "sound" in lastSoundPlayed
                {
                    lastSoundPlayed = registers[instructions[j][1]];
                    continue;
                }
                if (instructions[j][0] == "rcv")//Where the program terminates. Only if the second piece of the array is 0.
                {
                    if (registers[instructions[j][1]] != 0)
                    {
                        finalAnswer = lastSoundPlayed;
                        Console.WriteLine(finalAnswer);
                        return;
                    }
                    continue;//must continue so that other instructions are not accidentally executed.
                }

                //If the instructions at position 3 is a letter instead of a "long" 
                //then this block changes that lettler to its associated value for the duration of the iteration
                //changed back because it trips the hasLetterChanged bool at the beginning of the loop
                if (!IsInt(instructions[j][2]))
                {
                    hasLetterChanged = true;
                    temporaryJ = j;
                    temporaryLetter = instructions[j][2];
                    instructions[j][2] = registers[instructions[j][2]].ToString();
                }


                //Because actions cannot return a value, jgz must be handled here as well
                if (instructions[j][0] == "jgz")
                {
                    if (!IsInt(instructions[j][1]))//see if I should parse it as an int or check the dictionary for it
                    {
                        if (registers[instructions[j][1]] > 0)//per the instructions the value here must be greater than zero
                        {
                            j += int.Parse(instructions[j][2]);
                            j--;//decrement the result because the next iteration of the loop will increment it
                            continue;
                        }
                        continue;
                    }
                    else
                    {
                        if (int.Parse(instructions[j][1]) > 0)
                        {
                            j += int.Parse(instructions[j][2]);
                            j--;//decrement the result because the next iteration of the loop will increment it.
                            continue;
                        }
                        continue;
                    }
                }

                //run the appropriate action value based on the string key in the ActionDictionary dictionary
                ActionDictionary[instructions[j][0]](instructions[j][1], int.Parse(instructions[j][2]));

            }
        }

        private static bool IsInt(string s)
        {
            int x = 0;
            return int.TryParse(s, out x);
        }

        private static void Mod(string arg1, long arg2)
        {
            registers[arg1] %= arg2;
        }

        private static void Mul(string arg1, long arg2)
        {
            registers[arg1] *= arg2;
        }

        private static void Add(string arg1, long arg2)
        {
            registers[arg1] += arg2;
        }

        private static void Set(string arg1, long arg2)
        {
            registers[arg1] = arg2;
        }
    }
}
