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
            StudentInfo student = new StudentInfo("Partha","Muthukrishnan","978687675");
            student.Display();

            EmployeeInfo employee = new EmployeeInfo("Partha","Muthukrishnan");
            employee.Display();
        }
    }
}