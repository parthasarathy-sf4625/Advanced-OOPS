using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public interface IWallet
    {
        public double WalletBalance{get;}
        public void WalletRecharge(double amount);
        public void DeductBalance(double amount);
        
    }
}