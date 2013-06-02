using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class TaskBreakdownActivity : AbstractActivity, IEnumerable<Task>
    {
        public TaskBreakdownActivity(AbstractBreakdownActivity breakdownActivity, string title, string description, DateTime startDate, DateTime endDate, int id)
            : base(ActivityType.General_Activity, title, description, startDate, endDate, id)
        {
            if (breakdownActivity != null)
                if (breakdownActivity.StartDate <= startDate && endDate <= breakdownActivity.EndDate)
                {
                    BreakdownActivity = breakdownActivity;
                    tasks = new SortedSet<Task>(new Collections.Comparer<Task>((x, y) => x.StartDate.CompareTo(y.StartDate)));
                }
                else
                    throw new ArgumentException("A general activity cannot exceed the date bounds of the breakdown activity that contains it!");
            else
                throw new ArgumentNullException("The provided value for breakdown activity cannot be null!");
        }
        public TaskBreakdownActivity(AbstractBreakdownActivity breakdownActivity, string title, string description, DateTime startDate, DateTime endDate)
            : this(breakdownActivity, title, description, startDate, endDate, 0)
        {
        }

        public bool Add(Task task)
        {
            if (task != null)
                if (StartDate <= task.StartDate && task.EndDate <= EndDate)
                    return tasks.Add(task);
                else
                    throw new ArgumentException("The given task cannot exceed the date bounds of the activity that contains it!");
            else
                throw new ArgumentNullException("The provided value for task cannot be null!");
        }

        public bool Cotnains(Task task)
        {
            if (task != null)
                return tasks.Contains(task);
            else
                throw new ArgumentNullException("The provided value for task cannot be null!");
        }

        public bool Remove(Task task)
        {
            if (task != null)
                return tasks.Remove(task);
            else
                throw new ArgumentNullException("The provided value for task cannot be null!");
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        public int TaskCount
        {
            get
            {
                return tasks.Count;
            }
        }

        public AbstractBreakdownActivity BreakdownActivity { get; set; }

        public ISet<Task> tasks { get; set; }
    }
}
