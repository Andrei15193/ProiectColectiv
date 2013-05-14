using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Activity : AbstractActivity
    {
        public Activity(string title, string description, IEnumerable<ITask> tasks)
            : base(title, description)
        {
            if (tasks != null)
            {
                Tasks = new SortedSet<ITask>(new Collections.Comparer<ITask>((x, y) => x.StartDate.CompareTo(y.StartDate)));
                foreach (ITask task in Tasks)
                    if (task != null)
                        Tasks.Add(task);
                    else
                        throw new ArgumentException("The provided task collection cannot contain null values!");
            }
            else
                throw new ArgumentNullException("The provided task collection cannot be null!");
        }

        public Activity(string title, string description, params ITask[] tasks)
            : this(title, description, tasks as IEnumerable<ITask>)
        {
        }

        public Activity(string title, IEnumerable<ITask> tasks)
            : this(title, string.Empty, tasks)
        {
        }

        public Activity(string title, params ITask[] tasks)
            : this(title, string.Empty, tasks as IEnumerable<ITask>)
        {
        }

        public DateTime StartDate
        {
            get
            {
                return Tasks.Min((task) => task.StartDate);
            }
        }

        public DateTime EndDate
        {
            get
            {
                return Tasks.Max((task) => task.EndDate);
            }
        }

        public ICollection<ITask> Tasks { get; protected set; }

        public FinancialResource EstimatedBudget
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
