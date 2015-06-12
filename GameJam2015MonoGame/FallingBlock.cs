namespace GameJam2015MonoGame
{
    public class FallingBlock
    {
        private IRandomNumberProvider _rng;

        public FallingBlock(IRandomNumberProvider rng)
        {
            this._rng = rng;
            this.XPosition = rng.GetRandomNumber();
        }

        public float XPosition { get; set; }
    }
}