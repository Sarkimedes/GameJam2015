using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam2015MonoGame.Tests.Fakes;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GameJam2015MonoGame.Tests
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void FallingBlocks_AreGeneratedRandomly()
        {
            IRandomNumberProvider rng = new FakeRandomProvider();
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();
            IBlockLimiter limiter = new FakeBlockLimiter();
            var number = rng.GetRandomNumber();

            var block = new FallingBlock(fakeGraphicProvider, rng, limiter);
            Assert.AreEqual(number, block.XPosition);
        }

        [TestMethod]
        public void FallingBlock_BlockPositionIsTopOfGraphicsDevice_ByDefault()
        {
            var block = GenerateBlockWithDefaultFakes();
            var expectedYPosition = block.Height;
            Assert.AreEqual(expectedYPosition, block.YPosition);
        }

        private static FallingBlock GenerateBlockWithDefaultFakes()
        {
            IRandomNumberProvider rng = new FakeRandomProvider();
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();
            IBlockLimiter limiter = new FakeBlockLimiter();

            var block = new FallingBlock(fakeGraphicProvider, rng, limiter);
            return block;
        }

        [TestMethod]
        public void FallingBlock_ThrowsArgumentNullExpception_IfGivenNullRandomNumberProvider()
        {
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();
            IBlockLimiter limiter = new FakeBlockLimiter();

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var block = new FallingBlock(fakeGraphicProvider, null, limiter);
            });
        }

        [TestMethod]
        public void FallingBlock_ThrowsArgumentNullException_IfGivenNullGraphicProvider()
        {
            IRandomNumberProvider rng = new FakeRandomProvider();
            IBlockLimiter limiter = new FakeBlockLimiter();

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var block = new FallingBlock(null, rng, limiter);
            });
        }

        [TestMethod]
        public void FallingBlock_IsDeactivated_OnceItReachesALimit()
        {
            IRandomNumberProvider rng = new FakeRandomProvider();
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();
            IBlockLimiter blockLimiter = new FakeBlockLimiter() {PastLimitValue = true};
            var block = new FallingBlock(fakeGraphicProvider, rng, blockLimiter);

            block.Update();
            Assert.IsFalse(block.IsActive);
        }

        [TestMethod]
        public void FallingBlock_IsActive_WhenCreated()
        {
            IRandomNumberProvider rng = new FakeRandomProvider();
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();
            IBlockLimiter blockLimiter = new FakeBlockLimiter();
            var block = new FallingBlock(fakeGraphicProvider, rng, blockLimiter);

            Assert.IsTrue(block.IsActive);
        }

        [TestMethod]
        public void FallingBlock_ThrowsException_IfGivenNullLimiter()
        {
            IRandomNumberProvider rng = new FakeRandomProvider();
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var block = new FallingBlock(fakeGraphicProvider, rng, null);
            });
        }

        [TestMethod]
        public void FallingBlock_Falls_WhileUpdating()
        {
            var block = GenerateBlockWithDefaultFakes();
            var originalYPosition = block.YPosition;
            var speed = block.Speed;

            block.Update();

            var expectedYPosition = originalYPosition - block.Speed;
            Assert.AreEqual(expectedYPosition, block.YPosition);
        }
    }
}
