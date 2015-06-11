using System;

namespace GameJam2015MonoGame
{
    public class Player
    {
        private readonly IInputHandler _handler;

        public Player(IInputHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            this._handler = handler;
            this.Speed = 1;
        }

        public float XPosition { get; set; }
        public float Speed { get; set; }

        public void Update()
        {
            this.XPosition -= this.Speed;
        }
    }
}