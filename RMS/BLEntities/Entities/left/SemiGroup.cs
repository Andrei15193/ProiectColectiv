//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ResourceManagementSystem.BusinessLogic.Entities
//{
//    public class SemiGroup : Group
//    {
//        public bool isFirstSemigroup
//        {
//            get { return isFirstSemigroup; }
//            set { isFirstSemigroup = value; }
//        }

//        public SemiGroup()
//            : base()
//        {
//            this.isFirstSemigroup = true;
//        }

//        public SemiGroup(FormationType type, Specialization specialization, uint year, CourseSet courses)
//            : base(type, specialization, year, courses)
//        {
//            this.isFirstSemigroup = true;
//        }

//        public SemiGroup(FormationType type, Specialization specialization, uint year, CourseSet courses, uint group)
//            : base(type, specialization, year, courses, group)
//        {
//            this.isFirstSemigroup = true;
//        }

//        public SemiGroup(FormationType type, Specialization specialization, uint year, CourseSet courses, uint group,
//            bool isFirstSemigroup)
//            : base(type, specialization, year, courses, group)
//        {
//            this.isFirstSemigroup = isFirstSemigroup;
//        }
//    }
//}
