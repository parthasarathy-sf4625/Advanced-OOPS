using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TravelDetails
    {
        //fields
        private static int s_travelID = 2000;

        //Property
        public string TravelID{get;}
        public string CardNumber{get;set;}
        public string FromLocation{get;set;}
        public string ToLocation{get;set;}
        public DateTime Date{get;set;}
        public double TravelCost{get;set;}

        //Constructor
        public TravelDetails(string cardNumber,string fromLocation, string toLocation,DateTime date,double travelCost)
        {
            TravelID = "TID"+(++s_travelID);
            CardNumber = cardNumber;
            FromLocation= fromLocation;
            ToLocation = toLocation;
            Date = date;
            TravelCost = travelCost;
        }

        public TravelDetails(string line)
        {
            string[] values = line.Split(",");
            s_travelID++;
            TravelID = values[0];
            CardNumber = values[1];
            FromLocation = values[2];
            ToLocation = values[3];
            Date= DateTime.ParseExact(values[4],"dd/MM/yyyy",null);
            TravelCost = double.Parse(values[5]);
        }

        //Methods

        public void ShowTravelDetails()
        {
            Console.WriteLine($"|{TravelID,-10}|{CardNumber,-15}|{FromLocation,-10}|{ToLocation,-15}|{Date.ToString("dd/MM/yyyy"),-15}|{TravelCost,-13}|");
        }
    }
}