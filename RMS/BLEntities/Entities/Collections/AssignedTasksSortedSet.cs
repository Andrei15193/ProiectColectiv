using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class AssignedTasksSortedSet : ICollection<ITask>
    {
        public AssignedTasksSortedSet(Member assignee, IEnumerable<ITask> attendingTasks)
        {
            if (assignee != null)
                if (attendingTasks != null)
                {
                    Assignee = assignee;
                    tasks = new SortedSet<ITask>(new Comparer<ITask>((x, y) => x.StartDate.CompareTo(y.StartDate)));
                    foreach (ITask task in attendingTasks)
                        Add(task);
                }
                else
                    throw new ArgumentNullException("The provided value for attending tasks collection cannot be null!");
            else
                throw new ArgumentNullException("The provided value for member cannot be null!");
        }

        public AssignedTasksSortedSet(Member assignee)
            : this(assignee, new ITask[0] as IEnumerable<ITask>)
        {
        }

        public AssignedTasksSortedSet(Member assignee, params ITask[] attendingTasks)
            : this(assignee, attendingTasks as IEnumerable<ITask>)
        {
        }

        public void Add(ITask task)
        {
            if (task != null)
            {
                if (!Contains(task))
                {
                    Add(task);
                    task.Assignees.Add(Assignee);
                }
            }
            else
                throw new ArgumentNullException("The provided task cannot be null!");
        }

        public void Clear()
        {
            int taskCount = tasks.Count;
            while (taskCount > 0)
            {
                ITask task = tasks.First();
                task.Assignees.Remove(Assignee);
                if (taskCount == tasks.Count)
                    Remove(task);
                taskCount--;
            }
        }

        public bool Remove(ITask task)
        {
            if (task != null)
                if (tasks.Remove(task))
                {
                    task.Assignees.Remove(Assignee);
                    return true;
                }
                else
                    return false;
            else
                throw new ArgumentNullException("The provided value for task cannot be null!");
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

        public IEnumerator<ITask> GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        public Member Assignee { get; private set; }

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

        protected virtual IEnumerator<ITask> ProtectedGetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        private ISet<ITask> tasks;
    }
}
