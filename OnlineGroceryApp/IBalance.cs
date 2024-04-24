using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryApp
{
    public interface IBalance
    {
        //property
        public double WalletBalance{get;set;}

        public void WalletRecharge(double amount);
    }
}