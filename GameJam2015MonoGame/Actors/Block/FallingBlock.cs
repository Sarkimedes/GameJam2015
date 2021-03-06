﻿using System;
using GameJam2015MonoGame.ContentLoaders;
using GameJam2015MonoGame.GraphicDrawers;
using GameJam2015MonoGame.GraphicProviders;
using GameJam2015MonoGame.Utility;

namespace GameJam2015MonoGame.Actors.Block
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
            SetStartPosition();
        }

        public void SetStartPosition()
        {
            this.Speed = 0.5f;
            this.XPosition = this._rng.GetRandomNumber(400, 1200);
            this.YPosition = this._rng.GetRandomNumber(100, 500);
        }

        public float XPosition { get; set; }
        public float YPosition { get; set; }
        public float Height => this._graphicProvider.GraphicHeight;
        public bool IsActive { get; private set; }
        public float Speed { get; private set; }
        public float Width => this._graphicProvider.GraphicWidth;

        public void Update()
        {
            this.IsActive = true;

            if (this._limiter.IsPastLimit(this.YPosition))
            {
                this.IsActive = false;
                this.SetStartPosition();
            }

            this.YPosition += this.Speed;
        }

        public void LoadContent(IContentLoader loader)
        {
            this._graphicProvider.LoadContent(loader);
        }

        public void Draw(IGraphicDrawer drawer)
        {
            if (this.IsActive)
            {
                this._graphicProvider.Draw(this.XPosition, this.YPosition, drawer);
            }
        }
    }
}