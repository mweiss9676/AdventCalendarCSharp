using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//written to solve http://adventofcode.com/2017/day/12
namespace Day_12
{
    public class Part1
    {
        //from stackoverflow suggestion @https://stackoverflow.com/questions/47907811/trying-to-parse-a-text-file-line-by-line-and-split-lines-into-a-jagged-array-of
        //using the LINQ library to parse the file line by line 
        static string[][] input = File.ReadAllLines(@"day12.txt")
          .Select(x => x.Split(' '))
          .ToArray();

        public static void Run()
        {
            //using a hash to prevent repeated values and to get an accurate count
            //using the stack to make use of popping and pushing to check each line
            HashSet<int> hash = new HashSet<int>();
            Stack<int> stack = new Stack<int>();

            //define the string pattern I am basing my regex off of
            string pattern = @"\d";

            for (int i = 0; i < input.Length;)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    //get rid of all but the digits in the file
                    input[i][j] = Regex.Replace(input[i][j], "[^0-9]", "");
                    Match match = Regex.Match(input[i][j], pattern);
                    if (match.Success)
                    {
                        int current = Int32.Parse(input[i][j]);

                        //check if the hash contains the number already to prevent having to check the same values 
                        //multiple times
                        if (!hash.Contains(current))
                        {
                            stack.Push(current);
                        }
                        hash.Add(current);
                    }
                }
                if (stack.Count > 0) { i = stack.Pop(); }
                else { Console.WriteLine(hash.Count()); return; }
            }
        }
    }
}
