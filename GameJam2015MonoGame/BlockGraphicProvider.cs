using System;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2015MonoGame
{
    public class BlockGraphicProvider : IGraphicProvider
    {
        private static readonly string TexturePath = "Images\\block.xnb";

        private Texture2D _texture2D;

        public BlockGraphicProvider()
        {
        }

        public float GraphicWidth => this._texture2D.Width;
        public float GraphicHeight => this._texture2D.Height;
        public void LoadContent(IContentLoader loader)
        {
            loader.LoadContent<Texture2D>(TexturePath);
        }

        public void Draw(float xPosition, float yPosition, IGraphicDrawer drawer)
        {
            if (drawer == null)
            {
                throw new ArgumentNullException(nameof(drawer));
            }
            drawer.Draw(xPosition, yPosition);
        }

        public void Draw(float xPosition, float yPosition, SpriteBatchGraphicDrawer drawer)
        {
            if (drawer == null)
            {
                throw new ArgumentNullException(nameof(drawer));
            }

            drawer.TextureToDraw = this._texture2D;
            this.Draw(xPosition, yPosition, (IGraphicDrawer)drawer);
        }
    }
}