using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public class CustomerDetails : PersonalDetails, IBalance
    {
        //Field

        
        private static int s_customerID = 1000;
        private double _balance;

        //Properties

        /// <summary>
        /// Stores the customer id of each customer by Auto incrementing a static private field
        /// </summary>
       
        public string CustomerID { get; }

        /// <summary>
        /// Returns the WallateBalance  of the user by accessing a private field
        /// </summary>
        
        public double WalletBalance
        {
            get
            {
                return _balance;
            }
        }

        //Constructors
        public CustomerDetails(string name, string fatherName, Gender gender, string mobile, DateTime dob, string mailID, string location, double balance) : base()
        {
            CustomerID = "CID" + (++s_customerID);
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            DOB = dob;
            MailID = mailID;
            Location = location;
            _balance = balance;
        }

        public CustomerDetails(string line)
        {
            string[] values = line.Split(",");
            ++s_customerID;
            CustomerID = values[0];
            Name = values[1];
            FatherName = values[2];
            Gender = Enum.Parse<Gender>(values[3],true);
            Mobile = values[4];
            DOB = DateTime.ParseExact(values[5],"dd/MM/yyyy",null);
            MailID = values[6];
            Location = values[7];
            _balance = int.Parse(values[8]);
        }

        //Metthods



        public void WalletRecharge(double amount)
        {
            _balance += amount;
        }

        public void DeductBalance(double amount)
        {
            _balance -= amount;
        }
    }
}