using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLEntities.Entities
{
    class LogisticalResourceSetUnempty : ISet<LogisticalResource>
    {
        private List<LogisticalResource> items;
        private bool isReadOnly;

        public LogisticalResourceSetUnempty(LogisticalResource logisticalResource)
        {
            this.items = new List<LogisticalResource>();
            this.items.Add(logisticalResource);
            this.isReadOnly = false;
        }

        public LogisticalResourceSetUnempty(LogisticalResource logisticalResource, bool isReadOnly)
        {
            this.items = new List<LogisticalResource>();
            this.items.Add(logisticalResource);
            this.isReadOnly = isReadOnly;
        }

        public LogisticalResourceSetUnempty(List<LogisticalResource> logisticalResourceList)
        {
            this.items = logisticalResourceList;
            this.isReadOnly = false;
        }

        public LogisticalResourceSetUnempty(List<LogisticalResource> logisticalResourceList, bool isReadOnly)
        {
            this.items = logisticalResourceList;
            this.isReadOnly = isReadOnly;
        }
        
        public bool Add(LogisticalResource item)
        {
            if (!this.Contains(item))
            {
                this.items.Add(item);
                return true;
            }
            else
                return false;
        }

        public void ExceptWith(IEnumerable<LogisticalResource> other)
        {
            foreach (LogisticalResource ls in other)
            {
                if (this.Contains(ls))
                {
                    items.Remove(ls);
                }
            }
        }

        public void IntersectWith(IEnumerable<LogisticalResource> other)
        {
            foreach (LogisticalResource ls in items)
            {
                if (!other.Contains(ls))
                {
                    items.Remove(ls);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<LogisticalResource> other)
        {
            return ((this.Count() < other.Count()) && (this.IsProperSubsetOf(other)));
        }

        public bool IsProperSupersetOf(IEnumerable<LogisticalResource> other)
        {
            return ((this.Count() > other.Count()) && (this.IsProperSupersetOf(other)));
        }

        public bool IsSubsetOf(IEnumerable<LogisticalResource> other)
        {
            bool isSubset = true;
            foreach (LogisticalResource ls in items)
            {
                if (!other.Contains(ls))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool IsSupersetOf(IEnumerable<LogisticalResource> other)
        {
            bool isSubset = true;
            foreach (LogisticalResource ls in other)
            {
                if (!this.Contains(ls))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool Overlaps(IEnumerable<LogisticalResource> other)
        {
            bool found = false;
            foreach (LogisticalResource ls in other)
            {
                if (this.Contains(ls))
                {
                    found = true;
                    break;
                }
            }
            return found;

        }

        public bool SetEquals(IEnumerable<LogisticalResource> other)
        {
            if (other.Count() != this.Count)
                return false;
            else
            {
                foreach (LogisticalResource ls in other)
                {
                    if (!items.Contains(ls))
                        return false;
                }
                return true;
            }

        }

        public void SymmetricExceptWith(IEnumerable<LogisticalResource> other)
        {

            foreach (LogisticalResource ls in other)
            {
                if (this.Contains(ls))
                    this.Remove(ls);
                else
                    this.Add(ls);
            }
        }

        public void UnionWith(IEnumerable<LogisticalResource> other)
        {
            foreach (LogisticalResource ls in other)
            {
                if (!this.Contains(ls))
                {
                    items.Add(ls);
                }
            }
        }

        void ICollection<LogisticalResource>.Add(LogisticalResource item)
        {
            if (!this.Contains(item))
                items.Add(item);


        }

        public void Clear()
        {
            LogisticalResource item = items[0];
            items = new List<LogisticalResource>();
            items.Add(item);
        }

        public bool Contains(LogisticalResource item)
        {

            bool found = false;
            for (int i = 0; i < (items.Count) && (!found); i++)
            {
                if (items.ElementAt(i).Equals(item))
                    found = true;
            }
            return found;
        }

        public void CopyTo(LogisticalResource[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (LogisticalResource ls in items)
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

        public bool Remove(LogisticalResource item)
        {
            if (items.Count != 1)
                return items.Remove(item);
            else
                return false;
        }

        public IEnumerator<LogisticalResource> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    }
}
