﻿namespace GameJam2015MonoGame.Tests
{
    internal class FakeGraphicProvider : IGraphicProvider
    {
        public FakeGraphicProvider()
        {
        }

        public int TimesDrawCalled { get; private set; }

        public int TimesLoadContentCalled { get; private set; }

        public void LoadContent()
        {
            TimesLoadContentCalled++;
        }

        public void Draw(float xPosition, float yPosition)
        {
            TimesDrawCalled++;
        }
    }
}