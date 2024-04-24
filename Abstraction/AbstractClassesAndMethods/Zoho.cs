using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassesAndMethods
{
    public class Zoho:Employee
    {
        //Abstract Property
        public override string Name { get{return _name;} set{_name = value;} }

        //Abstract class
        public override double Salary(int dates)
        {
            Amount = dates *1000;
            return Amount;
        }
    }
}