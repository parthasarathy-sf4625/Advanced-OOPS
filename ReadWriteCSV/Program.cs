using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ReadWriteCSV
{
    public class Program
    {
        public static void Main(string[] args)
        {

            if (!Directory.Exists("TestFolder"))
            {
                Console.WriteLine("Crating Folder");
                Directory.CreateDirectory("TestFolder");
            }
            else
            {
                Console.WriteLine("File ALready Existrs");
            }


            //Creation of a csv File
            if (!File.Exists("TestFolder/Data.csv"))
            {
                Console.WriteLine("Creating csv File.....");
                File.Create("TestFolder/Data.csv").Close();
            }
            else
            {
                Console.WriteLine("CSV File Already exists");
            }



            // Creation of Json

            if (!File.Exists("TestFolder/Data1.json"))
            {
                Console.WriteLine("Creating Json File.....");
                File.Create("TestFolder/Data1.json").Close();
            }
            else
            {
                Console.WriteLine("CSV File Already exists");
            }
            List<StudentDetails> studentList = new List<StudentDetails>();
            StudentDetails student = new StudentDetails();
            studentList.Add(new StudentDetails() { Name = "Parthasarathy", FatherName = "Muthukrishnan", Gender = Gender.Male, DOB = new DateTime(2002, 06, 16), TotalMark = 475 });
            studentList.Add(new StudentDetails() { Name = "Yuvraj", FatherName = "Singh", Gender = Gender.Male, DOB = new DateTime(2002, 12, 12), TotalMark = 485 });


            // WriteToCSV(studentList);
            ReadCSV();
        }
        static void WriteToCSV(List<StudentDetails> studentList)
        {
            StreamWriter sw = new StreamWriter("TestFolder/Data.csv");
            foreach (StudentDetails student in studentList)
            {
                string line = student.Name + "," + student.FatherName + "," + student.DOB.ToString("dd/MM/yyyy") + "," + student.Gender + "," + student.TotalMark;
                sw.WriteLine(line);
            }
            sw.Close();
        }

        static void ReadCSV()
        {
            List<StudentDetails> newList = new List<StudentDetails>();
            StreamReader sr = new StreamReader("TestFolder/Data.csv");
            string line = sr.ReadLine();

            while (line != null)
            {
                string[] values = line.Split(",");
                if (values[0] != "")
                {
                    StudentDetails student = new StudentDetails()
                    {
                        Name = values[0],
                        FatherName = values[1],
                        DOB = DateTime.ParseExact(values[2], "dd/MM/yyyy", null),
                        Gender = Enum.Parse<Gender>(values[3], true),
                        TotalMark = int.Parse(values[4])
                    };
                    newList.Add(student);

                }
                line = sr.ReadLine();
            }

            sr.Close();
            foreach (StudentDetails student in newList)
            {
                Console.WriteLine($" Name : {student.Name} \n Father Name : {student.FatherName} \n DOB : {student.DOB.ToString("dd/MM/yyyy")} \n Gender : {student.Gender} \n TotalMarks : {student.TotalMark}");
            }

        }
    }
}