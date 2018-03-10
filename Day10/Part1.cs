using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Part1
    {
        public static void Run()
        {
            List<int> integersToHash = new List<int>();

            for (int i = 0; i < 256; i++)
            {
                integersToHash.Add(i);
            }

            List<int> rules = new List<int> { 225, 171, 131, 2, 35, 5, 0, 13, 1, 246, 54, 97, 255, 98, 254, 110 };

            Console.WriteLine(KnotHash(integersToHash, rules));
        }


        static int KnotHash(List<int> integersToHash, List<int> rules)
        {
            int result = 0;
            int integersToHashSize = integersToHash.Count;
            int skipNumber = 0;
            int subset = 0;
            int currentSubSetSize = 0;
            int currentIndex = 0;

            for (int i = 0; i < rules.Count; i++)//iterate through all of the rules of the hashing algorithm
            {
                int copyOfCurrentIndex1 = currentIndex;//we need two extra copies of this index value because it is used to iterate through our
                int copyOfCurrentIndex2 = currentIndex;//loops and also to calculate its own next value

                currentSubSetSize = rules[i];
                int subsetIterator = subset;
                List<int> copyOfIntegersToHash = new List<int>();

                for (int j = 0; j < integersToHashSize; j++)//iterate through the numbers to hash (0 - 255)
                {
                    if (currentIndex < integersToHashSize)//while the current index is less than the the size of the integersToHash we 
                                                          //simply copy each digit to the 0th index of the copy list
                    {
                        copyOfIntegersToHash.Add(integersToHash[currentIndex]);
                    }
                    else                                     //if the current index goes out of the bounds of the list we update the 
                                                             //current index to zero and continue adding the nums 0-255 to our copy
                    {
                        currentIndex = 0;
                        copyOfIntegersToHash.Add(integersToHash[currentIndex]);
                    }
                    currentIndex++;
                }

                List<int> temp = new List<int>(); //a list used to reverse the subset
                temp = copyOfIntegersToHash.GetRange(0, currentSubSetSize);//we grab the subset indicated by our rules and reverse it
                temp.Reverse();
                copyOfIntegersToHash.RemoveRange(0, currentSubSetSize);//we replace our copy of 0-255 list with our reversed numbers starting
                copyOfIntegersToHash.InsertRange(0, temp);             //with the 0th index


                for (int j = 0; j < integersToHashSize; j++)
                {
                    if (copyOfCurrentIndex1 < integersToHashSize)//while the current index is within the bounds of the list we copy
                    {                                            //the values in the copy of our main list back into the official list
                        integersToHash[copyOfCurrentIndex1] = copyOfIntegersToHash[j];
                    }
                    else                                         //once the current index would go out of bounds of the array we reset the index
                    {                                            //and continue to add the copy values back into the official list
                        copyOfCurrentIndex1 = 0;
                        integersToHash[copyOfCurrentIndex1] = copyOfIntegersToHash[j];
                    }
                    copyOfCurrentIndex1++;
                }

                currentIndex = (currentSubSetSize + skipNumber + copyOfCurrentIndex2) % integersToHashSize; //this algorithm properly updates
                copyOfCurrentIndex2 = currentIndex;                                                         //the current index, accounting for
                skipNumber++;                                                                               //the zero indexing of our algorithm
            }

            result = integersToHash[0] * integersToHash[1];//as per the instructions the result of the hash
            return result;                                 //is the product of the first 2 values of the list 0-255
        }

    }
}
