using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialClassesAndMethods
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PersonalDetails person = new PersonalDetails();
            person.DOB=new DateTime(2002,06,16);
            Console.WriteLine(person.CalculateAge());
        }
    }
}