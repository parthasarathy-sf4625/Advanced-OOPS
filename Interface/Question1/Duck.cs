using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface
{
    public class Duck:IAnimal
    {
        public string Name{get;set;}
        public string Habitat{get;set;}
        public string EatingHabit{get;set;}
        
        //Constructors
        public Duck(string name,string habitat,string eatingHabit)
        {
            Name=name;
            Habitat=habitat;
            EatingHabit=eatingHabit;
        }
        //Method
        public void DisplayName()
        {
            Console.WriteLine(Name);
            
        }
        
    }
}