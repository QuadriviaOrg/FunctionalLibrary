﻿using Quadrivia.FunctionalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class Sort : TestBase
    {
        #region Ascending
        [TestMethod]
        public void Sort1()
        {
            var list = FList.New(7,1,4,6,3,2,5);
            var actual = FList.Sort(list);
            var expected = FList.New(1,2,3,4,5,6,7);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort2()
        {
            var list = FList.New(1, 4, 6, 3, 2, 5);
            var actual = FList.Sort(list);
            var expected = FList.New(1, 2, 3, 4, 5, 6);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort3()
        {
            var list = FList.New(3,3, 4, 4, 3);
            var actual = FList.Sort(list);
            var expected = FList.New(3,3,3,4,4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort4()
        {
            var list = FList.New(3);
            var actual = FList.Sort(list);
            var expected = FList.New(3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort5()
        {
            var list = FList.Empty<int>();
            var actual = FList.Sort(list);
            var expected = FList.Empty<int>();
            Assert.AreEqual(expected, actual);
        }
        #endregion
        #region Descending
        [TestMethod]
        public void Sort6()
        {
            var list = FList.New(7, 1, 4, 6, 3, 2, 5);
            var actual = FList.Sort(list,true);
            var expected = FList.New(7,6,5,4,3,2,1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort7()
        {
            var list = FList.New(1, 4, 6, 3, 2, 5);
            var actual = FList.Sort(list,true);
            var expected = FList.New(6,5,4,3,2,1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort8()
        {
            var list = FList.New(3, 3, 4, 4, 3);
            var actual = FList.Sort(list, true);
            var expected = FList.New(4,4,3, 3, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort9()
        {
            var list = FList.New("Zoe", "Amy", "Ali", "Max", "Adi");
            var actual = FList.Sort(list);
            var expected = FList.New("Adi", "Ali", "Amy", "Max", "Zoe");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort10()
        {
            var list = FList.New("Zoe", "Amy", "Ali", "Max", "Adi");
            var actual = FList.Sort(list, true);
            var expected = FList.New("Zoe", "Max", "Amy", "Ali", "Adi");
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
