using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TicketFairDetails
    {
        //Field
        private static int s_ticketID = 3000;

        //Property
        public string TicketID {get;set;}
        public string FromLocation{get;set;}
        public string ToLocation{get;set;}
        public double TicketPrice{get;set;}

        //Constructors

        public TicketFairDetails(string fromLocation,string toLocation,double ticketPrice)
        {
            TicketID = "MR"+(++s_ticketID);
            FromLocation = fromLocation;
            ToLocation = toLocation;
            TicketPrice = ticketPrice; 
        }

        public TicketFairDetails(string line)
        {
            string [] values = line.Split(",");
            s_ticketID++;
            TicketID = values[0];
            FromLocation = values[1];
            ToLocation = values[2];
            TicketPrice = double.Parse(values[3]);
        }

        //Methods

        public void ShowTicketFairDetails()
        {
            Console.WriteLine($"|{TicketID,-10}|{FromLocation,-15}|{ToLocation,-15}|{TicketPrice,-14}|");
        }
    }
}