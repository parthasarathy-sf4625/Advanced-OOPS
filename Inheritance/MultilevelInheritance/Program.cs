using System;
using MultilevelInheritance;
using MultiLevelInheritance;
namespace MultiLevelInheritance;
class Program
{
    public static void Main(string[] args)
    {
        PersonalDetails person = new PersonalDetails("Parthasarathy","Muthukrishnan",Gender.Male,"9876543219");
        Console.WriteLine($"ID : {person.UserID} \nNAme : {person.Name} \nFatherName : {person.FatherName} \nGender : {person.Gender} \nPhone Number : {person.PhoneNumber}");

        StudentDetail student = new StudentDetail(person.UserID,person.Name,person.FatherName,person.Gender,person.PhoneNumber,10,"2017");
        EmployeeDetails employee = new EmployeeDetails(student.StudentId,person.UserID,person.Name,person.FatherName,person.Gender,person.PhoneNumber,student.Standard,student.YearOfJoining,"Developer");
    }


}

