using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class LogisticalResource
    {
        public string name
        {
            get { return name; }
            set { name = value; }
        }

        public string description
        {
            get { return description; }
            set { description = value; }
        }

        public Task task
        {
            get { return task; }
            set { task = value; }
        }

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

        public override bool Equals(Object obj)
        {
            LogisticalResource logisticalResourceObj = obj as LogisticalResource;
            if (logisticalResourceObj == null)
                return false;
            else
                return name.Equals(logisticalResourceObj.name);
        }

        public override string ToString()
        {
            return "Name: "+this.name+"; Description: "+this.description+"; Task: "+task.getDescription();
        }
    }
}
