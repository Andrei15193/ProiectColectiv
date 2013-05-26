using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Activity : AbstractActivity
    {
        public Activity(string title, string description, IEnumerable<string> allowedTaskTypes, IEnumerable<ITask> tasks)
            : base(title, description, allowedTaskTypes)
        {
            if (tasks != null)
            {
                Tasks = new SortedSet<ITask>(new Collections.Comparer<ITask>((x, y) => x.StartDate.CompareTo(y.StartDate)));
                foreach (ITask task in Tasks)
                    if (task != null)
                        if (allowedTaskTypes.Contains(task.Type.Name))
                            Tasks.Add(task);
                        else
                            throw new ArgumentException("The provided task type is not allowed!");
                    else
                        throw new ArgumentException("The provided task collection cannot contain null values!");
            }
            else
                throw new ArgumentNullException("The provided task collection cannot be null!");
        }

        public Activity(string title, string description, IEnumerable<string> allowedTaskTypes, params ITask[] tasks)
            : this(title, description, allowedTaskTypes, tasks as IEnumerable<ITask>)
        {
        }

        public Activity(string title, IEnumerable<string> allowedTaskTypes, IEnumerable<ITask> tasks)
            : this(title, string.Empty, allowedTaskTypes, tasks)
        {
        }

        public Activity(string title, IEnumerable<string> allowedTaskTypes, params ITask[] tasks)
            : this(title, string.Empty, allowedTaskTypes, tasks as IEnumerable<ITask>)
        {
        }

        public override bool TryGetStartDate(out DateTime startDate)
        {
            if (Tasks.Count > 0)
            {
                startDate = StartDate;
                return true;
            }
            else
            {
                startDate = DateTime.Now;
                return false;
            }
        }

        public override bool TryGetEndDate(out DateTime endDate)
        {
            if (Tasks.Count > 0)
            {
                endDate = EndDate;
                return true;
            }
            else
            {
                endDate = DateTime.Now;
                return false;
            }
        }

        public override DateTime StartDate
        {
            get
            {
                if (Tasks.Count > 0)
                    return Tasks.Min((task) => task.StartDate);
                else
                    throw new InvalidOperationException("There are no tasks in the current activity, could not calculate start date!");
            }
        }

        public override DateTime EndDate
        {
            get
            {
                if (Tasks.Count > 0)
                    return Tasks.Max((task) => task.EndDate);
                else
                    throw new InvalidOperationException("There are no tasks in the current activity, could not calculate end date!");
            }
        }

        public override ICollection<ITask> Tasks { get; protected set; }

        public override FinancialResource EstimatedBudget
        {
            get
            {
                return Tasks.Select((task) => task.EstimatedBudget).Aggregate((x, y) => x + y);
            }
        }

        protected Activity(string title, string description)
            : base(title, description)
        {
        }
    }
}
