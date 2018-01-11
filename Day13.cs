using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventCalendar2017
{
    class Day13
    {
        static void Main(string[] args)
        {
            double count = 0;
            List<KeyValuePair> keyValuePairList = new List<KeyValuePair>();
            char myExpression = ':';
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"c:/users/michael/desktop/day13.txt");

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
            //for (int j = 0; j < 1000; j++)
            //{
            //    double count = 0;
            //    int finishLine = j + 93;
            //    for (int i = j; i < finishLine; i++)
            //    {
            //        foreach (KeyValuePair kp in keyValuePairList)
            //        {
            //            if (kp.index == i && (i - j) % ((kp.range * 2) - 2) == 0)
            //            {
            //                count += (kp.range * kp.index);
            //            }
            //        }
            //    }
            //    Console.WriteLine("the count is: {0} at an offset value of: {1}", count, j);
            //}
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
