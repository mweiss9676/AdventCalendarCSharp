using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventCalendar2017.Day20Classes;

namespace AdventCalendar2017
{
    public class Day20Part2
    {
        static List<Particle> everyParticleLeft = new List<Particle>();

        static void Main(string[] args)
        {
            //"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day20TEST.txt"
            //"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day20.txt"

            StreamReader sr = new StreamReader(@"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day20.txt");

            int lineCount = File.ReadAllLines(@"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day20.txt").Count();

            //List<Particle> particles = new List<Particle>();

            for (int i = 0; i < lineCount; i++)
            {
                string name = "particle" + i;
                string[] eachLine = sr.ReadLine().Split('<', '>');
                string position = eachLine[1];
                string velocity = eachLine[3];
                string acceleration = eachLine[5];

                long[] positionCoordinates = Array.ConvertAll(position.Split(',').ToArray(), long.Parse);
                long[] velocityCoordinates = Array.ConvertAll(velocity.Split(',').ToArray(), long.Parse);
                long[] accelerationCoordinates = Array.ConvertAll(acceleration.Split(',').ToArray(), long.Parse);

                everyParticleLeft.Add(new Particle(name,
                              positionCoordinates, velocityCoordinates, accelerationCoordinates));
            }

            OneThousandIterations();
        }

        static void OneThousandIterations()
        {
           // Dictionary<Particle, long> positions = new Dictionary<Particle, long>();

            for (int i = 0; i < 1000; i++)
            {
                foreach (Particle p in everyParticleLeft)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        p.Velocity[j] += p.Acceleration[j];
                        p.Position[j] += p.Velocity[j];
                    }
                }
                ParticleCollideChecker();
            }
            Console.WriteLine(everyParticleLeft.Count);
        }

        static void ParticleCollideChecker()
        {
            for (int i = 0; i < everyParticleLeft.Count; i++)
            {
                bool needToRemoveFirstOccurence = false;

                Particle firstOccurrence = everyParticleLeft[i];

                for (int j = i + 1; j < everyParticleLeft.Count; j++)
                {
                    Particle compare = everyParticleLeft[j];

                    if (firstOccurrence.Position.SequenceEqual(compare.Position))
                    {
                        needToRemoveFirstOccurence = true;
                        everyParticleLeft.Remove(compare);
                        j--;
                    }
                }
                if (needToRemoveFirstOccurence)
                {
                    everyParticleLeft.Remove(firstOccurrence);
                    i--;
                }
            }
        }
    }
}
