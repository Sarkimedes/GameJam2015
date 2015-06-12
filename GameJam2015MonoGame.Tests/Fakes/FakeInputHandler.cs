using GameJam2015MonoGame.Utility;

namespace GameJam2015MonoGame.Tests.Fakes
{
    internal class FakeInputHandler : IInputHandler
    {
        public FakeInputHandler()
        {
            this.LeftPressed = false;
            this.RightPressed = false;
            this.JumpPressed = false;
        }

        public bool JumpPressed { get; set; }
        public bool LeftPressed { get; set; }
        public bool RightPressed { get; set; }
    }
}