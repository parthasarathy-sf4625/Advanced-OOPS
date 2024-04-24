using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public enum OrderStatus{Purchased,Cancelled}
    public class OrderDetails
    {
        //Fields
        private static int s_orderID = 2000;
        

        //Properties
        public string OrderID{get;}
        public string UserID{get;set;}
        public string MedicineID{get;set;}
        public int MedicineCount{get;set;}
        public double TotalPrice{get;set;}
        public DateTime OrderDate{get;set;}
        public OrderStatus OrderStatus{get;set;}
        

        //Constructor

        public OrderDetails(string userID,string medicineID,int medicineCount,double totalPrice,DateTime orderDate,OrderStatus orderStatus)
        {
            OrderID = "OID" +(++s_orderID);           
            UserID =userID;
            MedicineID = medicineID;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
        }
        public OrderDetails(string line)
        {
            string [] values = line.Split(",");
            ++s_orderID;
            OrderID = values[0];           
            UserID =values[1];
            MedicineID = values[2];
            MedicineCount = int.Parse(values[3]);
            TotalPrice = double.Parse(values[4]);
            OrderDate = DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
            OrderStatus = Enum.Parse<OrderStatus>(values[6],true);
        }
    }
}