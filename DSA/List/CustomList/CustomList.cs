using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomList
{
    public partial class CustomList<Type>
    {

        //Field
        private int _count;
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
            get
            {
                return _array[index];
            }
            set
            {
                _array[index] = value;
            }
        }

        //Constructors
        public CustomList()
        {
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }

        public CustomList(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }


        //Methods

        //Method to add data in the List
        public void Add(Type element)
        {
            if (_count == _capacity)
            {
                GrowSize();
            }
            _array[_count++] = element;
        }

        //Method to increease the size of the Array
        void GrowSize()
        {
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _count; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;//current address of _array is cleared and the new address  i.e the address of temp is assigned now
        }

        //While Adding a group of elements or a list into a list
        //Add range function
        public void AddRange(CustomList<Type> elements)
        {
            _capacity = _count+elements.Count;

            Type[] temp = new Type[_capacity];
            int k =0;
            for(int i=0;i<_capacity;i++)
            {
                if(i<_count)
                {
                    temp[i] = _array[i];
                }
                else
                {
                    temp[i]=elements[k++];
                }
            }
            _array=temp;
        }

        //Contains - return true or false based on if the particular element is present on the List

        public bool Contains(Type element)
        {
            foreach (Type data in _array)
            {
                if (data.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        //IndexOf - return the index of the value in the list 
        //if not present it will return -1

        public int IndexOf(Type element)
        {
            int index = -1;
            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Equals(element))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        //Insert Method - Inserts an element in the given index
            
        public void Insert(int index, Type element)
        {
            _capacity = _count + 1;
            Type[] temp = new Type[_capacity];

            int k = 0;//Pointer for _array --- 0  to _count
            for (int i = 0; i < _capacity; i++)
            {
                //i - pointer for temp --0 to capacity-1
                if (i == index)
                {
                    temp[i] = element;//Skips the increment of k so i increments and k stays at the same point to track elements in _array
                }
                else
                {
                    temp[i] = _array[k++];
                }

            }
            _count++;
            _array = temp;
        }

        //Insert range Inserts a list of elemets into a list in a particular index


        public void InsertRange(int position, CustomList<Type> elements)
        {
            _capacity = _count + elements.Count;
            Type[] temp = new Type[_capacity];

            int k = 0, j = 0;
            for (int i = 0; i < _capacity && j < _count; i++)
            {
                if (i >= position && i < position + elements.Count)
                {
                    temp[i] = elements[k++];
                }
                else
                {
                    temp[i] = _array[j++];
                }

            }
            _count = _count+elements.Count;
            _array = temp;
        }
        
        //Removeat Method - Removes the element which is present in the given index

        public void RemoveAt(int index)
        {
            _capacity = _count - 1;
            Type[] temp = new Type[_capacity];
            int k = 0;
            for (int i = 0; i < _count; i++)
            {
                if (i == index)
                {
                    continue;
                }
                temp[k++] = _array[i];
            }
            _count--;
            _array = temp;
        }

        //Remove  - removes the given element 

        public bool Remove(Type element)
        {
            int index = IndexOf(element);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        //Reverse - Reverses the list

        public void Reverse()
        {
            Type[] temp = new Type[_count];
            for (int i = 0, j = _count - 1; i < _count && j >= 0; i++, j--)
            {
                temp[i] = _array[j];
            }
            _array = temp;
        }

        
    //Sort

    public void Sort()
    {
        for(int i=0;i<_count-1;i++)
        {
            for(int j=0;j<_count-1;j++)
            {
                if(IsGreater(_array[j],_array[j+1]))
                {
                    Type temp = _array[j+1];
                    _array[j+1]=_array[j];
                    _array[j] = temp;
                }
            }
        }
    }


    //Is Greater

    public bool IsGreater(Type value, Type value1)
    {
        int result = Comparer<Type>.Default.Compare(value,value1);

        //value is greater result = 1 else -1
        if(result>0)
        {
            return true;
        }
        return false;
    }
    }


}