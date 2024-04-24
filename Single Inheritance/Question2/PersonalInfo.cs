using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public enum Gender{Male,Female}
    public class PersonalInfo
    {
        //Properties: Name, FatherName, Phone, Mail, DOB, Gender
        //Field
        private static int s_userID  = 1000;

        //Properties

        public string UserID {get;}
        public string Name{get;set;}
        public string FatherName{get;set;}
        public string Phone{get;set;}
        public string Mail{get;set;}
        public DateTime DOB{get;set;}
        public Gender Gender{get;set;}

        //Constructor
        public PersonalInfo(string name, string fatherName, string phone, string mail, DateTime dob, Gender gender)
        {
            UserID = "SID"+(++s_userID);
            Name = name;
            FatherName = fatherName;
            Phone = phone;
            Mail = mail;
            DOB = dob;
            Gender = gender;
        }
        public PersonalInfo(string studentID,string name, string fatherName, string phone, string mail, DateTime dob, Gender gender)
        {
            UserID = studentID;
            Name = name;
            FatherName = fatherName;
            Phone = phone;
            Mail = mail;
            DOB = dob;
            Gender = gender;
        }

    }
}