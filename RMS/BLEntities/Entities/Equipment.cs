﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    class Equipment : LogisticalResource
    {
        private string brand;
        private uint timesUsed;
        private bool isBroken;
        private ClassRoom classroom;

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

        public string getBrand()
        {
            return this.brand;
        }

        public uint getTimesUsed()
        {
            return this.timesUsed;
        }

        public bool getIsBroken()
        {
            return this.isBroken;
        }

        public ClassRoom getClassRoom()
        {
            return this.classroom;
        }

        public void setBrand(string brand)
        {
            this.brand = brand;
        }

        public void setTimesUsed(uint timesUsed)
        {
            this.timesUsed = timesUsed;
        }

        public void setIsBroken(bool isBroken)
        {
            this.isBroken = isBroken;
        }

        public void setClassRoom(ClassRoom classroom)
        {
            this.classroom = classroom;
        }

        public override bool Equals(Object obj)
        {
            Equipment equipmentObj = obj as Equipment;
            if (equipmentObj == null)
                return false;
            else
                return name.Equals(equipmentObj.getName());
        }

        public override string ToString()
        {
            return "Name: "+this.name+"; Description: "+this.description+"; Task: "+task.toString()+
                "Brand: " + this.brand + "; Times Used: " + this.timesUsed + "; Is Broken: " + isBroken +
                "ClassRoom: "+this.classroom.toString();
        }
    }
}
