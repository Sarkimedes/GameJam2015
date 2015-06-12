using System;

namespace GameJam2015MonoGame
{
    public class FallingBlock
    {
        private IRandomNumberProvider _rng;
        private readonly IGraphicProvider _graphicProvider;
        private readonly IBlockLimiter _limiter;

        public FallingBlock(IGraphicProvider graphicProvider, IRandomNumberProvider rng, IBlockLimiter limiter)
        {
            if (graphicProvider == null)
            {
                throw new ArgumentNullException(nameof(graphicProvider));
            }
            if (rng == null)
            {
                throw new ArgumentNullException(nameof(rng));
            }
            if (limiter == null)
            {
                throw new ArgumentNullException(nameof(limiter));
            }

            this._graphicProvider = graphicProvider;
            this._rng = rng;
            this._limiter = limiter;
            this.IsActive = true;
            this.Speed = 1;
            this.XPosition = this._rng.GetRandomNumber();
        }

        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Height => this._graphicProvider.GraphicHeight;
        public bool IsActive { get; private set; }
        public float Speed { get; private set; }

        public void Update()
        {
            if (this._limiter.IsPastLimit(this.YPosition))
            {
                this.IsActive = false;
            }

            this.YPosition += this.Speed;
        }

        public void LoadContent()
        {
            this._graphicProvider.LoadContent();
        }

        public void Draw(IGraphicDrawer drawer)
        {
            this._graphicProvider.Draw(this.XPosition, this.YPosition, drawer);
        }
    }
}