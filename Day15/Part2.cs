using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Created to solve http://adventofcode.com/2017/day/15 Part 2
namespace Day15
{
    public class Part2
    {
        //create 2 arrays of size 5 million to store the first 5 million binary string results of both of our hashes
        static string[] GeneratorAStringArray = new string[5_000_000];
        static string[] GeneratorBStringArray = new string[5_000_000];

        public static void Run()
        {
            //int testing1 = 65, testing2 = 8921;
            int real1 = 289, real2 = 629;
            int numberOfCycles = 40_000_000;

            Console.WriteLine(MathCheck(real1, real2, numberOfCycles));
        }

        //take our starting seeds and generate binary hashes based on their divisibility by 4 and 8 respectively
        static int MathCheck(long seedA, long seedB, int numberOfCycles)
        {
            int count = 0; // to return the number of matching binary hashes


            int A_Array_Incrementer = 0; //these are used for counting up to 5 million to ensure we have the proper number of binary strings to compare
            int B_Array_Incrementer = 0;

            long generatorA = 16807, generatorB = 48271, divideBy = 2147483647;  //numbers given to us by the problem. Used in the hashing
            long genAPreviousState = seedA, genBPreviousState = seedB; //updated with each cycle of the hash starting with the seed values provided by the website


            //40 million cycles to generate the 5 million binary hashes
            for (int i = 0; i < numberOfCycles; i++)
            {
                if (genAPreviousState % 4 == 0)
                {
                    if (A_Array_Incrementer < 5_000_000) //increment up to 5 million
                    {
                        GeneratorAStringArray[A_Array_Incrementer] = Convert.ToString(genAPreviousState, 2).PadLeft(32).Remove(0, 16); //convert numbers to binary and leave only the lowest 16 digits
                        A_Array_Incrementer++;
                    }
                }
                genAPreviousState = (generatorA * genAPreviousState) % divideBy; //the hashing algorithm provided by the website

            }

            //all the same as above
            for (int i = 0; i < numberOfCycles; i++)
            {

                if (genBPreviousState % 8 == 0)
                {
                    if (B_Array_Incrementer < 5_000_000)
                    {
                        GeneratorBStringArray[B_Array_Incrementer] = Convert.ToString(genBPreviousState, 2).PadLeft(32).Remove(0, 16);
                        B_Array_Incrementer++;
                    }
                }
                genBPreviousState = (generatorB * genBPreviousState) % divideBy;
            }


            //compare the first 5 million results and increment the count for each match. Return the count as the result.
            for (int i = 0; i < 5000000; i++)
            {
                if (GeneratorAStringArray[i].SequenceEqual(GeneratorBStringArray[i]))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
