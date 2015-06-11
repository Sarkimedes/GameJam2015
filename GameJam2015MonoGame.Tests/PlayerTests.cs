using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GameJam2015MonoGame.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Player_MovesLeftWhenLeftButtonIsPressed()
        {
            IInputHandler handler = new FakeInputHandler();
            handler.LeftPressed = true;
            var player = new Player(handler);

            var expectedNewPosition = player.XPosition - player.Speed;
            player.Update();

            Assert.AreEqual(player.XPosition, expectedNewPosition);
        }
    }
}
