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
            _capacity = 1;
            _array = new T[] { };
        }


        public void Add(T item)
        {
            if (Count + 1 > _array.Length)
            {
                _capacity *= 2;
                T[] tempArray = new T[_capacity];

                for (int i = 0; i < _array.Length + 1; i++)
                {
                    if (i == _array.Length)
                    {
                        tempArray[i] = item;
                        break;
                    }

                    tempArray[i] = _array[i];
                }

                _array = tempArray;
                Count++;

            }
            else
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    if (Count - i == 0)
                    {
                        _array[i] = item;
                    }
                }
                Count++;
            }
        }

        public void AddRange(T[] itemArray)
        {
            if (Count + itemArray.Length > _capacity)
            {
                while (Count + itemArray.Length > _capacity)
                {
                    _capacity *= 2;
                }

                T[] tempArray = new T[_capacity];

                for (int i = 0; i < _array.Length + 1; i++)
                {
                    if (i == Count)
                    {
                        int k = i;
                        for (int j = 0; j < itemArray.Length; j++)
                        {
                            tempArray[k] = itemArray[j];
                            k++;
                        }
                        break;
                    }

                    tempArray[i] = _array[i];
                }

                _array = tempArray;
                Count += itemArray.Length;
            }
            else
            {
                for (int i = 0; i < _array.Length; i++)
                {
                    if (_array[i] == null)
                    {
                        int k = i;
                        for (int j = 0; j < _capacity; j++)
                        {
                            _array[k] = itemArray[j];
                        }
                    }
                }

                Count += itemArray.Length;
            }
        }

        public bool Remove(T item)
        {
            if (Count == 0)
            {
                return false;
            }
            else
            {
                T[] tempArray = new T[_capacity];
                for (int i = 0; i < _array.Length; i++)
                {
                    if (_array[i].Equals(item))
                    {
                        continue;
                    }

                    tempArray[i] = _array[i];
                }

                _array = tempArray;
                Count--;

                return true;
            }
        }

        public bool RemoveAt(int index)
        {
            if (Count == 0)
            {
                return false;
            }
            else
            {
                T[] tempArray = new T[_capacity];

                int j = 0;
                for (int i = 0; i < Count; i++)
                {
                    if (i == index)
                    {
                        continue;
                    }

                    tempArray[j] = _array[i];
                    j++;
                }

                _array = tempArray;
                Count--;

                return true;
            }
        }

        public void Sort()
        {
            Array.Sort(_array);
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
                    catch(IndexOutOfRangeException)
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