using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class Activity : Task
    {
        public Activity(PerformersSet performers, UnemptySet<LogisticalResource> logisticalResources, FinancialResource estimatedBudget) : base(performers, logisticalResources, estimatedBudget)
        {

        }

        private UnemptySortedSet<Task> tasks;

        public SortedSet<Task> getTasks() { return tasks; }
    }
}
