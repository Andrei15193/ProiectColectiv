using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class AbstractAssignableActivity : AbstractActivity, IEnumerable<Member>
    {
        public bool Add(Member assignee)
        {
            return assignees.Add(assignee);
        }

        public bool Contains(Member assignee)
        {
            return assignees.Contains(assignee);
        }

        public bool Remove(Member assignee)
        {
            if (assignees.Count > 1)
                return assignees.Remove(assignee);
            else
                return false;
        }

        public IEnumerator<Member> GetEnumerator()
        {
            return assignees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return assignees.GetEnumerator();
        }

        public int AssigneeCount
        {
            get
            {
                return assignees.Count;
            }
        }

        protected AbstractAssignableActivity(ActivityType type, string title, string description, DateTime startDate, DateTime endDate, IEnumerable<Member> assignees, int id)
            : base(type, title, description, startDate, endDate, id)
        {
            if (assignees != null)
                if (assignees.Count() > 0)
                    if (assignees.Count((assignee) => assignee == null) == 0)
                        this.assignees = new HashSet<Member>(assignees, new Collections.EqualityComparer<Member>((x, y) => x.EMail == y.EMail, (x) => x.EMail.GetHashCode()));
                    else
                        throw new ArgumentException("The provided assingnee collection cannot contain null values!");
                else
                    throw new ArgumentException("There must be at least one assignee for this activity!");
            else
                throw new ArgumentNullException("The provided value for assignee collection cannot be null!");
        }

        protected AbstractAssignableActivity(ActivityType type, string title, string description, DateTime startDate, DateTime endDate, IEnumerable<Member> assignees)
            : this(type, title, description, startDate, endDate, assignees, 0)
        {
        }

        private ISet<Member> assignees;
    }
}
