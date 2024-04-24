using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CSEDepartment csBook = new CSEDepartment();
            csBook.SetBookInfo("Bruce Wayne","The Dark Knight","Alfred PennyWorth","2006");

            EEEDepartment eeBook1 = new EEEDepartment();
            eeBook1.SetBookInfo("Kal El","The Son of Krypton","Zod","2013");

            csBook.DisplayInfo();
            eeBook1.DisplayInfo();
        }
    }
}