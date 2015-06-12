using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2015MonoGame.GraphicProviders
{
    internal class HankGraphicProvider : IGraphicProvider
    {
        private static readonly string TexturePath = "Images\\hank";
        private static readonly string FlippedTexturePath = "Images\\hankflipped";

        private Texture2D _texture;
        private Texture2D _flippedTexture;

        internal HankGraphicProvider()
        {
            this.Facing = Facing.Left;
        }

        public Facing Facing { get; set; }


        public float GraphicWidth
        {
            get
            {
                if (this._texture != null)
                {
                    return this._texture.Width;
                }
                return 0;
            }
        }

        public float GraphicHeight
        {
            get
            {
                if (this._texture != null)
                {
                    return this._texture.Height;
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

            this._texture = loader.LoadContent<Texture2D>(TexturePath);
            this._flippedTexture = loader.LoadContent<Texture2D>(FlippedTexturePath);
        }

        public void Draw(float xPosition, float yPosition, IGraphicDrawer drawer)
        {
            if (drawer == null)
            {
                throw new ArgumentNullException(nameof(drawer));
            }

            var spriteBatchDrawer = drawer as SpriteBatchGraphicDrawer;
            if (spriteBatchDrawer != null)
            {
                spriteBatchDrawer.TextureToDraw = this.Facing == Facing.Right ? this._texture : this._flippedTexture;
            }
            drawer.Draw(xPosition, yPosition);
        }

        public void HandlePlayerFacingChange(object sender, FacingChangedEventArgs e)
        {
            this.Facing = e.NewFacing;
        }
    }
}
