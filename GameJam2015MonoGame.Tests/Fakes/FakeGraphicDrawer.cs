using Windows.UI;
using System;
using GameJam2015MonoGame.GraphicDrawers;

namespace GameJam2015MonoGame.Tests.Fakes
{
    internal class FakeGraphicDrawer : IGraphicDrawer
    {
        public FakeGraphicDrawer()
        {
        }

        public int TimesDrawCalled { get; private set; }

        public void Draw(float x, float y)
        {
            TimesDrawCalled++;
        }
    }
}