using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GameJam2015MonoGame.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Player_MovesLeft_WhenLeftButtonIsPressed()
        {
            IInputHandler handler = new FakeInputHandler();
            handler.LeftPressed = true;
            var player = new Player(handler);

            var expectedNewPosition = player.XPosition - player.Speed;
            player.Update();

            Assert.AreEqual(player.XPosition, expectedNewPosition);
        }

        //Player speed is one by default
        [TestMethod]
        public void Player_SpeedIsSetToOne_ByDefault()
        {
            IInputHandler handler = new FakeInputHandler();
            var player = new Player(handler);

            float defaultPlayerSpeed = 1;
            
            Assert.AreEqual(defaultPlayerSpeed, player.Speed);
        }


        //Arg null when adding null input handler
        [TestMethod]
        public void Player_ThrowsArgumentNullException_IfGivenNullInputHandler()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var player = new Player(null);
            });
        }
    }
}
