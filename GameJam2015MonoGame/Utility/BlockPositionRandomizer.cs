using System;

namespace GameJam2015MonoGame.Utility
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
