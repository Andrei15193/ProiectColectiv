using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class PhaseTasks : ICollection<ITask>, IObservableCollection<ITask>
    {
        public PhaseTasks(Phase phase, IEnumerable<ITask> tasks, IEnumerable<string> allowedTaskTypes)
        {
            if (phase != null)
                if (tasks != null)
                {
                    AllowedTaskTypes = TaskType.WithNames(allowedTaskTypes);
                    Phase = phase;
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
                throw new ArgumentNullException("The provided value for phase cannot be null!");
        }

        public void Add(ITask task)
        {
            if (task != null)
                if (AllowedTaskTypes.Contains(task.Type))
                    if (task.Assignees.Except(Phase.ResearchProject.Participants).Count() == 0)
                    {
                        if (tasks.Add(task))
                            task.Assignees.CollectionChanging += ValidateNewAssignee;
                    }
                    else
                        throw new ArgumentException("The given task has assignees that are not in the research projects team!");
                else
                    throw new ArgumentException("The provided task type is not allowed in the current phase!");
            else
                throw new ArgumentNullException("The provided value for task cannot be null!");
        }

        public void Clear()
        {
            foreach (ITask task in tasks)
                task.Assignees.CollectionChanging -= ValidateNewAssignee;
            tasks.Clear();
        }

        public bool Contains(ITask task)
        {
            if (task != null)
                return tasks.Contains(task);
            else
                throw new ArgumentNullException("The provided value for task cannot be null!");
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
                    task.Assignees.CollectionChanging -= ValidateNewAssignee;
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

        public Phase Phase { get; private set; }

        public IEnumerable<TaskType> AllowedTaskTypes { get; private set; }

        public event EventHandler<CollectionChangedEventArgs<ITask>> CollectionChanging;

        protected void ProtectedOnCollectionChanging(object sender, CollectionChangedEventArgs<ITask> e)
        {
            if (CollectionChanging != null)
                CollectionChanging(sender, e);
        }

        protected virtual IEnumerator<ITask> ProtectedGetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        private void ValidateNewAssignee(object sender, CollectionChangedEventArgs<Member> e)
        {
            if (e.ChangeState == CollectionChange.Add && !Phase.ResearchProject.Participants.Contains(e.Item))
                throw new ArgumentException("The new assignee is not in the research projects team! The assignee cannot be added!");
        }

        private ISet<ITask> tasks;
    }
}
