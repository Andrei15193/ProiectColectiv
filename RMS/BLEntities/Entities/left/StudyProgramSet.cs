//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ResourceManagementSystem.BusinessLogic.Entities
//{
//    public class StudyProgramSet: ISet<StudyProgram>
//    {
//        private List<StudyProgram> items;
//        private bool isReadOnly;

//        public StudyProgramSet()
//        {
//            items = new List<StudyProgram>();
//            isReadOnly = false;
//        }

//        public StudyProgramSet(bool isReadOnly)
//        {
//            items = new List<StudyProgram>();
//            this.isReadOnly = isReadOnly;
//        }

//        public StudyProgramSet(List<StudyProgram> programs)
//        {
//            items = programs;
//            isReadOnly = false;
//        }

//        public StudyProgramSet(List<StudyProgram> programs, bool isReadOnly)
//        {
//            this.items = programs;
//            this.isReadOnly = isReadOnly;
//        }

//        public bool Add(StudyProgram item)
//        {
//            if (!this.Contains(item))
//            {
//                items.Add(item);
//                return true;
//            }
//            else
//                return false;
//        }

//        public void ExceptWith(IEnumerable<StudyProgram> other)
//        {
//            foreach (StudyProgram e in other)
//            {
//                if (this.Contains(e))
//                {
//                    items.Remove(e);
//                }
//            }
//        }

//        public void IntersectWith(IEnumerable<StudyProgram> other)
//        {
//            foreach (StudyProgram e in items)
//            {
//                if (!other.Contains(e))
//                {
//                    items.Remove(e);
//                }
//            }
//        }

//        public bool IsProperSubsetOf(IEnumerable<StudyProgram> other)
//        {
//            return ((this.Count() < other.Count()) && (this.IsProperSubsetOf(other)));
//        }

//        public bool IsProperSupersetOf(IEnumerable<StudyProgram> other)
//        {
//            return ((this.Count() > other.Count()) && (this.IsProperSupersetOf(other)));
//        }

//        public bool IsSubsetOf(IEnumerable<StudyProgram> other)
//        {
//            bool isSubset = true;
//            foreach (StudyProgram e in items)
//            {
//                if (!other.Contains(e))
//                {
//                    isSubset = false;
//                    break;
//                }
//            }
//            return isSubset;
//        }

//        public bool IsSupersetOf(IEnumerable<StudyProgram> other)
//        {
//            bool isSubset = true;
//            foreach (StudyProgram e in other)
//            {
//                if (!this.Contains(e))
//                {
//                    isSubset = false;
//                    break;
//                }
//            }
//            return isSubset;
//        }

//        public bool Overlaps(IEnumerable<StudyProgram> other)
//        {
//            bool found = false;
//            foreach (StudyProgram e in other)
//            {
//                if (this.Contains(e))
//                {
//                    found = true;
//                    break;
//                }
//            }
//            return found;

//        }

//        public bool SetEquals(IEnumerable<StudyProgram> other)
//        {
//            if (other.Count() != this.Count)
//                return false;
//            else
//            {
//                foreach (StudyProgram e in other)
//                {
//                    if (!items.Contains(e))
//                        return false;
//                }
//                return true;
//            }

//        }

//        public void SymmetricExceptWith(IEnumerable<StudyProgram> other)
//        {

//            foreach (StudyProgram e in other)
//            {
//                if (this.Contains(e))
//                    this.Remove(e);
//                else
//                    this.Add(e);
//            }
//        }

//        public void UnionWith(IEnumerable<StudyProgram> other)
//        {
//            foreach (StudyProgram e in other)
//            {
//                if (!this.Contains(e))
//                {
//                    items.Add(e);
//                }
//            }
//        }

//        void ICollection<StudyProgram>.Add(StudyProgram item)
//        {
//            if (!this.Contains(item))
//                items.Add(item);
//        }

//        public void Clear()
//        {
//            items = new List<StudyProgram>();
//        }

//        public bool Contains(StudyProgram item)
//        {

//            bool found = false;
//            for (int i = 0; i < (items.Count) && (!found); i++)
//            {
//                if (items.ElementAt(i).Equals(item))
//                    found = true;
//            }
//            return found;
//        }

//        public void CopyTo(StudyProgram[] array, int arrayIndex)
//        {
//            int i = arrayIndex;
//            foreach (StudyProgram e in items)
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

//        public bool Remove(StudyProgram item)
//        {
//            return items.Remove(item);
//        }

//        public IEnumerator<StudyProgram> GetEnumerator()
//        {
//            return items.GetEnumerator();
//        }

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//        {
//            return this.GetEnumerator();
//        }
//    }
//}
