using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class StudyProgram
    {
        public StudyProgram(Specialization specialization, IEnumerable<Course> courses)
        {
            if (courses != null)
                if (courses.Count() > 0)
                    if (courses.Count((innerCourse) => innerCourse == null) == 0)
                    {
                        Specialization = specialization;
                        Courses = new Collections.UnemptySortedSet<Course>(new Collections.Comparer<Course>((x, y) => x.Credits.CompareTo(y.Credits)), courses);
                    }
                    else
                        throw new ArgumentException("None of the provided courses can be null!");
                else
                    throw new ArgumentException("There must be at least one course in the study program.");
            else
                throw new ArgumentNullException("The provided value for the courses collection cannot be null!");
        }

        public StudyProgram(Specialization specialization, params Course[] courses)
            : this(specialization, courses as IEnumerable<Course>)
        {
        }

        public Specialization Specialization { get; private set; }

        public ICollection<Course> Courses { get; private set; }
    }
}
