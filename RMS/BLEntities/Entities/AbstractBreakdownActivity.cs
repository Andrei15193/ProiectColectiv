using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class AbstractBreakdownActivity : AbstractActivity
    {
        public ICollection<TaskBreakdownActivity> BreakdownActvities { get; private set; }

        protected AbstractBreakdownActivity(ActivityType type, string title, string description, DateTime startDate, DateTime endDate, int id)
            : base(type, title, description, startDate, endDate, id)
        {
            BreakdownActvities = new Collections.DateTimeBoundCollection<TaskBreakdownActivity>(startDate, endDate);
        }

        protected AbstractBreakdownActivity(ActivityType type, string title, string description, DateTime startDate, DateTime endDate)
            : this(type, title, description, startDate, endDate, 0)
        {
        }
    }
}
