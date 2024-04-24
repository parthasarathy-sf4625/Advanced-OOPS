using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class ItemDetails
    {
        //Fields
        public static int s_itemID = 4000;

        //Properties
        public string ItemID{get;}
        public string OrderID{get;set;}
        public string FoodID{get;set;}
        public int PurchaseCount{get;set;}
        public double PriceOfOrder{get;set;}

        //Constructor
        public ItemDetails(string orderID,string foodID,int purchaseCount,double priceOfOrder)
        {
            ItemID = "ITID"+(++s_itemID);
            OrderID = orderID;
            FoodID = foodID;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }
        public ItemDetails(string line)
        {
            string[] values = line.Split(",");
            s_itemID++;
            ItemID = values[0];
            OrderID = values[1];
            FoodID = values[2];
            PurchaseCount = int.Parse(values[3]);
            PriceOfOrder = double.Parse(values[4]);
        }

    }
}