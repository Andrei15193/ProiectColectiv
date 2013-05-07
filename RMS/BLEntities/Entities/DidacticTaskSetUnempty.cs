using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class DidacticTaskSetUnempty: ISet<DidacticTask>
    {
        private List<DidacticTask> items;
        private bool isReadOnly;

        public DidacticTaskSetUnempty(DidacticTask task)
        {
            this.items = new List<DidacticTask>();
            this.items.Add(task);
            this.isReadOnly = false;
        }

        public DidacticTaskSetUnempty(DidacticTask task, bool isReadOnly)
        {
            this.items = new List<DidacticTask>();
            this.items.Add(task);
            this.isReadOnly = isReadOnly;
        }

        public DidacticTaskSetUnempty(List<DidacticTask> tasks)
        {
            this.items = tasks;
            this.isReadOnly = false;
        }

        public DidacticTaskSetUnempty(List<DidacticTask> tasks, bool isReadOnly)
        {
            this.items = tasks;
            this.isReadOnly = isReadOnly;
        }

        public bool Add(DidacticTask item)
        {
            if (!this.Contains(item))
            {
                this.items.Add(item);
                return true;
            }
            else
                return false;
        }

        public void ExceptWith(IEnumerable<DidacticTask> other)
        {
            foreach (DidacticTask ls in other)
            {
                if (this.Contains(ls))
                {
                    items.Remove(ls);
                }
            }
        }

        public void IntersectWith(IEnumerable<DidacticTask> other)
        {
            foreach (DidacticTask ls in items)
            {
                if (!other.Contains(ls))
                {
                    items.Remove(ls);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<DidacticTask> other)
        {
            return ((this.Count() < other.Count()) && (this.IsProperSubsetOf(other)));
        }

        public bool IsProperSupersetOf(IEnumerable<DidacticTask> other)
        {
            return ((this.Count() > other.Count()) && (this.IsProperSupersetOf(other)));
        }

        public bool IsSubsetOf(IEnumerable<DidacticTask> other)
        {
            bool isSubset = true;
            foreach (DidacticTask ls in items)
            {
                if (!other.Contains(ls))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool IsSupersetOf(IEnumerable<DidacticTask> other)
        {
            bool isSubset = true;
            foreach (DidacticTask ls in other)
            {
                if (!this.Contains(ls))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool Overlaps(IEnumerable<DidacticTask> other)
        {
            bool found = false;
            foreach (DidacticTask ls in other)
            {
                if (this.Contains(ls))
                {
                    found = true;
                    break;
                }
            }
            return found;

        }

        public bool SetEquals(IEnumerable<DidacticTask> other)
        {
            if (other.Count() != this.Count)
                return false;
            else
            {
                foreach (DidacticTask ls in other)
                {
                    if (!items.Contains(ls))
                        return false;
                }
                return true;
            }

        }

        public void SymmetricExceptWith(IEnumerable<DidacticTask> other)
        {

            foreach (DidacticTask ls in other)
            {
                if (this.Contains(ls))
                    this.Remove(ls);
                else
                    this.Add(ls);
            }
        }

        public void UnionWith(IEnumerable<DidacticTask> other)
        {
            foreach (DidacticTask ls in other)
            {
                if (!this.Contains(ls))
                {
                    items.Add(ls);
                }
            }
        }

        void ICollection<DidacticTask>.Add(DidacticTask item)
        {
            if (!this.Contains(item))
                items.Add(item);


        }

        public void Clear()
        {
            DidacticTask item = items[0];
            items = new List<DidacticTask>();
            items.Add(item);
        }

        public bool Contains(DidacticTask item)
        {

            bool found = false;
            for (int i = 0; i < (items.Count) && (!found); i++)
            {
                if (items.ElementAt(i).Equals(item))
                    found = true;
            }
            return found;
        }

        public void CopyTo(DidacticTask[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (DidacticTask ls in items)
            {
                array[i] = ls;
                i++;
            }
        }

        public int Count
        {
            get { return items.Count; }

        }

        public bool IsReadOnly
        {
            get { return this.isReadOnly; }
        }

        public bool Remove(DidacticTask item)
        {
            if (items.Count != 1)
                return items.Remove(item);
            else
                return false;
        }

        public IEnumerator<DidacticTask> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
