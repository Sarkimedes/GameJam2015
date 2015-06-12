namespace GameJam2015MonoGame.Tests.Fakes
{
    public class FakeBlockLimiter : IBlockLimiter
    {
        public FakeBlockLimiter()
        {
            this.PastLimitValue = false;
        }

        public bool IsPastLimit(float position)
        {
            return PastLimitValue;
        }

        public bool PastLimitValue { get; set; }
    }
}