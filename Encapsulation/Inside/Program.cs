using System;
using Outside;
namespace Inside
{
    public class Program
    {
        public static void Main(string[] args)
        {
            First obj = new First();
            Console.WriteLine(obj.PrivateOut);
            Console.WriteLine(obj.publicNumber);
            
            Second obj2 = new Second();
            Console.WriteLine(obj2.ProtectedNumberOut);
            Console.WriteLine(obj2._internalNum);
            
            Console.WriteLine(obj.InternalProtectedOut);
           
            
        }
    }
}