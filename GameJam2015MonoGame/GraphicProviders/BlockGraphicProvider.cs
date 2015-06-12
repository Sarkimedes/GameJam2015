using System;
using Windows.UI.Notifications;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2015MonoGame.GraphicProviders
{
    public class BlockGraphicProvider : IGraphicProvider
    {
        private static readonly string TexturePath = "Images\\block";

        private Texture2D _texture2D;

        public float GraphicWidth {
            get
            {
                if (this._texture2D == null)
                {
                    return this._texture2D.Width;
                }
                return 0;
            }
        }

        public float GraphicHeight
        {
            get
            {
                if (this._texture2D == null)
                {
                    return this._texture2D.Height;
                }
                return 0;
            }
        }
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
            var spriteBatchGraphicDrawer = drawer as SpriteBatchGraphicDrawer;
            if (spriteBatchGraphicDrawer != null)
            {
                spriteBatchGraphicDrawer.TextureToDraw = this._texture2D;
            }
            drawer.Draw(xPosition, yPosition);
        }
    }
}