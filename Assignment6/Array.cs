using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6
{
    public class Array<T>: ICollection<T>, IEnumerable<T> where T: IEquatable<T>
    {
        public int Size { get; private set; }
        private List<T> _Collection;
        public int Count { get; private set; } = 0;
        public bool IsReadOnly => throw new NotImplementedException();
        public Array(int size)
        {
            if(size <= 0)
            {
                throw new IndexOutOfRangeException($"{nameof(size)} cannot be zero or less");
            }
            Size = size;
            _Collection = new List<T>();
        }

        public Array()
        {
            _Collection = new List<T>();
        }
        
        public void Add(T item)
        {
            if(Count >= Size && Size != 0)
            {
                throw new IndexOutOfRangeException("Array is full");
            }
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item), "Null item reference");
            }

            _Collection.Add(item);
            Count++;
        }

        public void Clear()
        {
            _Collection.Clear();
            Count = 0;
        }

        public bool Contains(T item)
        {
            if(Count > Size)
            {
                throw new InvalidOperationException($"{nameof(item)} not found");

            }
            if (_Collection.Contains(item))
            {
                return true;
            }
            throw new InvalidOperationException($"{nameof(item)} not found");
        }

        public void CopyTo(T[] array, int index)
        {
            if(array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            if(array.Length - index <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(index)}: {index}");
            }
            if((array.Length - index) < Size)
            {
                throw new ArgumentOutOfRangeException($"Too many items for collection");
            }
            for(int i = index; i<Size; i++)
            {
                array[i] = _Collection[i];
            }
        }

        public T this[int index]
        {
            get
            {
                if(index> Count - 1)
                {
                    throw new IndexOutOfRangeException($"Value at {nameof(index)} is not initialized");
                }
                if (index < 0)
                {
                    throw new IndexOutOfRangeException($"Index cannot be zero or lower");
                }
                return _Collection[index];
            }
            set
            {
                if(index> Size - 1)
                {
                    throw new IndexOutOfRangeException($"Value at {nameof(index)} is not initialized");

                }
                if(index < 0)
                {
                    throw new IndexOutOfRangeException($"Index cannot be zero or lower");
                }
                _Collection[index] = value;
                Count++;
            }
        }

        public bool Remove(T item)
        {
            bool success = false;
            success = _Collection.Remove(item);
            if (success)
            {
                Count--;
            }
            return success;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator(_Collection);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ArrayEnumerator : IEnumerator<T>
        {
            private List<T> _Collection;
            int _Index = -1;
            public ArrayEnumerator(List<T> array)
            {
                _Collection = array;
            }
            public T Current
            {
                get
                {
                    try
                    {
                        return _Collection[_Index];
                    }
                    catch(IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            Object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
                
            }

            public void Dispose()
            {

            }
            public bool MoveNext()
            {
                _Index++;
                return (_Index < _Collection.Count);
            }
            public void Reset()
            {
                _Index = -1;
            }
        }





    }
}
