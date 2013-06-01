using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class AdministrativeEventViewModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }

        public IEnumerable<string> SelectedTeamEmails { get; set; }
        public AdministrativeEvent administrativeEvent { get; private set; }

        private ICollection<AdministrativeActivity> activities;
        private IAllAdministrativeEvents allEvents;
        private IAllMembers allMembers;


        public AdministrativeEventViewModel(IAllMembers allMembers, IAllAdministrativeEvents allEvents)
        {
            this.allEvents = allEvents;
            this.allMembers = allMembers;
            activities = new List<AdministrativeActivity>();
            this.allMembers = allMembers;
        }

        public IEnumerable<AdministrativeEvent> TryGetAllAdministrativeEvents(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                return allEvents.AsEnumerable;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return null;
            }

        }

        public IEnumerable<Member> TryGetAllMembers(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                return allMembers.AsEnumerable;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return null;
            }

        }

        public bool TryCreateAdministrativeEvent(out string errorMessage)
        {
            try
            {
                administrativeEvent = new AdministrativeEvent(
                    title,
                    description,
                    Convert.ToDateTime(startDate),
                    Convert.ToDateTime(endDate),
                    activities
                );
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return false;
            }
        }

        public bool TrySaveResearchProject(out string errorMessage)
        {
            try
            {
                allEvents.Add(administrativeEvent);
                errorMessage = null;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return false;
            }
        }

        public void AddAdministrativeActivity(string title, string description, DateTime startDate, DateTime endDate,
            ICollection<NamedTeam> teams)
        {
            AdministrativeActivity activity = new AdministrativeActivity
                (title, description, startDate, endDate);
            activity.Teams = teams;
            activities.Add(activity);
        }
    }
}
