using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class StudentCirclesViewModel : Feature
    {
        IStudentCircles activityDAO;
        
        public StudentCirclesViewModel(IStudentCircles activityDAO)
            : base("Defines student circles")
        {
            this.activityDAO = activityDAO;
        }

        public bool AddActivity(string title, string description, IEnumerable<string> allowedTaskTypes, IEnumerable<ITask> tasks)
        {
            Activity activity = new Activity(title, description, allowedTaskTypes, tasks);
            return activityDAO.addActivity(activity);
        }

        public bool AddTask(string title, ITask task)
        {
            Activity activity = activityDAO.getActivity(title);
            activity.Tasks.Add(task);
            return activityDAO.addTask(title, task);
        }
    }
}
