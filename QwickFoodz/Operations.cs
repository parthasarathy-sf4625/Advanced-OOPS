using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public static class Operations
    {
        //Global Static Lists
        /// <summary>
        /// A Custom List which stores All the CustomerDetails Object Data 
        /// </summary>
        /// <typeparam name="customerList"></typeparam>
        /// <returns></returns>
        public static CustomList<CustomerDetails> customerList = new CustomList<CustomerDetails>();

        /// <summary>
        /// A Custom List which stores All the FoodDetails Object Data
        /// </summary> 
        /// <typeparam name="foodList"></typeparam>
        /// <returns></returns>
        public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
        /// <summary>
        /// A Custom List which stores All the OrderDetails Object Data
        /// </summary> 
        /// <typeparam name="orderList"></typeparam>
        /// <returns></returns>
        public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
        /// <summary>
        /// A Custom List which stores All the ItemDetails Object Data
        /// </summary> 
        /// <typeparam name="itemList"></typeparam>
        /// <returns></returns>
        public static CustomList<ItemDetails> itemList = new CustomList<ItemDetails>();


        //Global - Current Logged in user
        public static CustomerDetails currentUser;

        //MainMenu
        public static void MainMenu()
        {


            string mainChoise = "yes";
            do
            {
                Console.WriteLine("1.Customer Registration");
                Console.WriteLine("2.Login");
                Console.WriteLine("3.Exit");
                Console.Write("Select an Option : ");

                int mainOption = int.Parse(Console.ReadLine());

                switch (mainOption)
                {
                    case 1:
                        {
                            //User Registration
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            //Login
                            Login();
                            break;
                        }
                    case 3:
                        {
                            //Exit
                            mainChoise = "no";
                            break;
                        }
                }

            } while (mainChoise.Equals("yes"));
        }
        //MainMenu Ends

        //User Registration
        public static void UserRegistration()
        {
            Console.Write("Enter you name :");
            string name = Console.ReadLine();

            Console.Write("Enter your Father Name : ");
            string fatherName = Console.ReadLine();

            Console.Write("Enter your Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            Console.Write("Enter your Mobile Number : ");
            string mobile = Console.ReadLine();

            Console.Write("Enter Your Date Of Birth : ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Console.Write("Enter Your MailID : ");
            string mailID = Console.ReadLine();

            Console.Write("Enter your Location : ");
            string location = Console.ReadLine();

            Console.Write("Enter the balance you want to add : ");
            double balance = double.Parse(Console.ReadLine());

            CustomerDetails customer = new CustomerDetails(name, fatherName, gender, mobile, dob, mailID, location, balance);

            customerList.Add(customer);

            Console.WriteLine($"User Registration Sucessfull. Your User ID is {customer.CustomerID}");
        }
        //User Registration Ends

        //Login
        public static void Login()
        {
            Console.Write("Enter your Customer ID : ");
            string customerID = Console.ReadLine().ToUpper();
            bool validID = true;
            foreach (CustomerDetails customer in customerList)
            {
                if (customer.CustomerID.Equals(customerID))
                {
                    currentUser = customer;
                    validID = false;
                    Submenu();
                }
            }
            if (validID)
            {
                Console.WriteLine("Invalid Customer ID");
            }
        }
        //Login Ends
        //Submenu
        public static void Submenu()
        {
            string subChoise = "yes";
            do
            {
                Console.WriteLine("1.Show Profile");
                Console.WriteLine("2.Order Food");
                Console.WriteLine("3.Cancel Order");
                Console.WriteLine("4.Modify Order ");
                Console.WriteLine("5.Order History");
                Console.WriteLine("6.Recharge Wallet");
                Console.WriteLine("7.Show Wallet Balance");
                Console.WriteLine("8.Exit");

                Console.Write("Select and Option : ");
                int subOption = int.Parse(Console.ReadLine());

                switch (subOption)
                {
                    case 1:
                        {
                            ShowProfile();
                            break;
                        }
                    case 2:
                        {
                            OrderFood();
                            break;
                        }
                    case 3:
                        {
                            CancelOrder();
                            break;
                        }
                    case 4:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
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
        //Submenu ends

        //Show Profile
        public static void ShowProfile()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"Customer ID : {currentUser.CustomerID}");
            Console.WriteLine();
            Console.WriteLine($"Customer Name : {currentUser.Name}");
            Console.WriteLine();
            Console.WriteLine($"Father Name :{currentUser.FatherName}");
            Console.WriteLine();
            Console.WriteLine($"Gender :{currentUser.Gender}");
            Console.WriteLine();
            Console.WriteLine($"Mobile : {currentUser.Mobile}");
            Console.WriteLine();
            Console.WriteLine($"Date of Birth : {currentUser.DOB.ToString("dd/MM/yyyy")}");
            Console.WriteLine();
            Console.WriteLine($"MailId : {currentUser.MailID}");
            Console.WriteLine("-----------------------------------------------------------------");
        }
        //Show Profile ends

        //OrderFood
        public static void OrderFood()
        {
            //a.	Create OrderDetails object with CustomerID, TotalPrice = 0, DateOfOrder as today and OrderStatus = Initiated.
            OrderDetails order = new OrderDetails(currentUser.CustomerID, 0, DateTime.Now, OrderStatus.Initiated);
            //b.	Create localItemList for adding your wishlist.
            CustomList<ItemDetails> localItemList = new CustomList<ItemDetails>();
            //c.	Show all the list of food items available in store for processing the order.
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|{"Food ID",-20}|{"Food Name",-25}|{"Price Per Quantity",-20}|{"Available Quantity",-23}|");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------");
            foreach (FoodDetails food in foodList)
            {
                Console.WriteLine($"|{food.FoodID,-20}|{food.FoodName,-25}|{food.PricePerQuantity,-20}|{food.QuantityAvailable,-23}|");
            }
            //d.	Ask the FoodID, order quantity from user and check whether it is available. If not show FoodID Invalid or FoodQuantity unavailable based on the scenario. 
            string orderChoise = "yes";
            do
            {
                Console.Write("Enter the food Item : ");
                string foodID = Console.ReadLine().ToUpper();
                bool validFood = true;
                foreach (FoodDetails food in foodList)
                {
                    if (foodID.Equals(food.FoodID))
                    {
                        validFood = false;
                        Console.Write("Enter the Quantity : ");
                        int foodQuantity = int.Parse(Console.ReadLine());
                        double priceOfOrder = foodQuantity * food.PricePerQuantity;
                        //e.	If it is available then, create ItemDetails object with created OrderID, FoodID, Quantity and Price of this order, 
                        ItemDetails item = new ItemDetails(order.OrderID, food.FoodID, foodQuantity, priceOfOrder);
                        //deduct the available quantity and store the ItemDetails object in localItemList. 
                        food.QuantityAvailable -= foodQuantity;
                        localItemList.Add(item);
                        //Calculate total price of this order by summing it with current item’s price. 
                        order.TotalPrice += priceOfOrder;
                        break;
                    }
                }
                if (validFood)
                {
                    Console.WriteLine("Invalid Food ID");
                }

                Console.Write("Do you want to order more Food (yes/no) : ");
                orderChoise = Console.ReadLine().ToLower();
            }
            while (orderChoise.Equals("yes"));
            //g.	If user select “No” then show “Do you want to confirm purchase.”
            Console.Write("Do you want to confrim Your Purchase (yes/no): ");
            string purchaseConfirm = Console.ReadLine().ToLower();
            //h.	If he says “Yes”. 
            if (purchaseConfirm.Equals("yes"))
            {

                //i.	Check whether the customer wallet has sufficient balance.
                bool confirmPurchase = true;
                do
                {
                    if (currentUser.WalletBalance >= order.TotalPrice)
                    {
                        //j.	 If he has balance then, modify OrderDetails object which was created at beginning with TotalPrice and OrderStatus to “Ordered”. 
                        //Deduct the total amount from user’s wallet balance. Add the localItemList to ItemList. 
                        order.OrderStatus = OrderStatus.Ordered;
                        currentUser.DeductBalance(order.TotalPrice);
                        itemList.AddRange(localItemList);
                        orderList.Add(order);

                        Console.WriteLine($"Order Confimred . Order ID is {order.OrderID}");
                        break;
                    }
                    //k.	If the balance is insufficient, inform the customer that the wallet has insufficient balance and whether wish to recharge /not.
                    else
                    {
                        Console.Write("Insufficiant Balance , Do you wish to recharge (yes/no):");
                        string rechargeChoise = Console.ReadLine().ToLower();
                        //m.	If “Yes” ask for the amount to be recharged. Show the balance after recharge and goto step “i” to proceed purchase again.
                        if (rechargeChoise.Equals("yes"))
                        {
                            RechargeWallet();
                        }
                        //l.	If he says “No” return the localItemList item’s count to FoodList.
                        else
                        {
                            purchaseConfirm = "no";
                            confirmPurchase = false;
                        }

                    }
                }
                while (confirmPurchase);


            }
            if (purchaseConfirm.Equals("no"))
            {
                //l.	 If he says “No” return the localItemList of items count back to FoodDetails list.

                foreach (ItemDetails item in localItemList)
                {
                    foreach (FoodDetails food in foodList)
                    {
                        if (item.FoodID.Equals(food.FoodID))
                        {
                            food.QuantityAvailable += item.PurchaseCount;
                            break;
                        }
                    }
                }

            }





        }
        //OrdeFoodEnds

        //CancelOrder
        public static void CancelOrder()
        {
            int orderCount = 0;
            foreach (OrderDetails order in orderList)
            {
                if (order.CustomerID.Equals(currentUser.CustomerID) && (order.OrderStatus == OrderStatus.Ordered))
                {
                    if (orderCount == 0)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine($"|{"OrderID",-15}|{"CustomerID",-15}|{"TotalPrice",-15}|{"DateOfOrder",-15}|{"OrderStatus",-15}|");
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                    }
                    orderCount++;
                    Console.WriteLine($"|{order.OrderID,-15}|{order.CustomerID,-15}|{order.TotalPrice,-15}|{order.DateOfOrder.ToString("dd/MM/yyyy"),-15}|{order.OrderStatus,-15}|");
                }
            }
            Console.WriteLine();
            if (orderCount == 0)
            {
                Console.WriteLine("You have no Order History to Show");
            }
            else
            {
                Console.Write("Select the Order you want to cancel (ORDER ID) : ");
                string orderID = Console.ReadLine().ToUpper();
                bool validOrder = true;
                foreach (OrderDetails order in orderList)
                {
                    if (order.OrderID.Equals(orderID) && order.CustomerID.Equals(currentUser.CustomerID))
                    {
                        validOrder = false;
                        order.OrderStatus = OrderStatus.Cancelled;
                        foreach(ItemDetails item in itemList)
                        {
                            if(item.OrderID.Equals(order.OrderID))
                            {
                                foreach(FoodDetails food in foodList)
                                {
                                    if(food.FoodID.Equals(item.FoodID))
                                    {
                                        food.QuantityAvailable+=item.PurchaseCount;
                                    }
                                }
                            }
                        }
                        Console.WriteLine($"Order Cancelled Sucessfully for {order.OrderID}");
                        currentUser.WalletRecharge(order.TotalPrice);
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }

                if (validOrder)
                {
                    Console.WriteLine("Invalid Order ID");
                }
            }
        }
        //CancelOrderEnds

        //Modify Order
        public static void ModifyOrder()
        {
            //Display the available order details which are ordered
            int orderCount = 0;
            foreach (OrderDetails order in orderList)
            {
                if (order.CustomerID.Equals(currentUser.CustomerID) && (order.OrderStatus == OrderStatus.Ordered))
                {
                    if (orderCount == 0)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine($"|{"OrderID",-15}|{"CustomerID",-15}|{"TotalPrice",-15}|{"DateOfOrder",-15}|{"OrderStatus",-15}|");
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                    }
                    orderCount++;
                    Console.WriteLine($"|{order.OrderID,-15}|{order.CustomerID,-15}|{order.TotalPrice,-15}|{order.DateOfOrder.ToString("dd/MM/yyyy"),-15}|{order.OrderStatus,-15}|");
                }
            }
            Console.WriteLine();
            if (orderCount == 0)
            {
                Console.WriteLine("You have no Order History to Show");
            }
            else
            {
                Console.Write("Select the Order you want to cancel (ORDER ID) : ");
                string orderID = Console.ReadLine().ToUpper();
                bool validOrder = true;
                foreach (OrderDetails order in orderList)
                {
                    if (order.OrderID.Equals(orderID) && order.CustomerID.Equals(currentUser.CustomerID))
                    {
                        validOrder = false;

                        //display Item List
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine($"|{"ItemID",-15}|{"OrderID",-15}|{"FoodID",-15}|{"PurchaseCount",-15}|{"PriceOfOrder",-15}|");
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        foreach (ItemDetails item in itemList)
                        {
                            if (item.OrderID.Equals(order.OrderID))
                                Console.WriteLine($"|{item.ItemID,-15}|{item.OrderID,-15}|{item.FoodID,-15}|{item.PurchaseCount,-15}|{item.PriceOfOrder,-15}|");
                        }
                        Console.WriteLine("-------------------------------------------------------------------------------------------");

                        //Select the Item
                        Console.Write("Select The Item You want to Modify (Item ID ): ");
                        string itemID = Console.ReadLine().ToUpper();
                        bool validItem = true;

                        foreach (ItemDetails item in itemList)
                        {
                            if (item.ItemID.Equals(itemID))
                            {
                                validItem = false;
                                foreach (FoodDetails food in foodList)
                                {
                                    if (food.FoodID.Equals(item.FoodID))
                                    {
                                        Console.Write("Enter the new Quantity of the selected Food Item : ");
                                        int modifiedQuantity = int.Parse(Console.ReadLine());
                                        if (modifiedQuantity > item.PurchaseCount)
                                        {
                                            
                                            double deductionAmount = food.PricePerQuantity * (modifiedQuantity - item.PurchaseCount);
                                            string rechargeChoise = "yes";
                                            do
                                            {
                                                if (currentUser.WalletBalance >= deductionAmount)
                                                {
                                                    item.PurchaseCount = modifiedQuantity;
                                                    item.PriceOfOrder = food.PricePerQuantity*modifiedQuantity;
                                                    currentUser.DeductBalance(deductionAmount);
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Insufficiant Balance. Please Recharge to Continue");
                                                    Console.Write("Do you want to recharge ?(yes/no) :");
                                                    rechargeChoise = Console.ReadLine().ToLower();
                                                    if (rechargeChoise.Equals("yes"))
                                                    {
                                                        RechargeWallet();
                                                    }
                                                }
                                            }
                                            while (rechargeChoise.Equals("yes"));


                                        }
                                        else
                                        {
                                            double additionAmount = food.PricePerQuantity * (item.PurchaseCount - modifiedQuantity);
                                            currentUser.WalletRecharge(additionAmount);
                                        }
                                        food.QuantityAvailable += item.PurchaseCount - modifiedQuantity;
                                        Console.WriteLine("Order Modified Sucessfully");
                                        Console.WriteLine();
                                        break;

                                    }
                                }
                                break;
                            }
                        }




                        if (validItem)
                        {
                            Console.WriteLine("Invalid Item ID");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    }
                }

                if (validOrder)
                {
                    Console.WriteLine("Invalid Order ID");
                }

            }
        }
        //Modify Order Ends

        //OrderHistory
        public static void OrderHistory()
        {
            int orderCount = 0;
            foreach (OrderDetails order in orderList)
            {
                if (order.CustomerID.Equals(currentUser.CustomerID))
                {
                    if (orderCount == 0)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                        Console.WriteLine($"|{"OrderID",-15}|{"CustomerID",-15}|{"TotalPrice",-15}|{"DateOfOrder",-15}|{"OrderStatus",-15}|");
                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                    }
                    orderCount++;
                    Console.WriteLine($"|{order.OrderID,-15}|{order.CustomerID,-15}|{order.TotalPrice,-15}|{order.DateOfOrder.ToString("dd/MM/yyyy"),-15}|{order.OrderStatus,-15}|");
                }
            }
            Console.WriteLine();
            if (orderCount == 0)
            {
                Console.WriteLine("You have no Order History to Show");
            }
        }
        //OrdeHistory ends

        //Recharge Wallet
        public static void RechargeWallet()
        {
            Console.Write("Enter the Amount to Recharge : ");
            double amount = double.Parse(Console.ReadLine());

            currentUser.WalletRecharge(amount);

            ShowWalletBalance();

        }
        //Recharge Wallet Ends

        //Show Wallet Balance
        public static void ShowWalletBalance()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Your Wallet Balance :{currentUser.WalletBalance}");
            Console.WriteLine("----------------------------------");
        }
        //Show Wallet Balance Ends

        //Add Default Values

        public static void AddDefaultDetails()
        {

            //Customer Defaault Data
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Ettapparajan", Gender.Male, "974774646", new DateTime(1999, 11, 11), "ravi@gmail.com", "Chennai", 10000);
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Sethurajan", Gender.Male, "847575775", new DateTime(1999, 11, 11), "baskaran@gmail.com", "Chennai", 15000);

            customerList.AddRange(new CustomList<CustomerDetails> { customer1, customer2 });

            //Food Default Data
            FoodDetails food1 = new FoodDetails("Chicken Briyani 1Kg", 100, 12);
            FoodDetails food2 = new FoodDetails("Mutton Briyani 1Kg", 150, 10);
            FoodDetails food3 = new FoodDetails("Veg Full Meals", 80, 30);
            FoodDetails food4 = new FoodDetails("Noodles", 100, 40);
            FoodDetails food5 = new FoodDetails("Dosa", 40, 40);
            FoodDetails food6 = new FoodDetails("Idly (2 pieces)", 20, 50);
            FoodDetails food7 = new FoodDetails("Pongal", 40, 20);
            FoodDetails food8 = new FoodDetails("Vegetable Biriyani", 80, 15);
            FoodDetails food9 = new FoodDetails("Lemon Rice", 50, 30);
            FoodDetails food10 = new FoodDetails("Veg Pulav", 120, 30);
            FoodDetails food11 = new FoodDetails("Chicken 65(200 Grams)", 75, 30);

            foodList.AddRange(new CustomList<FoodDetails> { food1, food2, food3, food4, food5, food6, food7, food8, food9, food10, food11 });

            //Order Default Data
            OrderDetails order1 = new OrderDetails("CID1001", 580, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("CID1002", 870, new DateTime(2022, 11, 26), OrderStatus.Ordered);
            OrderDetails order3 = new OrderDetails("CID1001", 820, new DateTime(2022, 11, 26), OrderStatus.Cancelled);

            orderList.AddRange(new CustomList<OrderDetails> { order1, order2, order3 });

            //Item Details Class
            ItemDetails item1 = new ItemDetails("OID3001", "FID2001", 2, 200);
            ItemDetails item2 = new ItemDetails("OID3001", "FID2002", 2, 300);
            ItemDetails item3 = new ItemDetails("OID3001", "FID2003", 1, 80);
            ItemDetails item4 = new ItemDetails("OID3002", "FID2001", 1, 100);
            ItemDetails item5 = new ItemDetails("OID3002", "FID2003", 4, 600);
            ItemDetails item6 = new ItemDetails("OID3002", "FID2010", 1, 120);
            ItemDetails item7 = new ItemDetails("OID3002", "FID2009", 1, 50);
            ItemDetails item8 = new ItemDetails("OID3003", "FID2002", 2, 300);
            ItemDetails item9 = new ItemDetails("OID3003", "FID2008", 4, 320);
            ItemDetails item10 = new ItemDetails("OID3003", "FID2001", 2, 200);

            itemList.AddRange(new CustomList<ItemDetails> { item1, item2, item3, item4, item5, item6, item7, item8, item9, item10 });

        }
    }
}