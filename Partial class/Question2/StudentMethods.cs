using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public partial class StudentInfo
    {
        public void CalculateTotalAndPercentage()
        {
            double total = Physics+Chemistry+Maths;
            Console.WriteLine($"Total : {total}");
            double percentage = (total)/3;
            Console.WriteLine($"Percentage :{percentage}% ") ;
        }
        public void Display()
        {
            Console.WriteLine($"Student ID : {StudentID}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Gender : {Gender}");
            Console.WriteLine($"Date of Birth : {DOB.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Mobile : {Mobile}");
            Console.WriteLine($"Physics : {Physics}");
            Console.WriteLine($"Chemistry : {Chemistry}");
            Console.WriteLine($"Maths : {Maths}");
        }
    }
}