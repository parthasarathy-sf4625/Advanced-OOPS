using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dog dog1 = new Dog("Pomerian","Home","Carnivore");
            Dog dog2 = new Dog("PitBull","Home","Carnivore");

            dog1.DisplayName();
            dog2.DisplayName();

            Duck duck1 = new Duck("Duck1","Pond","Carnivore");
            Duck duck2 = new Duck("Duck2","Pond","Carnivore");

            duck1.DisplayName();
            duck2.DisplayName();
        }
    }
}