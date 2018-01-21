using System;

namespace AdventCalendar2017
{
    //Written to solve http://adventofcode.com/2017/day/15 Part 1
    class Day15
    {
        static void Main (string[] args)
        {
            //int testing1 = 65, testing2 = 8921; 
            int seedA = 289, seedB = 629, numberOfCycles = 40000000; //numbers provided by the website, the seeds are generators of hashing algorithms
            Console.WriteLine(MathCheck(seedA, seedB, numberOfCycles));
        }

        static int MathCheck (long a, long b, int numberOfCycles)
        {
            int count = 0; //used to count the number of matching strings of binary hashes. This is the return value.

            long generatorA = 16807, generatorB = 48271, divideBy = 2147483647; //provided by the website for use in hashing our seeds
            long genAPreviousState = a, genBPreviousState = b; //the number updated on each cycle of the hash

            for (int i = numberOfCycles - 1; i >= 0; i--)
            {
                string GeneratorAString = Convert.ToString((generatorA * genAPreviousState) % divideBy, 2).PadLeft(32).Remove(0, 16); //the binary string of the previous state after the hashing algorithm
                string GeneratorBString = Convert.ToString((generatorB * genBPreviousState) % divideBy, 2).PadLeft(32).Remove(0, 16);
                genAPreviousState = (generatorA * genAPreviousState) % divideBy; //the hashing algorithm
                genBPreviousState = (generatorB * genBPreviousState) % divideBy;

                if (GeneratorAString.Equals(GeneratorBString)) // Checks to see if each string matches the other. Increments the count when the match.
                {
                    count++;
                }
            }
            return count;
        }
    }
}
