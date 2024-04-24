using System;
using AbstractClassesAndMethods;
namespace AbstractClassAndMethods;
class Program 
{
    public static void Main(string[] args)
    {
        SyncFusion job1 = new SyncFusion();
        Zoho job2 = new Zoho();
        job1.Name="Zoro";
        Console.WriteLine(job1.Display());
        Console.WriteLine(job1.Salary(30));
    }
}