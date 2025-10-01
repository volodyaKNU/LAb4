using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAb4.mainLogic
{
    public class Cat : Animal
    {
        string WoolType { get; set; } = string.Empty;

        public Cat(int age)
        {
            AnimalType = AnimalT.CAT;
            AverageLifeDuration = 15;
            Age = age;
        }

        public override string Eat() => "cat is eating";

        public override string Sleep() => "cat is sleeping";

        public override string getIDData()
        {
            var hasWool = !string.IsNullOrWhiteSpace(WoolType);
            var wool = hasWool ? $" тип шерсті: {WoolType}" : string.Empty;

            return $"Вид: {AnimalType}, Вік: {Age}, Середня тривалість життя: {AverageLifeDuration},{wool}";
        }

        public string GetCheckupResults()
        {
            return "Кішка отримала результати огляду.";
        }
    }
}
