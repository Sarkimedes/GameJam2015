namespace GameJam2015MonoGame.Tests
{
    internal class FakeRandomProvider : IRandomNumberProvider
    {
        public float GetRandomNumber()
        {
            return 1;
        }
    }
}