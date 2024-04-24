using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Cylinder cylinder = new Cylinder();
            Console.Write("Enter the Height of the Cylindder : ");
            cylinder.Height = double.Parse(Console.ReadLine());

            Console.Write("Enter the Height of the Radius : ");
            cylinder.Radius = double.Parse(Console.ReadLine());

            cylinder.CalculateArea();
            cylinder.CalculateVolume();

            Console.WriteLine($"Area : {cylinder.Area} \nVolume: {cylinder.Volume}");

            Cube cube = new Cube();
            Console.Write("Enter the Side of the Cube : ");
            cube.Side = double.Parse(Console.ReadLine());

            cube.CalculateArea();
            cube.CalculateVolume();

            Console.WriteLine($"Area : {cube.Area} \nVolume: {cube.Volume}");
        }
    }
}