﻿using GameJam2015MonoGame.ContentLoaders;
using GameJam2015MonoGame.GraphicDrawers;
using GameJam2015MonoGame.GraphicProviders;

namespace GameJam2015MonoGame.Tests.Fakes
{
    internal class FakeGraphicProvider : IGraphicProvider
    {
        public FakeGraphicProvider()
        {
        }

        public static float FakeGraphicWidth { get; set; }
        public static float FakeGraphicHeight { get; set; }

        public int TimesDrawCalled { get; private set; }

        public int TimesLoadContentCalled { get; private set; }

        public float GraphicWidth => FakeGraphicWidth;
        public float GraphicHeight => FakeGraphicHeight;

        public void LoadContent(IContentLoader loader)
        {
            TimesLoadContentCalled++;
        }

        public void Draw(float xPosition, float yPosition, IGraphicDrawer drawer)
        {
            TimesDrawCalled++;
        }
    }
}