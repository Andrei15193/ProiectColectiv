using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    class SuperUser : Member
    {
        private SuperUserRole dedicatedRole;
        public SuperUser(SuperUserRole r)
        {
            this.dedicatedRole = r;
        }
        
    }
}
