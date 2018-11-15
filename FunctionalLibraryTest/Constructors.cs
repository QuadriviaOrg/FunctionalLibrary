using Quadrivia.FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Constructors : TestBase
    {

        [TestMethod]
        public void IsEmptyWithNull()
        {
            try
            {
                FList.IsEmpty<int>(null);
                Assert.Fail("Should not get to here");
            }
            catch (System.Exception e)
            {
                Assert.AreEqual("Null being passed in place of an FList.", e.Message);
            }
            
        }

        [TestMethod]
        public void Empty()
        {
            var list = FList.Empty<int>();
            Assert.IsTrue(FList.IsEmpty(list));
        }

        [TestMethod]
        public void NewHeadOnly()
        {
            var list = FList.New(1);
            Assert.IsFalse(FList.IsEmpty(list));
            Assert.AreEqual("1", list.ToString());
        }

        [TestMethod]
        public void NewWithNull()
        {
            var list = FList.New<int>(null);
            Assert.IsTrue(FList.IsEmpty(list));
        }

        [TestMethod]
        public void NewWithHeadAndNull()
        {
            var list = FList.New(3, null);
            Assert.IsFalse(FList.IsEmpty(list));
            Assert.AreEqual("3", list.ToString());
        }

        [TestMethod]
        public void NewWithHeadAndNullNullableType()
        {
            var list = FList.New<string>(null, "a", "b");
            Assert.IsFalse(FList.IsEmpty(list));
            Assert.AreEqual(", a, b", list.ToString());
        }

    }
}
