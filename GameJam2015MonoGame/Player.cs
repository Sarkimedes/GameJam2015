﻿using System;

namespace GameJam2015MonoGame
{
    public class Player
    {
        private static readonly float JumpHeightLimit = 20;

        private readonly IInputHandler _inputHandler;
        private readonly IGraphicProvider _graphicProvider;
        private bool _isJumping;
        private float _jumpStartHeight;

        public Player(IInputHandler inputHandler, IGraphicProvider graphicProvider)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            if (graphicProvider == null)
            {
                throw new ArgumentNullException(nameof(graphicProvider));
            }

            this._inputHandler = inputHandler;
            this._graphicProvider = graphicProvider;
            this.Speed = 1;
        }

        public void LoadContent()
        {
            this._graphicProvider.LoadContent();
        }

        public float XPosition { get; set; }

        public float YPosition { get; set; }

        public float Speed { get; set; }

        public void Update()
        {
            if (this._inputHandler.LeftPressed)
            {
                this.XPosition -= this.Speed;
            }

            if (this._inputHandler.RightPressed)
            {
                this.XPosition += this.Speed;
            }

            if (this._inputHandler.JumpPressed && !this._isJumping)
            {
                this._isJumping = true;
                this._jumpStartHeight = this.YPosition;
            }

            if (this._isJumping && this.YPosition > (this._jumpStartHeight - JumpHeightLimit))
            {
                this.YPosition -= this.Speed*2;
            }
        }

        public void Draw()
        {
            this._graphicProvider.Draw(this.XPosition, this.YPosition);
        }
    }
}