using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public class StudentInfo:IDisplay
    {
        private static int s_studentID = 1000;
        //Properties        

        public string StudentID {get;}
        public string Name{get;set;}
        public string FatherName{get;set;}
        public string Mobile{get;set;}

        public StudentInfo(string name,string fatherName,string mobile)
        {
            StudentID = "SID"+(++s_studentID);
            Name = name;
            FatherName = fatherName;
            Mobile = mobile;
        }
        public void Display()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"StudentID : {StudentID}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"FatherName : {FatherName}");
            Console.WriteLine($"Mobile : {Mobile}");
            Console.WriteLine("---------------------------------------");
        }
    }
}