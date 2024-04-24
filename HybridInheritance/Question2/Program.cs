using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SavingsAccount account = new SavingsAccount("Partha","Male",new DateTime(2002,06,16),"6382810920","-09876tyujhn","09876544567","98uyhgbhxss",200000);
            account.Deposit(9000);
            Console.WriteLine()
        }
    }
}