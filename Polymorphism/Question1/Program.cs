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
            Method(3);
            Method(4,5);
            Method(4,5,6);
            Method(4.5,5.0);
            Method(4.1,5.0,6.0);

        }
        public static void Method(int number)
        {
            Console.WriteLine(number*number);
        }

        public static void Method(int number1,int number2)
        {
            Console.WriteLine(number1*number2);
        }
        public static void Method(int number1,int number2,int number3)
        {
            Console.WriteLine(number1*number2*number3);
        }

        public static void Method(double number1,double number2)
        {
            Console.WriteLine(number1*number2);
        }
        public static void Method(double number1,double number2,double number3)
        {
            Console.WriteLine(number1*number2*number3);
        }
        
    }
}