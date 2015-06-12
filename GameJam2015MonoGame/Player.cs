using System;

namespace GameJam2015MonoGame
{
    public class Player
    {
        private static readonly float JumpHeightLimit = 20;

        private readonly IInputHandler _inputHandler;
        private readonly IGraphicProvider _graphicProvider;
        private bool _isJumping;
        private float _jumpStartHeight;
        private bool _isDropping;

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
            this.Facing = Facing.Right;
        }

        public void LoadContent()
        {
            this._graphicProvider.LoadContent();
        }

        public float XPosition { get; set; }

        public float YPosition { get; set; }

        public float Speed { get; set; }
        public Facing Facing { get; set; }

        public void Update()
        {
            if (this._inputHandler.LeftPressed)
            {
                this.XPosition -= this.Speed;
                this.Facing = Facing.Left;
            }

            if (this._inputHandler.RightPressed)
            {
                this.XPosition += this.Speed;
                this.Facing = Facing.Right;
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
            else if (this._isJumping && this.YPosition <= this._jumpStartHeight - JumpHeightLimit)
            {
                this._isJumping = false;
                this._isDropping = true;
            }

            if (this._isDropping && this.YPosition < this._jumpStartHeight)
            {
                this.YPosition += this.Speed;
            }
            else if (this._isDropping && this.YPosition >= this._jumpStartHeight)
            {
                this._isDropping = false;
            }
        }

        public void Draw()
        {
            this._graphicProvider.Draw(this.XPosition, this.YPosition);
        }
    }
}