using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public interface ITask
    {
        string Title { get; }

        string Description { get; }

        TaskState State { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }

        ICollection<Member> Assignees { get; }

        ClassRoom Location { get; set; }

        ICollection<Equipment> Equipments { get; }

        FinancialResource EstimatedBudget { get; }

        FinancialResource RealizedBudget { get; set; }
    }
}
