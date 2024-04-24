using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interface
{
    public interface IAnimal
    {
        //Properties
        public string Name{get;set;}
        public string Habitat{get;set;}
        public string EatingHabit{get;set;}
        
        //Method
        public void DisplayName();
    }
}