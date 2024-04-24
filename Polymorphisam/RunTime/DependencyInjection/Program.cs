using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CCAccount ccAccount = new CCAccount();
            
            ccAccount.AccountNumber = 123;
            ccAccount.Name = "Partha";
            ccAccount.Balance = 1000;

            SBAccount sbAccount = new SBAccount();

            sbAccount.AccountNumber= 124;
            sbAccount.Name = "Sarathy";
            sbAccount.Balance = 1000;

            List<CCAccount> ccList = new List<CCAccount>();
            ccList.Add(ccAccount);


            List<SBAccount> sbList = new List<SBAccount>();
            sbList.Add(sbAccount);
            
            List<IAccount> accountList = new List<IAccount>();
            
            accountList.Add(ccAccount);
            accountList.Add(sbAccount);
        }
    }
}