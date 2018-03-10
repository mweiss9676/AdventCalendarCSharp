using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Day13
{
    public class Part1
    {
        public static void Run()
        {
            double count = 0;
            List<KeyValuePair> keyValuePairList = new List<KeyValuePair>();
            char myExpression = ':';
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"day13.txt");

                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] eachLine = line.Split(myExpression);
                    KeyValuePair kp = new KeyValuePair(Convert.ToDouble(eachLine[0]), Convert.ToDouble(eachLine[1]));
                    keyValuePairList.Add(kp);
                }
                file.Close();


            }
            catch (Exception e) { Console.WriteLine("try again: {0}", e); }

            for (double i = 0; i < 93; i++)
            {
                foreach (KeyValuePair kp in keyValuePairList)
                {
                    if (kp.index == i && i % ((kp.range * 2) - 2) == 0)
                    {
                        count += (kp.range * kp.index);
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
    class KeyValuePair
    {
        public double index;
        public double range;
        public KeyValuePair(double index, double range)
        {
            this.index = index;
            this.range = range;
        }
    }
}
