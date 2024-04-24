using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public class AreaCalculator
    {
        public double Area{get;set;}
        public double Radius{get;set;}

        public AreaCalculator(double radius)
        {
            Radius = radius;
        }
        public virtual void Calculate()
        {
            Area = Math.PI*Radius*Radius;
        }
        public virtual void Display()
        {
            Console.WriteLine(Area);
        }
    }
}