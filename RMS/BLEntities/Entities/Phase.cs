using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Phase : Activity
    {
        public Phase(string title, string description, ResearchProject researchProject, IEnumerable<string> allowedTaskTypes, IEnumerable<ITask> tasks)
            : base(title, description)
        {
            if (researchProject != null)
                if (allowedTaskTypes != null)
                    if (tasks != null)
                    {
                        ResearchProject = researchProject;
                        researchProject.Phases.Add(this);
                        Tasks = new Collections.PhaseTasks(this, tasks, allowedTaskTypes);
                    }
                    else
                        throw new ArgumentNullException("The provided value for task collection cannot be null!");
                else
                    throw new ArgumentNullException("The provided value for allowed task type collection cannot be null!");
            else
                throw new ArgumentNullException("The provided value for research project cannot be null!");
        }

        public Phase(string title, ResearchProject researchProject, IEnumerable<string> allowedTaskTypes, IEnumerable<ITask> tasks)
            : this(title, string.Empty, researchProject, allowedTaskTypes, tasks)
        {
        }

        public Phase(string title, ResearchProject researchProject, IEnumerable<string> allowedTaskTypes, params ITask[] tasks)
            : this(title, string.Empty, researchProject, allowedTaskTypes, tasks)
        {
        }

        public Phase(string title, string description, ResearchProject researchProject, IEnumerable<string> allowedTaskTypes, params ITask[] tasks)
            : this(title, description, researchProject, allowedTaskTypes, tasks as IEnumerable<ITask>)
        {
        }

        public ResearchProject ResearchProject { get; private set; }
    }
}
