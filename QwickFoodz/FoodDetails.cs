using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class FoodDetails
    {
        //Fields
        private static int s_foodID = 2000;

        //Properties

        public string FoodID { get; }
        public string FoodName { get; set; }
        public double PricePerQuantity { get; set; }
        public int QuantityAvailable { get; set; }

        //Constructor

        public FoodDetails(string foodName, double pricePerQuantity, int quantityAvailable)
        {
            FoodID = "FID"+(++s_foodID);
            FoodName = foodName;
            PricePerQuantity = pricePerQuantity;
            QuantityAvailable = quantityAvailable;
        }

        public FoodDetails(string line)
        {
            string[] values = line.Split(",");
            ++s_foodID;
            FoodID = values[0];
            FoodName = values[1];
            PricePerQuantity = double.Parse(values[2]);
            QuantityAvailable = int.Parse(values[3]);
        }
    }
}