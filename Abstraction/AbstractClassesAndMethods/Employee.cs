using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractClassesAndMethods
{
    public abstract class Employee //Abstract Class
    {

        //Abstract class - Partial Abstraction
        //It has fields , properties, methods, constructors,destructors,indexers,events
        //can have both abstract declaration and normal definitions
        //Can only used with an inherited class
        //Not support multiple inheritance
        //it cannot be static class
        protected string _name;//Normal Field

        public abstract string Name{get;set;}//Abstract Property  
        public double Amount{get;set;}//Normal Property

        //Method
        public string Display()
        {
            return _name;
        }      
        public abstract double Salary(int dates);//Abstract Method - 
    }
}