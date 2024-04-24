using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question1
{
    public partial class EmployeeInfo
    {
        //Methods

        //Update, Display


        public void Update()
        {
            Console.WriteLine("Select the data that you want to update :");
            Console.WriteLine("1.Name\n2.Gender\n3.Date of Birth\n4.Mobile\n5.Exit");
            int choise = int.Parse(Console.ReadLine());
            switch(choise)
            {
                case 1:
                {
                    Console.Write("Enter corrected Data : ");
                    Name = Console.ReadLine();
                    Console.WriteLine("Your name has been sucessfully updated");
                    break;
                }
                case 2:
                {
                    Console.Write("Enter corrected Data : ");
                    Gender = Enum.Parse<Gender>(Console.ReadLine(),true);
                    Console.WriteLine("Your Gender has been sucessfully updated");
                    break;
                }
                case 3:
                {
                    Console.Write("Enter corrected Data in(dd/MM/yyyy): ");
                    DOB = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                    Console.WriteLine("Your Date of birth has been sucessfully updated");
                    break;
                }
                case 4:
                {
                    Console.Write("Enter corrected Data : ");
                    Mobile = Console.ReadLine();
                    Console.WriteLine("Your Mobile has been sucessfully updated");
                    break;
                }
            }
        }
        public void Display()
        {
            Console.WriteLine($"Employee ID : {EmployeeID}");
            Console.WriteLine($"Employee Name : {Name}");
            Console.WriteLine($"Gender : {Gender}");
            Console.WriteLine($"Date of Birth : {DOB.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Mobile Number : {Mobile}");
        }
    }
}