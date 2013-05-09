using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{

    public class UnemptySortedSet<T> : SortedSet<T>
    {
        private T firstItem;
        public UnemptySortedSet(T item)
        {
            firstItem=item;
            Add(item);
        }
        
        public UnemptySortedSet(T item,IComparer<T> comparer):base(comparer)
        {
            firstItem = item;
            Add(item);
        }

       
        public new void ExceptWith(IEnumerable<T> other)
        {
            
            base.ExceptWith(other);
            if (base.Count == 0)
            {
                Add(firstItem);
            }
            

        }

        public override void IntersectWith(IEnumerable<T> other)
        {
            base.IntersectWith(other);
            if (base.Count == 0)
            {
                Add(firstItem);
            }
            
        }
        public new void SymmetricExceptWith(IEnumerable<T> other)
        {

            base.SymmetricExceptWith(other);
            if (base.Count == 0)
            {
                Add(firstItem);
            }
            
        }
        public override void Clear()
        {
           
            base.Clear();
            base.Add(firstItem);
        }
        public new bool Remove(T item)
        {
            if (base.Count > 1)
            {
                base.Remove(item);
                return true;
            }
            return false;
        }
    }
}
