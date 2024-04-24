using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public partial class CustomList<Type>
    {
        //Fields
        private int _count;
        private int _capacity;
        private Type[] _array;

        //Property
        public int Count 
        {
            get
            {
                return _count;
            }
        }
        public int Capacity 
        {
            get 
            {
                return _capacity;
            }
        }

        //Indexers
        public Type this[int index]
        {
            get { return _array[index]; }
            set {  _array[index] = value;}
        }

        //Constructors

        public CustomList()
        {
            _count=0;
            _capacity=4;
            _array = new Type[_capacity];
        }

        //Methods
        public void GrowSize()
        {
            _capacity*=2;
            Type[] temp = new Type[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array = temp;
        }

        public void Add(Type element)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            _array[_count++] = element;
        }

        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count+elements.Count;
            Type[] temp = new Type[_capacity];
            int k = 0;
            for(int i = 0;i<_capacity;i++)
            {
                if(i<_count)
                {
                    temp[i]=_array[i];
                }
                else
                {
                    temp[i]=elements[k++];
                }
            }
            _array = temp;
            _count = _capacity;
        }
    }
}