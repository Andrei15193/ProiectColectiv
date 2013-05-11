using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class FeatureSet : ISet<Feature>
    {
        private List<Feature> items;
        private bool isReadOnly;

        public FeatureSet()
        {
            items = new List<Feature>();
            isReadOnly = false;
        }

        public FeatureSet(bool isReadOnly)
        {
            items = new List<Feature>();
            this.isReadOnly = isReadOnly;
        }

        public bool Add(Feature item)
        {
            if (!this.Contains(item))
            {
                items.Add(item);
                return true;
            }
            else
                return false;
        }

        public void ExceptWith(IEnumerable<Feature> other)
        {
            foreach (Feature f in other)
            {
                if (this.Contains(f))
                {
                    items.Remove(f);
                }
            }
        }

        public void IntersectWith(IEnumerable<Feature> other)
        {
            foreach (Feature f in items)
            {
                if (!other.Contains(f))
                {
                    items.Remove(f);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<Feature> other)
        {
            return ((this.Count() < other.Count()) && (this.IsProperSubsetOf(other)));
        }

        public bool IsProperSupersetOf(IEnumerable<Feature> other)
        {
            return ((this.Count() > other.Count()) && (this.IsProperSupersetOf(other)));
        }

        public bool IsSubsetOf(IEnumerable<Feature> other)
        {
            bool isSubset = true;
            foreach (Feature f in items)
            {
                if (!other.Contains(f))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool IsSupersetOf(IEnumerable<Feature> other)
        {
            bool isSubset = true;
            foreach (Feature f in other)
            {
                if (!this.Contains(f))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool Overlaps(IEnumerable<Feature> other)
        {
            bool found = false;
            foreach (Feature f in other)
            {
                if (this.Contains(f))
                {
                    found = true;
                    break;
                }
            }
            return found;

        }

        public bool SetEquals(IEnumerable<Feature> other)
        {
            if (other.Count() != this.Count)
                return false;
            else
            {
                foreach (Feature f in other)
                {
                    if (!items.Contains(f))
                        return false;
                }
                return true;
            }

        }

        public void SymmetricExceptWith(IEnumerable<Feature> other)
        {

            foreach (Feature f in other)
            {
                if (this.Contains(f))
                    this.Remove(f);
                else
                    this.Add(f);
            }
        }

        public void UnionWith(IEnumerable<Feature> other)
        {
            foreach (Feature f in other)
            {
                if (!this.Contains(f))
                {
                    items.Add(f);
                }
            }
        }

        void ICollection<Feature>.Add(Feature item)
        {
            if (!this.Contains(item))
                items.Add(item);


        }

        public void Clear()
        {
            items = new List<Feature>();
        }

        public bool Contains(Feature item)
        {

            bool found = false;
            for (int i = 0; i < (items.Count) && (!found); i++)
            {
                if (items.ElementAt(i).Equals(item))
                    found = true;
            }
            return found;
        }

        public void CopyTo(Feature[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (Feature f in items)
            {
                array[i] = f;
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

        public bool Remove(Feature item)
        {
            return items.Remove(item);
        }

        public IEnumerator<Feature> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
