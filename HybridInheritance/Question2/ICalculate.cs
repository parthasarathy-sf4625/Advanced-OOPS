using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Question2
{
    public interface ICalculate
    {
        public void Deposit(double amount);
        public void WithDraw(double amount);
        public double BalanceCheck();

    }
}