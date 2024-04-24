using System;
namespace Interface
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Square number = new Square();
            number.Number = 20;
            Console.WriteLine(number.Calculate());

            Circle number1 = new Circle();
            number1.Number = 10;
            Console.WriteLine(number1.Calculate());
        }
    }
}