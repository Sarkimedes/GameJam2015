using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam2015MonoGame
{
    internal class BlockPositionRandomizer : IRandomNumberProvider
    {
        private static readonly Random Random = new Random();
        public float GetRandomNumber(int inclusiveMin, int exclusiveMax)
        {
            return Random.Next(inclusiveMin, exclusiveMax);
        }

        public float GetRandomFloat()
        {
            return (float)Random.NextDouble();
        }
    }
}
