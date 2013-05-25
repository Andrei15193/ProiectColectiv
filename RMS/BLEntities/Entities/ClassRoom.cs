using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class ClassRoom : LogisticalResource
    {
        public ClassRoom(string building, uint floor, uint number, string description)
            : base(BuildClassRoomName(building, floor, number), description)
        {
            Building = building;
            Floor = floor;
            Number = number;
            Equipments = new Collections.ClassRoomEquipmentSet(this);
        }

        public ClassRoom(string building, uint floor, uint number)
            : this(building, floor, number, string.Empty)
        {
        }

      

        

        public string Building { get; private set; }

        public uint Floor { get; private set; }

        public uint Number { get; private set; }

        public ICollection<Equipment> Equipments { get; private set; }

        

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
