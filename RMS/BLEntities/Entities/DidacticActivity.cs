using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class DidacticActivity : Task
    {
        public uint semester
        {
            get { return semester; }
            set { semester = value; }
        }

        public StudyProgram studyProgram
        {
            get { return studyProgram; }
            set { studyProgram = value; }
        }

        public UnemptySortedSet<DidacticTask> classes
        {
            get { return classes; }
            set { classes = value; }
        }

        public DidacticActivity(PerformersSet performers, UnemptySet<LogisticalResource> logisticalResources,
            FinancialResource estimatedBudget, UnemptySortedSet<DidacticTask> classes, Course course)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.semester = 0;
            this.studyProgram =new StudyProgram(course);
            this.classes = classes;
        }

        public DidacticActivity(DateTime startDate, DateTime endDate, string description, PerformersSet performers,
            UnemptySet<LogisticalResource> logisticalResources, FinancialResource estimatedBudget,
           UnemptySortedSet<DidacticTask> classes, Course course)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.semester = 0;
            this.studyProgram = new StudyProgram(course);
            this.classes = classes;
        }

        public DidacticActivity(PerformersSet performers, UnemptySet<LogisticalResource> logisticalResources,
            FinancialResource estimatedBudget, uint semester, StudyProgram studyProgram, UnemptySortedSet<DidacticTask> classes)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.semester = semester;
            this.studyProgram = studyProgram;
            this.classes = classes;
        }

        public DidacticActivity(DateTime startDate, DateTime endDate, string description, PerformersSet performers,
            UnemptySet<LogisticalResource> logisticalResources, FinancialResource estimatedBudget, uint semester,
            StudyProgram studyProgram, UnemptySortedSet<DidacticTask> classes)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.semester = semester;
            this.studyProgram = studyProgram;
            this.classes = classes;
        }
    }
}
