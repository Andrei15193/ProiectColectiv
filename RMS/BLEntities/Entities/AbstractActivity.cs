using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class AbstractActivity : IActivity
    {
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

        public abstract DateTime StartDate { get; }

        public abstract DateTime EndDate { get; }

        public abstract ICollection<ITask> Tasks { get; protected set; }

        public abstract FinancialResource EstimatedBudget { get; }

        protected AbstractActivity(string title, string description)
        {
            if (title != null)
                if (description != null)
                    if (title.Length > 4)
                    {
                        Title = title;
                        Description = description;
                    }
                    else
                        throw new ArgumentException("The provided title must have at least 5 characters.");
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            else
                throw new ArgumentNullException("The provided value for title cannot be null!");
        }

        protected AbstractActivity(string title)
            : this(title, string.Empty)
        {
        }
    }
}
