using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar2017
{
    class Day17Part2
    {
        //Built to solve http://adventofcode.com/2017/day/17 

        //This is what the output at each increment of the index should produce
        //{0} currentIndex = 0; count = 1;
        //{0, (1)} currentIndex = 1; count = 2;
        //{0, (2), 1} currentIndex = 1; count = 3;
        //{0  2 (3) 1} currentIndex = 2; count = 4;
        //{0  2 (4) 3  1} currentIndex = 2; count = 5;
        //{0 (5) 2  4  3  1} currentIndex = 1; count = 6;

        //static List<int> spinLock = new List<int>(2018); //the starting state of the "spinLock" according to the instructions
        static List<int> spinLock = Enumerable.Repeat(0, 2018).ToList();

        static void Main(string[] args)
        {
           // spinLock[0] = 0;

            int currentIndex = 0; //the updated value storing the index of the last integer inserted into the list

            for (int numberToInsert = 1; numberToInsert < 2018 ; numberToInsert++)
            {
                int stepsForward = 4; // provided by the instructions + 1 to account for being zero indexed

                //if (currentIndex + stepsForward < numberToInsert)
                //{
                //    currentIndex += stepsForward;
                //}
                //else
                //{
                //    int stepsICanTakeWithoutGoingOver = numberToInsert - stepsForward;
                //    int stepsFromZero = stepsForward - stepsICanTakeWithoutGoingOver;
                //    currentIndex = stepsFromZero;
                //    //currentIndex = (stepsForward - (numberToInsert - currentIndex)) + 1;
                //}

                while (stepsForward > 0) // a way to keep track of how many steps I can continue to take while updating my current index
                {
                    stepsForward--;

                    if (numberToInsert - currentIndex > 1) // if within the bounds of my list
                    {
                        currentIndex++;
                    }
                    else // if past the bounds of the size of the list, we simply reset the current index to 0 and continue
                    {
                        currentIndex = 0;
                    }
                }



                //spinLock.Insert(currentIndex, numberToInsert); //inserts the current number between 0 and 2018 into the current index, bumping back any other integers
                //spinLock[currentIndex] = numberToInsert;
                spinLock.RemoveAt(currentIndex);
                spinLock[currentIndex] = numberToInsert;

            }

            Console.WriteLine(spinLock[spinLock.IndexOf(2017) + 1]);
            //if (spinLock.IndexOf(2017) + 1 < spinLock.Count)
            //{
            //    Console.WriteLine(spinLock[spinLock.IndexOf(2017) + 1]);
            //}
            //else
            //{
            //    Console.WriteLine(spinLock[0]);
            //}

            foreach (int i in spinLock)
            {
                Console.WriteLine(i);
            }

        }
    }
}
