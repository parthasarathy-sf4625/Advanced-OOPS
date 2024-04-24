using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore
{
    public static class Operations
    {
        //static public list
        public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
        public static CustomList<MedicineDetails> medicineList = new CustomList<MedicineDetails>();
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();


        //Curent user 
        public static UserDetails currentUser;


        //MainMenu
        public static void MainMenu()
        {
            string mainChoise = "yes";

            do
            {
                //MainMenu
                Console.WriteLine("1.User Registration");
                Console.WriteLine("2.User Login");
                Console.WriteLine("3.Exit");
                Console.Write("Choose an Option (1,2,3):");
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
            }
            while (mainChoise.Equals("yes"));
        }

        //User Registration
        public static void UserRegistration()
        {
            Console.Write("Entyer your name : ");
            string name = Console.ReadLine();

            Console.Write("Enter your age : ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter your city : ");
            string city = Console.ReadLine();

            Console.Write("Enter your Phone Number : ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter the Amount you want to Add : ");
            double balance = double.Parse(Console.ReadLine());

            UserDetails user = new UserDetails(name, age, city, phoneNumber, balance);
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"User Registration Sucessfull . Your User ID is {user.UserID}");
            Console.WriteLine("--------------------------------------------------------------");
        }
        //User Registration ends

        //Login
        public static void Login()
        {
            Console.Write("Enter your User ID : ");
            string userID = Console.ReadLine().ToUpper();
            bool validUser = true;
            foreach (UserDetails user in userList)
            {
                if (user.UserID.Equals(userID))
                {
                    validUser = false;
                    currentUser = user;
                    SubMenu();
                    //Call submenu
                }
            }
            if (validUser)
            {
                Console.WriteLine("Invalid User ID");
            }
        }
        //Login ends

        //Submenu
        public static void SubMenu()
        {
            string subChoise = "yes";

            do
            {
                Console.WriteLine("1.Show Medicine List");
                Console.WriteLine("2.Purchase Medicine");
                Console.WriteLine("3.Modify Purchase");
                Console.WriteLine("4.Cancel Purchase");
                Console.WriteLine("5.Show Purchase history");
                Console.WriteLine("6.Recharge Wallet");
                Console.WriteLine("7.Show Wallet Balance");
                Console.WriteLine("8.Exit");
                Console.Write("Select an Option : ");
                int mainOption = int.Parse(Console.ReadLine());

                switch (mainOption)
                {
                    case 1:
                        {
                            ShowMedicineDetails();

                            break;
                        }
                    case 2:
                        {
                            PurchaseMedcine();
                            break;
                        }
                    case 3:
                        {
                            ModifyPurchase();
                            break;
                        }
                    case 4:
                        {
                            CancelOrder();
                            break;
                        }
                    case 5:
                        {
                            ShowPurchaseHistory();
                            break;
                        }
                    case 6:
                        {
                            RechargeWallet();
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            subChoise = "no";
                            break;
                        }
                }

            } while (subChoise.Equals("yes"));
        }
        //Submenu Ends

        //Show Medicine Details
        public static void ShowMedicineDetails()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"MedicineID",-15}|{"MedicineName",-15}|{"AvailableCount",-15}|{"Price",-15}|{"DateOfExpiry",-15}|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            foreach (MedicineDetails medicine in medicineList)
            {
                Console.WriteLine($"|{medicine.MedicineID,-15}|{medicine.MedicineName,-15}|{medicine.AvailableCount,-15}|{medicine.Price,-15}|{medicine.DateOfExpiry.ToString("dd/MM/yyyy"),-15}|");
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        }
        //Show Medicine Details End


        //Purchase Medicine
        public static void PurchaseMedcine()
        {

            //1.	Show the List of medicine details by traversing the medicine details list.
            ShowMedicineDetails();
            //2.	Ask the user to select the medicine using MedicineID.
            Console.Write("Select the Medicine ID : ");
            string medID = Console.ReadLine().ToUpper();

            //3.	Ask the number of counts of that medicine he wants to buy.
            Console.Write("Enter the Quantity : ");
            int medQuantity = int.Parse(Console.ReadLine());
            //4.	Check the Medicine list whether the MedicineID was available. If it is available, then 
            bool validMed = true;
            foreach (MedicineDetails medicine in medicineList)
            {
                if (medicine.MedicineID.Equals(medID))
                {
                    validMed = false;
                    //a.	check the asked count is available. If it is available, then 
                    if (medicine.AvailableCount >= medQuantity)
                    {
                        //b.	Check the medicine was not expired. If it is expired or not available, then show the user “Medicine is not available”.
                        if (medicine.DateOfExpiry > DateTime.Now)
                        {
                            //c.	If the medicine is not expired, then check User has enough balance to purchase that medicine. 

                            double totalPrice = medicine.Price * medQuantity;
                            if (totalPrice <= currentUser.WalletBalance)
                            {
                                //5.	Reduce the number of AvailableCount of that medicine in MedicineDetails.
                                medicine.AvailableCount--;
                                //6.	Deduct the total amount from user’s balance amount.
                                currentUser.DeductBalance(totalPrice);
                                //7.	If all the conditions specified in step 4 are true then calculate the total amount of purchased medicines, OrderDate is Now, Put OrderStatus as “Purchased” and create object for OrderDetails class and add it to the list. 
                                OrderDetails order = new OrderDetails(currentUser.UserID, medicine.MedicineID, medQuantity, totalPrice, DateTime.Now, OrderStatus.Purchased);
                                //8.	Finally show the message “Medicine was purchased successfully”.
                                Console.WriteLine("Medicine was purchased sucessfully");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Medicine is Not Available");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Medicine is Not available");
                    }
                }
            }
            if (validMed)
            {
                Console.WriteLine("Invalid Medicine ID");
            }
        }

        //Modify Purchase
        public static void ModifyPurchase()
        {
            //1.	Show the order details of current logged in user to pick a order detail by using OrderID and whose status is “Purchased”.
            foreach (OrderDetails order in orderList)
            {
                // Check whether the purchase details is present. If yes then,
                if (order.UserID.Equals(currentUser.UserID) && (order.OrderStatus == OrderStatus.Purchased))
                {
                    Console.WriteLine($"|{order.OrderID}|{order.UserID}|{order.MedicineID}|{order.MedicineCount}|{order.TotalPrice}|{order.OrderDate.ToString("dd/MM/yyyy")}|{order.OrderStatus}|");
                } //2.Ensure the order ID is available and ask the user to enter the new quantity of the medicine. Calculate the order price and update in the order price.

            }
            Console.Write("Enter the Order ID : ");
            string orderID = Console.ReadLine().ToUpper();
            bool validOrder = true;

            foreach (OrderDetails order in orderList)
            {
                if (orderID.Equals(order.OrderID))
                {
                    validOrder = false;
                    Console.Write("Enter the new Quantity of Medicine : ");
                    int newQuantity = int.Parse(Console.ReadLine());
                    double newTotalPrice = (order.TotalPrice / order.MedicineCount) * newQuantity;
                    order.TotalPrice = newTotalPrice;
                    foreach (MedicineDetails medicine in medicineList)
                    {
                        if (medicine.MedicineID.Equals(order.MedicineID))
                        {
                            //3.	Calculate the total price of order and update in order details entry. 
                            medicine.AvailableCount += order.MedicineCount - newQuantity;
                            break;
                        }
                    }
                    order.MedicineCount = newQuantity;
                    //4.	Show order modified successfully.
                    Console.WriteLine("Order Modified Sucessfully");
                    break;
                }
            }
            if (validOrder)
            {
                Console.WriteLine("Invalid Order ID");
            }
        }
        //Modify Purchase ends

        //Cancel Purchase
        public static void CancelOrder()
        {
            int purchaseCount = 0;
            foreach (OrderDetails order in orderList)
            {
                if (order.UserID.Equals(currentUser.UserID) && order.OrderStatus == OrderStatus.Purchased)
                {
                    if (purchaseCount == 0)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"|{"OrderID",-15}|{"UserID",-15}|{"MedicineID",-15}|{"MedicineCount",-15}|{"TotalPrice",-15}|{"OrderDate",-15}|{"OrderStatus",-15}|");
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
                    }
                    purchaseCount++;
                    Console.WriteLine($"|{order.OrderID,-15}|{order.UserID,-15}|{order.MedicineID,-15}|{order.MedicineCount,-15}|{order.TotalPrice,-15}|{order.OrderDate.ToString("dd/MM/yyyy"),-15}|{order.OrderStatus,-15}|");

                }
            }
            if(purchaseCount==0)
            {
                Console.WriteLine("You have not made any Purchases");
            }
            else
            {
                Console.Write("Enter the OrderID you want to cancel : ");
                string cancelOrderID = Console.ReadLine().ToUpper();
                bool validOrder = true;
                foreach(OrderDetails order in orderList)
                {
                    if(order.OrderID.Equals(cancelOrderID))
                    {
                        validOrder = false;
                        order.OrderStatus = OrderStatus.Cancelled;
                        Console.WriteLine("Order Cancelled Sucessfully");
                        foreach(MedicineDetails medicine in medicineList )
                        {
                            if(medicine.MedicineID.Equals(order.MedicineID))
                            {
                                medicine.AvailableCount+=order.MedicineCount;
                                break;
                            }
                        }
                        currentUser.WalletRecharge(order.TotalPrice);
                    }
                }
                if(validOrder)
                {
                    Console.WriteLine("Invalid OrderID");
                }
            }
        }
        //Cancel Purchase Ends

        //Show Purchase History
        public static void ShowPurchaseHistory()
        {
            int purchaseCount = 0;
            foreach (OrderDetails order in orderList)
            {
                if (order.UserID.Equals(currentUser.UserID))
                {
                    if (purchaseCount == 0)
                    {
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"|{"OrderID",-15}|{"UserID",-15}|{"MedicineID",-15}|{"MedicineCount",-15}|{"TotalPrice",-15}|{"OrderDate",-15}|{"OrderStatus",-15}|");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    }
                    purchaseCount++;
                    Console.WriteLine($"|{order.OrderID,-15}|{order.UserID,-15}|{order.MedicineID,-15}|{order.MedicineCount,-15}|{order.TotalPrice,-15}|{order.OrderDate.ToString("dd/MM/yyyy"),-15}|{order.OrderStatus,-15}|");

                }
            }
            if(purchaseCount==0)
            {
                Console.WriteLine("You have not made any Purchases");
            }
        }

        //Recharge Wallet
        public static void RechargeWallet()
        {
            Console.Write("Enter the Amount : ");
            double amount = double.Parse(Console.ReadLine());
            currentUser.WalletRecharge(amount);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Recharge Suceessfull");
            Console.WriteLine("----------------------------------------------");

        }

        //Show Wallet Balance 
        public static void ShowWalletBalance()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Your Current Balance is {currentUser.WalletBalance}");
            Console.WriteLine("----------------------------------------------");
        }

        //AddDefault Values
        public static void AddDefaultDetails()
        {
            UserDetails user1 = new UserDetails("Ravi", 33, "Theni", "9877774440", 400);
            UserDetails user2 = new UserDetails("Baskaran", 33, "Chennai", "8847757470", 500);

            userList.AddRange(new CustomList<UserDetails> { user1, user2 });

            MedicineDetails medicine1 = new MedicineDetails("Paracitamol", 40, 5, new DateTime(2024, 06, 30));
            MedicineDetails medicine2 = new MedicineDetails("Calpol", 40, 5, new DateTime(2024, 06, 30));
            MedicineDetails medicine3 = new MedicineDetails("Gelucil", 40, 5, new DateTime(2024, 06, 30));
            MedicineDetails medicine4 = new MedicineDetails("Metrogel", 40, 5, new DateTime(2024, 06, 30));
            MedicineDetails medicine5 = new MedicineDetails("Povidin lodin", 40, 5, new DateTime(2024, 06, 30));

            medicineList.AddRange(new CustomList<MedicineDetails> { medicine1, medicine2, medicine3, medicine4, medicine5 });

            OrderDetails order1 = new OrderDetails("UID1001", "MD101", 3, 15, new DateTime(2022, 11, 13), OrderStatus.Purchased);
            OrderDetails order2 = new OrderDetails("UID1001", "MD102", 2, 10, new DateTime(2022, 11, 13), OrderStatus.Cancelled);
            OrderDetails order3 = new OrderDetails("UID1001", "MD104", 2, 100, new DateTime(2022, 11, 13), OrderStatus.Purchased);
            OrderDetails order4 = new OrderDetails("UID1002", "MD103", 3, 120, new DateTime(2022, 11, 15), OrderStatus.Cancelled);
            OrderDetails order5 = new OrderDetails("UID1002", "MD105", 5, 250, new DateTime(2022, 11, 15), OrderStatus.Purchased);
            OrderDetails order6 = new OrderDetails("UID1002", "MD102", 3, 15, new DateTime(2022, 11, 15), OrderStatus.Purchased);

            orderList.AddRange(new CustomList<OrderDetails> { order1, order2, order3, order4, order5, order6 });
        }
        //AddDefault Values End

    }
}