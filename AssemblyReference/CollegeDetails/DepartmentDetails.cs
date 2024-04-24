using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeDetails
{
    public class DepartmentDetails
    {
        //Fields
        private static long s_departmentID = 100;

        //Properties
        public string DepartmentID{get;}
        public string DepartName{get;}
        public int NumberOfSeats{get;set;}

        //Constructors

        public DepartmentDetails(string departName,int numberOfSeats)
        {
            DepartmentID = "DID"+(++s_departmentID);
            DepartName =departName;
            NumberOfSeats = numberOfSeats;
        }
    }
}