using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class TaskEquipmentSet : ICollection<Equipment>
    {

        public TaskEquipmentSet(ITask task, IEnumerable<Equipment> equipments)
        {
            if (task != null)
                if (equipments != null)
                {
                    Task = task;
                    this.equipments = new HashSet<Equipment>();
                    foreach (Equipment equipment in equipments)
                        if (equipment != null)
                            Add(equipment);
                        else
                            throw new ArgumentException("The provided equipment collection cannot contain any null values!");
                }
                else
                    throw new ArgumentNullException("The provided value for equipment collection cannot be null!");
            else
                throw new ArgumentNullException("The provided value for task cannot be null!");
        }
        public TaskEquipmentSet(ITask task)
            : this(task, new Equipment[0] as IEnumerable<Equipment>)
        {
        }

        public TaskEquipmentSet(ITask task, params Equipment[] equipments)
            : this(task, equipments as IEnumerable<Equipment>)
        {
        }

        public void Add(Equipment equipment)
        {
            if (equipment != null)
            {
                if (equipments.Add(equipment))
                    Task.Equipments.Add(equipment);
            }
            else
                throw new ArgumentNullException("The provided value for equipment cannot be null!");
        }

        public void Clear()
        {
            int equipmentCount = equipments.Count;
            while (equipmentCount > 0)
            {
                Equipment equipment = equipments.First();
                Task.Equipments.Remove(equipment);
                if (equipmentCount == equipments.Count)
                    equipments.Remove(equipment);
                equipmentCount--;
            }
        }

        public bool Contains(Equipment equipment)
        {
            if (equipment != null)
                return equipments.Contains(equipment);
            else
                throw new ArgumentNullException("The provided value for equipment cannot be null!");
        }

        public void CopyTo(Equipment[] array, int arrayIndex)
        {
            equipments.CopyTo(array, arrayIndex);
        }

        public bool Remove(Equipment equipment)
        {
            if (equipment != null)
                return equipments.Remove(equipment);
            else
                throw new ArgumentNullException("The provided value for equipment cannot be null!");
        }

        public IEnumerator<Equipment> GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        public ITask Task { get; private set; }

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

        protected virtual IEnumerator<Equipment> ProtectedGetEnumerator()
        {
            return equipments.GetEnumerator();
        }

        private ISet<Equipment> equipments;
    }
}
