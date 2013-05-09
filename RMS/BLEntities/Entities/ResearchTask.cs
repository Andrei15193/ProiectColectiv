using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class ResearchTask : Task
    {
        public SortedSet<ReportEntry> taskReport
        {
            get { return taskReport; }
            set { taskReport = value; }
        }

        public DateTime endDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public ResearchTask(PerformersSet performers, UnemptySet<LogisticalResource> logisticalResources,
            FinancialResource estimatedBudget)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.taskReport = new SortedSet<ReportEntry>();
            this.endDate = new DateTime();
        }

        public ResearchTask(DateTime startDate, DateTime endDate, string description, PerformersSet performers,
            UnemptySet<LogisticalResource> logisticalResources, FinancialResource estimatedBudget)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.taskReport = new SortedSet<ReportEntry>();
            this.endDate = new DateTime();
        }

        public ResearchTask(PerformersSet performers, UnemptySet<LogisticalResource> logisticalResources,
            FinancialResource estimatedBudget, SortedSet<ReportEntry> taskReport, DateTime endDate)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.taskReport = taskReport;
            this.endDate = endDate;
        }

        public ResearchTask(DateTime startDate, DateTime endDate, string description, PerformersSet performers,
            UnemptySet<LogisticalResource> logisticalResources, FinancialResource estimatedBudget, SortedSet<ReportEntry> taskReport, 
            DateTime endDateReport)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.taskReport = taskReport;
            this.endDate = endDateReport;
        }
        public SortedSet<ReportEntry> getReports()
        {
            return taskReport;
        }
    }
}
