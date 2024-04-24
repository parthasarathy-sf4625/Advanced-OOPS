using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public class VolumeCalculator:AreaCalculator
    {
        public double Volume{get;set;}

        public double H {get;set;}
        public VolumeCalculator(double h,double radius):base(radius)
        {
            H = h;
        }
        public override void Calculate()
        {
            Volume = Math.PI*Radius*Radius*H;
        }
        public override void Display()
        {
            Console.WriteLine(Volume);
        }
    }
}