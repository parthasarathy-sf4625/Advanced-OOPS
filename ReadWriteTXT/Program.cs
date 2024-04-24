using System;
using System.IO;
namespace ReadWriteTXT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Folder Creation
            if (!Directory.Exists("TestFolder"))
            {
                Console.WriteLine("Creating Folder....");
                Directory.CreateDirectory("TestFolder");
            }
            else
            {
                Console.WriteLine("Folder already exists");
            }

            //File Creation

            if (!File.Exists("TestFolder/data.txt"))
            {
                Console.WriteLine("Creating File...");
                File.Create("TestFolder/data.txt").Close();
            }
            else
            {
                Console.WriteLine("File Already Exists");
            }


            //Read or Write Menu
            Console.WriteLine("Select \n1. Read from file \n2.Write from file");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {
                        //Read 
                        StreamReader sr = new StreamReader("TestFolder/data.txt");
                        string data = sr.ReadLine();
                        while(data!=null)
                        {
                            Console.WriteLine(data);
                            data = sr.ReadLine();   
                        }
                        sr.Close();
                        break;
                    }
                case 2:
                    {
                        //Write
                        string[] contents = File.ReadAllLines("TestFolder/data.txt");
                        StreamWriter sw = new StreamWriter("TestFolder/data.txt");
                        Console.WriteLine("Enter what you want to place in the file");
                        string data = Console.ReadLine();

                        string oldData = "";

                        foreach (string line in contents)
                        {
                            oldData = oldData+line+"\n";
                        }

                        oldData = oldData+data;

                        sw.WriteLine(oldData);
                        sw.Close();
                        break;
                    }
            }
        }
    }



}