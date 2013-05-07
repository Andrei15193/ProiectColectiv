using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class ResearchTask : Task
    {
        public TaskReport report
        {
            get { return report; }
            set { report = value; }
        }

        public DateTime endDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public ResearchTask(MemberSetUnempty performers, LogisticalResourceSetUnempty logisticalResources,
            FinancialResource estimatedBudget)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.report = new TaskReport();
            this.endDate = new DateTime();
        }

        public ResearchTask(DateTime startDate, DateTime endDate, string description, MemberSetUnempty performers,
            LogisticalResourceSetUnempty logisticalResources, FinancialResource estimatedBudget)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.report = new TaskReport();
            this.endDate = new DateTime();
        }

        public ResearchTask(MemberSetUnempty performers, LogisticalResourceSetUnempty logisticalResources,
            FinancialResource estimatedBudget, TaskReport report, DateTime endDate)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.report = report;
            this.endDate = endDate;
        }

        public ResearchTask(DateTime startDate, DateTime endDate, string description, MemberSetUnempty performers,
            LogisticalResourceSetUnempty logisticalResources, FinancialResource estimatedBudget, TaskReport report, 
            DateTime endDateReport)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.report = report;
            this.endDate = endDateReport;
        }
    }
}
