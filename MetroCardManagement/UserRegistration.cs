using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserRegistration:PersonalDetails,IBalance
    {
        //field
        private static int s_cardNumber = 1000;
        
        //Property
        public string CardNumber{get;}
        public double Balance{get;set;}

        //Constructors

        public UserRegistration(string name,string mobileNumber,double balance):base(name,mobileNumber)
        {
            CardNumber = "CMRL"+(++s_cardNumber);
            Balance = balance;
        }
        public UserRegistration(string line):base()
        {
            s_cardNumber++;
            string[] values= line.Split(",");
            CardNumber = values[0];
            UserName =  values[1];
            PhoneNumber = values[2];
            Balance = double.Parse(values[3]);
        }

        //Methods

        public void WalletRecharge(double amount)
        {
            Balance += amount;
        }
        public void DeductBalance(double amount)
        {
            Balance -= amount;
        }
    }
}