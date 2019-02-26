using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12Final
{
    class ShortList<T> : IList<T>
    {
        private readonly int _maxSize;
        private List<T> _list;
        public ShortList() : this(10) { }

        public ShortList(int maxSize)
        {
            if (maxSize >= 10)
            {
                _maxSize = maxSize;
            }
            else
            {
                throw new ArgumentException("Must be 10 or less");
            }
        }

        public ShortList(int maxSize, IEnumerable<T> initialItems) : this(maxSize)
        {
            int count = 0;
            foreach (var item in initialItems)
            {
                _list.Add(item);
                count++;
                if (count > maxSize)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public T this[int index] { get => _list[index]; set => _list[index] = value; }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (!IsFull)
            {
                _list.Add(item);
            } else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private bool IsFull {
            get
            {
                return Count == _maxSize;
            }
        }
    }
}
