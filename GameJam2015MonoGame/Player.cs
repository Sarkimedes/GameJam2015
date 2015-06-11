namespace GameJam2015MonoGame
{
    public class Player
    {
        private IInputHandler handler;

        public Player(IInputHandler handler)
        {
            this.handler = handler;
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