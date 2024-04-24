using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static class Operations
    {

        //public static lists
        public static CustomList<UserRegistration> userList = new CustomList<UserRegistration>();
        public static CustomList<TravelDetails> travelList = new CustomList<TravelDetails>();
        public static CustomList<TicketFairDetails> ticketList = new CustomList<TicketFairDetails>();

        //global user obj
        public static UserRegistration currentUser;

        //Mainmenu
        public static void Mainmenu()
        {
            string mainChoise = "yes";

            do
            {
                Console.WriteLine("1.User Registration");
                Console.WriteLine("2.UserLogin");
                Console.WriteLine("3.Exit");

                Console.Write("Select an Option : ");
                int mainOption = int.Parse(Console.ReadLine());

                switch (mainOption)
                {
                    case 1:
                        {
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            mainChoise = "no";
                            break;
                        }
                }

            } while (mainChoise.Equals("yes"));
        }
        //Main menu ends

        //User Registration
        public static void UserRegistration()
        {
            Console.Write("Enter your name : ");
            string userName = Console.ReadLine();

            Console.Write("Enter your Mobile Number : ");
            string mobile = Console.ReadLine();

            Console.Write("Enter the amount for the initial Balance : ");
            double balance = double.Parse(Console.ReadLine());

            UserRegistration user = new UserRegistration(userName, mobile, balance);

            userList.Add(user);
            Console.WriteLine($"Registration Sucessfull . Card Number is {user.CardNumber} ");
        }
        //User Registration Ends
        //Login
        public static void Login()
        {
            Console.Write("Enter your card Number : ");
            string cardNumber = Console.ReadLine().ToUpper();
            bool validCard = true;
            //foreach (UserRegistration user in userList)
            for(int i=0;i<userList.Count;i++)
            {
                if (userList[i].CardNumber.Equals(cardNumber))
                {
                    currentUser = userList[i];
                    Submenu();
                    validCard = false;
                }
            }
            if (validCard)
            {
                Console.WriteLine("Invalid Card Number ....");
            }
        }
        //Login Ends
        //Submenu
        //Submenu ends
        public static void Submenu()
        {
            string subChoise = "yes";
            do
            {
                Console.WriteLine("1.Balance Check");
                Console.WriteLine("2.Recharge");
                Console.WriteLine("3.View Travel History");
                Console.WriteLine("4.Travel");
                Console.WriteLine("5.Exit");
                Console.Write("Select an option : ");
                int subOption = int.Parse(Console.ReadLine());

                switch (subOption)
                {
                    case 1:
                        {
                            BalanceCheck();
                            break;
                        }
                    case 2:
                        {
                            Recharge();
                            break;
                        }
                    case 3:
                        {
                            TravelHistory();
                            break;
                        }
                    case 4:
                        {
                            Travel();
                            break;
                        }
                    case 5:
                        {
                            subChoise = "no";
                            break;
                        }
                }

            } while (subChoise.Equals("yes"));
        }
        //Subchoise Ends


        //Balance Check
        public static void BalanceCheck()
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Your Current Balance : {currentUser.Balance}");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }
        //Balance Check Ends


        //Recharge
        public static void Recharge()
        {
            Console.Write("Enter the Amount that you want to recharge : ");
            double amount = double.Parse(Console.ReadLine());
            if (amount <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Enter a valid Amount");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine();
            }
            else
            {
                currentUser.WalletRecharge(amount);
                Console.WriteLine();
                BalanceCheck();
            }

        }
        //Recharge Ends


        //Travel History
        public static void TravelHistory()
        {
            int travelCount = 0;
            //foreach (TravelDetails travel in travelList)
            for(int i = 0;i<travelList.Count;i++)
            {
                if (currentUser.CardNumber.Equals(travelList[i].CardNumber))
                {
                    if (travelCount == 0)
                    {
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        Console.WriteLine($"|{"TravelID",-10}|{"Card Number",-15}|{"From",-10}|{"To",-15}|{"Travel Date",-15}|{"TravelCost",-13}|");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                    }
                    travelCount++;
                    travelList[i].ShowTravelDetails();
                }
            }
            
            if (travelCount == 0)
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine("No Travel History found.....:(");
                Console.WriteLine("---------------------------------");
            }
            else
            {
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
        }
        //Travel History Ends

        //Travel
        public static void Travel()
        {
            //Displaying Available Ticket Details
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"TicketID",-10}|{"From",-15}|{"To",-15}|{"TicketPrice",-14}|");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            for (int i =0 ;i<ticketList.Count;i++)
            {
                ticketList[i].ShowTicketFairDetails();
            }

            //Asking to select the ticket
            Console.Write("Select the Ticket ID : ");
            string ticketID = Console.ReadLine().ToUpper();
            Console.WriteLine();

            //Checking if ticket is valid
            bool validTicket = true;
            //TicketBooking
            for(int i= 0 ;i<ticketList.Count;i++)
            {
                if (ticketList[i].TicketID.Equals(ticketID))
                {
                    validTicket = false;
                    //if balance is less than travel price ask him to recharge
                    if (ticketList[i].TicketPrice > currentUser.Balance)
                    {
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Insufficiant Balance , Please Recharge Your Card");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine();
                        break;
                    }
                    //else proceed
                    else
                    {
                        currentUser.DeductBalance(ticketList[i].TicketPrice);//Deduct the travel price from current user balance


                        //Create travel obj
                        TravelDetails travel = new TravelDetails(currentUser.CardNumber, ticketList[i].FromLocation, ticketList[i].ToLocation, DateTime.Now, ticketList[i].TicketPrice);
                        //Add Details to travel list
                        travelList.Add(travel);
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine($"Ticket Booked Successfully and your ticket ID is  {travel.TravelID}");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine();
                        break;
                    }
                }
            }
            //IF ticket is invalid
            if (validTicket)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("Invalid Ticket");
                Console.WriteLine("------------------");
            }
        }
        //Adding Default Data
        public static void AddDefaultData()
        {

            //User registration
            UserRegistration user = new UserRegistration("Ravi", "9848812345", 1000);
            UserRegistration user1 = new UserRegistration("Baskaran", "9948854321", 1000);

            userList.Add(user);
            userList.Add(user1);

            //TravelDetails 
            TravelDetails travel = new TravelDetails("CMRL1001", "Airport", "Egmore", new DateTime(2023, 10, 10), 55);
            TravelDetails travel1 = new TravelDetails("CMRL1001", "Egmore", "Koyambedu", new DateTime(2023, 10, 10), 32);
            TravelDetails travel2 = new TravelDetails("CMRL1002", "Alandur", "Koyambedu", new DateTime(2023, 10, 11), 25);
            TravelDetails travel3 = new TravelDetails("CMRL1002", "Egmore", "Thirumangalam", new DateTime(2023, 10, 11), 25);

            travelList.Add(travel);
            travelList.Add(travel1);
            travelList.Add(travel2);
            travelList.Add(travel3);

            //Ticket Details
            TicketFairDetails ticket = new TicketFairDetails("Airport", "Egmore", 55);
            TicketFairDetails ticket1 = new TicketFairDetails("Airport", "Koyambedu", 25);
            TicketFairDetails ticket2 = new TicketFairDetails("Alandur", "Koyambedu", 25);
            TicketFairDetails ticket3 = new TicketFairDetails("Koyambedu", "Egmore", 32);
            TicketFairDetails ticket4 = new TicketFairDetails("Vadapalani", "Egmore", 45);
            TicketFairDetails ticket5 = new TicketFairDetails("Arumbakkam", "Egmore", 25);
            TicketFairDetails ticket6 = new TicketFairDetails("Vadapalani", "Koyambedu", 25);
            TicketFairDetails ticket7 = new TicketFairDetails("Arumbakkam", "Koyambedu", 16);

            ticketList.Add(ticket);
            ticketList.Add(ticket1);
            ticketList.Add(ticket2);
            ticketList.Add(ticket3);
            ticketList.Add(ticket4);
            ticketList.Add(ticket5);
            ticketList.Add(ticket6);
            ticketList.Add(ticket7);
        }
        //Adding Default Data Ends
    }
}