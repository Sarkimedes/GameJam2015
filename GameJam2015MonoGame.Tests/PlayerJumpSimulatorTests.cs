using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GameJam2015MonoGame.Tests
{
    [TestClass]
    public class PlayerJumpSimulatorTests
    {
        [TestMethod]
        public void PlayerJumpSimulator_JumpUntilLimit_CausesPlayerToJumpUntilLimitIsReached()
        {
            PlayerJumpSimulator simulator = new PlayerJumpSimulator();
            var limit = -6;

            simulator.JumpUntilLimit(limit);
            Assert.AreEqual(limit, simulator.Player.YPosition);
        }

        [TestMethod]
        public void PlayerJumpSimulator_ReturnsPlayer_WhenPropertyIsRead()
        {
            PlayerJumpSimulator simulator = new PlayerJumpSimulator();
            Assert.IsNotNull(simulator.Player);
        }
    }
}
