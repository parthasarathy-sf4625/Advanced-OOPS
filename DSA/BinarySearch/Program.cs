using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int [] arr = new int[]{1,3,4,5};
            Console.WriteLine(BinarySearch(arr,4));
        }
        public static int BinarySearch(int[] arr,int element)
        {
            
            int left = 0;
            int right = arr.Length - 1;
            
            while(left<=right)
            {
                int middle =left+(right - left)/2;
                if(arr[middle]==element)
                {
                    return middle;
                }
                else if(arr[middle]<element)
                {
                    left= middle+1;
                }
                else if(arr[middle]>element)
                {
                    right=middle-1;
                }
            }
            return -1;
        }
    }
}