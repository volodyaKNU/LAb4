using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using LAb4.mainLogic;

namespace LAb4.Tests
{
    [TestClass]
    public class CatTests
    {
        [TestMethod]
        public void Cat_BasicFieldsAndBehaviors()
        {
            var cat = new Cat(age: 5);

            Assert.AreEqual(AnimalT.CAT, cat.AnimalType);
            Assert.AreEqual(5, cat.Age);
            Assert.AreEqual(15, cat.AverageLifeDuration);

            Assert.AreEqual("cat is eating", cat.Eat());
            Assert.AreEqual("cat is sleeping", cat.Sleep());

            // ID дані мають містити базові поля
            var id = cat.getIDData();
            StringAssert.Contains(id, "Вид: CAT");
            StringAssert.Contains(id, "Вік: 5");
            StringAssert.Contains(id, "Середня тривалість життя: 15");
        }

        [TestMethod]
        public void Cat_GetCheckupResults_ReturnsUAText()
        {
            var cat = new Cat(3);
            Assert.AreEqual("Кішка отримала результати огляду.", cat.GetCheckupResults());
        }

        [TestMethod]
        public void Cat_PrivateWoolType_Reflected_VisibleInIdData()
        {
            var cat = new Cat(2);

            // Встановлюємо приватну властивість WoolType через рефлексію
            var prop = typeof(Cat).GetProperty("WoolType", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(prop, "WoolType property not found via reflection.");
            prop.SetValue(cat, "Коротка");

            var id = cat.getIDData();
            StringAssert.Contains(id, "тип шерсті: Коротка");
        }
    }
}
