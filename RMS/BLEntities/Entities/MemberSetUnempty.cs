using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    class MemberSetUnempty: ISet<Member>
    {
   
        private List<Member> items;
        private bool isReadOnly;

        public MemberSetUnempty(Member r)
        {
            items = new List<Member>();
            items.Add(r);
            isReadOnly = false;
        }

        public MemberSetUnempty(Member r,bool isReadOnly)
        {
            items = new List<Member>();
            items.Add(r);
            this.isReadOnly = isReadOnly;
        }

        public bool Add(Member item)
        {
            if (!this.Contains(item))
            {
                items.Add(item);
                return true;
            }
            else
                return false;
        }

        public void ExceptWith(IEnumerable<Member> other)
        {


            foreach (Member f in other)
            {
                if (this.Contains(f))
                {
                    items.Remove(f);
                }
            }
            
        }

        public void IntersectWith(IEnumerable<Member> other)
        {
            foreach (Member f in items)
            {
                if (!other.Contains(f))
                {
                    items.Remove(f);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<Member> other)
        {
            return ((this.Count() < other.Count()) && (this.IsProperSubsetOf(other)));
        }

        public bool IsProperSupersetOf(IEnumerable<Member> other)
        {
            return ((this.Count() > other.Count()) && (this.IsProperSupersetOf(other)));
        }

        public bool IsSubsetOf(IEnumerable<Member> other)
        {
            bool isSubset = true;
            foreach (Member f in items)
            {
                if (!other.Contains(f))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool IsSupersetOf(IEnumerable<Member> other)
        {
            bool isSubset = true;
            foreach (Member f in other)
            {
                if (!this.Contains(f))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool Overlaps(IEnumerable<Member> other)
        {
            bool found = false;
            foreach (Member f in other)
            {
                if (this.Contains(f))
                {
                    found = true;
                    break;
                }
            }
            return found;

        }

        public bool SetEquals(IEnumerable<Member> other)
        {
            if (other.Count() != this.Count)
                return false;
            else
            {
                foreach (Member f in other)
                {
                    if (!items.Contains(f))
                        return false;
                }
                return true;
            }

        }

        public void SymmetricExceptWith(IEnumerable<Member> other)
        {

            foreach (Member f in other)
            {
                if (this.Contains(f))
                    this.Remove(f);
                else
                    this.Add(f);
            }
        }

        public void UnionWith(IEnumerable<Member> other)
        {
            foreach (Member f in other)
            {
                if (!this.Contains(f))
                {
                    items.Add(f);
                }
            }
        }

        void ICollection<Member>.Add(Member item)
        {
            if (!this.Contains(item))
                items.Add(item);


        }

        public void Clear()
        {
            Member r = items.ElementAt(0);
            items = new List<Member>();
            items.Add(r);
        }

        public bool Contains(Member item)
        {

            bool found = false;
            for (int i = 0; i < (items.Count) && (!found); i++)
            {
                if (items.ElementAt(i).Equals(item))
                    found = true;
            }
            return found;
        }

        public void CopyTo(Member[] array, int arrayIndex)
        {

            int i = arrayIndex;
            foreach (Member f in items)
            {
                array[i] = f;
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

        public bool Remove(Member item)
        {
            if (items.Count > 1)
                return items.Remove(item);
            else
                return false;
        }   

        public IEnumerator<Member> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

    

