using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public partial class EmployeeInfo
    {
        //Constructos
        public EmployeeInfo(string name, Gender gender, DateTime dob,string mobile)
        {
            EmployeeID = "SF"+(++s_employeeID);
            Name = name;
            Gender = gender;
            DOB = dob;
            Mobile = mobile;
        }
    }
}