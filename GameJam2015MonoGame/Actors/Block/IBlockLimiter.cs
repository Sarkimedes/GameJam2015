namespace GameJam2015MonoGame.Actors.Block
{
    public interface IBlockLimiter
    {
        bool IsPastLimit(float position);
    }
}