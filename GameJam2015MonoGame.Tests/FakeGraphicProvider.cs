namespace GameJam2015MonoGame.Tests
{
    internal class FakeGraphicProvider : IGraphicProvider
    {
        public FakeGraphicProvider()
        {
        }

        public int TimesDrawCalled { get; private set; }

        public void Draw()
        {
            TimesDrawCalled++;
        }
    }
}