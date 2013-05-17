using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class DidacticTask : AbstractTask
    {
        public DidacticTask(Course course, string description, DateTime startDate, uint duration, ClassType type, ClassRoom classRoom, FinancialResource estimatedBudget, Member teacher, Formation formation)
            : base(GetCourseName(course), description, startDate, startDate.AddHours(duration), "didactic", classRoom, estimatedBudget, teacher)
        {
            if (formation != null)
                if (duration > 0)
                {
                    ClassType = type;
                    Course = course;
                    Formation = formation;
                }
                else
                    throw new ArgumentException("The duration of the course cannot be 0 (zero)!");
            else
                throw new ArgumentNullException("The provided value for formation cannot be null!");
        }

        public Formation Formation { get; private set; }

        public Course Course { get; private set; }

        public ClassType ClassType { get; private set; }

        private static string GetCourseName(Course course)
        {
            if (course != null)
                return course.Name;
            else
                throw new ArgumentNullException("The provided value for course cannot be null!");
        }

        private static string GetDidacticTaskType()
        {
            if (TaskType.Exists("didactic"))
                return "didactic";
            else
                throw new ArgumentException("There is no \"didactic\" task type registered! Please register this type before creating didactic tasks.");
        }
    }
}
