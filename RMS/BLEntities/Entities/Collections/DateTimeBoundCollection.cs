using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    public class DateTimeBoundCollection<T> : ICollection<T> where T : IDateTimeBound
    {
        public DateTimeBoundCollection(DateTime lowerBound, DateTime higherBound)
        {
            if (lowerBound < higherBound)
            {
                this.lowerBound = lowerBound;
                this.higherBound = higherBound;
                this.items = new LinkedList<T>();
            }
            else
                throw new ArgumentException("The higher bound cannot be lower than the lower bound!");
        }

        public void Add(T item)
        {

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

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private DateTime lowerBound;
        private DateTime higherBound;
        private ICollection<T> items;
    }
}
