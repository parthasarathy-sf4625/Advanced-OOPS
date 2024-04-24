using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public class StudentInfo:PersonalInfo
    {
        private static int s_registerNumber = 3000;

        public string RegisterNumber {get;set;}
        public int Standard {get;set;}
        public string Branch{get;set;}
        public int AcademicYear{get;set;}

        public StudentInfo(string userID,string name, string fatherName, string phone ,string mail, DateTime dOB, string gender,int standard,string branch,int academicYear):base(userID,name, fatherName, phone ,mail, dOB, gender)
        {
            RegisterNumber = "RG"+(++s_registerNumber);
            Standard = standard;
            Branch = branch;
            AcademicYear =academicYear;
        }

        public void ShowStudentInfo()
        {


            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"RegisterNumber : {RegisterNumber}");
            Console.WriteLine($"Student Name : {UserName}");
            Console.WriteLine($"Father Name : {FatherName}");
            Console.WriteLine($"Phone : {Phone}");
            Console.WriteLine($"Mail : {Mail}");
            Console.WriteLine($"Date of Birth : {DOB.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Gender : {Gender}");
            Console.WriteLine($"Standard : {Standard}");
            Console.WriteLine($"Branch : {Branch}");
            Console.WriteLine($"Academic Year : {AcademicYear}");
            
            Console.WriteLine("---------------------------------------");
        }
    }
}