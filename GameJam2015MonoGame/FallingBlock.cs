using System;

namespace GameJam2015MonoGame
{
    public class FallingBlock
    {
        private IRandomNumberProvider _rng;
        private readonly IGraphicProvider _graphicProvider;

        public FallingBlock(IGraphicProvider graphicProvider, IRandomNumberProvider rng)
        {
            if (graphicProvider == null)
            {
                throw new ArgumentNullException(nameof(graphicProvider));
            }
            if (rng == null)
            {
                throw new ArgumentNullException(nameof(rng));
            }

            this._graphicProvider = graphicProvider;
            this._rng = rng;

            this.XPosition = this._rng.GetRandomNumber();
        }

        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Height => this._graphicProvider.GraphicHeight;
    }
}