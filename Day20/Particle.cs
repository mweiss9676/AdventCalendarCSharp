using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20
{
    public class Particle
    {
        public Particle(string name, long[] position, long[] velocity, long[] acceleration)
        {
            this.Name = name;
            this.Position = position;
            this.Velocity = velocity;
            this.Acceleration = acceleration;
        }

        public string Name { get; set; }

        public long[] Position { get; set; }

        public long[] Acceleration { get; set; }

        public long[] Velocity { get; set; }
    }
}
