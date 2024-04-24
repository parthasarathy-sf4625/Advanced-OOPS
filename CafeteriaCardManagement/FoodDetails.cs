using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class FoodDetails
    {
        /*•	FoodID (Auto - FID101)
          •	FoodName
          •	FoodPrice
          •	AvailableQuantity*/

          //Fields
          private static int s_foodID=100;

          //Property
          public string FoodID {get;}
          public string FoodName{get;set;} 
          public double FoodPrice{get;set;}
          public int AvailableQuantity{get;set;}  


          //Construcor
            //FID101	Coffee	20	100
          public FoodDetails(string foodName , double foodPrice, int availableQuality)
          {
            FoodID = "FID"+(++s_foodID);
            FoodName = foodName;
            FoodPrice = foodPrice;
            AvailableQuantity  =availableQuality;            
          }        
    }
}