using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam2015MonoGame.Tests
{
    class PlayerJumpSimulator
    {
        public Player Player { get; private set; }

        public PlayerJumpSimulator()
        {
            IInputHandler fakeInputHandler = new FakeInputHandler();
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();
            Player = new Player(fakeInputHandler, fakeGraphicProvider);
        }


        public void JumpUntilLimit(int limit)
        {
            IInputHandler fakeHandler = new FakeInputHandler();
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();
            fakeHandler.JumpPressed = true;
            this.Player = new Player(fakeHandler, fakeGraphicProvider);
            var startPosition = this.Player.YPosition;
            while (Player.YPosition > startPosition + limit)
            {
                Player.Update();
            }
        }
    }
}
