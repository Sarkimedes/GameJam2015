using System;
using GameJam2015MonoGame.ContentLoaders;
using GameJam2015MonoGame.GraphicDrawers;
using GameJam2015MonoGame.GraphicProviders;
using GameJam2015MonoGame.Utility;

namespace GameJam2015MonoGame.Actors.Player
{
    public class Player
    {
        private static readonly float JumpHeightLimit = 70;

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
            this.IsDead = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is dead.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is dead; otherwise, <c>false</c>.
        /// </value>
        public bool IsDead { get; set; }

        public void LoadContent(IContentLoader loader)
        {
            this._graphicProvider.LoadContent(loader);
        }

        public float Width => this._graphicProvider.GraphicWidth;
        public float Height => this._graphicProvider.GraphicHeight;

        public float XPosition { get; set; }

        public float YPosition { get; set; }

        public float Speed { get; set; }
        public Facing Facing { get; set; }

        public void Update()
        {
            if (this.IsDead)
            {
                return;
            }

            if (this._inputHandler.LeftPressed)
            {
                this.XPosition -= this.Speed;
                if (this.Facing == Facing.Right)
                {
                    this.Facing = Facing.Left;
                    this.OnRaiseFacingChanged(new FacingChangedEventArgs(this.Facing));
                }
            }

            if (this._inputHandler.RightPressed)
            {
                this.XPosition += this.Speed;
                if (this.Facing == Facing.Left)
                {
                    this.Facing = Facing.Right;
                    this.OnRaiseFacingChanged(new FacingChangedEventArgs(this.Facing));
                }
            }

            if (this._inputHandler.JumpPressed && !this._isJumping && !this._isDropping)
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

        public void Draw(IGraphicDrawer drawer)
        {
            if (drawer == null)
            {
                throw new ArgumentNullException(nameof(drawer));
            }

            if (this.IsDead)
            {
                return;
            }

            this._graphicProvider.Draw(this.XPosition, this.YPosition, drawer);
        }

        public event EventHandler<FacingChangedEventArgs> FacingChanged;

        protected virtual void OnRaiseFacingChanged(FacingChangedEventArgs e)
        {
            EventHandler<FacingChangedEventArgs> handler = FacingChanged;

            handler?.Invoke(this, e);
        }
    }
}