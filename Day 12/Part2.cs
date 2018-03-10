using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

//Written to achieve this http://adventofcode.com/2017/day/12
namespace Day_12
{
    public class Part2
    {
        //from stackoverflow suggestion @https://stackoverflow.com/questions/47907811/trying-to-parse-a-text-file-line-by-line-and-split-lines-into-a-jagged-array-of
        //using the LINQ library to parse the file line by line 

        //ACTUAL DATA HERE
        static string[][] input = File.ReadAllLines(@"day12.txt")
          .Select(x => x.Split(' '))
          .ToArray();

        //TEST DATA BELOW
        //static string[][] input = File.ReadAllLines(@"day12TEST.txt")
        //  .Select(x => x.Split(' '))
        //  .ToArray();

        public static void Run()
        {
            //using a hash table to prevent repeated values and to get an accurate count
            //using the stack to make use of popping and pushing to check each line
            SortedSet<int> hash;
            Stack<int> stack = new Stack<int>();
            List<SortedSet<int>> allSets = new List<SortedSet<int>>();

            //define the string pattern I am basing my regex off of
            string pattern = @"\d";

            for (int k = 0; k < input.Length; k++)
            {
                hash = new SortedSet<int>();
                for (int i = k; i < input.Length;)
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
                    else { allSets.Add(hash); break; }
                }
            }

            //once allsets has been populated with all of the sorted sets in "hash" we check each one to see if it is 
            //setequal to another and if it is we remove it, leaving us with just the unique values in our allsets.count
            //this is super ugly code... my apologies to my future self.
            for (int i = 0; i < allSets.Count - 1; i++)
            {
                for (int j = i + 1; j < allSets.Count; j++)
                {
                    if (allSets[i].SetEquals(allSets[j]))
                    {
                        allSets.Remove(allSets[i]);
                        i--;
                        break;
                    }
                }
            }
            Console.WriteLine("The number of unique sets in allSets is: {0}", allSets.Count);

        }
    }
}
