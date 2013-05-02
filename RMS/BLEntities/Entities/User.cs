using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    class User
    {
        private string userName;
        private RoleSetUnempty roles;

        public User() { }

        public User(RoleSetUnempty roles)
        {
            this.userName = "";
            this.roles = roles;
            
        }

       

         public User(Role r)
        {
            this.userName = "";
            this.roles = new RoleSetUnempty(r);
            
        }
        public User(string userName,Role r)
        {
            this.userName = userName;
            this.roles = new RoleSetUnempty(r);
            
        }
        public User(string userName, RoleSetUnempty roles)
        {
            this.userName = userName;
            this.roles = roles;
        }
        public string getUserName()
        {
            return userName;
        }
        public RoleSetUnempty getRoles()
        {
            return roles;
        }
    }

}