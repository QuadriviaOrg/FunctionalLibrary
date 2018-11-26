using Quadrivia.FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class AllTests : TestBase
    {
        [TestMethod]
        public void All1()
        {
            var list = FList.New(1, 2, 3);
            var all = FList.All(i => i >= 1, list);
            Assert.IsTrue(all);
        }

        [TestMethod]
        public void All2()
        {
            var list = FList.New(1, 2, 3);
            var all = FList.All(i => i > 1, list);
            Assert.IsFalse(all);
        }

        [TestMethod]
        public void All3()
        {
            var list = FList.New(3);
            var all = FList.All(i => i > 2, list);
            Assert.IsTrue(all);
        }

        [TestMethod]
        public void All4()
        {
            var list = FList.New(3);
            var all = FList.All(i => i > 3, list);
            Assert.IsFalse(all);
        }

        [TestMethod]
        public void All5()
        {
            var list = FList.Empty<int>();
            var all = FList.All(i => i > 3, list);
            Assert.IsFalse(all);
        }
    }
}
