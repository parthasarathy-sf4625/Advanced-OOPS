using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileHandling.Create();
            //FileHandling.ReadFromCSV();
            Operations.AddDefaultDetails();
            Operations.MainMenu();
            FileHandling.WriteToCSV();
        }
    }
}