using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAb4.mainLogic
{
    public class AnimalAnalysis
    {

        public static int getAverage5YearOldAnimal(List<Animal> animals)
        {
            if (animals == null || animals.Count == 0) return 0;

            int count = 0;
            int sumYears = 0;

            foreach (var animal in animals)
            {
                if (animal == null) continue;

                if (animal.Age > 5)
                {
                    sumYears += animal.Age;
                    count++;
                }
            }

            return count == 0 ? 0 : (sumYears / count);
        }
    }
}
