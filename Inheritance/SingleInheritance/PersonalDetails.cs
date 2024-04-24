using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SingleInheritance
{
    public enum Gender{Select,Male,Female}
    public class PersonalDetails
    {
        //Field
        private static int s_userID = 1000;


        //Properties
        public string UserID{get;}
        public string Name{get;set;}
        public string FatherName{get;set;}
        public Gender Gender{get;set;}
        public string PhoneNumber{get;set;}

        //Constructor
        public PersonalDetails(string name,string fatherName,Gender gender,string phoneNumber)
        {
            UserID = "UID"+(++s_userID);
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }
        public PersonalDetails(string userID,string name,string fatherName,Gender gender,string phoneNumber)
        {
            UserID = userID;
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            PhoneNumber = phoneNumber;
        }
    }
}