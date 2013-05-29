using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class StudentCircle : AbstractBreakdownActivity
    {
        public StudentCircle(string title, string description, DateTime startDate, DateTime endDate, StudyProgram studyProgram)
            : base(ActivityType.Student_Circle, title, description, startDate, endDate)
        {
            if (studyProgram != null)
                StudyProgram = studyProgram;
            else
                throw new ArgumentNullException("The provided value for study program cannot be null!");
        }

        public StudyProgram StudyProgram { get; private set; }
    }
}
