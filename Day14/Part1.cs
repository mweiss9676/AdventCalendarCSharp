using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day10;

//this program written to achieve this: http://adventofcode.com/2017/day/14
namespace Day14
{
    public class Part1
    {
        static int globalcount = 0;

        public static void Run()
        {
            NumberTheInputs("stpzcrnm"); // this is the real input
            //NumberTheInputs("flqrgnkx"); //this is the example/testing input
        }

        //creates a list of strings of the required value to be hashed and appends them with the digits 0-127
        //also creates a new list of the values 0-255 for knothashing
        //then for some reason I call knothash from within this method
        static void NumberTheInputs(string inputToAddend)
        {
            List<string> inputs = new List<string>();

            string inputCopy = inputToAddend;

            for (int i = 0; i < 128; i++)
            {
                inputToAddend = inputCopy;
                inputToAddend += "-" + i.ToString();
                inputs.Add(inputToAddend);
            }

            int count = 0;

            foreach (string s in inputs)
            {
                List<int> numbers0To255 = Enumerable.Range(0, 256).ToList();

                List<int> AsciiConverted = AsciiConverter(s);

                List<int> KnotHashed = Day10.Part2.KnotHash(input: numbers0To255, rules: AsciiConverted);

                List<int> bitWiseInts = Day10.Part2.BitwiseXOR(KnotHashed);

                string result = Day10.Part2.ConvertToHex(bitWiseInts);

                string binary = convertToBinary(result);

                Console.WriteLine(binary);

                CountOnes(binary);

                count++;
            }

            Console.WriteLine(globalcount);


        }

        //creates an ASCII conversion of each NumberTheInputs string (i.e. stpzcrnm-1 becomes 115 116 112 122 99 114 110 109 45 49 17 31 73 47 23)
        public static List<int> AsciiConverter(string rule)
        {
            List<int> converted = new List<int>();

            //concatenate all integers in rules as comma separated values in a string

            foreach (char c in rule)
            {
                //converting characters to integers creates their ASCII counterparts
                int unicode = c;
                converted.Add(unicode);
            }

            //add this end sequence as provided by the instructions
            int[] endSequence = { 17, 31, 73, 47, 23 };

            converted.AddRange(endSequence);
            return converted;
        }

        public static string convertToBinary(string hexvalue)
        {
            string result = "";

            foreach (char c in hexvalue)
            {
                switch(c)
                {
                    case '1':
                        result += "0001";
                        break;
                    case '2':
                        result += "0010";
                        break;
                    case '3':
                        result += "0011";
                        break;
                    case '4':
                        result += "0100";
                        break;
                    case '5':
                        result += "0101";
                        break;
                    case '6':
                        result += "0110";
                        break;
                    case '7':
                        result += "0111";
                        break;
                    case '8':
                        result += "1000";
                        break;
                    case '9':
                        result += "1001";
                        break;
                    case '0':
                        result += "0000";
                        break;
                    case 'a':
                        result += "1010";
                        break;
                    case 'b':
                        result += "1011";
                        break;
                    case 'c':
                        result += "1100";
                        break;
                    case 'd':
                        result += "1101";
                        break;
                    case 'e':
                        result += "1110";
                        break;
                    case 'f':
                        result += "1111";
                        break;
                    default:
                        Console.WriteLine("something went wrong");
                        break;
                }
            }

            return result;

        }

        //counts all the ones in the denseHash list by converting them to strings and seeing the chars in the strings are 1'inputToAddend
        //if so they add their particular number of 1'inputToAddend to the global static variable global count and write this information to the console.
        static void CountOnes(string input)
        {
            foreach (char c in input)
            {
                if (c == '1')
                {
                    globalcount++;
                }
            }
        }
    }
}
