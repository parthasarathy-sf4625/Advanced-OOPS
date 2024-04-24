using System;
using System.IO;

namespace FileHandling;
public class Program
{
    public static void Main(string[] args)
    {
        string path =@"C:\Users\Parthasarathyvenkidu\OneDrive - Syncfusion\Desktop\FileFolder";
        string folderPath = path+"/Partha";

        //Checking if the folder exists or not

        if(!Directory.Exists(folderPath))
        {
            Console.WriteLine("Creating Directory");
            Directory.CreateDirectory(folderPath);
        }
        else
        {
            Console.WriteLine("Folder Already Exists");
        }

        string filePath = path + "/myFile.txt";

        if(!File.Exists(filePath))
        {
            Console.WriteLine("Creating File");
            File.Create(filePath);
        }
        else
        {
            Console.WriteLine("File Already Exist");
        }


        Console.WriteLine("1.Create Folder\n2.Create File\n3.Delete Folder\n4.Delete File");
        int option = int.Parse(Console.ReadLine());
        switch (option)
        {
            case 1:
            {
                Console.WriteLine("Enter the FolderName");
                string folder = Console.ReadLine();
                string newPath = path +"/"+folder;

                if(!Directory.Exists(newPath))
                {
                    Console.WriteLine("Creating Folder");

                    Directory.CreateDirectory(newPath);
                }
                else
                {
                    Console.WriteLine("Folder Already Exists");
                }

                break;
            }
            case 2:
            {
                Console.WriteLine("Enter the fileName");
                string file  = Console.ReadLine();
                Console.WriteLine("Enter the file Extention");
                string extention = Console.ReadLine();
                string newFilePath = path+"/"+file+"."+extention;
                
                if(!File.Exists(newFilePath))
                {
                    Console.WriteLine("Creationg new File....");
                    File.Create(newFilePath);
                }
                else
                {
                    Console.WriteLine("File Already Exists");
                }
                break;
            }
            case 3:
            {

                foreach(string path1 in Directory.GetDirectories(path))
                {
                    Console.WriteLine(path1);
                }

                Console.WriteLine("Enter the Fodler that you wish to delete");

                string folderToDelete = Console.ReadLine();
                bool validPath = true;
                foreach(string path1 in Directory.GetDirectories(path))
                {
                    if(path1.Contains(folderToDelete))
                    {
                        validPath = false;
                        Console.WriteLine("Deleting the Folder");
                        Directory.Delete(path1);
                    }
                }
                if(validPath)
                {
                    Console.WriteLine("Folder does not exist");
                }
                break;
            }
            case 4:
            {
                foreach(string file1 in Directory.GetFiles(path))
                {
                    Console.WriteLine(file1);
                }

                Console.WriteLine("Select the file that you want to delete along with extention");
                string fileToDelete = Console.ReadLine();

                bool validFile = true;
                foreach(string file1 in Directory.GetFiles(path))
                {
                    if(file1.Contains(fileToDelete))
                    {   
                        validFile = false;
                        Console.WriteLine("Deleting File ");
                        File.Delete(fileToDelete);
                    }
                }
                if(validFile)
                {
                    Console.WriteLine("Folder Does not exists");
                }
                break;
            }
        }
    }
}