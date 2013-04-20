using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    class User
    {
        private string userName;
        private RoleSet roles;

        public User()
        {
            this.userName = "";
            this.roles = new RoleSet();
        }

        public User(string userName)
        {
            this.userName = userName;
            this.roles = new RoleSet();
        }

        public User(string userName, RoleSet roles)
        {
            this.userName = userName;
            this.roles = roles;
        }

        public string getUserName()
        {
            return userName;
        }

        public RoleSet getRoles()
        {
            return roles;
        }
    }
}
