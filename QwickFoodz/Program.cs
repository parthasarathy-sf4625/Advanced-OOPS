using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileHandling.Create();
            //Operations.AddDefaultDetails();

            FileHandling.ReadFromCSV();
            Operations.MainMenu();
            FileHandling.WriteToCSV();
        }
    }
}