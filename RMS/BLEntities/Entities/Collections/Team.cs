using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    public class Team : IEnumerable<Member>
    {
        public Team(IEnumerable<Member> members)
        {
            if (members != null)
                if (!members.Contains(null))
                    if (members.Count() > 0)
                        this.members = new HashSet<Member>(members, new EqualityComparer<Member>((x, y) => x.EMail == y.EMail, (x) => x.EMail.GetHashCode()));
                    else
                        throw new ArgumentException("A team cannot be empty! Please provide at least one member!");
                else
                    throw new ArgumentException("The provided member collection cannot contain null values!");
            else
                throw new ArgumentNullException("The provided value for member cannot be null!");
        }

        public bool Add(Member member)
        {
            if (member != null)
                if (!members.Contains(member))
                {
                    members.Add(member);
                    return true;
                }
                else
                    return false;
            else
                throw new ArgumentNullException("The provided value for member cannot be null!");
        }

        public bool Contains(Member member)
        {
            if (member != null)
                return members.Contains(member);
            else
                throw new ArgumentNullException("The provided value for member cannot be null!");
        }

        public bool Remove(Member member)
        {
            if (member != null)
                if (members.Count > 1)
                    return members.Remove(member);
                else
                    return false;
            else
                throw new ArgumentNullException("The provided value for member cannot be null!");
        }

        public int Count
        {
            get
            {
                return members.Count;
            }
        }

        public IEnumerator<Member> GetEnumerator()
        {
            return members.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return members.GetEnumerator();
        }

        private ICollection<Member> members;
        private int idTeam;
    }
}
