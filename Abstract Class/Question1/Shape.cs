using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public abstract class Shape
    {
        public abstract double Volume{get;set;}
        public abstract double Area {get;set;}

        public virtual double Radius{get;set;}
        public virtual double Height{get;set;}
        public virtual double Width{get;set;}

        //Methods
        public abstract void CalculateArea();
        public abstract void CalculateVolume();

    }
}