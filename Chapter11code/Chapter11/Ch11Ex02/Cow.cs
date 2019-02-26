using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch11Ex02
{
   public class Cow : Animal
   {
      public void Milk() => WriteLine("{0} has been milked.", name);

      public Cow(string newName) : base(newName) {}
   }
}
