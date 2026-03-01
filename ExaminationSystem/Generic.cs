using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem
{
    internal class Generic<T> : IComparable<T>, ICloneable
    {
        private T[] arr;
        int capacity;
        int count;
        public Generic(int _capacity = 5)
        {
            capacity = _capacity;
            count = -1;
            arr = new T[capacity];
        }
        public void Add(T item)
        {
            if (count < capacity)
                arr[++count] = item;
            else
                resize();
        }
        void resize()
        {

        }
        public bool Remove(T item)
        {
            return false;
        }
        public void Sort() { }
        public T[] GetAll()
        {
            return arr;
        }

        public object Clone()
        {
            T[] temp = new T[count + 1];
            Array.Copy(arr, temp, count + 1);
            return temp;
        }

        public int CompareTo(T? other)
        {
            if (other == null)
                return 1;

            return 0;
        }
    }
}
