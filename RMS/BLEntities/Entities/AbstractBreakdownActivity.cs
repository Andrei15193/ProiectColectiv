using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class AbstractBreakdownActivity : AbstractActivity
    {
        public ICollection<TaskBreakdownActivity> BreakdownActvities { get; private set; }

        protected AbstractBreakdownActivity(ActivityType type, string title, string description, DateTime startDate, DateTime endDate)
            :base(type, title, description, startDate, endDate)
        {
            BreakdownActvities = new Collections.DateTimeBoundCollection<TaskBreakdownActivity>(startDate, endDate);
        }
    }
}
