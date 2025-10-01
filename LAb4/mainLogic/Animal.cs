using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAb4.mainLogic
{

    public enum AnimalT
    {
        DOG, CAT
    }

    public abstract class Animal
    {
        public AnimalT AnimalType { get; set; }
        public int Age { get; set; }
        public int AverageLifeDuration { get; set; }

        public abstract string Eat();
        public abstract string Sleep();
        public abstract string getIDData();
    }
}
