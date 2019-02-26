using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Ex04
{
    public class Chicken : Animal
    {
        public void LayEgg() => Console.WriteLine($"{name} has laid an egg.");

        public override void MakeANoise()
        {
            Console.WriteLine($"{name} says 'cluck'!");
        }

        public Chicken(string newName) : base(newName) { }
    }
}
