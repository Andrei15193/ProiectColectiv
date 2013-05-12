//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ResourceManagementSystem.BusinessLogic.Entities
//{
//    public class DidacticTaskSet : ISet<DidacticTask>
//    {
//        private List<DidacticTask> items;
//        private bool isReadOnly;

//        public DidacticTaskSet()
//        {
//            items = new List<DidacticTask>();
//            isReadOnly = false;
//        }

//        public DidacticTaskSet(bool isReadOnly)
//        {
//            items = new List<DidacticTask>();
//            this.isReadOnly = isReadOnly;
//        }

//        public DidacticTaskSet(List<DidacticTask> tasks)
//        {
//            items = tasks;
//            isReadOnly = false;
//        }

//        public DidacticTaskSet(List<DidacticTask> tasks, bool isReadOnly)
//        {
//            this.items = tasks;
//            this.isReadOnly = isReadOnly;
//        }

//        public bool Add(DidacticTask item)
//        {
//            if (!this.Contains(item))
//            {
//                items.Add(item);
//                return true;
//            }
//            else
//                return false;
//        }

//        public void ExceptWith(IEnumerable<DidacticTask> other)
//        {
//            foreach (DidacticTask e in other)
//            {
//                if (this.Contains(e))
//                {
//                    items.Remove(e);
//                }
//            }
//        }

//        public void IntersectWith(IEnumerable<DidacticTask> other)
//        {
//            foreach (DidacticTask e in items)
//            {
//                if (!other.Contains(e))
//                {
//                    items.Remove(e);
//                }
//            }
//        }

//        public bool IsProperSubsetOf(IEnumerable<DidacticTask> other)
//        {
//            return ((this.Count() < other.Count()) && (this.IsProperSubsetOf(other)));
//        }

//        public bool IsProperSupersetOf(IEnumerable<DidacticTask> other)
//        {
//            return ((this.Count() > other.Count()) && (this.IsProperSupersetOf(other)));
//        }

//        public bool IsSubsetOf(IEnumerable<DidacticTask> other)
//        {
//            bool isSubset = true;
//            foreach (DidacticTask e in items)
//            {
//                if (!other.Contains(e))
//                {
//                    isSubset = false;
//                    break;
//                }
//            }
//            return isSubset;
//        }

//        public bool IsSupersetOf(IEnumerable<DidacticTask> other)
//        {
//            bool isSubset = true;
//            foreach (DidacticTask e in other)
//            {
//                if (!this.Contains(e))
//                {
//                    isSubset = false;
//                    break;
//                }
//            }
//            return isSubset;
//        }

//        public bool Overlaps(IEnumerable<DidacticTask> other)
//        {
//            bool found = false;
//            foreach (DidacticTask e in other)
//            {
//                if (this.Contains(e))
//                {
//                    found = true;
//                    break;
//                }
//            }
//            return found;

//        }

//        public bool SetEquals(IEnumerable<DidacticTask> other)
//        {
//            if (other.Count() != this.Count)
//                return false;
//            else
//            {
//                foreach (DidacticTask e in other)
//                {
//                    if (!items.Contains(e))
//                        return false;
//                }
//                return true;
//            }

//        }

//        public void SymmetricExceptWith(IEnumerable<DidacticTask> other)
//        {

//            foreach (DidacticTask e in other)
//            {
//                if (this.Contains(e))
//                    this.Remove(e);
//                else
//                    this.Add(e);
//            }
//        }

//        public void UnionWith(IEnumerable<DidacticTask> other)
//        {
//            foreach (DidacticTask e in other)
//            {
//                if (!this.Contains(e))
//                {
//                    items.Add(e);
//                }
//            }
//        }

//        void ICollection<DidacticTask>.Add(DidacticTask item)
//        {
//            if (!this.Contains(item))
//                items.Add(item);
//        }

//        public void Clear()
//        {
//            items = new List<DidacticTask>();
//        }

//        public bool Contains(DidacticTask item)
//        {

//            bool found = false;
//            for (int i = 0; i < (items.Count) && (!found); i++)
//            {
//                if (items.ElementAt(i).Equals(item))
//                    found = true;
//            }
//            return found;
//        }

//        public void CopyTo(DidacticTask[] array, int arrayIndex)
//        {
//            int i = arrayIndex;
//            foreach (DidacticTask e in items)
//            {
//                array[i] = e;
//                i++;
//            }
//        }

//        public int Count
//        {
//            get { return items.Count; }

//        }

//        public bool IsReadOnly
//        {
//            get { return this.isReadOnly; }
//        }

//        public bool Remove(DidacticTask item)
//        {
//            return items.Remove(item);
//        }

//        public IEnumerator<DidacticTask> GetEnumerator()
//        {
//            return items.GetEnumerator();
//        }

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//        {
//            return this.GetEnumerator();
//        }
//    }
//}
