using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class ResearchProjectTasks : ICollection<ITask>
    {
        public ResearchProjectTasks(ResearchProject researchProject, IEnumerable<string> allowedTaskTypes, IEnumerable<ITask> tasks)
        {
            if (researchProject != null)
                if (allowedTaskTypes != null)
                    if (tasks != null)
                    {
                        AllowedTaskTypes = TaskType.WithNames(allowedTaskTypes);
                        ResearchProject = researchProject;
                        this.tasks = new SortedSet<ITask>(new Comparer<ITask>((x, y) => x.StartDate.CompareTo(y.StartDate)));
                        foreach (ITask task in tasks)
                            if (task != null)
                                Add(task);
                            else
                                throw new ArgumentException("The provided task collection cannot contain null values!");
                    }
                    else
                        throw new ArgumentNullException("The provided value for task collection cannot be null!");
                else
                    throw new ArgumentNullException("The provided value for allowed task type collection cannot be null!");
            else
                throw new ArgumentNullException("The provided value for research project cannot be null!");
        }

        public ResearchProjectTasks(ResearchProject researchProject, IEnumerable<string> allowedTaskTypes)
            : this(researchProject, allowedTaskTypes, new ITask[0] as IEnumerable<ITask>)
        {
        }

        public ResearchProjectTasks(ResearchProject researchProject, IEnumerable<string> allowedTaskTypes, params ITask[] tasks)
            : this(researchProject, allowedTaskTypes, tasks as IEnumerable<ITask>)
        {
        }

        public void Add(ITask task)
        {
            if (task != null)
                if (AllowedTaskTypes.Contains(task.Type))
                    if (task.Assignees.Except(ResearchProject.Participants).Count() == 0)
                    {
                        if (tasks.Add(task))
                            task.Assignees.CollectionChanged += ValidateNewAssignee;
                    }
                    else
                        throw new ArgumentException("The provided task has assignees that are not part of the research project team!");
                else
                    throw new ArgumentException("The provided task type is not allowed!");
            else
                throw new ArgumentNullException("The provided value for task cannot be null!");

        }

        public void Clear()
        {
            foreach (ITask task in tasks)
                task.Assignees.CollectionChanged -= ValidateNewAssignee;
            tasks.Clear();
        }

        public bool Contains(ITask task)
        {
            return tasks.Contains(task);
        }

        public void CopyTo(ITask[] array, int arrayIndex)
        {
            tasks.CopyTo(array, arrayIndex);
        }

        public bool Remove(ITask task)
        {
            if (task != null)
                if (tasks.Remove(task))
                {
                    task.Assignees.CollectionChanged -= ValidateNewAssignee;
                    return true;
                }
                else
                    return false;
            else
                throw new ArgumentNullException("The provided value for task cannot be null!");
        }

        public IEnumerator<ITask> GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        public int Count
        {
            get
            {
                return tasks.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public IEnumerable<TaskType> AllowedTaskTypes { get; private set; }

        public ResearchProject ResearchProject { get; private set; }

        protected virtual IEnumerator<ITask> ProtectedGetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        private void ValidateNewAssignee(object sender, CollectionChangedEventArgs<Member> e)
        {
            if (e.ChangeState == CollectionChange.Add && !ResearchProject.Participants.Contains(e.Item))
                throw new ArgumentException("The new assignee is not in the research projects team! The assignee cannot be added!");
        }

        private ISet<ITask> tasks;
    }
}
