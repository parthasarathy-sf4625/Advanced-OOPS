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

            Square(5);
            Square(4.0);
            Square(4.98f);
            long num = 50574465;
            Square(num);
        }
        public static void Square(int number)
        {
            Console.WriteLine(number*number);
        }

        public static void Square(double number)
        {
            Console.WriteLine(number*number);
        }

        public static void Square(float number)
        {
            Console.WriteLine(number*number);
        }

        public static void Square(long number)
        {
            Console.WriteLine(number*number);
        }


    }
}