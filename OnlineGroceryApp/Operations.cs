using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryApp
{
    public static class Operations
    {
        public static List<CustumerDetails> custumerList = new List<CustumerDetails>();
        public static List<ProductDetails> productList = new List<ProductDetails>();
        public static List<BookingDetails> bookingList = new List<BookingDetails>();
        public static List<OrderDetails> orderList = new List<OrderDetails>();

        public static CustumerDetails currentLoggedInUser;


        //Main Menu
        public static void MainMenu()
        {
            string mainChoise = "yes";
            do
            {
                Console.WriteLine("1.Custumer Registration");
                Console.WriteLine("2.Custumer Login");
                Console.WriteLine("3.Exit");
                int mainOption = int.Parse(Console.ReadLine());

                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("**********Reg*******");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("**********Login*******");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*******Exit******");
                            break;
                        }
                }
            } while (mainChoise == "yes");
        }
        //MainMenu Ends

        //Registration
        public static void Registration()
        {
            Console.Write("Enter Your Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter Your FatherName : ");
            string fatherName = Console.ReadLine();

            Console.Write("Enter Your Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            Console.Write("Enter Your Mobile : ");
            string mobile = Console.ReadLine();

            Console.Write("Enter your Date of Birth : ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Enter Your MailID : ");
            string mailID = Console.ReadLine();

            Console.Write("Enter the Amount that you want to Deposit : ");
            double amount = double.Parse(Console.ReadLine());

            CustumerDetails custumer = new CustumerDetails(name, fatherName, gender, mobile, dob, mailID, amount);

            custumerList.Add(custumer);

            Console.WriteLine($"Registration sucessfull. CustumerID is {custumer.CustumerID}");
        }
        //Registration Ends

        //Login
        public static void Login()
        {
            Console.Write("Enter your User ID : ");
            string userID = Console.ReadLine();
            bool validUser = true;
            foreach (CustumerDetails custumer in custumerList)
            {
                if (custumer.CustumerID.Equals(userID))
                {
                    currentLoggedInUser = custumer;
                    validUser = false;
                }
            }
            if (validUser)
            {
                Console.WriteLine("Invalid User");
            }
            else
            {
                string loginChoise = "yes";
                do
                {
                    Console.WriteLine("1.Show Custumer Details");
                    Console.WriteLine("2.Show Product Details");
                    Console.WriteLine("3.Wallet Recharge");
                    Console.WriteLine("4.Take Order");
                    Console.WriteLine("5.Modify Order Quantity");
                    Console.WriteLine("6.Cancel Order");
                    Console.WriteLine("7.Show Balance");
                    Console.WriteLine("8.Exit");
                    Console.WriteLine();
                    Console.Write("Choose an Option : ");

                    int loginOption = int.Parse(Console.ReadLine());

                    switch (loginOption)
                    {
                        case 1:
                            {
                                Console.WriteLine("*******Custumer Details***********");
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("**********Product Details**********");
                                ShowProductDetails();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("***********Wallet Recharge**********");
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("**********Take Order*************");
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("*************Modify ***************");
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("*************Cancel**********");
                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("**************Balance************");
                                break;
                            }
                        case 8:
                            {
                                Console.WriteLine("*************Exit****************");
                                loginChoise = "no";
                                break;
                            }
                    }
                } while (loginChoise.Equals("yes"));
            }

        }
        //Login Ends
        //Show Custumer Details
        //Show Product Details
        public static void ShowProductDetails()
        {
            foreach (ProductDetails product in productList)
            {
                product.ShowProductDetails();
            }
        }
        //Wallet Recharge
        //Take Order
        public static void TakeOrder()
        {


            BookingDetails booking = new BookingDetails(currentLoggedInUser.CustumerID, 0);
            List<OrderDetails> tempOrderList = new List<OrderDetails>();

            Console.Write("Do you want to purchase : ");
            string orderChoise = Console.ReadLine().ToLower();
            double totalPurchaseAmount = 0;

            while (orderChoise.Equals("yes"))
            {

                ShowProductDetails();

                Console.Write("Select the Product that you want to buy : ");
                string productID = Console.ReadLine();
                bool validProduct = true;
                //Check if the product id is valid
                foreach (ProductDetails product in productList)
                {
                    if (product.ProductID.Equals(productID))
                    {
                        validProduct = false;
                        Console.Write("Enter the Quantity that you want to bowl : ");
                        int productQuantity = int.Parse(Console.ReadLine());
                        if (productQuantity <= product.CurrentAvailablity)
                        {

                            double purchaseAmount = product.PricePerQuantity * productQuantity;
                            product.CurrentAvailablity--;
                            totalPurchaseAmount += purchaseAmount;

                            OrderDetails order = new OrderDetails(booking.BookingID, product.ProductID, productQuantity, purchaseAmount);
                            tempOrderList.Add(order);
                        }
                        else
                        {
                            Console.WriteLine("The selected Product is not a available for the selected Quantity");
                            break;
                        }
                    }
                    if (validProduct)
                    {
                        Console.WriteLine("Invalid ProductID");
                        break;
                    }
                    Console.Write("Do you want to purchase : ");
                    orderChoise = Console.ReadLine().ToLower();
                }
            }
            Console.Write("Do you want to continue the Order (yes/no): ");
            string confirmOrder = Console.ReadLine().ToLower();

            if (confirmOrder.Equals("yes"))
            {
                if (totalPurchaseAmount > currentLoggedInUser.WalletBalance)
                {
                    do
                    {
                        Console.WriteLine($"Insufficiant Balance. Recharge with {totalPurchaseAmount}");
                        Console.WriteLine("Do you want to continue (yes/no): ");
                        string rechargeChoise = Console.ReadLine().ToLower();
                        currentLoggedInUser.WalletRecharge(totalPurchaseAmount);
                    } while (totalPurchaseAmount > currentLoggedInUser.WalletBalance);
                }
                else
                {
                    currentLoggedInUser.WalletBalance -= totalPurchaseAmount;
                    booking.BookingStatus = BookingStatus.Booked;
                    bookingList.Add(booking);
                }
            }
            else
            {
                foreach (OrderDetails order in tempOrderList)
                {
                    foreach (ProductDetails product in productList)
                    {
                        if (order.ProductID.Equals(product.ProductID))
                        {
                            product.CurrentAvailablity++;
                        }
                    }
                }
            }




        }
        //Modify Order Quantity
        //Cancel Order
        //Add Default Values
        public static void AddDefaultDetails()
        {
            //Custumer Details
            CustumerDetails custumer = new CustumerDetails("Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmail.com", 10000);

            CustumerDetails custumer1 = new CustumerDetails("Baskaran", "Sethurajan", Gender.Male, "977849493", new DateTime(1999, 11, 11), "baskar@gmail.com", 15000);

            custumerList.AddRange(new List<CustumerDetails>() { custumer, custumer1 });

            //Product Details

            ProductDetails product = new ProductDetails("Sugar", 20, 40);
            ProductDetails product1 = new ProductDetails("Rice", 100, 20);
            ProductDetails product2 = new ProductDetails("Milk", 40, 40);
            ProductDetails product3 = new ProductDetails("Tea", 100, 25);
            ProductDetails product4 = new ProductDetails("Coffee", 100, 30);

            productList.AddRange(new List<ProductDetails>() { product, product1, product2, product3, product4 });

            //Booking ID


        }
        //Add Default Values End
    }
}