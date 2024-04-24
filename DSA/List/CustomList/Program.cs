using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(5);
            list.Add(16);
            list.Add(17);

            list.Add(5);


            CustomList<int> list2 = new CustomList<int>();

            list2.Add(23);
            list2.Add(24);

            list.AddRange(list2);


            if (list.Contains(23))
            {
                Console.WriteLine("is present");
            }
            else
            {
                Console.WriteLine("Not present");
            }


            // Console.WriteLine($"Index : {list.IndexOf(16)}");

            list.RemoveAt(3);


            bool temp = list.Remove(5);
            list.Reverse();


            Console.WriteLine();
            CustomList<int> list3 = new CustomList<int> { 1, 2, 3 };
            list.InsertRange(2, list3);
            list.Sort();
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

        }
    }
}