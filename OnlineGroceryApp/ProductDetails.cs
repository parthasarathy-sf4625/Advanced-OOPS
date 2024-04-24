using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryApp
{
    public class ProductDetails
    {
        //Fields
        private static int s_productID = 2000;

        //Property
        public string ProductID{get;}
        public string ProductName{get;set;}
        public int CurrentAvailablity{get;set;}
        public double PricePerQuantity{get;set;}

        //Constructor

        public ProductDetails(string productName,int currentAvailablity,double pricePerQuantity)
        {
            ProductID = "PID"+(++s_productID);
            ProductName = productName;
            CurrentAvailablity = currentAvailablity;
            PricePerQuantity = pricePerQuantity;
        }

        //Methods


        public void ShowProductDetails()
        {
            Console.WriteLine($"|{ProductID}|{ProductName}|{CurrentAvailablity}|{PricePerQuantity}|");
        }
    }
}