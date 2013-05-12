using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class ClassRoom : LogisticalResource
    {
        public ClassRoom(string building, uint floor, uint number, string description, ITask task)
            : base(BuildClassRoomName(building, floor, number), description, task)
        {
            Building = building;
            Floor = floor;
            Number = number;
            Task = task;
            Equipments = new Collections.ClassRoomEquipmentSet(this);
        }

        public ClassRoom(string building, uint floor, uint number)
            : this(building, floor, number, string.Empty, null)
        {
        }

        public ClassRoom(string building, uint floor, uint number, ITask task)
            : this(building, floor, number, string.Empty, task)
        {
        }

        public ClassRoom(string building, uint floor, uint number, string description)
            : this(building, floor, number, description, null)
        {
        }

        public string Building { get; private set; }

        public uint Floor { get; private set; }

        public uint Number { get; private set; }

        public ICollection<Equipment> Equipments { get; private set; }

        public override ITask Task
        {
            get
            {
                return base.Task;
            }
            set
            {
                if (value != null && base.Task != value)
                    value.Location = this;
                base.Task = value;
            }
        }

        private static string BuildClassRoomName(string building, uint floor, uint number)
        {
            if (building != null)
                if (building.Length > 4)
                {
                    StringBuilder nameBuilder = new StringBuilder(building);
                    nameBuilder.Append(' ');
                    nameBuilder.Append(floor);
                    nameBuilder.Append(number);
                    return nameBuilder.ToString();
                }
                else
                    throw new ArgumentException("The provided building name must have at least 5 characters!");
            else
                throw new ArgumentNullException("The provided value for building name cannot be null!");
        }
    }
}
