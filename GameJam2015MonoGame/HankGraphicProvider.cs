using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2015MonoGame
{
    internal class HankGraphicProvider : IGraphicProvider
    {
        private static readonly string TexturePath = "Images\\hank.png";
        private static readonly string FlippedTexturePath = "Images\\hankflipped.png";

        private Texture2D _texture;
        private Texture2D _flippedTexture;
        private ContentManager _contentManager;

        internal HankGraphicProvider(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            if (spriteBatch == null)
            {
                throw new ArgumentNullException(nameof(spriteBatch));
            }
            if (contentManager == null) throw new ArgumentNullException(nameof(contentManager));
            this.Facing = Facing.Left;
            this.SpriteBatch = spriteBatch;
            this._contentManager = contentManager;
        }

        public Facing Facing { get; set; }

        public SpriteBatch SpriteBatch { get; set; }


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
            this._texture = this._contentManager.Load<Texture2D>(TexturePath);
            this._flippedTexture = this._contentManager.Load<Texture2D>(FlippedTexturePath);
        }

        public void Draw(float xPosition, float yPosition, IGraphicDrawer drawer)
        {
            if (this.SpriteBatch == null)
            {
                throw new InvalidOperationException("Could not draw object as SpriteBatch was not set.");
            }

            if (this._texture == null)
            {
                throw new InvalidOperationException("Could not draw object as texture was not set.");
            }

            Vector2 drawPosition = new Vector2(xPosition, yPosition);
            if (this.Facing == Facing.Right)
            {
                this.SpriteBatch.Draw(this._texture, drawPosition, Color.White);
            }
            else
            {
                this.SpriteBatch.Draw(this._flippedTexture, drawPosition, Color.White);
            }
        }

        public void HandlePlayerFacingChange(object sender, FacingChangedEventArgs e)
        {
            this.Facing = e.NewFacing;
        }
    }
}
