using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class AssigneeUnemptySet : UnemptySet<Member>
    {
        public AssigneeUnemptySet(ITask task, IEnumerable<Member> assignees)
            : base(assignees)
        {
            if (task != null)
            {
                Task = task;
                foreach (Member assignee in assignees)
                    if (assignee != null)
                        Add(assignee);
                    else
                        throw new ArgumentNullException("The given value for assignee cannot be null!");
            }
            else
                throw new ArgumentNullException("The given value for task cannot be null!");
        }

        public AssigneeUnemptySet(ITask task, Member assignee)
            : this(task, new Member[] { assignee } as IEnumerable<Member>)
        {
        }

        public AssigneeUnemptySet(ITask task, params Member[] assignees)
            : this(task, assignees as IEnumerable<Member>)
        {
        }

        public override void Add(Member assignee)
        {
            if (assignee != null)
            {
                if (!Contains(assignee))
                {
                    base.Add(assignee);
                    assignee.Tasks.Add(Task);
                }
            }
            else
                throw new ArgumentNullException("The provided value for assignee cannot be null!");
        }

        public override bool Remove(Member assignee)
        {
            if (assignee != null)
            {
                if (base.Remove(assignee))
                {
                    assignee.Tasks.Remove(Task);
                    return true;
                }
                else
                    return false;
            }
            else
                throw new ArgumentNullException("The provided value for assignee cannot be null!");
        }

        public new System.Collections.IEnumerator GetEnumerator()
        {
            return base.GetEnumerator();
        }

        public ITask Task { get; private set; }
    }
}
