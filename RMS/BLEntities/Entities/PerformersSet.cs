using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class PerformersSet : UnemptySet<Member>
    {
        public PerformersSet(Member m):base(m)
        {
        }
    }
}
