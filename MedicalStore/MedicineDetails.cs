using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public class MedicineDetails
    {
        //Fiedls
        private static int s_medicineID = 100;

        //Properties
        
        public string MedicineID {get;}
        public string MedicineName{get;set;}
        public int AvailableCount{get;set;}
        public double Price{get;set;}
        public DateTime DateOfExpiry{get;set;}

        //Constructors

        public MedicineDetails(string medicineName,int availableCount,double price,DateTime dateOfExpiry)
        {
            MedicineID = "MD"+(++s_medicineID);
            MedicineName = medicineName;
            AvailableCount = availableCount;
            Price = price;
            DateOfExpiry = dateOfExpiry;
        }

        public MedicineDetails(string line)
        {
            string [] values = line.Split(",");
            ++s_medicineID;
            MedicineID = values[0];
            MedicineName = values[1];
            AvailableCount = int.Parse(values[2]);
            Price = int.Parse(values[3]);
            DateOfExpiry = DateTime.ParseExact(values[4],"dd/MM/yyyy",null);

        }
    }
}