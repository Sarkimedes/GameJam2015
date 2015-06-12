namespace GameJam2015MonoGame.Utility
{
    public interface IRandomNumberProvider
    {
        /// <summary>
        /// Gets a random number.
        /// </summary>
        /// <returns></returns>
        float GetRandomNumber(int inclusiveMin, int exclusiveMax);

        /// <summary>
        /// Gets a float between 0 and 1
        /// </summary>
        /// <returns></returns>
        float GetRandomFloat();
    }
}