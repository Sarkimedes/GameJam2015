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
        private static readonly string TexturePath = "\\Images\\Hank.xnb";

        private Texture2D _texture;

        internal HankGraphicProvider()
        {
        }

        public SpriteBatch SpriteBatch { get; set; }


        public void LoadContent()
        {
            throw new NotImplementedException();
        }

        public void Draw(float xPosition, float yPosition)
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
            this.SpriteBatch.Draw(this._texture, drawPosition, Color.White);
        }
    }
}
