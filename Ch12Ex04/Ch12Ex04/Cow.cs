using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex04
{
    public class Cow : Animal
    {
        public void Milk() => Console.WriteLine($"{name} has been milked.");

        public override void MakeANoise()
        {
            Console.WriteLine($"{name} says 'moo!'");
        }

        public Cow(string newName) : base(newName) { }
    }
}
