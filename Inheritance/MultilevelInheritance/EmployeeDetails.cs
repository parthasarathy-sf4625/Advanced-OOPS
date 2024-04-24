using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiLevelInheritance;

namespace MultilevelInheritance
{
    public class EmployeeDetails: StudentDetail
    {
        //Fields
        private static int s_employeeID =3000;
        
        //Properties
        public string EmployeeID{get;}
        public string Designation{get;set;}
        

        //Constructor
        public EmployeeDetails(string studentID,string userID,string name,string fatherName,Gender gender,string phoneNumber,int standard,string yearOfJoining,string designation):base(studentID,userID,name,fatherName,gender,phoneNumber,standard,yearOfJoining)
        {
            EmployeeID = "SF"+(++s_employeeID);
            Designation =designation;
        }
    }
}