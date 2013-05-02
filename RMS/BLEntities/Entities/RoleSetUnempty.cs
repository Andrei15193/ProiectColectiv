﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    class RoleSetUnempty : ISet<Role>
    {
        private List<Role> items;
        private bool isReadOnly;

        public RoleSetUnempty(Role r)
        {
            items = new List<Role>();
            items.Add(r);
            isReadOnly = false;
        }

        public RoleSetUnempty(Role r,bool isReadOnly)
        {
            items = new List<Role>();
            items.Add(r);
            this.isReadOnly = isReadOnly;
        }

        public bool Add(Role item)
        {
            if (!this.Contains(item))
            {
                items.Add(item);
                return true;
            }
            else
                return false;
        }

        public void ExceptWith(IEnumerable<Role> other)
        {


            foreach (Role f in other)
            {
                if (this.Contains(f))
                {
                    items.Remove(f);
                }
            }
            
        }

        public void IntersectWith(IEnumerable<Role> other)
        {
            foreach (Role f in items)
            {
                if (!other.Contains(f))
                {
                    items.Remove(f);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<Role> other)
        {
            return ((this.Count() < other.Count()) && (this.IsProperSubsetOf(other)));
        }

        public bool IsProperSupersetOf(IEnumerable<Role> other)
        {
            return ((this.Count() > other.Count()) && (this.IsProperSupersetOf(other)));
        }

        public bool IsSubsetOf(IEnumerable<Role> other)
        {
            bool isSubset = true;
            foreach (Role f in items)
            {
                if (!other.Contains(f))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool IsSupersetOf(IEnumerable<Role> other)
        {
            bool isSubset = true;
            foreach (Role f in other)
            {
                if (!this.Contains(f))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool Overlaps(IEnumerable<Role> other)
        {
            bool found = false;
            foreach (Role f in other)
            {
                if (this.Contains(f))
                {
                    found = true;
                    break;
                }
            }
            return found;

        }

        public bool SetEquals(IEnumerable<Role> other)
        {
            if (other.Count() != this.Count)
                return false;
            else
            {
                foreach (Role f in other)
                {
                    if (!items.Contains(f))
                        return false;
                }
                return true;
            }

        }

        public void SymmetricExceptWith(IEnumerable<Role> other)
        {

            foreach (Role f in other)
            {
                if (this.Contains(f))
                    this.Remove(f);
                else
                    this.Add(f);
            }
        }

        public void UnionWith(IEnumerable<Role> other)
        {
            foreach (Role f in other)
            {
                if (!this.Contains(f))
                {
                    items.Add(f);
                }
            }
        }

        void ICollection<Role>.Add(Role item)
        {
            if (!this.Contains(item))
                items.Add(item);


        }

        public void Clear()
        {
            Role r = items.ElementAt(0);
            items = new List<Role>();
            items.Add(r);
        }

        public bool Contains(Role item)
        {

            bool found = false;
            for (int i = 0; i < (items.Count) && (!found); i++)
            {
                if (items.ElementAt(i).Equals(item))
                    found = true;
            }
            return found;
        }

        public void CopyTo(Role[] array, int arrayIndex)
        {

            int i = arrayIndex;
            foreach (Role f in items)
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

        public bool Remove(Role item)
        {
            if (items.Count > 1)
                return items.Remove(item);
            else
                return false;
        }   

        public IEnumerator<Role> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
