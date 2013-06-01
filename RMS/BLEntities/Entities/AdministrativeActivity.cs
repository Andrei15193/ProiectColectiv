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

        }


        public Team team { get; set; }
    }
}
