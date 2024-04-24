using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public class Rectangle:Dimension
    {
        public double Length{get;set;}
        public double Height{get;set;}

        public Rectangle(int value1,int value2):base(value1,value2)
        {
            Length = value1;
            Height = value2;
        }

        public override void Calculate()
        {
            Area = Length*Height;
        }
    }
}