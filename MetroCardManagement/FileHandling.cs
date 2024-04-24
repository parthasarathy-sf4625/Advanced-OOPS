using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("MyData"))
            {
                Directory.CreateDirectory("MyData");
            }
            if(!File.Exists("MyData/UserRegistration.csv")&&!File.Exists("MyData/TicketFairDetails.csv") && !File.Exists("MyData/TravelDetails.csv"))
            {
                File.Create("MyData/UserRegistration.csv");
                File.Create("MyData/TicketFairDetails.csv");
                File.Create("MyData/TravelDetails.csv");
            }
        }

        public static void WriteToCSV()
        {
            
            
            string[] userDetails = new string[Operations.userList.Count];
            for(int i =0;i<Operations.userList.Count;i++)
            {
                
                UserRegistration user = Operations.userList[i];

                userDetails[i] = user.CardNumber+","+user.UserName+","+user.PhoneNumber+","+user.Balance;
                
                
            }
            File.WriteAllLines("MyData/UserRegistration.csv",userDetails);



            string[] ticketDetails = new string[Operations.ticketList.Count];
            for(int i = 0 ;i<Operations.ticketList.Count;i++)
            {
                TicketFairDetails ticket = Operations.ticketList[i];
                ticketDetails[i] = ticket.TicketID+","+ticket.FromLocation+","+ticket.ToLocation+","+ticket.TicketPrice;
            }
            File.WriteAllLines("MyData/TicketFairDetails.csv",ticketDetails);


            string[] travelDetails = new string[Operations.travelList.Count];
            for(int i = 0;i<Operations.travelList.Count;i++)
            {
                TravelDetails travel = Operations.travelList[i];
                travelDetails[i] = travel.TravelID + ","+travel.CardNumber+","+travel.FromLocation+","+travel.ToLocation+","+travel.Date.ToString("dd/MM/yyyy")+","+travel.TravelCost;
            }
            File.WriteAllLines("MyData/TravelDetails.csv",travelDetails);

        }

        public static void ReadFromCSV()
        {
            string [] userList = File.ReadAllLines("MyData/UserRegistration.csv");
            foreach(string line in userList)
            {
                UserRegistration user = new UserRegistration(line);
                Operations.userList.Add(user);
            }

            string[] travelList = File.ReadAllLines("MyData/TravelDetails.csv");
            foreach(string line in travelList)
            {
                TravelDetails travel = new TravelDetails(line);
                Operations.travelList.Add(travel);
            }

            string [] ticketList = File.ReadAllLines("MyData/TicketFairDetails.csv");

            foreach(string line in ticketList)
            {
                TicketFairDetails ticket = new TicketFairDetails(line);
                Operations.ticketList.Add(ticket);
            }
            
        }
    }
}