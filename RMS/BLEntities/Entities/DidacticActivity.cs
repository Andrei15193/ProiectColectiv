using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class DidacticActivity : Activity
    {
        public DidacticActivity(uint semester, StudyProgram studyProgram, IEnumerable<DidacticTask> didacticTasks)
            : base(string.Format("{0}, semester {1}", studyProgram.Specialization.ToString(), semester), string.Format("Courses, seminars and laboratories for semster {0}, {1} specialization", semester, studyProgram.Specialization.ToString()), new string[] { "didactic" }, didacticTasks)
        {
            if (studyProgram != null)
                if (semester > 0)
                {
                    Semester = semester;
                    StudyProgram = studyProgram;
                }
                else
                    throw new ArgumentException("The provided value for semester cannot be 0 (zero)!");
            else
                throw new ArgumentNullException("The provided value for study program cannot be null!");
        }

        public IEnumerable<DidacticTask> DidacticTasks
        {
            get
            {
                return Tasks.OfType<DidacticTask>();
            }
        }

        public uint Semester { get; private set; }

        public StudyProgram StudyProgram { get; private set; }
    }
}
