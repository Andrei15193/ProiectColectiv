using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class ClassRoom : LogisticalResource
    {
        public string building
        {
            get { return building; }
            set { building = value; }
        }

        public uint floor
        {
            get { return floor; }
            set { floor = value; }
        }

        public uint number
        {
            get { return number; }
            set { number = value; }
        }

        public EquipmentSet equipments
        {
            get { return equipments; }
            set { equipments = value; }
        }

        public ClassRoom(Task task)
            : base(task)
        {
            this.building = "";
            this.floor = 0;
            this.number = 0;
            this.equipments = new EquipmentSet();
        }

        public ClassRoom(string name, Task task)
            : base(name, task)
        {
            this.building = "";
            this.floor = 0;
            this.number = 0;
            this.equipments = new EquipmentSet();
        }

        public ClassRoom(string name, string description, Task task, string building)
            : base(name, description, task)
        {
            this.building = building;
            this.floor = 0;
            this.number = 0;
            this.equipments = new EquipmentSet();
        }

        public ClassRoom(string name, Task task, string building, uint floor, uint number)
            : base(name, task)
        {
            this.building = building;
            this.floor = floor;
            this.number = number;
            this.equipments = new EquipmentSet();
        }

        public ClassRoom(string name, string description, Task task, string building, uint floor, uint number,
            EquipmentSet equipments)
            : base(name, description, task)
        {
            this.building = building;
            this.floor = floor;
            this.number = number;
            this.equipments = equipments;
        }

      

        public override string ToString()
        {
            return "Name: " + this.name + "; Description: " + this.description + "; Task: " + task.getDescription() +
                "Building: " + this.building + "; Floor: " + this.floor + "; Number: " + this.number;
        }
    }
}
