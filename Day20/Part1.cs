using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20
{
    public class Part1
    {
        public static void Run()
        {
            //"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day20TEST.txt"
            //"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day20.txt"

            StreamReader sr = new StreamReader(@"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day20.txt");

            int lineCount = File.ReadAllLines(@"C:\Users\Michael Weiss\Documents\repo-ster\Advent_of_Code_2017\AdventCalendarCSharp\inputs\Day20.txt").Count();

            List<Particle> particles = new List<Particle>();

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

                particles.Add(new Particle(name,
                              positionCoordinates, velocityCoordinates, accelerationCoordinates));
            }

            OneThousandIterations(particles);
        }

        static long DistanceFromOriginCalculator(Particle p)
        {
            long distance = p.Position.Aggregate((x, y) => Math.Abs(x) + Math.Abs(y));
            //Console.WriteLine($"{p.Name} is {distance} far from the origin.");
            return distance;
        }

        static void OneThousandIterations(List<Particle> particles)
        {
            Dictionary<Particle, long> positions = new Dictionary<Particle, long>();

            for (int i = 0; i < 10000; i++)
            {
                foreach (Particle p in particles)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        p.Velocity[j] += p.Acceleration[j];
                        p.Position[j] += p.Velocity[j];
                    }
                    if (positions.ContainsKey(p))
                    {
                        positions[p] = DistanceFromOriginCalculator(p);
                    }
                    else
                    {
                        positions.Add(p, DistanceFromOriginCalculator(p));
                    }
                }
                //Console.WriteLine();
            }

            ClosestParticle(positions);
        }

        static void ClosestParticle(Dictionary<Particle, long> positions)
        {
            long smallest = positions.Values.Min();
            Particle myKey = positions.FirstOrDefault(x => x.Value == smallest).Key;
            Console.WriteLine($"The Particle closest to the origin is: {myKey.Name} at a distance of {smallest}");
        }
    }
}
