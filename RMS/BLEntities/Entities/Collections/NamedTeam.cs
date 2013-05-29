using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    public class NamedTeam : Team
    {
        public NamedTeam(string name, IEnumerable<Member> members)
            : base(members)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                    if (value.Length > 0)
                        name = value;
                    else
                        throw new ArgumentException("The provided name must contain at least 1 character!");
                else
                    throw new ArgumentNullException("The provided value for name cannot be null!");
            }
        }

        private string name;
    }
}
