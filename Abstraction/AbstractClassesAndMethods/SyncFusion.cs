using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassesAndMethods
{
    public class SyncFusion : Employee
    {
        //Abstract property defenition
        public override string Name{get{return _name;}set{_name = value;}}
        //Abstract Method Definition
        public override double Salary(int dates)
        {
            Amount = dates*500;
            return Amount;
        }
    }
}