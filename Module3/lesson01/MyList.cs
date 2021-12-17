using System;
using System.Collections;
using System.Collections.Generic;

namespace lesson01
{
    class MyList<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _capacity;
        public int Count { get; private set; }

        public IEnumerator GetEnumerator()
        {
            return new MyListEnumerator<T>(_array, Count);
        }

        public MyList()
        {
            Count = 0;
            _capacity = 0;
            _array = new T[] { };
        }


        public void Add(T item)
        {
            T[] array = new T[] { item };
            AddRange(array);
        }

        public void AddRange(T[] itemArray)
        {
            if (_capacity == 0)
            {
                _capacity = 1;
            }

            while (Count + itemArray.Length > _capacity)
            {
                _capacity *= 2;
            }

            var tmpArray = new T[_capacity];
            _array.CopyTo(tmpArray, 0);
            itemArray.CopyTo(tmpArray, Count);

            _array = tmpArray;
            Count += itemArray.Length;

        }

        public bool Remove(T item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }
            else
            {
                RemoveAt(IndexOf(item));
                return true;
            }
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                return false;
            }
            else
            {
                Array.Copy(_array, index + 1, _array, index, _array.Length - index - 1);
                Count--;

                return true;
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_array, item);
        }

        public void Sort()
        {
            T[] tmpArray = new T[Count];

            for(int i = 0; i < Count; i++)
            {
                tmpArray[i] = _array[i]; 
            }
            Array.Sort(tmpArray);

            tmpArray.CopyTo(_array, 0);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        internal class MyListEnumerator<Type> : IEnumerator<Type>
        {
            private Type[] _items;
            private int _position = -1;
            private int _count = 0;

            public MyListEnumerator(Type[] items, int count)
            {
                _items = items;
                _count = count;
            }

            public Type Current
            {
                get
                {
                    try
                    {
                        return _items[_position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                _position++;

                return (_position < _count);
            }

            public void Reset()
            {
                _position = -1;
            }
        }
    }
}