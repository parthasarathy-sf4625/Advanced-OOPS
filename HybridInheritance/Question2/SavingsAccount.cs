using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public enum AccountType{Savings,Current}
    public class SavingsAccount : IDInfo, IBankInfo, ICalculate
    {
        public static int s_acccountNo = 1000;
        public double _balance;

        public string AccountNumber { get; }
        public AccountType AccountType{get;set;}
        public string BankName { get; set; }
        public string IFSC { get; set; }
        public string Branch { get; set; }
        

        public SavingsAccount(string name, string gender, DateTime dob,string mobile,string voterID,string aadharID,string panNumber,double balance)
        {
            AccountNumber = "AID"+(++s_acccountNo);
            Name = name;
            Gender = gender;
            DOB = dob;
            Mobile = mobile;
            VoterID = voterID;
            AadharID = aadharID;
            PANNumber = panNumber;
            _balance = balance;
        }


        public void Deposit(double amount)
        {
            _balance+=amount;
        }
        public void WithDraw(double amount)
        {
            _balance-=amount;
        }
        public double BalanceCheck()
        {
            return _balance;
        }
    }
}