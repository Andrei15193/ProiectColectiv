using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class ClassRoomEquipmentSet : ICollection<Equipment>
    {
        public ClassRoomEquipmentSet(ClassRoom classRoom, IEnumerable<Equipment> equipments)
        {
            if (classRoom != null)
                if (equipments != null)
                    if (equipments.Count((equipment) => equipment == null) == 0)
                    {
                        ClassRoom = classRoom;
                        this.equipments = new HashSet<Equipment>(equipments);
                    }
                    else
                        throw new ArgumentException("The provided equipment collection cannot contain null values!");
                else
                    throw new ArgumentNullException("The provided equipment collection cannot be null!");
            else
                throw new ArgumentNullException("The provided class room collection cannot be null!");
        }

        public ClassRoomEquipmentSet(ClassRoom classRoom)
            : this(classRoom, new Equipment[0] as IEnumerable<Equipment>)
        {
        }

        public ClassRoomEquipmentSet(ClassRoom classRoom, params Equipment[] equipments)
            : this(classRoom, equipments as IEnumerable<Equipment>)
        {
        }

        public void Add(Equipment equipment)
        {
            equipments.Add(equipment);
        }

        public void Clear()
        {
            equipments.Clear();
        }

        public bool Contains(Equipment equipment)
        {
            return equipments.Contains(equipment);
        }

        public void CopyTo(Equipment[] array, int arrayIndex)
        {
            equipments.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return equipments.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(Equipment equipment)
        {
            return equipments.Remove(equipment);
        }

        public IEnumerator<Equipment> GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        public ClassRoom ClassRoom { get; private set; }

        protected virtual IEnumerator<Equipment> ProtectedGetEnumerator()
        {
            return equipments.GetEnumerator();
        }

        private ICollection<Equipment> equipments;
    }
}
