using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class Guest : User
    {
        
        private Role dedicatedRole;
        public Guest(Role r)
        {
            this.dedicatedRole = r;
        }
       
    }
}
