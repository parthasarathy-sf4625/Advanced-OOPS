using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public class Cylinder:Shape
    {
        public override double Area{get;set;}
        public override double Volume{get;set;}

        public override double Radius{get;set;}
        public override double Height { get;set; }

        public override void CalculateArea()
        {
            Area = 2*Math.PI*Radius*(Radius+Height);
        }
        public override void CalculateVolume()
        {
            Volume = Math.PI*Radius*2*Height;
        }
    }
}