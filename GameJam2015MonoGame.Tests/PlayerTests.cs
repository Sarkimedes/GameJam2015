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

            Assert.AreEqual(expectedNewPosition, player.XPosition);
        }

        [TestMethod]
        public void Player_MovesRight_WhenRightButtonIsPressed()
        {
            IInputHandler handler = new FakeInputHandler();
            handler.RightPressed = true;
            var player = new Player(handler);

            var expectedNewPosition = player.XPosition + player.Speed;
            player.Update();
            Assert.AreEqual(expectedNewPosition, player.XPosition);
        }

        //Player speed is one by default
        [TestMethod]
        public void Player_SpeedIsSetToOne_ByDefault()
        {
            IInputHandler handler = new FakeInputHandler();
            var player = new Player(handler);

            const float defaultPlayerSpeed = 1;
            
            Assert.AreEqual(defaultPlayerSpeed, player.Speed);
        }


        //Arg null when adding null input handler
        [TestMethod]
        public void Player_ThrowsArgumentNullException_IfGivenNullInputHandler()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var player = new Player(null);
            });
        }


    }
}
