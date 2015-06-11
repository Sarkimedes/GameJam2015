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
            IGraphicProvider provider = new FakeGraphicProvider();
            handler.LeftPressed = true;
            var player = new Player(handler, provider);

            var expectedNewPosition = player.XPosition - player.Speed;
            player.Update();

            Assert.AreEqual(expectedNewPosition, player.XPosition);
        }

        [TestMethod]
        public void Player_MovesRight_WhenRightButtonIsPressed()
        {
            IInputHandler handler = new FakeInputHandler();
            IGraphicProvider graphicProvider = new FakeGraphicProvider();
            handler.RightPressed = true;
            var player = new Player(handler, graphicProvider);

            var expectedNewPosition = player.XPosition + player.Speed;
            player.Update();
            Assert.AreEqual(expectedNewPosition, player.XPosition);
        }

        //Player speed is one by default
        [TestMethod]
        public void Player_SpeedIsSetToOne_ByDefault()
        {
            IInputHandler handler = new FakeInputHandler();
            IGraphicProvider provider = new FakeGraphicProvider();
            var player = new Player(handler, provider);

            const float defaultPlayerSpeed = 1;
            
            Assert.AreEqual(defaultPlayerSpeed, player.Speed);
        }


        //Arg null when adding null input handler
        [TestMethod]
        public void Player_ThrowsArgumentNullException_IfGivenNullInputHandler()
        {
            IGraphicProvider provider = new FakeGraphicProvider();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var player = new Player(null, provider);
            });
        }

        [TestMethod]
        public void Player_CallsDrawMethodOfGraphicProvider_OnCallingDrawMethod()
        {
            var fakeHandler = new FakeInputHandler();
            var fakeGraphicProvider = new FakeGraphicProvider();
            var player = new Player(fakeHandler, fakeGraphicProvider);

            player.Draw();

            Assert.AreEqual(1, fakeGraphicProvider.TimesDrawCalled);
        }

        [TestMethod]
        public void Player_ThrowArgumentNullException_IfGivenNullGraphicProvider()
        {
            IInputHandler handler = new FakeInputHandler();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var player = new Player(handler, null);
            });
        }
    }
}
