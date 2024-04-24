using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public class AccountInfo:PersonalInfo
    {
        //Field
        private static int s_AccountNumber = 5000;
        // Properties: AccountNumber, BranchName, IFSCCode, Balance
        
        public string AccountNumber{get;}
        public string BranchName{get;set;}
        public string IFSCCode{get;set;}
        public double Balance{get;set;}
        
        //Constructor

        public AccountInfo(string name, string fatherName, string phone, string mail, DateTime dob, Gender gender,string branchName,string ifscCode,double balance):base(name,fatherName, phone,mail,dob,gender)
        {
            AccountNumber = "AID"+(++s_AccountNumber);
            BranchName = branchName;
            IFSCCode =ifscCode;
            Balance = balance;
        }
        public AccountInfo(string studentID,string name, string fatherName, string phone, string mail, DateTime dob, Gender gender,string branchName,string ifscCode,double balance):base(studentID,name,fatherName, phone,mail,dob,gender)
        {
            AccountNumber = "AID"+(++s_AccountNumber);
            BranchName = branchName;
            IFSCCode =ifscCode;
            Balance = balance;
        }

        // Methods: ShowAccountInfo, Deposit , Withdraw, ShowBalance.

        public void ShowAccountInfo()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Account Holder : {Name}");
            Console.WriteLine($"Branch Name : {BranchName}");
            Console.WriteLine($"IFSC Code : {IFSCCode}");
            Console.WriteLine($"Balance : {Balance}");
            Console.WriteLine("---------------------------------------");
        }
        public void Deposit(double amount)
        {
            Balance+=amount;
        }
        public void Withdraw(double amount)
        {
            Balance-=amount;
        }
        public void ShowBalance()
        {
            Console.WriteLine($"Balance : {Balance}");
        }

        
    }
}