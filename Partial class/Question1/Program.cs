using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Question1
{
    public class Program
    {
        static List<EmployeeInfo> employeeList = new List<EmployeeInfo>();
        public static void Main(string[] args)
        {
            bool loopBreaker = true;

            do
            {
                Console.WriteLine("1.Registration \n2.Update \n3.Display\n4.Exit");
                int choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        {
                            Console.Write("Enter your Name : ");
                            string name = Console.ReadLine();
                            Console.Write("Enter your Gender : ");
                            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
                            Console.Write("Enter your Date of Birth : ");
                            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                            Console.Write("Enter your Mobile Number : ");
                            string mobile = Console.ReadLine();
                            EmployeeInfo employee = new EmployeeInfo(name, gender, dob, mobile);
                            employeeList.Add(employee);
                            Console.WriteLine($"Registration Sucessfull . The user Id is {employee.EmployeeID}");
                            break;
                        }

                    case 2:
                        {
                            Console.Write("Enter your Employee ID : ");
                            string loginID = Console.ReadLine();
                            bool isValid = true;
                            foreach (EmployeeInfo employee in employeeList)
                            {
                                if (employee.EmployeeID.Equals(loginID))
                                {
                                    isValid = false;
                                    employee.Update();
                                    break;
                                }
                            }
                            if (isValid)
                            {
                                Console.WriteLine("Invalid user ID");
                            }
                            break;
                        }
                    case 3:
                        {

                            Console.Write("Enter your Employee ID : ");
                            string loginID = Console.ReadLine();
                            bool isValid = true;
                            foreach (EmployeeInfo employee in employeeList)
                            {
                                if (employee.EmployeeID.Equals(loginID))
                                {
                                    isValid = false;
                                    employee.Display();
                                    break;
                                }
                            }
                            if (isValid)
                            {
                                Console.WriteLine("Invalid user ID");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Exitting");
                            loopBreaker = false;
                            break;
                        }
                }
            } while (loopBreaker);



        }
    }
}