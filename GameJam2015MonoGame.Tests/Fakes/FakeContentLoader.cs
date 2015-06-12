namespace GameJam2015MonoGame.Tests.Fakes
{
    public class FakeContentLoader : IContentLoader
    {
        public int TimesLoadCalled { get; private set; }
        public T LoadContent<T>(string assetPath)
        {
            TimesLoadCalled++;
            return default(T);
        }
    }
}