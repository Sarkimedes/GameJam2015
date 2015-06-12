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

        [TestMethod]
        public void Player_CallsLoadMethodOfGraphicProvider_OnCallingDrawMethod()
        {
            FakeGraphicProvider provider = new FakeGraphicProvider();
            var handler = new FakeInputHandler();
            var player = new Player(handler, provider);

            player.LoadContent();

            Assert.AreEqual(1, provider.TimesLoadContentCalled);
        }

        [TestMethod]
        public void Player_YPositionDecreases_WhenJumpIsPressed()
        {
            var fakeInputHandler = new FakeInputHandler();
            fakeInputHandler.JumpPressed = true;
            var fakeGraphicProvider = new FakeGraphicProvider();

            var player = new Player(fakeInputHandler, fakeGraphicProvider);
            var startingYPosition = player.YPosition;

            var expectedDecrement = player.Speed*2;

            player.Update();

            var expectedYPosition = startingYPosition - expectedDecrement;
            var currentYPosition = player.YPosition;
            
            //Check player's position has increased
            Assert.AreEqual(expectedYPosition, currentYPosition);
        }

        [TestMethod]
        public void Player_YPositionContinuesIncreasing_AfterJumpIsReleased()
        {
            var fakeInputHandler = new FakeInputHandler();
            fakeInputHandler.JumpPressed = true;
            var fakeGraphicProvider = new FakeGraphicProvider();
            var player = new Player(fakeInputHandler, fakeGraphicProvider);
            var startingPosition = player.YPosition;
            var jumpSpeed = player.Speed*2;

            player.Update();
            fakeInputHandler.JumpPressed = false;
            player.Update();

            var expectedPosition = startingPosition - jumpSpeed*2;
            var currentPosition = player.YPosition;
            Assert.AreEqual(expectedPosition, currentPosition);
        }

        [TestMethod]
        public void Player_YPositionDoesNotIncrease_AfterJumpingAndHittingALimit()
        {
            const int maxJumpHeight = -20;

            var simulator = new PlayerJumpSimulator();

            simulator.JumpUntilLimit(maxJumpHeight);
            var player = simulator.Player;
            var speed = player.Speed*2;
            var oldPosition = player.YPosition;
            player.Update();

            var currentPosition = player.YPosition;
            Assert.AreEqual(oldPosition, currentPosition);
        }
    }
}
