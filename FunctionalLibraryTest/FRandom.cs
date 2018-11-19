using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Quadrivia.FunctionalLibrary;
using System;

namespace FunctionalLibraryTest
{
    [TestClass]
    public class RandomNumberTests
    {
        [TestMethod]
        public void TestSequenceFromSeedDefault()
        {
            var random = FRandom.SeedDefault();
            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                random = FRandom.Next(random, 0, 10);
                sb.Append(random.Number).Append(" ");
            }
            string gen1Results = sb.ToString();
            Assert.AreEqual("5 1 2 2 8 0 2 7 9 0 ", gen1Results);
        }
        [TestMethod]
        public void TestSequenceFromSeed()
        {
            var random = FRandom.Seed(3, 7);
            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                random = FRandom.Next(random, 0, 10);
                sb.Append(random.Number).Append(" ");
            }
            string gen1Results = sb.ToString();
            Assert.AreEqual("6 1 2 8 4 2 5 1 3 6 ", gen1Results);
        }

        [TestMethod]
        public void TestFunctionRepeatability()
        {
            var random = FRandom.SeedDefault();
            Assert.AreEqual(2, FRandom.Next(random, 0, 5).Number);
            Assert.AreEqual(2, FRandom.Next(random, 0, 5).Number);
            Assert.AreEqual(2, FRandom.Next(random, 0, 5).Number);
        }

        [TestMethod] //Very crude test to check that there is an approximately even distribution of 0, 1 results
        public void TestSeedFromClock()
        {
            var random = FRandom.SeedFromClock(DateTime.Now);
            int zeros = 0;
            int ones = 0;
            for (int i = 0; i < 1000; i++)
            {
                random = FRandom.Next(random, 0, 2);
                if (random.Number == 0)
                {
                    zeros += 1;
                }
                else
                {
                    ones += 1;
                }
            }

            Assert.AreEqual(1000, zeros + ones);
            Assert.IsTrue(zeros < 550);
            Assert.IsTrue(ones < 550);
        }
    }
}
