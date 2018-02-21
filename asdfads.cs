using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar2017
{
    public class asdfads
    {
        static Dictionary<string, string> someDict = new Dictionary<string, string>();

        public static void Main(string[] args)
        {
            someDict["...#"] = "###..###.";

            if (someDict.ContainsKey("...#"))
            {
                Console.WriteLine("it's there");
            }
            else
            {
                Console.WriteLine("it's not there");
            }
        }
    }
}
