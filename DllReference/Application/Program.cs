using System;
namespace Application;
public class Program 
{
    public static void Main(string[] args)
    {
        //Calling Add Default Data
        Operations.AddDefaultData();
        //Calling Main Menu
        Operations.MainMenu();
    }
}