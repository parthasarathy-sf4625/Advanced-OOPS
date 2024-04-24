using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryApp
{
    public class CustumerDetails:PersonalDetails,IBalance
    {
        //Field
        private static int s_custumerID = 1000;
        

        //Property
        public string CustumerID{get;}
        public double WalletBalance{get;set;}

        //Constructors

        public CustumerDetails(string name,string fatherName,Gender gender,string mobile, DateTime dob, string mailID,double walletBalance):base(name,fatherName,gender,mobile,dob,mailID)
        {
            CustumerID = "CID"+(++s_custumerID);
            WalletBalance = walletBalance;
        }

        //Methods

        public void WalletRecharge(double amount)
        {
            WalletBalance += amount;
        }
    }
}