using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class AdministrativeEvent
    {
        public string title { get; set; }
        public DateTime startDate {get;set;}
        public DateTime endDate { get; set; }
        public ICollection<AdministrativeActivity> activities;

        public AdministrativeEvent(string title, DateTime startDate, DateTime endDate)
        {
            this.title = title;
            this.startDate = startDate;
            this.endDate = endDate;
            activities = new List<AdministrativeActivity>();
        }

        public AdministrativeEvent(string title, DateTime startDate, DateTime endDate, ICollection<AdministrativeActivity> activities)
        {
            this.title = title;
            this.startDate = startDate;
            this.endDate = endDate;
            this.activities = activities;
        }
    }
}
