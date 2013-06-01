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
        private DateTime startDate;  
        private DateTime endDate;

        private ICollection<AdministrativeActivity> activities;
        private IAllAdministrativeEvents allEvents;

        public AdministrativeEventViewModel(IAllAdministrativeEvents allEvents)
        {
            this.allEvents = allEvents;
            activities = new List<AdministrativeActivity>();
            this.startDate = Convert.ToDateTime(startDate);
            this.endDate = Convert.ToDateTime(endDate);
        }

        public void addTeam(IEnumerable<Member> members)
        {
            Team team = new Team(members);
            //teams.Add(team);
        }

        public void addAdministrativeActivity(string title, string description, DateTime startDate, DateTime endDate)
        {
            AdministrativeActivity administrativeActivity = new AdministrativeActivity(title,
                description, startDate, endDate);
            activities.Add(administrativeActivity);
        }

        public void addTask(TaskType type, string title, string description, DateTime startDate, DateTime endDate, IEnumerable<Member> assignees, FinancialResource mobilityCost, FinancialResource laborCost, FinancialResource logisticalCost, int id)
        {
            ResourceManagementSystem.BusinessLogic.Entities.Task task = new ResourceManagementSystem.BusinessLogic.Entities.Task(type, title, description, startDate, endDate, assignees, mobilityCost,
                laborCost, logisticalCost);
            //tasks.Add(task);
        }

        public IEnumerable<Member> TryGetAllTeams(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                localAllMembers = allMembers.AsEnumerable;
                return localAllMembers;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return null;
            }

        }

        //public bool TryCreateAd(out string errorMessage)
        //{
        //    try
        //    {
        //        ResearchProject = new ResearchProject(
        //            Title,
        //            Description,
        //            DateTime.ParseExact(
        //                StartDate,
        //                "dd/MM/yyyy",
        //                CultureInfo.InvariantCulture),
        //            DateTime.ParseExact(
        //                EndDate,
        //                "dd/MM/yyyy",
        //                CultureInfo.InvariantCulture),
        //            new Team(
        //                localAllMembers.Where(
        //                    (localMember) => SelectedTeamEmails.Contains(localMember.EMail))
        //            )
        //        );
        //        errorMessage = string.Empty;
        //        return true;
        //    }
        //    catch (Exception exception)
        //    {
        //        errorMessage = exception.Message;
        //        return false;
        //    }
        //}
    }
}
