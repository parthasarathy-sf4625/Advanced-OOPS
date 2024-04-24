using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public interface IBankInfo
    {
        public string BankName{get;set;}
        public string IFSC{get;set;}
        public string Branch{get;set;}
    }
}