//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ResourceManagementSystem.BusinessLogic.Entities
//{
//    public class Formation
//    {
//        public FormationType type
//        {
//            get { return type; }
//            set { type = value; }
//        }

//        public Specialization specialization
//        {
//            get { return specialization; }
//            set { specialization = value; }
//        }

//        public uint year
//        {
//            get { return year; }
//            set { year = value; }
//        }

//        public CourseSet courses
//        {
//            get { return courses; }
//            set { courses = value; }
//        }

//        public Formation()
//        {
//            this.type = FormationType.Group;
//            this.specialization = Specialization.ComputerScience;
//            this.year = 0;
//            this.courses = new CourseSet();
//        }

//        public Formation(FormationType type, Specialization specialization, uint year, CourseSet courses)
//        {
//            this.type = type;
//            this.specialization = specialization;
//            this.year = year;
//            this.courses = courses;
//        }
//    }
//}
