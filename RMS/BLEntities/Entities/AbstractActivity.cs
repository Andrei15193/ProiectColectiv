using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class AbstractActivity : IActivity
    {
        public abstract bool TryGetStartDate(out DateTime startDate);

        public abstract bool TryGetEndDate(out DateTime endDate);

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<Member> Participants
        {
            get
            {
                return Tasks.SelectMany((task) => task.Assignees);
            }
        }

        public IEnumerable<ClassRoom> Locations
        {
            get
            {
                return Tasks.Select((task) => task.Location);
            }
        }

        public IEnumerable<Equipment> Equipments
        {
            get
            {
                return Tasks.SelectMany((task) => task.Equipments);
            }
        }

        public FinancialResource RealizedBudget
        {
            get
            {
                if (Tasks.Count > 0)
                    return new FinancialResource((uint)Tasks.Sum((task) => task.RealizedBudget.Value), Tasks.First().EstimatedBudget.Currency);
                else
                    return null;
            }
        }

        public bool IsActive
        {
            get
            {
                DateTime now = DateTime.Now;
                return (StartDate <= now && now <= EndDate);
            }
        }

        public IEnumerable<TaskType> AllowedTaskTypes { get; set; }

        public abstract DateTime StartDate { get; }

        public abstract DateTime EndDate { get; }

        public abstract ICollection<ITask> Tasks { get; protected set; }

        public abstract FinancialResource EstimatedBudget { get; }

        protected AbstractActivity(string title, string description, IEnumerable<string> allowedTaskTypes)
        {
            if (title != null)
                if (description != null)
                    if (allowedTaskTypes != null)
                        if (title.Length > 4)
                        {
                            Title = title;
                            Description = description;
                            AllowedTaskTypes = new HashSet<TaskType>(TaskType.WithNames(allowedTaskTypes));
                        }
                        else
                            throw new ArgumentException("The provided title must have at least 5 characters.");
                    else
                        throw new ArgumentNullException("The provided value for allowed task type collection cannot be null!");
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            else
                throw new ArgumentNullException("The provided value for title cannot be null!");
        }

        protected AbstractActivity(string title, IEnumerable<string> allowedTaskTypes)
            : this(title, string.Empty, allowedTaskTypes)
        {
        }

        protected AbstractActivity(string title, params string[] allowedTaskTypes)
            : this(title, string.Empty, allowedTaskTypes as IEnumerable<string>)
        {
        }

        protected AbstractActivity(string title, string description, params string[] allowedTaskTypes)
            : this(title, description, allowedTaskTypes as IEnumerable<string>)
        {
        }
    }
}
