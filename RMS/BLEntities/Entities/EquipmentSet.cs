using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    class EquipmentSet : ISet<Equipment>
    {
        private List<Equipment> items;
        private bool isReadOnly;

        public EquipmentSet()
        {
            items = new List<Equipment>();
            isReadOnly = false;
        }

        public EquipmentSet(bool isReadOnly)
        {
            items = new List<Equipment>();
            this.isReadOnly = isReadOnly;
        }

        public EquipmentSet(List<Equipment> equipments)
        {
            items = equipments;
            isReadOnly = false;
        }

        public EquipmentSet(List<Equipment> equipments, bool isReadOnly)
        {
            this.items = equipments;
            this.isReadOnly = isReadOnly;
        }

        public bool Add(Equipment item)
        {
            if (!this.Contains(item))
            {
                items.Add(item);
                return true;
            }
            else
                return false;
        }

        public void ExceptWith(IEnumerable<Equipment> other)
        {
            foreach (Equipment e in other)
            {
                if (this.Contains(e))
                {
                    items.Remove(e);
                }
            }
        }

        public void IntersectWith(IEnumerable<Equipment> other)
        {
            foreach (Equipment e in items)
            {
                if (!other.Contains(e))
                {
                    items.Remove(e);
                }
            }
        }

        public bool IsProperSubsetOf(IEnumerable<Equipment> other)
        {
            return ((this.Count() < other.Count()) && (this.IsProperSubsetOf(other)));
        }

        public bool IsProperSupersetOf(IEnumerable<Equipment> other)
        {
            return ((this.Count() > other.Count()) && (this.IsProperSupersetOf(other)));
        }

        public bool IsSubsetOf(IEnumerable<Equipment> other)
        {
            bool isSubset = true;
            foreach (Equipment e in items)
            {
                if (!other.Contains(e))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool IsSupersetOf(IEnumerable<Equipment> other)
        {
            bool isSubset = true;
            foreach (Equipment e in other)
            {
                if (!this.Contains(e))
                {
                    isSubset = false;
                    break;
                }
            }
            return isSubset;
        }

        public bool Overlaps(IEnumerable<Equipment> other)
        {
            bool found = false;
            foreach (Equipment e in other)
            {
                if (this.Contains(e))
                {
                    found = true;
                    break;
                }
            }
            return found;

        }

        public bool SetEquals(IEnumerable<Equipment> other)
        {
            if (other.Count() != this.Count)
                return false;
            else
            {
                foreach (Equipment e in other)
                {
                    if (!items.Contains(e))
                        return false;
                }
                return true;
            }

        }

        public void SymmetricExceptWith(IEnumerable<Equipment> other)
        {

            foreach (Equipment e in other)
            {
                if (this.Contains(e))
                    this.Remove(e);
                else
                    this.Add(e);
            }
        }

        public void UnionWith(IEnumerable<Equipment> other)
        {
            foreach (Equipment e in other)
            {
                if (!this.Contains(e))
                {
                    items.Add(e);
                }
            }
        }

        void ICollection<Equipment>.Add(Equipment item)
        {
            if (!this.Contains(item))
                items.Add(item);


        }

        public void Clear()
        {
            items = new List<Equipment>();
        }

        public bool Contains(Equipment item)
        {

            bool found = false;
            for (int i = 0; i < (items.Count) && (!found); i++)
            {
                if (items.ElementAt(i).Equals(item))
                    found = true;
            }
            return found;
        }

        public void CopyTo(Equipment[] array, int arrayIndex)
        {
            int i = arrayIndex;
            foreach (Equipment e in items)
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

        public bool Remove(Equipment item)
        {
            return items.Remove(item);
        }

        public IEnumerator<Equipment> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
