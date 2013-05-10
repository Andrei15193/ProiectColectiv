using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class Equipment : LogisticalResource
    {
        public string brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public uint timesUsed
        {
            get { return timesUsed; }
            set { timesUsed = value; }
        }

        public bool isBroken
        {
            get { return isBroken; }
            set { isBroken = value; }
        }

        public ClassRoom classroom
        {
            get { return classroom; }
            set { classroom = value; }
        }

        public Equipment(string name, Task task, string brand)
            : base(name, task)
        {
            this.brand = brand;
            this.timesUsed = 0;
            this.isBroken = false;
            this.classroom = new ClassRoom(task);
        }

        public Equipment(string name, string description, Task task, string brand) :base(name, description, task)
        {
            this.brand = brand;
            this.timesUsed = 0;
            this.isBroken = false;
            this.classroom = new ClassRoom(task);
        }

        public Equipment(string name, string description, Task task, string brand, uint timesUsed,
            bool isBroken, ClassRoom classroom) : base(name, description, task)
        {
            this.name = name;
            this.description = description;
            this.task = task;
            this.brand = brand;
            this.timesUsed = timesUsed;
            this.isBroken = isBroken;
            this.classroom = classroom;
        }

 /*       public override bool Equals(Object obj)
        {
            DidacticTask equipmentObj = obj as DidacticTask;
            if (equipmentObj == null)
                return false;
            else
                return name.Equals(equipmentObj.name);
        }*/

        public override string ToString()
        {
            return "Name: "+this.name+"; Description: "+this.description+"; Task: "+task.getDescription()+
                "Brand: " + this.brand + "; Times Used: " + this.timesUsed + "; Is Broken: " + isBroken +
                "ClassRoom: "+this.classroom.ToString();
        }
    }
}
