using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Sphere sphere = new Sphere(3.00);
            sphere.Calculate();
            sphere.DisplayArea();

            Rectangle rectangle = new Rectangle(10,5);
            rectangle.Calculate();
            rectangle.DisplayArea();
        }
    }
}