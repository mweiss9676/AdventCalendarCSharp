using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Part2
    {
        //denseHash will be what we convert for out final output so I have made it class level and static
        //it is designed to hold our 16 XOR'd numbers
        static List<int> denseHash = new List<int>();

        public static void Run()
        {
            //create a list populated with the numbers 0-255 as per the instructions
            List<int> input = new List<int>();
            for (int i = 0; i < 256; i++)
            {
                input.Add(i);
            }

            //a list to hold our "lengths" that we are basing our iterations on
            List<int> rules = new List<int> { 225, 171, 131, 2, 35, 5, 0, 13, 1, 246, 54, 97, 255, 98, 254, 110 };
            //List<int> rules = new List<int> { 1, 2, 4 };

            List<string> conversionToString = rules.Select(x => x.ToString()).ToList();

            //run a KnotHash function on our list of 255 numbers sequential, and our "lengths" converted to their ASCII counterparts
            List<int> KnotHashed = KnotHash(input, AsciiConverter(conversionToString));


            //write the results of our 16 denseHash elements as their hexadecimal counterparts. The "x2" is the conversion and the 
            //number of relevant digits respectively.
            List<int> bitwised = BitwiseXOR(KnotHashed);

            string result = ConvertToHex(bitwised);

            Console.WriteLine(result);
        }

        public static List<int> AsciiConverter(List<string> rules)
        {
            List<int> converted = new List<int>();
            int size = rules.Count();

            //concatenate all integers in rules as comma separated values in a string
            string rulesString = string.Join(",", rules.ToArray());

            foreach (char c in rulesString)
            {
                //converting characters to integers creates their ASCII counterparts
                int unicode = c;
                converted.Add(unicode);
            }
            rules.RemoveRange(0, size);

            //add this end sequence as provided by the instructions
            int[] endSequence = { 17, 31, 73, 47, 23 };

            converted.AddRange(endSequence);
            return converted;
        }

        public static List<int> BitwiseXOR(List<int> input)
        {
            //temp is a temporary storage place for our XOR function to act upon. It holds our input 16 digits at a time.
            List<int> returnList = new List<int>();
            List<int> temp;
            int length = input.Count();

            //iterate over the input 16 digits at a time
            for (int i = 0; i < length; i += 16)
            {
                //create a new list called Temp to store each unique set of 16 ints each time i iterate to the next 16
                temp = new List<int>();

                //add each successive 16 digits into a list called temp
                for (int j = i; j < i + 16; j++)
                {
                    temp.Add(input[j]);
                }

                //lambda function to perform the same function over an entire collection and return one result.
                //In this case the ^ or XOR function
                int XOR = temp.Aggregate((x, y) => x ^ y);

                //add each XOR aggregate integer to our denseHash list of 16 ints
                returnList.Add(XOR);
            }
            return returnList;
        }

        public static List<int> KnotHash(List<int> input, List<int> rules)
        {
            int sizeOfInput = input.Count;
            int skipNumber = 0;
            int currentSubSetCount = 0;
            int currentPosition = 0;

            //our original solution to Part 1, with the addition of running it 64 times
            for (int z = 0; z < 64; z++)
            {
                for (int j = 0; j < rules.Count; j++)
                {
                    int currentPositionCopy = currentPosition;
                    int currentPositionCopy2 = currentPosition;
                    currentSubSetCount = rules[j];
                    List<int> copy2 = new List<int>();
                    List<int> temp = new List<int>();

                    for (int i = 0; i < sizeOfInput; i++)
                    {
                        //if currentPosition is less than the size of the input then simply add that digit into copy2
                        //otherwise the position must be set to zero (the next position "after" the last index) and the process cont.
                        //this is to keep the current subset at index 0 and make it easier to reverse the subset without dealing with
                        //whether the subset goes out of bounds by being "longer" than the list
                        if (currentPosition < sizeOfInput)
                        {
                            copy2.Add(input[currentPosition]);

                        }
                        else
                        {
                            currentPosition = 0;
                            copy2.Add(input[currentPosition]);
                        }

                        //increment the current position as per the instructions
                        currentPosition++;
                    }

                    //copy the subset based on the current "length" in rules into a temp list to be reversed
                    //then remove that subset from copy2 and replace it with the reversed list
                    temp = copy2.GetRange(0, currentSubSetCount);
                    temp.Reverse();
                    copy2.RemoveRange(0, currentSubSetCount);
                    copy2.InsertRange(0, temp);


                    //this iteration is copying copy2 back into input based on the position moving forward by the skipsize and the 
                    //current length as per the instructions. It copies the zero index of copy2 into the proper index after "moving"
                    //of input
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

                    //this calculation updates the current position based on the skipnumber and the current "length"
                    currentPosition = (currentSubSetCount + skipNumber + currentPositionCopy2) % sizeOfInput;
                    currentPositionCopy2 = currentPosition;
                    skipNumber++;
                }
            }
            return input;
        }

        public static string ConvertToHex(List<int> input)
        {
            string result = "";

            foreach (int i in input)
            {
                result += i.ToString("x2");
            }

            return result;
        }
    }
}
