using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam2015MonoGame
{
    class ViewportBlockLimiter : IBlockLimiter
    {
        private readonly Viewport _viewport;

        public ViewportBlockLimiter(Viewport viewport)
        {
            this._viewport = viewport;
        }

        public bool IsPastLimit(float position)
        {
            return position > this._viewport.TitleSafeArea.Bottom;
        }
    }
}
