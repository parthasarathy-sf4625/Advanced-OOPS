using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public class Cube:Shape
    {
        public override double Area{get;set;}
        public override double Volume{get;set;}

        public  double Side{get;set;}


        public override void CalculateArea()
        {
            Area = 6*Side*Side;
        }
        public override void CalculateVolume()
        {
            Volume = Side*Side*Side;
        }
        
    }
}