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

        public AbstractBreakdownActivity BreakdownActivity { get; private set; }

        private ISet<Task> tasks;
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ResourceManagementSystem.BusinessLogic.Entities
//{
//    public class Activity
//    {
//        public static class Facotry
//        {
//            public Activity BuildMeeting(string title, string description, DateTime startDate, DateTime endDate, FinancialResource mobolityCost, FinancialResource laborCost, FinancialResource logisticalCost, IEnumerable<ClassRoom> classRooms, IEnumerable<Equipment> equipments, IEnumerable<Member> assignees)
//            {
//                return new Activity(ActivityType.Meeting, title, description, startDate, endDate, mobolityCost, laborCost, logisticalCost, classRooms, equipments, assignees);
//            }

//            public Activity BuildMeeting(string title, string description, DateTime startDate, DateTime endDate, FinancialResource mobolityCost, FinancialResource laborCost, FinancialResource logisticalCost, IEnumerable<ClassRoom> classRooms, IEnumerable<Equipment> equipments, IEnumerable<Member> assignees)
//            {
//                return new Activity(ActivityType.Meeting, title, description, startDate, endDate, mobolityCost, laborCost, logisticalCost, classRooms, equipments, assignees);
//            }
//        }

//        public string Title { get; private set; }

//        public string Description { get; private set; }

//        public DateTime StartDate { get; private set; }

//        public DateTime EndDate { get; private set; }

//        public FinancialResource MobolityCost { get; private set; }

//        public FinancialResource LaborCost { get; private set; }

//        public FinancialResource LogisticalCost { get; private set; }

//        public IEnumerable<ClassRoom> ClassRooms { get; private set; }

//        public IEnumerable<Equipment> Equipments { get; private set; }

//        public IEnumerable<Member> Assignees { get; private set; }

//        public ActivityType Type { get; private set; }

//        protected Activity(ActivityType type, string title, string description, DateTime startDate, DateTime endDate, FinancialResource mobolityCost, FinancialResource laborCost, FinancialResource logisticalCost, IEnumerable<ClassRoom> classRooms, IEnumerable<Equipment> equipments, IEnumerable<Member> assignees)
//        {
//            if (title != null)
//                if (description != null)
//                    if (mobolityCost != null)
//                        if (laborCost != null)
//                            if (logisticalCost != null)
//                                if (classRooms != null)
//                                    if (equipments != null)
//                                        if (assignees != null)
//                                            if (title.Length > 0)
//                                                if (startDate < endDate)
//                                                    if (assignees.Count() > 0)
//                                                    {
//                                                        Title = title;
//                                                        Description = description;
//                                                        StartDate = startDate;
//                                                        EndDate = endDate;
//                                                        MobolityCost = mobolityCost;
//                                                        LaborCost = laborCost;
//                                                        LogisticalCost = logisticalCost;
//                                                        Type = type;
//                                                        ClassRooms = new HashSet<ClassRoom>(classRooms, new Collections.EqualityComparer<ClassRoom>((x, y) => x.Name == y.Name, (x) => x.Name.GetHashCode()));
//                                                        Equipments = new HashSet<Equipment>(equipments, new Collections.EqualityComparer<Equipment>((x, y) => x.SerialNumber == y.SerialNumber, (x) => x.SerialNumber.GetHashCode()));
//                                                        Assignees = new HashSet<Member>(assignees, new Collections.EqualityComparer<Member>((x, y) => x.EMail == y.EMail, (x) => x.EMail.GetHashCode()));
//                                                    }
//                                                    else
//                                                        throw new ArgumentException("The must be at least one assignee!");
//                                                else
//                                                    throw new ArgumentException("The end date cannot be before that start date!");
//                                            else
//                                                throw new ArgumentException("The title must be at least one character lenght!");
//                                        else
//                                            throw new ArgumentNullException("The provided value for assignees cannot be null!");
//                                    else
//                                        throw new ArgumentNullException("The provided value for equipments cannot be null!");
//                                else
//                                    throw new ArgumentNullException("The provided value for class rooms cannot be null!");
//                            else
//                                throw new ArgumentNullException("The provided value for logistical cost cannot be null");
//                        else
//                            throw new ArgumentNullException("The provided value for labor cost cannot be null!");
//                    else
//                        throw new ArgumentNullException("The provided value for mobility cost canot be null!");
//                else
//                    throw new ArgumentNullException("The provided value for description cannot be null!");
//            else
//                throw new ArgumentNullException("The provided value for title cannot be null!");
//        }
//    }
//}
