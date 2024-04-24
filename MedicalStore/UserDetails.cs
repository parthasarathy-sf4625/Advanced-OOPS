using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public class UserDetails:PersonalDetails,IWallet
    {
        //Field
        private static int s_userID = 1000;
        private static double _balance;

        //Properties

        public string UserID{get;}
        public double WalletBalance
        {
            get
            {
                return _balance;
            }
        }
        

        //Constructors
        public UserDetails(string name,int age,string city,string phoneNumber,double balance):base()
        {
            UserID = "UID"+(++s_userID);
            Name=name;
            Age =age;
            City = city;
            PhoneNumber=phoneNumber;
            _balance = balance;
        }

        public UserDetails(string line):base()
        {
            string[] values = line.Split(",");
            ++s_userID;
            UserID = values[0];
            Name=values[1];
            Age =int.Parse(values[2]);
            City = values[3];
            PhoneNumber=values[4];
            _balance = double.Parse(values[5]);

        }

        //Methods

        public void WalletRecharge(double amount)
        {
            _balance+=amount;
        }
        public void DeductBalance(double amount)
        {
            _balance-=amount;
        }
    }
}