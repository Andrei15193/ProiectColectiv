using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class TaskViewModel
    {
        IActivity activity;
        ITasks taskDAO;

        public TaskState state;
        public TaskType taskType;
        public Course course { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public uint duration { get; set; }
        public ClassType classType { get; set; }
        public ClassRoom classRoom { get; set; }
        public FinancialResource estimatedBudget { get; set; }
        public Member member { get; set; }
        public Formation formation { get; set; }
        
        public TaskViewModel(IActivity activity, ITasks taskDAO)
        {
            this.activity = activity;
            this.taskDAO = taskDAO;
        }

        public void AddTask()
        {
            switch(taskType.Name) 
            {
                case "Didactic": 
                    { 
                        DidacticTask dt = new DidacticTask(course, description, startDate, duration, classType, classRoom, estimatedBudget, member, formation); 
                        activity.Tasks.Add(dt);
                        taskDAO.addTask(dt);
                        break; 
                    }
                case "Research": 
                    { 
                        ResearchTask rt = new ResearchTask(title, startDate, endDate, classRoom, estimatedBudget, member); 
                        activity.Tasks.Add(rt);
                        taskDAO.addTask(rt);
                        break; 
                    }  
            }
        }

        public void UpdateTask()
        {
            ((AbstractTask)(activity.Tasks.Where((task) => task.StartDate == startDate && task.Location == classRoom)).First()).State = state;
        }
       
    }
}
