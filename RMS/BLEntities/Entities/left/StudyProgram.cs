//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ResourceManagementSystem.BusinessLogic.Entities
//{
//    public class StudyProgram
//    {
//        public Specialization specialization
//        {
//            get { return specialization; }
//            set { specialization = value; }
//        }

//        public UnemptySortedSet<Course> courses
//        {
//            get { return courses; }
//            set { courses = value; }
//        }

//        public StudyProgram(Course course)
//        {
//            this.specialization = Specialization.ComputerScience;
//            this.courses = new UnemptySortedSet<Course>(course);
//        }

//        public StudyProgram(UnemptySortedSet<Course> courses)
//        {
//            this.specialization = Specialization.ComputerScience;
//            this.courses = courses;
//        }

//        public StudyProgram(Specialization specialization, Course course)
//        {
//            this.specialization = specialization;
//            this.courses = new UnemptySortedSet<Course>(course);
//        }

//        public StudyProgram(Specialization specialization, UnemptySortedSet<Course>    courses)
//        {
//            this.specialization = specialization;
//            this.courses = courses;
//        }
//    }
//}
