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
        public void BlocksAreGeneratedRandomly()
        {
            IRandomNumberProvider rng = new FakeRandomProvider();
            float number = rng.GetRandomNumber();

            FallingBlock block = new FallingBlock(rng);
            Assert.AreEqual(number, block.XPosition);
        }
    }
}
