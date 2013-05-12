using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class AbstractTask : ITask
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public TaskType Type { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public ICollection<Member> Assignees { get; private set; }

        public ClassRoom Location
        {
            get
            {
                return location;
            }
            set
            {
                if (value != null && value != location)
                {
                    location = value;
                    location.Task = this;
                }
            }
        }

        public ICollection<Equipment> Equipments { get; private set; }

        public FinancialResource EstimatedBudget { get; private set; }

        public FinancialResource RealizedBudget { get; set; }

        public TaskState State
        {
            get
            {
                return state;
            }
            set
            {
                if (value == TaskState.Finished && RealizedBudget == null)
                    throw new ArgumentException("Cannot finish a task without setting a realized budget!");
                else
                    state = value;
            }
        }

        protected AbstractTask(string title, string description, DateTime startDate, DateTime endDate, string typeName, ClassRoom location, FinancialResource estimatedBudget, IEnumerable<Member> assignees)
        {
            TaskType type;
            string trimmedTitle = title.Trim();
            string trimmedDescription = description.Trim();
            Validate(trimmedTitle, trimmedDescription, startDate, endDate, location, estimatedBudget, assignees);
            if (TaskType.TryWithName(typeName, out type))
                Type = type;
            else
                throw new ArgumentException("The provided task type name is not currently registered in the TaskType collection!");
            Title = trimmedTitle;
            Description = trimmedDescription;
            StartDate = startDate;
            EndDate = endDate;
            this.location = location;
            EstimatedBudget = estimatedBudget;
            Equipments = new Collections.TaskEquipmentSet(this);
            RealizedBudget = null;
            State = TaskState.Request;
            Assignees = new Collections.AssigneeUnemptySet(this, assignees);
        }

        protected AbstractTask(string title, string description, DateTime startDate, DateTime endDate, string typeName, ClassRoom location, FinancialResource estimatedBudget, Member assignee)
            : this(title, description, startDate, endDate, typeName, location, estimatedBudget, new Member[] { assignee } as IEnumerable<Member>)
        {
        }

        protected AbstractTask(string title, string description, DateTime startDate, DateTime endDate, string typeName, ClassRoom location, FinancialResource estimatedBudget, params Member[] assignees)
            : this(title, description, startDate, endDate, typeName, location, estimatedBudget, assignees as IEnumerable<Member>)
        {
        }

        private TaskState state;
        private ClassRoom location;

        private static void Validate(string title, string description, DateTime startDate, DateTime endDate, ClassRoom location, FinancialResource estimatedBudget, IEnumerable<Member> assignees)
        {
            if (title == null)
                throw new ArgumentNullException("The provided value for title cannot be null!");
            if (title.Length > 6)
                throw new ArgumentNullException("The provided value for title must have at least 6 characters!");
            if (description == null)
                throw new ArgumentNullException("The provided value for description cannot be null!");
            if (startDate.CompareTo(endDate) >= 0)
                throw new ArgumentException("The start date must be before the end date!");
            if (location == null)
                throw new ArgumentNullException("The provided value for location cannot be null!");
            if (estimatedBudget == null)
                throw new ArgumentNullException("The provided value for estimated budget cannot be null!");
            if (assignees == null)
                throw new ArgumentNullException("The provided value for assignees cannot be null!");
            if (assignees.Count() < 1)
                throw new ArgumentNullException("The must be at least one assignee to the task!");
        }
    }
}
