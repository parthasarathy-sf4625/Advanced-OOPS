using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Question1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter your Father Name : ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter your Phone : ");
            string phone =  Console.ReadLine();
            Console.Write("Enter your Mail : ");
            string mail =  Console.ReadLine();
            Console.Write("Enter your Date of Birth (dd/MM/yyyy)");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter your Gender : ");
            string gender = Console.ReadLine();
            PersonalInfo person = new PersonalInfo(name,fatherName,phone,mail,dob,gender);
            Console.Write("Enter the Standard : ");
            int standard = int.Parse(Console.ReadLine());
            Console.Write("Enter your Branch : ");
            string branch =  Console.ReadLine();
            Console.Write("Enter the Academnic Year : ");
            int academicYear = int.Parse(Console.ReadLine());

                                  //  StudentInfo(string userID,string name, string fatherName, string phone ,string mail, DateTime dOB, string gender,int standard,string branch,int academicYear):base(userID,name, fatherName, phone ,mail, dOB, gender)
            StudentInfo student = new StudentInfo(person.UserID,person.UserName,person.FatherName,person.Phone,person.Mail,person.DOB,person.Gender,standard,branch,academicYear); 
            student.ShowStudentInfo();

        }
    }
}