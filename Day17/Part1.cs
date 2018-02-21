using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Built to solve http://adventofcode.com/2017/day/17 
namespace Day17
{
    public class Part1
    {
        //This is what the output at each increment of the index should produce
        //{0} currentIndex = 0; count = 1;
        //{0, (1)} currentIndex = 1; count = 2;
        //{0, (2), 1} currentIndex = 1; count = 3;
        //{0  2 (3) 1} currentIndex = 2; count = 4;
        //{0  2 (4) 3  1} currentIndex = 2; count = 5;
        //{0 (5) 2  4  3  1} currentIndex = 1; count = 6;


        public static void Run()
        {
            List<int> spinLock = new List<int> { 0, }; //the starting state of the "spinLock" according to the instructions

            Console.WriteLine(SpinLockCycle(spinLock));
        }

        static int SpinLockCycle(List<int> spinLock)
        {
            int numberAfter2017 = 0;//  the number being returned after 2018 cycles. This number occupies the index after the index of the number 2017

            int currentIndex = 0; //the updated value storing the index of the last integer inserted into the list

            for (int numberToInsert = 1; numberToInsert < 2018; numberToInsert++)
            {
                int stepsForward = 304; // provided by the instructions + 1 to account for being zero indexed

                while (stepsForward > 0) // a way to keep track of how many steps I can continue to take while updating my current index
                {
                    stepsForward--;

                    if (spinLock.Count - currentIndex > 1) // if within the bounds of my list
                    {
                        currentIndex++;
                    }
                    else // if past the bounds of the size of the list, we simply reset the current index to 0 and continue
                    {
                        currentIndex = 0;
                    }
                }

                spinLock.Insert(currentIndex, numberToInsert); //inserts the current number between 0 and 2018 into the current index, bumping back any other integers

            }

            numberAfter2017 = spinLock[spinLock.IndexOf(2017) + 1]; //assigns the number in the index after the index of 2017 (i.e. the number requested) 

            return numberAfter2017;
        }
    }
}
