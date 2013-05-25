using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class AdministrativeTask : AbstractTask
    {
        public AdministrativeTask(string title, string description, DateTime startDate, DateTime endDate, ClassRoom location, FinancialResource estimatedBudget, IEnumerable<Member> assignees) :
            base(title, description, startDate, endDate, "administrative", location, estimatedBudget, assignees)
        { }
    }
}
