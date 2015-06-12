using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GameJam2015MonoGame.Tests
{
    [TestClass]
    class FakeGraphicProviderTests
    {
        [TestMethod]
        public void FakeGraphicProvider_CallsToDrawAre0ByDefault()
        {
            var fakeGraphicProvider = new FakeGraphicProvider();
            Assert.AreEqual(0, fakeGraphicProvider.TimesDrawCalled);
        }

        [TestMethod]
        public void FakeGraphicProvider_CallsToDrawAre1_IfDrawCalledOnce()
        {
            var fakeGraphicProvider = new FakeGraphicProvider();
            fakeGraphicProvider.Draw(0, 0);
            Assert.AreEqual(1, fakeGraphicProvider.TimesDrawCalled);
        }

        [TestMethod]
        public void FakeGraphicProvider_CallsToDrawAre2_IfDrawCalledTwice()
        {
            var fakeGraphicProvider = new FakeGraphicProvider();
            fakeGraphicProvider.Draw(0, 0);
            Assert.AreEqual(2, fakeGraphicProvider.TimesDrawCalled);
        }
    }
}
