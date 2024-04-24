using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public static class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("MyData"))
            {
                Directory.CreateDirectory("MyData");
            }
            if(!File.Exists("MyData/OrderDetails.csv")  && !File.Exists("MyData/UserDetails.csv") && !File.Exists("MyData/MedicineDatails.csv"))
            {
                File.Create("MyData/OrderDetails.csv").Close();
                File.Create("MyData/UserDetails.csv").Close();
                File.Create("MyData/MedicineDetails.csv").Close();
            }
        }

        
        public static void ReadFromCSV()
        {
            string[] UserDetails = File.ReadAllLines("MyData/UserDetails.csv");
            foreach (string line in UserDetails)
            {
                UserDetails user = new UserDetails(line);
                Operations.userList.Add(user);
            }

            //MedicineDetails
            string[] medicineDetails = File.ReadAllLines("MyData/MedicineDetails.csv");
            foreach (string line in medicineDetails)
            {
                MedicineDetails medicine  =  new MedicineDetails(line);
                Operations.medicineList.Add(medicine);
            }

            //OrderDetails
            string[] orderDetails = File.ReadAllLines("MyData/OrderDetails.csv");
            foreach (string line in orderDetails)
            {
                OrderDetails order = new OrderDetails(line);
                Operations.orderList.Add(order);
            }

        }
         public static void WriteToCSV()
        {
            //User Details
            string[] userDetails = new string[Operations.userList.Count];
            for (int i = 0; i < Operations.userList.Count; i++)
            {
                UserDetails user = Operations.userList[i];
                userDetails[i] = user.UserID + "," +user.Name+","+ user.Age + "," + user.City + "," + user.PhoneNumber + "," + user.WalletBalance;
            }
            File.WriteAllLines("MyData/UserDetails.csv",userDetails);

            //Medicine Details
            string[] medicineDetails = new string[Operations.medicineList.Count];
            for (int i = 0; i < Operations.medicineList.Count; i++)
            {
                MedicineDetails medicine = Operations.medicineList[i];
                medicineDetails[i] = medicine.MedicineID + "," + medicine.MedicineName + "," + medicine.Price + "," + medicine.DateOfExpiry.ToString("dd/MM/yyyy");
            }
            File.WriteAllLines("MyData/MedicineDetails.csv",medicineDetails);

            //Order Details
            string[] orderDetails = new string[Operations.orderList.Count];
            for (int i = 0; i < Operations.orderList.Count; i++)
            {
                OrderDetails order = Operations.orderList[i];
                orderDetails[i] = order.OrderID +","+order.UserID+","+order.MedicineID+","+order.MedicineCount+","+order.TotalPrice+","+order.OrderDate.ToString("dd/MM/yyyy")+","+order.OrderStatus;
            }
            File.WriteAllLines("MyData/OrderDetails.csv",orderDetails);

        }
    }
}