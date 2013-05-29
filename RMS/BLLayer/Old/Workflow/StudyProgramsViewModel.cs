//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ResourceManagementSystem.BusinessLogic.Entities;
//using ResourceManagementSystem.DataAccess.DAOInterface;

//namespace ResourceManagementSystem.BusinessLogic.Workflow
//{
//    public class StudyProgramsViewModel
//    {
//        public Specialization specialization;
//        private ICollection<Course> allCourses;
//        private ICollection<Course> studyProgramCourses;
//        private IStudyPrograms studyPrograms;
//        private ISpecializations specializations;
//        private ICourses courses;

//        public StudyProgramsViewModel(ISpecializations specializations, ICourses courses, IStudyPrograms studyPrograms)
//        {
//            this.specializations = specializations;
//            this.courses = courses;
//            this.studyPrograms = studyPrograms;
//            this.studyProgramCourses = new List<Course>();
//            this.allCourses = new List<Course>();
//        }

//        public ICollection<string> GetAllCourses()
//        {
//            ICollection<string> courseNamesList = new List<string>();
//            ICollection<Course> courseList = courses.GetAllCourses();
//            allCourses.Clear();

//            foreach (Course c in courseList)
//            {
//                allCourses.Add(c);
//                courseNamesList.Add(c.Name);
//            }
//            return courseNamesList;
//        }

//        public ICollection<string> GetSpecializationList()
//        {
//            ICollection<string> specializationList = new List<string>();
//            ICollection<Specialization> spec = specializations.GetAllSpecializations();
//            foreach (Specialization s in spec)
//            {
//                specializationList.Add(s.ToString());
//            }
//            return specializationList;
//        }

//        public bool SetSpecialization(string name)
//        {
//            ICollection<Specialization> spec = specializations.GetAllSpecializations();
//            foreach (Specialization s in spec)
//            {
//                if (string.Compare(s.ToString(), name, true) == 0)
//                {
//                    specialization = s;
//                    return true;
//                }
//            }
//            return false;
//        }

//        public bool AddCourse(string name)
//        {
//            foreach(Course c  in allCourses)
//            {
//                if (string.Compare(c.Name, name, true)==0)
//                {
//                    studyProgramCourses.Add(c);
//                    return true;
//                }
//            }
//            return false;
//        }

//        public bool RemoveCourse(string name)
//        {
//            foreach (Course c in allCourses)
//            {
//                if (string.Compare(c.Name, name, true) == 0)
//                {
//                    studyProgramCourses.Remove(c);
//                    return true;
//                }
//            }
//            return false;
//        }

//        public bool submit()
//        {
//            StudyProgram studyProgram = new StudyProgram(specialization, studyProgramCourses);
//            return studyPrograms.AddStudyProgram(studyProgram);
//        }
//    }
//}
