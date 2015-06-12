﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2015MonoGame
{
    public class SpriteBatchGraphicDrawer : IGraphicDrawer
    {
        private readonly SpriteBatch _spriteBatch;

        public SpriteBatchGraphicDrawer(SpriteBatch spriteBatch)
        {
            if (spriteBatch == null)
            {
                throw new ArgumentNullException(nameof(spriteBatch));
            }

            this._spriteBatch = spriteBatch;
        }

        public Texture2D TextureToDraw { get; set; }

        public void Draw(float x, float y)
        {
            this._spriteBatch.Draw(this.TextureToDraw, new Vector2(x, y), Color.White);
        }
    }
}
