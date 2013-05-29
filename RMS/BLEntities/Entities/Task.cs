using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Task : IDateTimeBound, ILogisticalResourceConsumer, IEnumerable<Member>
    {
        public Task(TaskType type, string title, string description, DateTime startDate, DateTime endDate, IEnumerable<Member> assignees, FinancialResource mobilityCost, FinancialResource laborCost, FinancialResource logisticalCost)
        {
            if (title != null)
                if (description != null)
                    if (assignees != null)
                        if (mobilityCost != null)
                            if (laborCost != null)
                                if (logisticalCost != null)
                                    if (assignees.Count() > 0)
                                        if (assignees.Count((assignee) => assignee == null) > 0)
                                            if (title.Length > 0)
                                                if (startDate < endDate)
                                                {
                                                    State = State.Proposed;
                                                    Type = type;
                                                    Title = title;
                                                    Description = description;
                                                    StartDate = startDate;
                                                    EndDate = endDate;
                                                    MobilityCost = mobilityCost;
                                                    LaborCost = laborCost;
                                                    LogisticalCost = logisticalCost;
                                                    ClassRooms = new SortedSet<ClassRoom>(new Collections.Comparer<ClassRoom>((x, y) => x.Name.CompareTo(y.Name)));
                                                    Equipments = new SortedSet<Equipment>(new Collections.Comparer<Equipment>((x, y) => x.Model.CompareTo(y.Model)));
                                                    this.assignees = new HashSet<Member>(assignees, new Collections.EqualityComparer<Member>((x, y) => x.EMail == y.EMail, (x) => x.EMail.GetHashCode()));
                                                }
                                                else
                                                    throw new ArgumentException("The end date cannot be before the start date!");
                                            else
                                                throw new ArgumentException("The title must be at least one character long!");
                                        else
                                            throw new ArgumentException("The provided assingnee collection cannot contain null values!");
                                    else
                                        throw new ArgumentException("There must be at least one assignee for this activity!");
                                else
                                    throw new ArgumentNullException("The provided value for logistical cost cannot be null!");
                            else
                                throw new ArgumentNullException("The provided value for laborcost cannot be null!");
                        else
                            throw new ArgumentNullException("The provided value for mobility cost cannot be null!");
                            else
                                throw new ArgumentNullException("The provided value for assignee collection cannot be null!");
                        else
                            throw new ArgumentNullException("The provided value for description cannot be null!");
                    else
                        throw new ArgumentNullException("The provided value for title cannot be null!");
        }

        public bool Add(Member assignee)
        {
            return assignees.Add(assignee);
        }

        public bool Contains(Member assignee)
        {
            return assignees.Contains(assignee);
        }

        public bool Remove(Member assignee)
        {
            if (assignees.Count > 1)
                return assignees.Remove(assignee);
            else
                return false;
        }

        public IEnumerator<Member> GetEnumerator()
        {
            return assignees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return assignees.GetEnumerator();
        }

        public int AssigneeCount
        {
            get
            {
                return assignees.Count;
            }
        }

        public State State { get; set; }

        public TaskType Type { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public FinancialResource MobilityCost { get; private set; }

        public FinancialResource LaborCost { get; private set; }

        public FinancialResource LogisticalCost { get; private set; }

        public ICollection<ClassRoom> ClassRooms { get; private set; }

        public ICollection<Equipment> Equipments { get; private set; }

        private ISet<Member> assignees;
    }
}
