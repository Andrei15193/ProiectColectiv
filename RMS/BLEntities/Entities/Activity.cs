using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Activity : IActivity
    {
        public Activity(string title, string description, IEnumerable<ITask> tasks)
        {
            if (title != null)
                if (description != null)
                    if (tasks != null)
                        if (title.Length > 4)
                        {
                            Title = title;
                            Description = description;
                            this.tasks = new SortedSet<ITask>(new Collections.Comparer<ITask>((x, y) => x.StartDate.CompareTo(y.StartDate)));
                            foreach (ITask task in tasks)
                                if (task != null)
                                    this.tasks.Add(task);
                                else
                                    throw new ArgumentException("The provided task collection cannot contain null values!");
                        }
                        else
                            throw new ArgumentException("The provided title must have at least 5 characters.");
                    else
                        throw new ArgumentNullException("The provided tasks collection cannot be null!");
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            else
                throw new ArgumentNullException("The provided value for title cannot be null!");
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

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDate
        {
            get
            {
                return tasks.Min((task) => task.StartDate);
            }
            private set
            {
            }
        }

        public DateTime EndDate
        {
            get
            {
                return tasks.Max((task) => task.EndDate);
            }
            private set
            {
            }
        }

        public IEnumerable<Member> Participants
        {
            get
            {
                return tasks.SelectMany((task) => task.Assignees);
            }
            private set
            {
            }
        }

        public IEnumerable<ClassRoom> Locations
        {
            get
            {
                return tasks.Select((task) => task.Location);
            }
            private set
            {
            }
        }

        public IEnumerable<Equipment> Equipments
        {
            get
            {
                return tasks.SelectMany((task) => task.Equipments);
            }
            private set
            {
            }
        }

        public FinancialResource EstimatedBudget
        {
            get
            {
                return new FinancialResource((uint)tasks.Sum((task) => task.EstimatedBudget.Value), tasks.First().EstimatedBudget.Currency);
            }
            private set
            {
            }
        }

        public FinancialResource RealizedBudget
        {
            get
            {
                if (IsActive)
                    return null;
                else
                    return new FinancialResource((uint)tasks.Sum((task) => task.RealizedBudget.Value), tasks.First().EstimatedBudget.Currency);
            }
            private set
            {
            }
        }

        public bool IsActive
        {
            get
            {
                return EndDate.CompareTo(DateTime.Now) <= 0 && tasks.Count((task) => task.State == TaskState.Approved || task.State == TaskState.Undergoing) > 0;
            }
            private set
            {
            }
        }

        private ICollection<ITask> tasks;
    }
}
