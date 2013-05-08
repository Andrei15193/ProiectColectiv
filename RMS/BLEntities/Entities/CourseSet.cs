using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class CourseSet: ISet<Course>
    {
        private List<Course> items;
        private bool isReadOnly;

        public CourseSet()
        {
            items = new List<Course>();
            isReadOnly = false;
        }

        public CourseSet(bool isReadOnly)
        {
            items = new List<Course>();
            this.isReadOnly = isReadOnly;
        }

        public CourseSet(List<Course> courses)
        {
            items = courses;
            isReadOnly = false;
        }

        public CourseSet(List<Course> courses, bool isReadOnly)
        {
            this.items = courses;
            this.isReadOnly = isReadOnly;
        }

        public bool Add(Course item)
        {
            if (!this.Contains(item))
            {
                items.Add(item);
                return true;
            }
            else
                return false;
        }

        public void ExceptWith(IEnumerable<Course> other)
        {
            foreach (Course e in other)
            {
                if (this.Contains(e))
                {
                    items.Remove(e);
                }
            }
        }

        public void IntersectWith(IEnumerable<Course> other)
        {
            foreach (Course e in items)
            {
                if (!other.Contains(e))
                {
                    items.Remove(e);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<Course> other)
        {
            return ((this.Count() < other.Count()) && (this.IsProperSubsetOf(other)));
        }

        public bool IsProperSupersetOf(IEnumerable<Course> other)
        {
            return ((this.Count() > other.Count()) && (this.IsProperSupersetOf(other)));
        }

        public bool IsSubsetOf(IEnumerable<Course> other)
        {
            bool isSubset = true;
            foreach (Course e in items)
            {
                if (!other.Contains(e))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool IsSupersetOf(IEnumerable<Course> other)
        {
            bool isSubset = true;
            foreach (Course e in other)
            {
                if (!this.Contains(e))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool Overlaps(IEnumerable<Course> other)
        {
            bool found = false;
            foreach (Course e in other)
            {
                if (this.Contains(e))
                {
                    found = true;
                    break;
                }
            }
            return found;

        }

        public bool SetEquals(IEnumerable<Course> other)
        {
            if (other.Count() != this.Count)
                return false;
            else
            {
                foreach (Course e in other)
                {
                    if (!items.Contains(e))
                        return false;
                }
                return true;
            }

        }

        public void SymmetricExceptWith(IEnumerable<Course> other)
        {

            foreach (Course e in other)
            {
                if (this.Contains(e))
                    this.Remove(e);
                else
                    this.Add(e);
            }
        }

        public void UnionWith(IEnumerable<Course> other)
        {
            foreach (Course e in other)
            {
                if (!this.Contains(e))
                {
                    items.Add(e);
                }
            }
        }

        void ICollection<Course>.Add(Course item)
        {
            if (!this.Contains(item))
                items.Add(item);
        }
       

        public void Clear()
        {
            items = new List<Course>();
        }

        public bool Contains(Course item)
        {

            bool found = false;
            for (int i = 0; i < (items.Count) && (!found); i++)
            {
                if (items.ElementAt(i).Equals(item))
                    found = true;
            }
            return found;
        }

        public void CopyTo(Course[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (Course e in items)
            {
                array[i] = e;
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

        public bool Remove(Course item)
        {
            return items.Remove(item);
        }

        public IEnumerator<Course> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
