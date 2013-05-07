using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class StudyProgram
    {
        public Specialization specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public CourseSetUnempty courses
        {
            get { return courses; }
            set { courses = value; }
        }

        public StudyProgram(Course course)
        {
            this.specialization = Specialization.ComputerScience;
            this.courses = new CourseSetUnempty(course);
        }

        public StudyProgram(CourseSetUnempty courses)
        {
            this.specialization = Specialization.ComputerScience;
            this.courses = courses;
        }

        public StudyProgram(Specialization specialization, Course course)
        {
            this.specialization = specialization;
            this.courses = new CourseSetUnempty(course);
        }

        public StudyProgram(Specialization specialization, CourseSetUnempty courses)
        {
            this.specialization = specialization;
            this.courses = courses;
        }
    }
}
