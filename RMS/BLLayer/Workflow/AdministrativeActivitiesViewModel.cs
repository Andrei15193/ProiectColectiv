using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.Workflow
{
    public class AdministrativeActivitiesViewModel
    {
        private DateTime startDate;  
        private DateTime endDate;
        private IAllTeams allTeams;
        private IAllActivities allActivities;
        private ICollection<AdministrativeActivity> activities;
        private ICollection<Team> teams;
        private ICollection<ResourceManagementSystem.BusinessLogic.Entities.Task> tasks;

        public AdministrativeActivitiesViewModel(IAllTeams allTeams, IAllActivities allActivities)
        {
            this.allTeams = allTeams;
            this.allActivities = allActivities;
        }

        public void addTeam(int id)
        {
            //this.teams.Add
        }
    }
}
