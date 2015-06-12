using Microsoft.Xna.Framework.Graphics;

namespace GameJam2015MonoGame.Actors.Block
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
