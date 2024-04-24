using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MulitpleInheritance;

namespace MulitpleInheritance
{
    public class StudentDetail:PersonalDetails
    {
        //Fields
        private static int s_studentID =3000;
        
        //Properties
        public string StudentId{get;}
        public int Standard{get;set;}
        public string YearOfJoining{get;set;}
        

        //Constructor
        public StudentDetail(string userID,string name,string fatherName,Gender gender,string phoneNumber,int standard,string yearOfJoining):base(name,fatherName,gender,phoneNumber)
        {
            StudentId = "SID"+(++s_studentID);
            Standard =standard;
            YearOfJoining =yearOfJoining;
        }
        public StudentDetail(string studentID,string userID,string name,string fatherName,Gender gender,string phoneNumber,int standard,string yearOfJoining):base(name,fatherName,gender,phoneNumber)
        {
            StudentId = studentID;
            Standard =standard;
            YearOfJoining =yearOfJoining;
        }
        
    }
}