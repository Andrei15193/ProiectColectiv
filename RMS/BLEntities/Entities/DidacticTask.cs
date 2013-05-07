using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class DidacticTask : Task
    {
        public ClassType type
        {
            get { return type; }
            set { type = value; }
        }

        public Course course
        {
            get { return course; }
            set { course = value; }
        }

        public DidacticActivity activity
        {
            get { return activity; }
            set { activity = value; }
        }

        public DidacticTask(MemberSetUnempty performers, LogisticalResourceSetUnempty logisticalResources,
            FinancialResource estimatedBudget, DidacticTaskSetUnempty classes)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.type = ClassType.Course;
            this.course = new Course();
            this.activity = new DidacticActivity(performers, logisticalResources, estimatedBudget, classes);
        }

        public DidacticTask(DateTime startDate, DateTime endDate, string description, MemberSetUnempty performers,
            LogisticalResourceSetUnempty logisticalResources, FinancialResource estimatedBudget,
            DidacticTaskSetUnempty classes)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.type = ClassType.Course;
            this.course = new Course();
            this.activity = new DidacticActivity(performers, logisticalResources, estimatedBudget, classes);
        }

        public DidacticTask(MemberSetUnempty performers, LogisticalResourceSetUnempty logisticalResources,
            FinancialResource estimatedBudget, ClassType type, Course course, DidacticActivity activity)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.type = type;
            this.course = course;
            this.activity = activity;
        }

        public DidacticTask(DateTime startDate, DateTime endDate, string description, MemberSetUnempty performers,
            LogisticalResourceSetUnempty logisticalResources, FinancialResource estimatedBudget, ClassType type,
            Course course, DidacticActivity activity)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.type = type;
            this.course = course;
            this.activity = activity;
        }
    }
}
