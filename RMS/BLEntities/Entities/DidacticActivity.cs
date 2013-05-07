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

        public DidacticTaskSetUnempty classes
        {
            get { return classes; }
            set { classes = value; }
        }

        public DidacticActivity(MemberSetUnempty performers, LogisticalResourceSetUnempty logisticalResources,
            FinancialResource estimatedBudget, DidacticTaskSetUnempty classes)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.semester = 0;
            this.studyProgram = new StudyProgram();
            this.classes = classes;
        }

        public DidacticActivity(DateTime startDate, DateTime endDate, string description, MemberSetUnempty performers,
            LogisticalResourceSetUnempty logisticalResources, FinancialResource estimatedBudget, 
            DidacticTaskSetUnempty classes)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.semester = 0;
            this.studyProgram = new StudyProgram();
            this.classes = classes;
        }

        public DidacticActivity(MemberSetUnempty performers, LogisticalResourceSetUnempty logisticalResources,
            FinancialResource estimatedBudget, uint semester, StudyProgram studyProgram, DidacticTaskSetUnempty classes)
            : base(performers, logisticalResources, estimatedBudget)
        {
            this.semester = semester;
            this.studyProgram = studyProgram;
            this.classes = classes;
        }

        public DidacticActivity(DateTime startDate, DateTime endDate, string description, MemberSetUnempty performers,
            LogisticalResourceSetUnempty logisticalResources, FinancialResource estimatedBudget, uint semester, 
            StudyProgram studyProgram, DidacticTaskSetUnempty classes)
            : base(startDate, endDate, description, performers, logisticalResources, estimatedBudget)
        {
            this.semester = semester;
            this.studyProgram = studyProgram;
            this.classes = classes;
        }
    }
}
