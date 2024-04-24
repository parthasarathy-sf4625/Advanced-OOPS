using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    
    public enum Gender{Male,Female}
    public partial class EmployeeInfo
    {
        //Fields
        private static int s_employeeID =1000;

        //Properties
        public string EmployeeID{get;}
        public string Name{get;set;}
        public Gender Gender{get;set;}
        public DateTime DOB{get;set;}
        public string Mobile{get;set;}

        
    }
}