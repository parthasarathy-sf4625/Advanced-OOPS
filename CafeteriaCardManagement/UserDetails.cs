using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class UserDetails:PersonalDetails,IBalance
    {
        //Field
        private static int s_userID = 1000;
        private double _balance ;

        //Property
        public double WalletBalance
        {
            get
            {
                return _balance;
            }
        } //ReadOnly Property
        public string UserID{get;}  
        public string WorkStationNumber{get;set;}
        
        //Constructor

        public UserDetails(string name,string fatherName,Gender gender,string mobile,string mailID,double walletBalance,string workStationNumber):base(name,fatherName,gender,mobile,mailID)
        {
            UserID = "SF"+(++s_userID);
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            MailID = mailID;
            _balance = walletBalance;
            WorkStationNumber = workStationNumber;
        }

        //Methods
        public void WalletRecharge()
        {
            Console.Write("Enter the Amount to Recharge : ");
            double amount = double.Parse(Console.ReadLine());
            _balance = _balance+amount;
        }
        public void DeductAmount(double amount)
        {
            _balance = _balance-amount;
        }

    }
}