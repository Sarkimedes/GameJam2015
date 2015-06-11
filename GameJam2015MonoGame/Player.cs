using System;

namespace GameJam2015MonoGame
{
    public class Player
    {
        private readonly IInputHandler _inputHandler;

        public Player(IInputHandler inputHandler)
        {
            if (inputHandler == null)
            {
                throw new ArgumentNullException(nameof(inputHandler));
            }

            this._inputHandler = inputHandler;
            this.Speed = 1;
        }

        public float XPosition { get; set; }
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
    }
}