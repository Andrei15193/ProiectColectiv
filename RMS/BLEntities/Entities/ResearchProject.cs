using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class ResearchProject : IActivity
    {
        public ResearchProject(string title, string description, DateTime startDate, DateTime endDate, IEnumerable<Member> participants, FinancialResource estimatedBudget, IEnumerable<string> allowedTaskTypes)
        {
            if (title != null)
                if (description != null)
                    if (participants != null)
                        if (estimatedBudget != null)
                            if (allowedTaskTypes != null)
                                if (title.Length > 4)
                                    if (startDate <= endDate)
                                    {
                                        Title = title;
                                        Description = description;
                                        StartDate = startDate;
                                        EndDate = endDate;
                                        Tasks = new Collections.ResearchProjectTasks(this, allowedTaskTypes);
                                        Participants = new HashSet<Member>(participants);
                                        Phases = new Collections.ResearchProjectPhaseCollection(this);
                                        EstimatedBudget = estimatedBudget;
                                    }
                                    else
                                        throw new ArgumentException("The provided start date cannot be after the specified end date!");
                                else
                                    throw new ArgumentException("The provided title must be at least 5 characters long.");
                            else
                                throw new ArgumentNullException("The provided value for allowed task type collection cannot be null!");
                        else
                            throw new ArgumentNullException("The provided value for estimated budget cannot be null!");
                    else
                        throw new ArgumentNullException("The provided value for team collection cannot be null!");
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            else
                throw new ArgumentNullException("The provided value for title cannot be null!");
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public ApplicationState State { get; set; }

        public ICollection<ITask> Tasks { get; private set; }

        public IEnumerable<Member> Participants { get; private set; }

        public ICollection<Phase> Phases { get; private set; }

        public FinancialResource EstimatedBudget { get; private set; }

        public IEnumerable<ClassRoom> Locations
        {
            get
            {
                return Phases.SelectMany((phase) => phase.Tasks.Select((task) => task.Location)).Union(Tasks.Select((task) => task.Location));
            }
        }

        public IEnumerable<Equipment> Equipments
        {
            get
            {
                return Phases.SelectMany((phase) => phase.Tasks.SelectMany((task) => task.Equipments)).Union(Tasks.SelectMany((task) => task.Equipments));
            }
        }

        public FinancialResource RealizedBudget
        {
            get
            {
                FinancialResource realizedTasksBudget = null;
                FinancialResource realizedPhasesBudget = null;
                if (Phases.Count > 0)
                    realizedPhasesBudget = Phases.SelectMany((phase) => phase.Tasks.Select((task) => task.RealizedBudget)).Aggregate((x, y) => x + y);
                if (Tasks.Count > 0)
                    realizedTasksBudget = Tasks.Select((task) => task.RealizedBudget).Aggregate((x, y) => x + y);
                if (realizedTasksBudget != null && EstimatedBudget != null)
                    return realizedTasksBudget + realizedPhasesBudget;
                else if (realizedTasksBudget != null)
                    return realizedTasksBudget;
                else if (realizedPhasesBudget != null)
                    return realizedPhasesBudget;
                else
                    return null;
            }
        }

        public bool IsActive
        {
            get
            {
                return State == ApplicationState.Active;
            }
        }
    }
}
