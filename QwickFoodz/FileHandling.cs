using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class FileHandling
    {
        public static void  Create()
        {
            if (!Directory.Exists("MyData"))
            {
                Directory.CreateDirectory("MyData");
            }

            if (!File.Exists("MyData/CustomerDetails.csv") && !File.Exists("MyData/FoodDetails.csv") && !File.Exists("MyData/OrderDetails.csv") && !File.Exists("MyData/OrderDetails.csv"))
            {
                File.Create("MyData/CustomerDetails.csv").Close();
                File.Create("MyData/FoodDetails.csv").Close();
                File.Create("MyData/OrderDetails.csv").Close();
                File.Create("MyData/OrderDetails.csv").Close();
            }
        }

        public static void ReadFromCSV()
        {
            //Customer Details
            string[] customerDetails = File.ReadAllLines("MyData/CustomerDetails.csv");

            foreach (string line in customerDetails)
            {
                CustomerDetails customer = new CustomerDetails(line);
                Operations.customerList.Add(customer);
            }

            //FoodDetails
            string[] foodDetails = File.ReadAllLines("MyData/FoodDetails.csv");
            foreach (string line in foodDetails)
            {
                FoodDetails food  =  new FoodDetails(line);
                Operations.foodList.Add(food);
            }

            //OrderDetails
            string[] orderDetails = File.ReadAllLines("MyData/OrderDetails.csv");
            foreach (string line in orderDetails)
            {
                OrderDetails order = new OrderDetails(line);
                Operations.orderList.Add(order);
            }

            //Order Details
            string[] orderDetails = File.ReadAllLines("MyData/OrderDetails.csv");
            foreach (string line in orderDetails)
            {
                OrderDetails order = new OrderDetails(line);
                Operations.orderList.Add(order);
            }


        }

        public static void WriteToCSV()
        {
            //Customer Details
            string[] customerDetails = new string[Operations.customerList.Count];
            for (int i = 0; i < Operations.customerList.Count; i++)
            {
                CustomerDetails customer = Operations.customerList[i];
                customerDetails[i] = customer.CustomerID + "," + customer.Name + "," + customer.FatherName + "," + customer.Gender + "," + customer.Mobile + "," + customer.DOB.ToString("dd/MM/yyyy") + "," + customer.MailID + "," + customer.Location + "," + customer.WalletBalance;
            }
            File.WriteAllLines("MyData/CustomerDetails.csv",customerDetails);

            //Food Details
            string[] foodDetails = new string[Operations.foodList.Count];
            for (int i = 0; i < Operations.foodList.Count; i++)
            {
                FoodDetails food = Operations.foodList[i];
                foodDetails[i] = food.FoodID + "," + food.FoodName + "," + food.PricePerQuantity + "," + food.QuantityAvailable;
            }
            File.WriteAllLines("MyData/FoodDetails.csv",foodDetails);

            //Order Details
            string[] orderDetails = new string[Operations.orderList.Count];
            for (int i = 0; i < Operations.orderList.Count; i++)
            {
                OrderDetails order = Operations.orderList[i];
                orderDetails[i] = order.OrderID +","+order.OrderID+","+order.FoodID+","+order.PurchaseCount+","+order.PriceOfOrder;
            }
            File.WriteAllLines("MyData/OrderDetails.csv",orderDetails);

            //OrderDetails
            string[] orderDetails = new string[Operations.orderList.Count];
            for (int i = 0; i < Operations.orderList.Count; i++)
            {
                OrderDetails order = Operations.orderList[i];
                orderDetails[i] = order.OrderID+","+order.CustomerID+","+order.TotalPrice+","+order.DateOfOrder.ToString("dd/MM/yyyy")+","+order.OrderStatus;
            }
            File.WriteAllLines("MyData/OrderDetails.csv",orderDetails);
        }
    }
}