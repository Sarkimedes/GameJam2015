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
            var number = rng.GetRandomNumber();

            var block = new FallingBlock(fakeGraphicProvider, rng);
            Assert.AreEqual(number, block.XPosition);
        }

        [TestMethod]
        public void FallingBlock_BlockPositionIsTopOfGraphicsDevice_ByDefault()
        {
            IRandomNumberProvider rng = new FakeRandomProvider();
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();
            
            var block = new FallingBlock(fakeGraphicProvider, rng);
            var expectedYPosition = block.Height;
            Assert.AreEqual(expectedYPosition, block.YPosition);
        }

        [TestMethod]
        public void FallingBlock_ThrowsArgumentNullExpception_IfGivenNullRandomNumberProvider()
        {
            IGraphicProvider fakeGraphicProvider = new FakeGraphicProvider();

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var block = new FallingBlock(fakeGraphicProvider, null);
            });
        }

        [TestMethod]
        public void FallingBlock_ThrowsArgumentNullException_IfGivenNullGraphicProvider()
        {
            IRandomNumberProvider rng = new FakeRandomProvider();

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var block = new FallingBlock(null, rng);
            });
        }
    }
}
