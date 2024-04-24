using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface
{
    public interface ICalculate
    {
        //No fields and constructors
        //Property
        int Number {get;set;} // declaration only
        int Calculate();// Method - Declaration  (No defenitionn inside the Interface)

        //Fully abstraction - no defenition
    }
}