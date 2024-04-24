using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadWriteCSV
{
    public enum Gender { Male, Female }
    public class StudentDetails
    {
        //Properties
        public string Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public int TotalMark { get; set; }

    }
}