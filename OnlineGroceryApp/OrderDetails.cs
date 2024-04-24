using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryApp
{
    public class OrderDetails
    {
        //Fields
        private static int s_orderID = 2000;

        //Properties
        public string OrderID{get;set;}
        public string BookingID{get;set;}
        public string ProductID{get;set;}
        public int PurchaceCount{get;set;}
        public double PriceOfOrder{get;set;}

        //Constructor
        public OrderDetails(string bookingID,string productID,int purchaceCount,double priceOfOrder)
        {
            OrderID = "OID"+(++s_orderID);
            BookingID = bookingID;
            ProductID = productID;
            PurchaceCount = purchaceCount;
            PriceOfOrder = priceOfOrder;
        }
    }
}