namespace GameJam2015MonoGame.ContentLoaders
{
    public interface IContentLoader
    {
        T LoadContent<T>(string assetPath);
    }
}