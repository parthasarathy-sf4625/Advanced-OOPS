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
             AccountInfo accoun1 = new AccountInfo("Partha","Muthukrishnan","978694339","partha@gmail.com",new DateTime(2002,06,16),Gender.Male,"Erode","BANKL008",90000);
             AccountInfo accoun2 = new AccountInfo("Surya","Kumar","567890","sky@gmail.com",new DateTime(2000,06,16),Gender.Male,"Erode","BANKL008",90000);
             AccountInfo accoun3 = new AccountInfo("Rahul","KL","0987654313","rahul@gmail.com",new DateTime(1998,06,16),Gender.Male,"Erode","BANKL008",90000);

             accoun1.ShowAccountInfo();
             accoun2.ShowAccountInfo();
             accoun3.ShowAccountInfo();
        }
    }
}