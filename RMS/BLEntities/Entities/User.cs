using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class User
    {
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (value != null)
                    if (Regex.IsMatch(value, @"[\p{Lu}\p{Ll}0-9\p{P}]+"))
                        userName = value.Trim();
                    else
                        throw new ArgumentException("The provided value is not a valid username!");
                else
                    throw new ArgumentNullException("The provided value for username cannot be null!");
            }
        }

        public ICollection<Role> Roles { get; private set; }

        protected User(string userName, Role role)
        {
            if (!role.Equals(null))
            {
                UserName = userName;
                Roles = new Collections.UnemptySet<Role>(role);
            }
            else
                throw new ArgumentNullException("The provided role cannot be null!");
        }

        protected User(string userName, IEnumerable<Role> roles)
        {
            if (roles != null)
                if (roles.Count() > 0)
                {
                    UserName = userName;
                    Roles = new Collections.UnemptySet<Role>(roles);
                }
                else
                    throw new ArgumentException("The provided role collection cannot be empty! The must be at least one role!");
            else
                throw new ArgumentNullException("The provided value for roles cannot be null!");
        }

        private string userName;
    }
}
