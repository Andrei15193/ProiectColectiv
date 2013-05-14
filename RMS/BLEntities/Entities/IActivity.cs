using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public interface IActivity
    {
        string Title { get; }

        string Description { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }

        ICollection<ITask> Tasks { get; }

        IEnumerable<Member> Participants { get; }

        IEnumerable<ClassRoom> Locations { get; }

        IEnumerable<Equipment> Equipments { get; }

        FinancialResource EstimatedBudget { get; }

        FinancialResource RealizedBudget { get; }

        bool IsActive { get; }
    }
}
