using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketBooking
{
    public class CustomList<Type>
    {
        private int _count ;
        private int _capacity;
        private Type[] _array;


        //Properties

        public int Count 
        {
            get 
            {
                return _count;
            }
        }
        //Constructor

        public CustomList()
        {
            _count=0;
            _capacity=4;
            _array = new Type[_capacity];
        }

        private void Growsize()
        {
            _capacity *=2;
            Type[] temp = new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
        
        public  void Push(Type element)
        {
            if(_count == _capacity )
            {
                Growsize();
            }
            Type[] temp = new Type[_count+1];
            temp[0]=element;
            
            for(int i = 0;i<_count;i++)
            {
                temp[i+1] = _array[i];
            }
            _array = temp;
            _count++;         
        }

        public Type Peak()
        {
            return _array[0];
        }

        public Type Pop()
        {
            
            Type value =  _array[0];

            Type [] temp = new Type[_count-1];
            for(int i = 0;i<_count-1;i++)
            {
                temp[i] = _array[i];
            }
            _count --;
            _array = temp;
            return value;
        }
    }
}