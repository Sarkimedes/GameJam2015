using GameJam2015MonoGame.Utility;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GameJam2015MonoGame.Tests.Fakes
{
    [TestClass]
    public class FakeInputHandlerTests
    {
        [TestMethod]
        public void FakeInputHandlerReturnsTrueIfMovingLeftIsSetToTrue()
        {
            IInputHandler handler = new FakeInputHandler {LeftPressed = true, RightPressed = false, JumpPressed = false};
            Assert.IsTrue(handler.LeftPressed);
        }

        [TestMethod]
        public void FakeInputHandlerReturnsTrueIfMovingRightIsSetToTrue()
        {
            IInputHandler handler = new FakeInputHandler {LeftPressed = false, RightPressed = true, JumpPressed = false};
            Assert.IsTrue(handler.RightPressed);
        }

        [TestMethod]
        public void FakeInputHandlerReturnsTrueIfJumpIsSetToTrue()
        {
            IInputHandler handler = new FakeInputHandler {LeftPressed = false, RightPressed = false, JumpPressed = true};
            Assert.IsTrue(handler.JumpPressed);
        }


    }
}
