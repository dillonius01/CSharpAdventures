using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch11Ex02
{
   public class Chicken : Animal
   {
      public void LayEgg() => WriteLine("{0} has laid an egg.", name);

      public Chicken(string newName) : base(newName) {}
   }
}
