using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public class EmployeeInfo
    {
        private static int s_employeeID = 8000;
        //Properties        

        public string EmployeeID {get;}
        public string Name{get;set;}
        public string FatherName{get;set;}

        public EmployeeInfo(string name,string fatherName)
        {
            EmployeeID = "EM"+(++s_employeeID);
            Name = name;
            FatherName = fatherName;

        }
        public void Display()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"StudentID : {EmployeeID}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"FatherName : {FatherName}");
            Console.WriteLine("---------------------------------------");
        }
    }
}