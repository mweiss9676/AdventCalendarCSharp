using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day21
{
    public class Part1
    {
        static Dictionary<string, string> instructions = new Dictionary<string, string>();

        static string fullInput = "#..#........#..#";
        static string size2String = "";
        static string size3String = "";


        //static List<string> size3List = new List<string>();
        //static List<string> size2List = new List<string>();


        static int count = 0, iterations = 4;

        public static void Run()
        {
            //test
            //StreamReader sr = new StreamReader(@"day21TEST.txt");

            //real
            StreamReader sr = new StreamReader(@"day21.txt");

            List<string[]> inputOutput = new List<string[]>();
            while (!sr.EndOfStream)
            {
                Regex pattern = new Regex(@"(?:=>)");
                string eachLine = sr.ReadLine();
                inputOutput.Add(pattern.Split(eachLine));
            }

            for (int i = 0; i < inputOutput.Count; i++)
            {
                //inputOutput[i] == string[] == {"../.#", "##./#../..."}

                //inputOutput[i][0] == string == "../.#"
                //inputOutput[i][1] == string == "##./#../..."
                string temp1 = inputOutput[i][0].Replace("/", "");
                string temp2 = inputOutput[i][1].Replace("/", "");
                //temp1 == string[] == {"..", ".#"}
                //temp2 == string[] == {"##.", "#..", "..."}

                temp1 = temp1.Trim();
                temp2 = temp2.Trim();
                instructions[temp1] = temp2;
            }
            Start(fullInput);
        }

        private static void Start(string input)
        {
            size2String = "";
            size3String = "";

            if (count == iterations)
            {
                Console.WriteLine($"The final is {input}");
                CountPountSigns(input);
            }
            count++;

            if (input.Length % 2 == 0)
            {
                List<string> inputInSetsOfFour = new List<string>();

                double size = input.Length;
                int squareRoot = (int)Math.Sqrt(size);

                for (int i = 0; i < input.Length; i += (squareRoot * 2))
                {
                    for (int j = i; j < squareRoot + i; j += 2)
                    {
                        inputInSetsOfFour.Add(input.Substring(j, 2) + input.Substring(j + squareRoot, 2));
                    }
                }

                foreach (string s in inputInSetsOfFour)
                {
                    Size2FlipperRotator(s);
                }
                //size2List.Clear();
                RefactorEvensIntoThrees();
                //Start(size2String);
            }
            else if (input.Length % 3 == 0)
            {
                List<string> inputInSetsOfThree = new List<string>();
                double size = input.Length;
                int squareRoot = (int)Math.Sqrt(size);

                for (int i = 0; i < input.Length; i += (squareRoot * 3))
                {
                    for (int j = i; j < squareRoot + i; j += 3)
                    {
                        inputInSetsOfThree.Add(input.Substring(j, 3) + input.Substring(j + squareRoot, 3) + input.Substring(j + (2 * squareRoot), 3));
                    }
                }
                // .#. | ..# | ###
                //      0           9          18
                //input	.#.#....# | #....##.# | .#.##.#.. | ##...#### | #.##..### | #.##..### | #.##..### | ##...#### | .#.##.#..
                foreach (string s in inputInSetsOfThree)
                {
                    Size3FlipperRotator(s);
                }
                //size3List.Clear();
                //RefactorEvens();
                //Start(size3String);
            }
            else
            {
                Console.WriteLine("Something went wrong, string wasn't size 2 or 3");
            }
        }

        private static void NameUndecided(string input)
        {
            string temp = "";

            int size = input.Length;
            int squareRoot = (int)Math.Sqrt(size);
            //int quarter = size / 4;
            int half = size / 2;

            for (int i = 0; i < size; i += half)
            {
                for (int j = i; j < squareRoot + i; j += 2)
                {
                    temp += input.Substring(j, 2) + input.Substring(j + squareRoot, 2);
                }
            }
            //int size = size3String.Length;
            //int half = size / 2;
            //int squareRoot = (int)Math.Sqrt(size3String.Length);
            //int halfSquareRoot = squareRoot / 2;

            //for (int i = 0; i < size; i += half)
            //{
            //    for (int j = i; j < squareRoot + halfSquareRoot + i; j += 3)
            //    {
            //        temp += size2String.Substring(j, 3) + size2String.Substring((j + squareRoot + halfSquareRoot), 3);
            //    }
            //}
            Start(temp);
        }

        private static void RefactorEvensIntoThrees()
        {
            string temp = "";
            int size = size2String.Length;
            int squareRoot = (int)Math.Sqrt(size);
            int third = size / 3;
            int half = size / 2;
            int quarter = size / 4;

            for (int i = 0; i < size; i += half)
            {
                for (int j = 0; j < quarter; j += 3)
                {
                    temp += size2String.Substring(j, 3) + size2String.Substring(j + quarter, 3);
                }
            }
            Start(temp);
        }

        private static void Size3FlipperRotator(string input)
        {
            List<string> temp = new List<string>();

            string original = input;
            string originalReversed = new string(original.ToCharArray().Reverse().ToArray());
            string firstOfEach = input[6].ToString() + input[3] + input[0] + input[7] + input[4] + input[1] + input[8] + input[5] + input[2];
            string firstOfEachReversed = new string(firstOfEach.ToCharArray().Reverse().ToArray());
            string originalFlipped = input.Substring(6, 3) + input.Substring(3, 3) + input.Substring(0, 3);
            string originalFlippedReversed = new string(originalFlipped.ToCharArray().Reverse().ToArray());
            string firstOfEachFlipped = firstOfEach.Substring(6, 3) + firstOfEach.Substring(3, 3) + firstOfEach.Substring(0, 3);
            string firstOfEachFlippedReversed = new string(firstOfEachFlipped.ToCharArray().Reverse().ToArray());

            temp.Add(original);
            temp.Add(originalReversed);
            temp.Add(originalFlipped);
            temp.Add(originalFlippedReversed);
            temp.Add(firstOfEach);
            temp.Add(firstOfEachFlipped);
            temp.Add(firstOfEachFlippedReversed);
            temp.Add(firstOfEachReversed);

            foreach (string s in temp)
            {
                if (instructions.ContainsKey(s))
                {
                    size3String += instructions[s];
                    break;
                }
            }
        }

        private static void Size2FlipperRotator(string input)
        {
            List<string> temp = new List<string>();

            string original = input;
            string originalReversed = new string(original.ToCharArray().Reverse().ToArray());
            string firstOfEach = original[2].ToString() + original[0] + original[3] + original[1];
            string firstOfEachReversed = new string(firstOfEach.ToCharArray().Reverse().ToArray());
            string originalFlipped = original.Substring(2, 2) + original.Substring(0, 2);
            string originalFlippedReversed = new string(originalFlipped.ToCharArray().Reverse().ToArray());
            string firstOfEachFlipped = firstOfEach.Substring(2, 2) + firstOfEach.Substring(0, 2);
            string firstOfEachFlippedReversed = new string(firstOfEachFlipped.ToCharArray().Reverse().ToArray());

            temp.Add(original);
            temp.Add(originalReversed);
            temp.Add(originalFlipped);
            temp.Add(originalFlippedReversed);
            temp.Add(firstOfEach);
            temp.Add(firstOfEachFlipped);
            temp.Add(firstOfEachFlippedReversed);
            temp.Add(firstOfEachReversed);

            foreach (string s in temp)
            {
                if (instructions.ContainsKey(s))
                {
                    size2String += instructions[s];
                    break;
                }
            }
        }

        private static void CountPountSigns(string input)
        {
            int counter = 0;
            foreach (char c in input)
            {
                if (c == '#')
                {
                    counter++;
                }
            }
            Console.WriteLine($"And the total number of # signs is {counter}");
            Environment.Exit(0);
        }
    }
}
