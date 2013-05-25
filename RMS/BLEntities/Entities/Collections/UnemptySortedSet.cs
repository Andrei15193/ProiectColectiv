using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class UnemptySortedSet<T> : ICollection<T>
    {
        public UnemptySortedSet(IComparer<T> comparer, IEnumerable<T> items)
        {
            if (comparer != null)
                if (items != null)
                    if (items.Count() > 0)
                        this.items = new SortedSet<T>(items, comparer);
                    else
                        throw new ArgumentException("The provided item collection must not be empty!");
                else
                    throw new ArgumentNullException("The provided value for item collection cannot be null!");
            else
                throw new ArgumentNullException("The provided value for comparer cannot be null!");
        }
        public UnemptySortedSet(IComparer<T> comparer, T item)
            : this(comparer, new T[] { item } as IEnumerable<T>)
        {
        }

        public UnemptySortedSet(IComparer<T> comparer, params T[] items)
            : this(comparer, items as IEnumerable<T>)
        {
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            T item = items.First();
            items.Clear();
            items.Add(item);
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        public bool Remove(T item)
        {
            if (items.Count > 1)
            {
                items.Remove(item);
                return true;
            }
            else
                return false;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        protected virtual IEnumerator<T> ProtectedGetEnumerator()
        {
            return items.GetEnumerator();
        }

        private ISet<T> items;
    }
}
