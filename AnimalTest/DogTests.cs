using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using LAb4.mainLogic;

namespace LAb4.Tests
{
    [TestClass]
    public class DogTests
    {
        [TestMethod]
        public void Dog_BasicFieldsAndBehaviors()
        {
            var dog = new Dog(age: 4);

            Assert.AreEqual(AnimalT.DOG, dog.AnimalType);
            Assert.AreEqual(4, dog.Age);
            Assert.AreEqual(20, dog.AverageLifeDuration);

            Assert.AreEqual("dog is eating", dog.Eat());
            Assert.AreEqual("dog is sleeping", dog.Sleep());

            // ID дані мають містити базові поля
            var id = dog.getIDData();
            StringAssert.Contains(id, "Вид: DOG");
            StringAssert.Contains(id, "Вік: 4");
            StringAssert.Contains(id, "Середня тривалість життя: 20");
        }

        [TestMethod]
        public void Dog_GetAgeData_NoBreed()
        {
            var dog = new Dog(2);
            var text = dog.getAgeData();
            StringAssert.Contains(text, "Породу собаки не виявлено");
        }

        [TestMethod]
        public void Dog_PrivateBreed_Reflected_VisibleInOutputs()
        {
            var dog = new Dog(3);

            // Встановлюємо приватну властивість Breed через рефлексію
            var prop = typeof(Dog).GetProperty("Breed", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.IsNotNull(prop, "Breed property not found via reflection.");
            prop.SetValue(dog, "Хаскі");

            var id = dog.getIDData();
            StringAssert.Contains(id, "порода: Хаскі");

            var ageData = dog.getAgeData();
            StringAssert.Contains(ageData, "порода: Хаскі");
        }
    }
}
