using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public enum Gender
    {
        Select,
        Male,
        Female,
        Transgender
    }
    public class PersonalDetails
    {
        //Properties
        public string Name{get;set;}
        public string FatherName{get;set;}
        public Gender Gender{get;set;}
        public string Mobile {get;set;}
        public DateTime DOB {get;set;}
        public string MailID{get;set;}
        public string Location{get;set;} 

        //Constructor
        public PersonalDetails()
        {
            
        }

    }
}