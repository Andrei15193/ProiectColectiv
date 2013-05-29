//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ResourceManagementSystem.BusinessLogic.Entities;
//using ResourceManagementSystem.DataAccess.DAOInterface;

//namespace ResourceManagementSystem.BusinessLogic.Workflow
//{
//    public class StudentCirclesViewModel : Feature
//    {
//        IActivities activityDAO;
        
//        public StudentCirclesViewModel(IActivities activityDAO)
//            : base("Defines student circles")
//        {
//            this.activityDAO = activityDAO;
//        }

//        public bool AddActivity(string title, string description, IEnumerable<string> allowedTaskTypes, IEnumerable<ITask> tasks)
//        {
//            Activity activity = new Activity(title, description, allowedTaskTypes, tasks);
//            return activityDAO.addActivity(activity);
//        }
//    }
//}
