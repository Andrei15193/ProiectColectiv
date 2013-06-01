using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public AdministrativeActivity administrativeActivity { get; private set; }

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

        public bool TryCreateAdministrativeActivity(out string errorMessage)
        {
            try
            {
                administrativeActivity = new AdministrativeActivity(
                    title,
                    description,
                    DateTime.ParseExact(
                        startDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddDays(1).AddMilliseconds(-1),
                    DateTime.ParseExact(
                        endDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddDays(1).AddMilliseconds(-1)
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

        public bool TrySaveAdministrativeActivity(out string errorMessage)
        {
            try
            {
                //allEvents.Add(administrativeActivity);
                errorMessage = null;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return false;
            }
        }

        public void AddAdministrativeActivity(string title, string description, DateTime startDate, DateTime endDate)
        {
            //AdministrativeActivity activity = new AdministrativeActivity
            //    (title, description, startDate, endDate);
            //activity.team = new Team(allMembers.AsEnumerable.Where(
            //            (localMember) => SelectedTeamEmails.Contains(allMembers.AsEnumerable.EMail)
            //        ));
            //activities.Add(activity);
        }
    }
}
