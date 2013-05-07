using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    class CourseSetUnempty: ISet<Course>
    {
        private List<Course> items;
        private bool isReadOnly;

        public CourseSetUnempty(Course course)
        {
            this.items = new List<Course>();
            this.items.Add(course);
            this.isReadOnly = false;
        }

        public CourseSetUnempty(Course course, bool isReadOnly)
        {
            this.items = new List<Course>();
            this.items.Add(course);
            this.isReadOnly = isReadOnly;
        }

        public CourseSetUnempty(List<Course> courses)
        {
            this.items = courses;
            this.isReadOnly = false;
        }

        public CourseSetUnempty(List<Course> courses, bool isReadOnly)
        {
            this.items = courses;
            this.isReadOnly = isReadOnly;
        }

        public bool Add(Course item)
        {
            if (!this.Contains(item))
            {
                this.items.Add(item);
                return true;
            }
            else
                return false;
        }

        public void ExceptWith(IEnumerable<Course> other)
        {
            foreach (Course ls in other)
            {
                if (this.Contains(ls))
                {
                    items.Remove(ls);
                }
            }
        }

        public void IntersectWith(IEnumerable<Course> other)
        {
            foreach (Course ls in items)
            {
                if (!other.Contains(ls))
                {
                    items.Remove(ls);
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
            foreach (Course ls in items)
            {
                if (!other.Contains(ls))
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
            foreach (Course ls in other)
            {
                if (!this.Contains(ls))
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
            foreach (Course ls in other)
            {
                if (this.Contains(ls))
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
                foreach (Course ls in other)
                {
                    if (!items.Contains(ls))
                        return false;
                }
                return true;
            }

        }

        public void SymmetricExceptWith(IEnumerable<Course> other)
        {

            foreach (Course ls in other)
            {
                if (this.Contains(ls))
                    this.Remove(ls);
                else
                    this.Add(ls);
            }
        }

        public void UnionWith(IEnumerable<Course> other)
        {
            foreach (Course ls in other)
            {
                if (!this.Contains(ls))
                {
                    items.Add(ls);
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
            Course item = items[0];
            items = new List<Course>();
            items.Add(item);
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
            foreach (Course ls in items)
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

        public bool Remove(Course item)
        {
            if (items.Count != 1)
                return items.Remove(item);
            else
                return false;
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
