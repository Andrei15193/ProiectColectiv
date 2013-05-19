using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class ResearchTask : AbstractTask
    {
        public ResearchTask(string title, string description, DateTime startDate, DateTime endDate, ClassRoom location, FinancialResource estimatedBudget, Member assignee)
            : base(title, description, startDate, endDate, "research", location, estimatedBudget, assignee)
        {
        }

        public ResearchTask(string title, DateTime startDate, DateTime endDate, ClassRoom location, FinancialResource estimatedBudget, Member assignee)
            : base(title, string.Empty, startDate, endDate, "research", location, estimatedBudget, assignee)
        {
        }
    }
}
