using Quadrivia.FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class SortBy : TestBase
    {
        [TestMethod]
        public void SortBy1()
        {
            var list = FList.New(7,1,4,6,3,2,5);
            var actual = FList.SortBy((x,y) => x < y, list);
            var expected = FList.New(1,2,3,4,5,6,7);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortBy2()
        {
            var list = FList.New(1, 4, 6, 3, 2, 5);
            var actual = FList.SortBy((x, y) => x < y, list);
            var expected = FList.New(1, 2, 3, 4, 5, 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortBy3()
        {
            var list = FList.New(3,3, 4, 4, 3);
            var actual = FList.SortBy((x, y) => x < y, list);
            var expected = FList.New(3,3,3,4,4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortBy4()
        {
            var list = FList.New(3);
            var actual = FList.SortBy((x, y) => x < y, list);
            var expected = FList.New(3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortBy5()
        {
            var list = FList.Empty<int>();
            var actual = FList.SortBy((x, y) => x < y, list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortBy6()
        {
            var list = FList.New("Zoe", "Amy", "Ali", "Max", "Adi");
            var actual = FList.SortBy((x,y) =>x[0] <= y[0],list);
            var expected = FList.New("Adi", "Ali", "Amy", "Max", "Zoe");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortBy7() //Test for stability
        {
            var list = FList.New("Adi", "Ali", "Amy", "Max", "Zoe");
            var actual = FList.SortBy((x, y) => x[0] < y[0], list);
            var expected = FList.New("Adi", "Ali", "Amy", "Max", "Zoe");
            Assert.AreEqual(expected, actual);
        }
    }
}
