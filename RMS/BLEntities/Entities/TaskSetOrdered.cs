using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace BusinessLogic.Entities
{
      



    public class TaskSetOrdered : ISet<Task>
    {
        private class TaskComparer : IComparer<Task>
        {
            public int Compare(Task x, Task y)
            {
                return x.getStartDate().CompareTo(y.getStartDate());
            }

        }
        private SortedSet<Task> items;
        private bool isReadOnly;

        public TaskSetOrdered()
        {
            items = new SortedSet<Task>(new TaskComparer());
            isReadOnly = false;
        }

        public TaskSetOrdered(bool isReadOnly)
        {
            items = new SortedSet<Task>(new TaskComparer());
            this.isReadOnly = isReadOnly;
        }
       

        public bool Add(Task item)
        {
            if (!this.Contains(item))
            {
                items.Add(item);
                return true;
            }
            else
                return false;
        }

        public void ExceptWith(IEnumerable<Task> other)
        {


            items.ExceptWith(other);

        }

        public void IntersectWith(IEnumerable<Task> other)
        {
            items.IntersectWith(other);
        }

        public bool IsProperSubsetOf(IEnumerable<Task> other)
        {
            return items.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<Task> other)
        {
            return items.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<Task> other)
        {
            return items.IsProperSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<Task> other)
        {
            return items.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<Task> other)
        {
            return items.Overlaps(other);

        }

        public bool SetEquals(IEnumerable<Task> other)
        {
            return items.SetEquals(other);

        }

        public void SymmetricExceptWith(IEnumerable<Task> other)
        {

            items.SymmetricExceptWith(other);
        }

        public void UnionWith(IEnumerable<Task> other)
        {
            items.UnionWith(other);
        }

        void ICollection<Task>.Add(Task item)
        {
            items.Add(item);


        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(Task item)
        {

            return items.Contains(item);
        }

        public void CopyTo(Task[] array, int arrayIndex)
        {

            items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return items.Count; }

        }

        public bool IsReadOnly
        {
            get { return this.isReadOnly; }
        }

        public bool Remove(Task item)
        {
            return items.Remove(item);
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

