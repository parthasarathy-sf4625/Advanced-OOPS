using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public partial class CustomList<Type>
    {
        //Fields
        private int _count = 0;
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

        //Indexer

        public Type this[int index]
        {
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        //Constructor
        public CustomList()
        {
            _capacity = 3;
            _array = new Type[_capacity];
        }

        //Methods
        //GrowArray
        public void Grow()
        {
            _capacity *= 2;
        }

        //Add
        public void Add(Type element)
        {
            if (_capacity == _count)
            {
                Grow();
            }
                Type[] temp = new Type[_count + 1];
                for (int i = 0; i < _count; i++)
                {
                    temp[i] = _array[i];
                }
                temp[_count++] = element;
                _array = temp;
            
           
        }

        //AddRange
        public void AddRange(CustomList<Type> elememts)
        {

            _capacity = elememts.Count+_count;
            Type[] temp = new Type[_capacity];
            int k = 0;
            for (int i = 0; i < _capacity; i++)
            {
                if (i < _count)
                {
                    temp[i] = _array[i];
                }
                else
                {
                    temp[i] = elememts[k++];
                }
            }

        }

    }
}