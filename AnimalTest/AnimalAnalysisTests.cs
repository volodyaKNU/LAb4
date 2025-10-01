using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LAb4.mainLogic;

namespace LAb4.Tests
{
    [TestClass]
    public class AnimalAnalysisTests
    {
        [TestMethod]
        public void Average_Returns0_WhenListIsNull()
        {
            var result = AnimalAnalysis.getAverage5YearOldAnimal(null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Average_Returns0_WhenNoAnimalsOlderThan5()
        {
            var animals = new List<Animal>
            {
                new Dog(3),
                new Cat(5) // рівно 5 не враховується (умова > 5)
            };

            var result = AnimalAnalysis.getAverage5YearOldAnimal(animals);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Average_IgnoresNullEntries_AndComputesIntegerAverage()
        {
            var animals = new List<Animal>
            {
                new Dog(6),
                null,
                new Cat(7)
            };

            // (6 + 7) / 2 = 6 (цілочисельне ділення)
            var result = AnimalAnalysis.getAverage5YearOldAnimal(animals);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Average_WorksWithLargeList()
        {
            var animals = new List<Animal>();
            for (int i = 1; i <= 10; i++)
                animals.Add(new Dog(i)); // 1..10

            // враховуються 6..10: сума 40, кількість 5, середнє 8
            var result = AnimalAnalysis.getAverage5YearOldAnimal(animals);
            Assert.AreEqual(8, result);
        }
    }
}
