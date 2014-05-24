using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    // The sex of the animal
    enum Sex { Male, Female }

    class Animal
    {
        #region Properties
        public string Name { get; set; }
        public byte Age { get; set; }
        public Sex Sex { get; set; }
        #endregion

        #region Constructor
        public Animal(string name, byte age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }
        #endregion

        // Average age of each kind of animal
        public static double? AverageAge(Animal[] animals)
        {
            List<Animal> result = new List<Animal>();
            foreach (Animal animal in animals)
            {
                if (animal == null) break;
                result.Add(animal);
            }
            return result.Average(m => m.Age);
        }
    }
}