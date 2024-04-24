using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Question2
{
    public class Program
    {
        static List<StudentInfo> studentList = new List<StudentInfo>();
        public static void Main(string[] args)
        {
            bool loopBreaker = true;

            do
            {
                Console.WriteLine("1.Registration \n2.Calculate Total And Percentage \n3.Display\n4.Exit");
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
                            Console.Write("Enter your Physics mark :");
                            double physics = double.Parse(Console.ReadLine());
                            Console.Write("Enter your Chemistry mark :");
                            double chemistry = double.Parse(Console.ReadLine());
                            Console.Write("Enter your Maths mark :");
                            double maths = double.Parse(Console.ReadLine());
                            StudentInfo student = new StudentInfo(name, gender, dob, mobile,physics,chemistry,maths);
                            studentList.Add(student);
                            Console.WriteLine($"Registration Sucessfull . The user Id is {student.StudentID}");
                            break;
                        }

                    case 2:
                        {
                            Console.Write("Enter your Student ID : ");
                            string loginID = Console.ReadLine();
                            bool isValid = true;
                            foreach (StudentInfo student in studentList)
                            {
                                if (student.StudentID.Equals(loginID))
                                {
                                    isValid = false;
                                    student.CalculateTotalAndPercentage();
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

                            Console.Write("Enter your Student ID : ");
                            string loginID = Console.ReadLine();
                            bool isValid = true;
                            foreach (StudentInfo student in studentList)
                            {
                                if (student.StudentID.Equals(loginID))
                                {
                                    isValid = false;
                                    student.Display();
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