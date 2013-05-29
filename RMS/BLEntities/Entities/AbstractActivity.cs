using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class DidacticActivity : AbstractAssignableActivity, ILogisticalResourceConsumer
    {
        public DidacticActivity(CourseType courseType, string courseName, string description, string formation, DateTime startDate, DateTime endDate, Member assignee)
            : base(ActivityType.Didactic, string.Format("{0} {1}", courseName, courseType.ToString().ToLower()), description, startDate, endDate, new Member[] { assignee })
        {
            if (courseName != null)
                if (formation != null)
                {
                    CourseName = courseName;
                    Formation = formation;
                    ClassRooms = new SortedSet<ClassRoom>(new Collections.Comparer<ClassRoom>((x, y) => x.Name.CompareTo(y.Name)));
                    Equipments = new SortedSet<Equipment>(new Collections.Comparer<Equipment>((x, y) => x.Model.CompareTo(y.Model)));
                }
                else
                    throw new ArgumentNullException("The provided value for formation cannot be null!");
            else
                throw new ArgumentNullException("The provided value for course name cannot be null!");
        }

        public CourseType CourseType { get; private set; }

        public string CourseName { get; private set; }

        public string Formation { get; private set; }

        public ICollection<ClassRoom> ClassRooms { get; private set; }

        public ICollection<Equipment> Equipments { get; private set; }
    }
}
