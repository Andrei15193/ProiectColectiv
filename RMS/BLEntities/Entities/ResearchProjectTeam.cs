using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
   public class ResearchProjectTeam:UnemptySet<Member>
    {
       public ResearchProjectTeam(Member m)
           : base(m)
       {
       }
    }
}
