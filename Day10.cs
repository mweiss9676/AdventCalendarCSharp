using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//this program written to achieve this: http://adventofcode.com/2017/day/10
namespace AdventCalendar2017
{
    class Day10
    {
        public static void Main(string[] args)
        {
            List<int> input = new List<int>();
            for (int i = 0; i < 256; i++) { input.Add(i); }
            List<int> rules = new List<int> { 225, 171, 131, 2, 35, 5, 0, 13, 1, 246, 54, 97, 255, 98, 254, 110 };
            someFunction(input, rules);
        }

        static void someFunction(List<int> input, List<int> rules)
        {
            int sizeOfInput = input.Count;
            int skipNumber = 0;
            int subset = 0;
            int currentSubSetCount = 0;
            int currentPosition = 0;

            for (int j = 0; j < rules.Count; j++)
            {
                int currentPositionCopy = currentPosition;
                int currentPositionCopy2 = currentPosition;
                currentSubSetCount = rules[j];
                int subsetIterator = subset;
                List<int> copy2 = new List<int>();
                List<int> temp = new List<int>();

                for (int i = 0; i < sizeOfInput; i++)
                {
                    if (currentPosition < sizeOfInput)
                    {
                        copy2.Add(input[currentPosition]);

                    }
                    else
                    {
                        currentPosition = 0;
                        copy2.Add(input[currentPosition]);
                    }
                    currentPosition++;
                }
                temp = copy2.GetRange(0, currentSubSetCount);
                temp.Reverse();
                copy2.RemoveRange(0, currentSubSetCount);
                copy2.InsertRange(0, temp);

                for (int k = 0; k < sizeOfInput; k++)
                {
                    if (currentPositionCopy < sizeOfInput)
                    {
                        input[currentPositionCopy] = copy2[k];
                    }
                    else
                    {
                        currentPositionCopy = 0;
                        input[currentPositionCopy] = copy2[k];
                    }
                    currentPositionCopy++;
                }
                currentPosition = (currentSubSetCount + skipNumber + currentPositionCopy2) % sizeOfInput;
                currentPositionCopy2 = currentPosition;
                skipNumber++;
            }
            foreach (int i in input) { Console.Write(i + ","); }

        }
    }
}