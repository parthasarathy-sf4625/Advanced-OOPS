using System;
using System.Collections.Generic;
using System.Linq;


namespace CafeteriaCardManagement
{

    public static class Operations
    {
        public static List<FoodDetails> foodList = new List<FoodDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();
        public static List<UserDetails> userList = new List<UserDetails>();

        static UserDetails currentLoggedInUser;
        public static void MainMenu()
        {

            string mainChoise = "yes";

            do
            {
                //Displaying the MainMenu
                Console.WriteLine("1.User Registration");
                Console.WriteLine("2.User Login");
                Console.WriteLine("3.Exit");
                Console.Write("Select an Option : ");
                //Asking the user to select the option
                int mainOption = int.Parse(Console.ReadLine());
                //Pass the control using switch
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("**********************User Registration********************");
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("***********************User Login***************************");
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

        //UserRegistration 
        public static void UserRegistration()
        {

            Console.Write("Enter your Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter your Father Name : ");
            string fatherName = Console.ReadLine();

            Console.Write("Enter your Mobile Number : ");
            string mobile = Console.ReadLine();

            Console.Write("Enter your mailID : ");
            string mailID = Console.ReadLine();

            Console.Write("Enter your Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            Console.Write("Enter your workstation Number Eg.(WS100): ");
            string workStationNumber = Console.ReadLine();

            Console.Write("Enter your Balance Amount you want to add : ");
            double walletBalance = double.Parse(Console.ReadLine());
            //string name,string fatherName,Gender gender,string mobile,string mailID,double walletBalance,string workStationNumber
            UserDetails user = new UserDetails(name, fatherName, gender, mobile, mailID, walletBalance, workStationNumber);

            userList.Add(user);

        }//User Registration Ends

        //Login
        public static void Login()
        {
            string loginChoise = "yes";

            Console.Write("Enter your User ID : ");
            string userID = Console.ReadLine().ToUpper();

            bool validUser = true;
            foreach (UserDetails user in userList)
            {
                if (user.UserID.Equals(userID))
                {
                    validUser = false;
                    currentLoggedInUser = user;
                    break;
                }
            }

            //if user not found
            if (validUser)
            {
                Console.WriteLine("Invalid User.......Try again");//takes to the main menu
            }
            else
            {
                do
                {
                    Console.WriteLine("Select an Option  : ");
                    Console.WriteLine("1.Show my Profile");
                    Console.WriteLine("2.Food Order");
                    Console.WriteLine("3.Modify Order");
                    Console.WriteLine("4.Cancel Order");
                    Console.WriteLine("5.Order History");
                    Console.WriteLine("6.Wallet Recharge");
                    Console.WriteLine("7.Show Wallet Balance");
                    Console.WriteLine("8.Exit");

                    int loginOption = int.Parse(Console.ReadLine());

                    switch (loginOption)
                    {
                        case 1:
                            {
                                Console.WriteLine("*****************Profile*****************");
                                break;
                            }

                        case 2:
                            {
                                Console.WriteLine("****************Food Order*****************");
                                break;
                            }

                        case 3:
                            {
                                Console.WriteLine("****************Modify Order***************");
                                break;
                            }

                        case 4:
                            {
                                Console.WriteLine("****************Cancel Order*****************");
                                break;
                            }

                        case 5:
                            {
                                Console.WriteLine("****************Order History**************");
                                break;
                            }

                        case 6:
                            {
                                Console.WriteLine("****************Wallet Recharge**************");
                                break;
                            }

                        case 7:
                            {
                                Console.WriteLine("*****************Wallet Balance***************");
                                break;
                            }
                        case 8:
                            {
                                Console.WriteLine("********************Exit*****************");
                                break;
                            }


                    }
                } while (loginChoise.Equals("yes"));
            }

        }//Login ends

        //show user Details

        public static void ShowUserDetails()
        {

        }//Show user Detail Ends

        //Food Order
        //Modify order
        //Cancel Order
        //Order History
        //Wallet Recharge
        public static void WalletRecharge()
        {
            currentLoggedInUser.WalletRecharge();
            WalletBalance();
        }
        //Wallet Recharge Ends
        //Show WalletBalance
        public static void WalletBalance()
        {
            Console.WriteLine();
            Console.WriteLine($"Current Wallet Balance : {currentLoggedInUser.WalletBalance}");
        }
        //Show Wallet Balance ends
        //Adding default Values
        public static void AddDefaultDetails()
        {
            FoodDetails food1 = new FoodDetails("Coffee", 20, 100);
            FoodDetails food2 = new FoodDetails("Tea", 15, 100);
            FoodDetails food3 = new FoodDetails("Biscuit", 10, 100);
            FoodDetails food4 = new FoodDetails("Juice", 50, 100);
            FoodDetails food5 = new FoodDetails("Puff", 20, 100);
            FoodDetails food6 = new FoodDetails("Puff", 20, 100);
            FoodDetails food7 = new FoodDetails("Puff", 20, 100);

            foodList.AddRange(new List<FoodDetails> { food1, food2, food3, food4, food5 });

            OrderDetails order1 = new OrderDetails("SF1001", new DateTime(2022, 06, 15), 70, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("SF1002", new DateTime(2022, 06, 15), 100, OrderStatus.Ordered);

            orderList.AddRange(new List<OrderDetails> { order1, order2 });


            UserDetails user1 = new UserDetails("Ravichandran", "Ettapparajan", Gender.Male, "8857777575", "ravi@gmail.com", 400, "WS101");
            UserDetails user2 = new UserDetails("Baskaran", "Sethurajan", Gender.Male, "8857777575", "baskaran@gmail.com", 500, "WS105");

            userList.AddRange(new List<UserDetails> { user1, user2 });

        }
        //Add Default values end
    }
}