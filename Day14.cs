using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//UGLIEST CODE EVERRRRRRRRR!!!!!!!
//this program written to achieve this: http://adventofcode.com/2017/day/14
namespace AdventCalendar2017
{
    class Day14
    {
        //denseHash will be what we convert for out final output so I have made it class level and static
        //it is designed to hold our 16 XOR'd numbers
    

        static int globalcount = 0;
        static int row = 0;

        public static void Main(string[] args)
        {
            //create a list populated with the numbers 0-255 as per the instructions

            InputIfied("stpzcrnm");
        }

        //creates a list of strings of the required value to be hashed and appends them with the digits 0-127
        //also creates a new list of the values 0-255 for knothashing
        //then for some reason I call knothash from within this method
        static void InputIfied(string s)
        {
            List<int> input;
            string inputCopy = s;
            for (int i = 0; i < 128; i++)
            {
                input = new List<int>();
                for (int j = 0; j < 256; j++) { input.Add(j); }
                s = inputCopy;
                s += "-" + i;
                KnotHash(input: input, rules: AsciiConverter(s.ToCharArray()));
            }

        }

        //creates an ASCII conversion of each InputIfied string (i.e. stpzcrnm-1 becomes 115 116 112 122 99 114 110 109 45 48 17 31 73 47 23)
        static List<int> AsciiConverter(char[] rules)
        {
            List<int> rulesReturn = new List<int>();
            int size = rules.Count();

                foreach (char c in rules)
                {
                    //Console.WriteLine(c);
                    //converting characters to integers creates their ASCII counterparts
                    int unicode = c;
                    rulesReturn.Add(unicode);
                }

            //add this end sequence as provided by the instructions
            int[] endSequence = { 17, 31, 73, 47, 23 };

            rulesReturn.AddRange(endSequence);
            Console.WriteLine("ascii is: ");
            rulesReturn.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            return rulesReturn;
        }

        //got here from KnotHash method
        //XORs each KnotHashed result and stores the XORs in a denseHash list
        //calls the final method CountOnes to count all of the 1's in the denseHash
        static void BitwiseXOR(List<int> input)
        {
            List<int> denseHash = new List<int>();

            //temp is a temporary storage place for our XOR function to act upon. It holds our input 16 digits at a time.
            List<int> temp;
            int length = input.Count();

            //iterate over the input 16 digits at a time
            for (int i = 0; i < length; i += 16)
            {
                //create a new list called Temp to store each unique set of 16 ints each time i iterates to the next 16
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
                denseHash.Add(XOR);
            }
            Console.WriteLine("every value in hex is: ");
            denseHash.ForEach(x => Console.Write("{0} ", x.ToString("x2")));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("every value post-Xor is: ");
            denseHash.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine();
            denseHash.ForEach(x => Console.Write("{0} ", Convert.ToString(x, 2)));
            Console.WriteLine("end row");
            CountOnes(denseHash);

            
        }

        //counts all the ones in the denseHash list by converting them to strings and seeing the chars in the strings are 1's
        //if so they add their particular number of 1's to the global static variable global count and write this information to the console.
        static void CountOnes(List<int> d)
        {
            List<string> copy = new List<string>();
            foreach (int i in d)
            {
                copy.Add((Convert.ToString(i, 2)));
            }

            copy.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            int count = 0;
            foreach (string s in copy)
            {
                foreach (char c in s)
                {
                    if (c.Equals('1'))
                    {
                        count++;
                    }
                }
            }

            globalcount += count;
            Console.WriteLine("count is: {0} and row is {1}", count, row);
            row++;
            Console.WriteLine("global count is: " + globalcount);
        }

        //code from Day10 part2
        //got here from the Inputified method
        //calls BitwiseXOR method on the result of this
        static void KnotHash(List<int> input, List<int> rules)
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
            BitwiseXOR(input);
        }
    }
}