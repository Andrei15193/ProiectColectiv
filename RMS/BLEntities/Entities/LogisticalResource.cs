using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLEntities.Entities
{
    class LogisticalResource
    {
        protected string name;
        protected string description;
        protected Task task;

        public LogisticalResource(Task task)
        {
            this.name = "";
            this.description = "";
            this.task = task;
        }

        public LogisticalResource(string name, Task task)
        {
            this.name = name;
            this.description = "";
            this.task = task;
        }

        public LogisticalResource(string name, string description, Task task)
        {
            this.name = name;
            this.description = description;
            this.task = task;
        }

        public string getName()
        {
            return this.name;
        }

        public string getDescription()
        {
            return this.description;
        }

        public Task getTask()
        {
            return this.task;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setTask(Task task)
        {
            this.task = task;
        }

        public override bool Equals(Object obj)
        {
            LogisticalResource logisticalResourceObj = obj as LogisticalResource;
            if (logisticalResourceObj == null)
                return false;
            else
                return name.Equals(logisticalResourceObj.getName());
        }

        public override string ToString()
        {
            return "Name: "+this.name+"; Description: "+this.description+"; Task: "+task.toString();
        }
    }
}
