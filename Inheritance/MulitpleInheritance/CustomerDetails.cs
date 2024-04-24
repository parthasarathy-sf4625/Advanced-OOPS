using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MulitpleInheritance
{
    public class CustomerDetails : PersonalDetails
    {
        //Fields
        private static int s_customerID = 1200;

        //Properties

        public string CustomerID{get;}
        public int Balance{get;set;}

        public CustomerDetails(string userID,string name,string fatherName,Gender gender,string phoneNumber,int balance):base(userID,name,fatherName,gender,phoneNumber)
        {
            CustomerID="CID"+(++s_customerID);
            Balance = balance;
        }


    }
}