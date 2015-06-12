namespace GameJam2015MonoGame.Tests.Fakes
{
    internal class FakeRandomProvider : IRandomNumberProvider
    {
        public float GetRandomNumber()
        {
            return 1;
        }
    }
}