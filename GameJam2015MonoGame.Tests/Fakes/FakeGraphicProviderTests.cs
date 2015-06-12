using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace GameJam2015MonoGame.Tests.Fakes
{
    [TestClass]
    public class FakeGraphicProviderTests
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
            fakeGraphicProvider.Draw(0, 0, null);
            Assert.AreEqual(1, fakeGraphicProvider.TimesDrawCalled);
        }

        [TestMethod]
        public void FakeGraphicProvider_CallsToDrawAre2_IfDrawCalledTwice()
        {
            var fakeGraphicProvider = new FakeGraphicProvider();
            fakeGraphicProvider.Draw(0, 0, null);
            fakeGraphicProvider.Draw(0, 0, null);
            Assert.AreEqual(2, fakeGraphicProvider.TimesDrawCalled);
        }
    }
}
