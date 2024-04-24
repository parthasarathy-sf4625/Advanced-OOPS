using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public class Sphere:Dimension
    {
        public Sphere(double value1):base(value1,value1)
        {
    
            
        }

        public override void Calculate()
        {
            Area =4*Math.PI*Value1*Value2;
        }

    }
}