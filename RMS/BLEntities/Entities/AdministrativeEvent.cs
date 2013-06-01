using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class AdministrativeEvent
    {
        public DateTime startDate {get;set;}
        public DateTime endDate { get; set; }
        public ICollection<AdministrativeActivity> activities;

        public AdministrativeEvent()
        {
            startDate = DateTime.Today;
            endDate = DateTime.Today;
            activities = new List<AdministrativeActivity>();
        }
    }
}
