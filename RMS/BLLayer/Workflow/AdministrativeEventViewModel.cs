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

        private IAllAdministrativeActivities allActivities;
        private IAllMembers allMembers;


        public AdministrativeEventViewModel(IAllMembers allMembers, IAllAdministrativeActivities allActivities)
        {
            this.allActivities = allActivities;
            this.allMembers = allMembers;
        }

        public IEnumerable<AdministrativeActivity> TryGetAllAdministrativeActivities(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                return allActivities.AsEnumerable;
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
                allActivities.Add(administrativeActivity);
                errorMessage = null;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return false;
            }
        }

        public bool addTeam(IEnumerable<string> SelectedTeamEmails, String teamName, out string errorMessage)
        {
            NamedTeam team = null;
            try
            {
                team = new NamedTeam(teamName, allMembers.AsEnumerable.Where(
                            (localMember) => SelectedTeamEmails.Contains(localMember.EMail)
                        ));
                administrativeActivity.Teams.Add(team);
                errorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool addTaskBreakdownActivity(string title, string description, string startDate, string endDate,
            out TaskBreakdownActivity taskBreakdownActivity, out string errorMessage)
        {
            taskBreakdownActivity = null;
            try
            {
                taskBreakdownActivity = new TaskBreakdownActivity(administrativeActivity,
                    title, description,
                    DateTime.ParseExact(
                        startDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddDays(1).AddMilliseconds(-1),
                    DateTime.ParseExact(
                        endDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddDays(1).AddMilliseconds(-1));
                administrativeActivity.BreakdownActvities.Add(taskBreakdownActivity);

                errorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public bool 
            insertTaskIntoTaskBreakdownActivity(TaskBreakdownActivity taskBreakdownActivity, 
            string title, string description, string startDate, string endDate, IEnumerable<string> emailList, 
            int mobilityCostValue, Currency mobilityCostCurrency, int laborCostValue, Currency laborCostCurrency,
            int logisticalCostValue, Currency logisticalCostCurrency, out string errorMessage)
        {
            try
            {
                ResourceManagementSystem.BusinessLogic.Entities.Task task
                    = new ResourceManagementSystem.BusinessLogic.Entities.Task(TaskType.Administrative, title, description,
                    DateTime.ParseExact(
                        startDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddDays(1).AddMilliseconds(-1),
                    DateTime.ParseExact(
                        endDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddDays(1).AddMilliseconds(-1),
                    allMembers.AsEnumerable.Where(
                            (localMember) => SelectedTeamEmails.Contains(localMember.EMail)), 
                    new FinancialResource(mobilityCostValue, mobilityCostCurrency), 
                    new FinancialResource(laborCostValue, laborCostCurrency), 
                    new FinancialResource(logisticalCostValue, logisticalCostCurrency));
                errorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
