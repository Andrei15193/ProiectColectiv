using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    class MeetingTask : AbstractTask
    {
        public MeetingTask(string title, string description, DateTime startDate, DateTime endDate, ClassRoom location, FinancialResource estimatedBudget, IEnumerable<Member> assignees)
            : base(title, description, startDate, endDate, "meeting", location, estimatedBudget, assignees)
        {
        }
    }
}
