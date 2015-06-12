using System;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2015MonoGame
{
    public class BlockGraphicProvider : IGraphicProvider
    {
        private static readonly string TexturePath = "Images\\block";

        private Texture2D _texture2D;

        public BlockGraphicProvider()
        {
        }

        public float GraphicWidth => this._texture2D.Width;
        public float GraphicHeight => this._texture2D.Height;
        public void LoadContent(IContentLoader loader)
        {
            if (loader == null)
            {
                throw new ArgumentNullException(nameof(loader));
            }

            this._texture2D = loader.LoadContent<Texture2D>(TexturePath);
        }

        public void Draw(float xPosition, float yPosition, IGraphicDrawer drawer)
        {
            if (drawer == null)
            {
                throw new ArgumentNullException(nameof(drawer));
            }
            if (drawer is SpriteBatchGraphicDrawer)
            {
                ((SpriteBatchGraphicDrawer) drawer).TextureToDraw = this._texture2D;
            }
            drawer.Draw(xPosition, yPosition);
        }
    }
}