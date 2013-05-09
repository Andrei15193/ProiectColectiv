using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class Activity : Task
    {
        private UnemptySortedSet<Task> tasks;

        public SortedSet<Task> GetTasks() { return tasks; }
    }
}
