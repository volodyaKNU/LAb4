using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAb4.mainLogic
{
    public class Dog : Animal
    {
        string Breed { get; set; } = string.Empty;

        public Dog(int age)
        {
            AnimalType = AnimalT.DOG;
            AverageLifeDuration = 20;
            Age = age;
        }

        public override string Eat() => "dog is eating";

        public override string Sleep() => "dog is sleeping";

        public override string getIDData()
        {
            var hasBreed = !string.IsNullOrWhiteSpace(Breed);
            var breed = hasBreed ? $" порода: {Breed}" : string.Empty;

            return $"Вид: {AnimalType}, Вік: {Age}, Середня тривалість життя: {AverageLifeDuration},{breed}";
        }

        public string getAgeData()
        {
            return !string.IsNullOrWhiteSpace(Breed)
                ? $"У собаки виявлена така порода: {Breed}"
                : "Породу собаки не виявлено";
        }
    }
}
