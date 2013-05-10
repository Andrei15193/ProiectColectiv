using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class User
    {
        private string userName;
        private UnemptySet<Role> roles;

        public User() { }

        public User(UnemptySet<Role> roles)
        {
            this.userName = "";
            this.roles = roles;
            
        }

       

         public User(Role r)
        {
            this.userName = "";
            this.roles = new UnemptySet<Role>(r);
            
        }
        public User(string userName,Role r)
        {
            this.userName = userName;
            this.roles = new UnemptySet<Role>(r);
            
        }
        public User(string userName, UnemptySet<Role> roles)
        {
            this.userName = userName;
            this.roles = roles;
        }
        public string getUserName()
        {
            return userName;
        }
        public UnemptySet<Role> getRoles()
        {
            return roles;
        }
    }

}