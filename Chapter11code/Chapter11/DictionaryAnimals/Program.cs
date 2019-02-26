using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DictionaryAnimals
{
   class Program
   {
      static void Main(string[] args)
      {
         Animals animalCollection = new Animals();
         animalCollection.Add("Jack", new Cow("Jack"));
         animalCollection.Add("Vera", new Chicken("Vera"));
         foreach (Animal myAnimal in animalCollection)
         {
            WriteLine($"New {myAnimal.ToString()} object added to custom collection, " +
                              $"Name = {myAnimal.Name}");
         }
         ReadKey();
      }
   }
}
