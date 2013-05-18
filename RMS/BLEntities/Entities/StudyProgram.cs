using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class StudyProgram
    {
        public Specialization Specialization { get; private set; }

        public ICollection<Course> Courses { get; private set; }

        public StudyProgram(Specialization specialization, IEnumerable<Course> courses)
        {
            if (courses != null)
            {
                Specialization = specialization;
                Courses = new Collections.UnemptySortedSet<Course>(new Collections.Comparer<Course>((x, y) => x.Credits.CompareTo(y.Credits)), courses);
            }
            else
                throw new ArgumentNullException("The provided value for the courses collection cannot be null!");
        }

        public StudyProgram(Specialization specialization, Course course)
            : this(specialization, new Course[] { course } as IEnumerable<Course>)
        {
            if (course == null)
                throw new ArgumentNullException("The provided value for course cannot be null!");
        }

        public StudyProgram(Specialization specialization, params Course[] courses)
            : this(specialization, courses as IEnumerable<Course>)
        {
            if (courses.Count((innerCourse) => innerCourse == null) != 0)
                throw new ArgumentNullException("None of the provided courses can be null!");
        }
    }
}
