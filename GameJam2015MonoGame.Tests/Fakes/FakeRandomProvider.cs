using System.ComponentModel;
using GameJam2015MonoGame.Utility;

namespace GameJam2015MonoGame.Tests.Fakes
{
    internal class FakeRandomProvider : IRandomNumberProvider
    {
        public static float DefaultValue
        {
            get { return 1; }
        }

        public float GetRandomNumber(int inclusiveMin, int exclusiveMax)
        {
            return DefaultValue;
        }

        public float GetRandomFloat()
        {
            return DefaultValue;
        }
    }
}