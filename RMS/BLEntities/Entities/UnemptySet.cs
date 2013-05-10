using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class UnemptySet<T>:ISet<T>
    {
        protected HashSet<T> items;
        protected bool isReadOnly;
        
         public UnemptySet(T item)
        {
            items = new HashSet<T>();
            items.Add(item);
            isReadOnly = false;
        }

         public UnemptySet(T item,bool isReadOnly)
        {
            items = new HashSet<T>();
            items.Add(item);
            this.isReadOnly = isReadOnly;
        }

        public bool Add(T item)
        {
           return  items.Add(item);
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            T item = items.ElementAt(0);
            items.ExceptWith(other);
            if (items.Count == 0)
            {
                items.Add(item);
            }
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            T item = items.ElementAt(0);
            items.IntersectWith(other);
            if (items.Count == 0)
            {
                items.Add(item);
            }
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return items.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return items.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return items.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return items.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            return items.Overlaps(other);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return items.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            T item = items.ElementAt(0);
            items.SymmetricExceptWith(other);
            if (items.Count == 0)
            {
                items.Add(item);
            }
        }

        public void UnionWith(IEnumerable<T> other)
        {
            items.UnionWith(other);
        }

        void ICollection<T>.Add(T item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            T item = items.ElementAt(0);
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

        public int Count
        {
            get { return items.Count; }
        }

        public bool IsReadOnly
        {
            get {return  this.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            if (items.Count > 1)
            {
                items.Remove(item);
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
