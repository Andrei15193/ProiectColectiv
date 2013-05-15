using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class UnemptySet<T> : ICollection<T>, IObservableCollection<T>
    {
        public UnemptySet(IEnumerable<T> items)
        {
            if (items != null)
                if (items.Count() > 0)
                    this.items = new HashSet<T>(items);
                else
                    throw new ArgumentException("The provided item collection must not be empty!");
            else
                throw new ArgumentNullException("The provided value for items cannot be null!");
        }
        public UnemptySet(T item)
            : this(new T[] { item } as IEnumerable<T>)
        {
        }

        public UnemptySet(params T[] items)
            : this(items as IEnumerable<T>)
        {
        }

        public void Clear()
        {
            throw new NotImplementedException("This method is not implemented because the underlying collection does not support it.");
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public virtual void Add(T item)
        {
            ProtectedOnCollectionChanging(this, new CollectionChangedEventArgs<T>(item, CollectionChange.Add));
            items.Add(item);
        }

        public virtual bool Remove(T item)
        {
            if (items.Count > 1)
            {
                ProtectedOnCollectionChanging(this, new CollectionChangedEventArgs<T>(item, CollectionChange.Add));
                items.Remove(item);
                return true;
            }
            else
                return false;
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

        public event EventHandler<CollectionChangedEventArgs<T>> CollectionChanging;

        protected virtual IEnumerator<T> ProtectedGetEnumerator()
        {
            return items.GetEnumerator();
        }

        protected void ProtectedOnCollectionChanging(object sender, CollectionChangedEventArgs<T> e)
        {
            if (CollectionChanging != null)
                CollectionChanging(sender, e);
        }

        private ISet<T> items;
    }
}
