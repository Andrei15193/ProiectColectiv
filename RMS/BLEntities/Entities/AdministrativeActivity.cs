using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class AdministrativeActivity : AbstractBreakdownActivity
    {
        public AdministrativeActivity(string title, string description, DateTime startDate, DateTime endDate)
            :base(ActivityType.Administrative, title, description, startDate, endDate)
        {
            Teams = new SortedSet<Collections.NamedTeam>(new Collections.Comparer<Collections.NamedTeam>((x, y) => x.Name.CompareTo(y.Name)));
        }


        public ICollection<Collections.NamedTeam> Teams { get; set; }
    }
}
