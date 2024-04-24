using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryApp
{
    public enum  BookingStatus{Default,Intiated,Booked,Cancelled}
    public class BookingDetails
    {
        //Fields
        private static int  bookingID = 3000;

        //Property
        public string BookingID{get;}
        public string CustumerID{get;set;}
        public double TotalPrice{get;set;}
        public DateTime DateOfBooking{get;set;}
        public BookingStatus BookingStatus{get;set;}

        //Constructors

        public BookingDetails(string custumerID,double totalPrice)
        {
            BookingID = "BID"+(++bookingID);
            CustumerID = custumerID;
            TotalPrice = totalPrice;
        }

        //Methods 

        public void ShowBookingDetails()
        {
            Console.WriteLine($"|{BookingID}|{CustumerID}|{TotalPrice}|{DateOfBooking}|{BookingStatus}");
        }

    }
}