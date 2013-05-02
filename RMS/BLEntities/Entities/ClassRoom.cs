using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    class ClassRoom : LogisticalResource
    {
        private string building;
        private uint floor;
        private uint number;
        private EquipmentSet equipments;

        public ClassRoom(Task task) :base(task)
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
        {
            this.name = name;
            this.description = description;
            this.task = task;
            this.building = building;
            this.floor = 0;
            this.number = 0;
            this.equipments = new EquipmentSet();
        }

        public ClassRoom(string name, Task task, string building, uint floor, uint number)
        {
            this.name = name;
            this.description = "";
            this.task = task;
            this.building = building;
            this.floor = floor;
            this.number = number;
            this.equipments = new EquipmentSet();
        }

        public ClassRoom(string name, string description, Task task, string building, uint floor, uint number,
            EquipmentSet equipments)
        {
            this.name = name;
            this.description = description;
            this.task = task;
            this.building = building;
            this.floor = floor;
            this.number = number;
            this.equipments = equipments;
        }

        public string getBuilding()
        {
            return this.building;
        }

        public uint getFloor()
        {
            return this.floor;
        }

        public uint getNumber()
        {
            return this.number;
        }

        public EquipmentSet getEquipments()
        {
            return this.equipments;
        }

        public void setBuilding(string building)
        {
            this.building = building;
        }

        public void setFloor(uint floor)
        {
            this.floor = floor;
        }

        public void setNumber(uint number)
        {
            this.number = number;
        }

        public void setEquipments(EquipmentSet equipments)
        {
            this.equipments = equipments;
        }
    }
}
