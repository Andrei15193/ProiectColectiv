using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public interface ITask
    {
        string Title { get; }

        string Description { get; }

        TaskState State { get; set; }

        TaskType Type { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }

        Collections.IObservableCollection<Member> Assignees { get; }

        ClassRoom Location { get; set; }

        ICollection<Equipment> Equipments { get; }

        FinancialResource EstimatedBudget { get; }

        FinancialResource RealizedBudget { get; set; }
    }
}
