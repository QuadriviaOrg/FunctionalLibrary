using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Quadrivia.FunctionalLibrary;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class RandomNumberTests
    {
        [TestMethod]
        public void TestSequenceFromSeededGenerator()
        {
            var random = FRandom.Seed(521288629, 362436069);
            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                random = FRandom.Next(random,0, 10);
                sb.Append(random.Number).Append(" ");
            }
            string gen1Results = sb.ToString();
            Assert.AreEqual("5 1 2 2 8 0 2 7 9 0 ", gen1Results);
        }

        [TestMethod]
        public void TestSequenceFromFunctionalImplementation() { 
            var random0 = FRandom.Seed(1,0);
            var random1 = FRandom.Next(random0, 0, 10);
            Assert.AreEqual(5, random1.Number);
            var random2 = FRandom.Next(random1, 0, 10);
            Assert.AreEqual(2, random2.Number);
            var random3 = FRandom.Next(random2, 0, 2);
            Assert.AreEqual(1, random3.Number);
            var random4 = FRandom.Next(random3, 0, 10);
            Assert.AreEqual(9, random4.Number);

        }

        [TestMethod]
        public void TestFunctionRepeatability()
        {
            var random = FRandom.Seed(1,0);
            Assert.AreEqual(2, FRandom.Next(random, 0, 5).Number);
            Assert.AreEqual(2, FRandom.Next(random, 0, 5).Number);
            Assert.AreEqual(2, FRandom.Next(random, 0, 5).Number);
        }       
    }
}
