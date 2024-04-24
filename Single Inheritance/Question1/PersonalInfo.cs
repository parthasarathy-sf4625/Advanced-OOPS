using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public class PersonalInfo
    {
        //Fields
        private static int s_userID = 100;
        //Properties
        public string UserID{get;}
        public string UserName{get;set;}
        public string FatherName{get;set;}
        public string Phone {get;set;}
        public string Mail {get;set;}
        public DateTime DOB{get;set;}
        public string Gender{get;set;}

        public PersonalInfo(string userName,string fatherName,string phone,string mail,DateTime dob,string gender)
        {
            UserID = "SID"+(++s_userID);
            UserName = userName;
            FatherName = fatherName;
            Phone = phone;
            Mail = mail;
            DOB = dob;
            Gender = gender;
        }

        public PersonalInfo(string userID,string userName,string fatherName,string phone,string mail,DateTime dob,string gender)
        {
            UserID = userID;
            UserName = userName;
            FatherName = fatherName;
            Phone = phone;
            Mail = mail;
            DOB = dob;
            Gender = gender;
        }
    }
}