using System;

namespace GameJam2015MonoGame
{
    public class Player
    {
        private readonly IInputHandler _inputHandler;
        private readonly IGraphicProvider _graphicProvider;

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
        }



        public void Draw()
        {
            this._graphicProvider.Draw(this.XPosition, this.YPosition);
        }
    }
}