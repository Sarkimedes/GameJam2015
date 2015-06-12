﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam2015MonoGame.Tests.Fakes;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GameJam2015MonoGame.Tests
{
    [TestClass]
    public class BlockGraphicProviderTests
    {
        [TestMethod]
        public void BlockGraphicProvider_CallsSpriteDrawerDrawMethod_WhenDrawing()
        {
            var blockGraphicProvider = new BlockGraphicProvider();
            IGraphicDrawer fakeDrawer = new FakeGraphicDrawer();
            blockGraphicProvider.Draw(0, 0, fakeDrawer);

            Assert.AreEqual(1, ((FakeGraphicDrawer) fakeDrawer).TimesDrawCalled);
        }

        [TestMethod]
        public void BlockGraphicProvider_ThrowsException_WhenGivenANullSpriteDrawer()
        {
            var blockGraphicProvider = new BlockGraphicProvider();
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                blockGraphicProvider.Draw(0, 0, null);
            });
        }
    }
}
