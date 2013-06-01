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
    public class ResearchProjectViewModel
    {
        public ResearchProjectViewModel(IAllMembers allMembers)
        {
            this.allMembers = allMembers;
            Title = string.Empty;
            Description = string.Empty;
            StartDate = DateTime.Now.ToString("dd/MM/yyyy");
            EndDate = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");
            CurrentPhase = null;
        }

        public IEnumerable<Member> TryGetAllHumanResources(out string errorMessage)
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

        public bool TryCreateResearchProject(out string errorMessage)
        {
            try
            {
                ResearchProject = new ResearchProject(
                    Title,
                    Description,
                    DateTime.ParseExact(
                        StartDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture),
                    DateTime.ParseExact(
                        EndDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture),
                    new Team(
                        localAllMembers.Where(
                            (localMember) => SelectedTeamEmails.Contains(localMember.EMail))
                    )
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

        public bool TryCreatePhase(out string errorMessage)
        {
            try
            {
                CurrentPhase = ResearchProject.Add(
                    Title,
                    Description,
                    DateTime.ParseExact(
                        StartDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture),
                    DateTime.ParseExact(EndDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture)
                );
                errorMessage = null;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return false;
            }
        }

        public bool TryCreateActivity(out string errorMessage)
        {
            try
            {
                CurrentPhase.Add(
                    Title,
                    Description,
                    DateTime.ParseExact(
                        StartDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture),
                    DateTime.ParseExact(
                    EndDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture),
                    localAllMembers.Where(
                        (localMember) => SelectedTeamEmails.Contains(localMember.EMail)
                    ),
                    new FinancialResource(MobilityCost, (Currency)MobilityCostSelectedIndex),
                    new FinancialResource(LaborCost, (Currency)LaborCostSelectedIndex),
                    new FinancialResource(LogisticalCost, (Currency)LogisticalCostSelectedIndex),
                    IsConfidential
                );
                errorMessage = null;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return false;
            }
        }

        public ResearchProject ResearchProject { get; private set; }

        public ResearchPhase CurrentPhase { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public IEnumerable<string> SelectedTeamEmails { get; set; }

        public string[] Currency
        {
            get
            {
                return currency;
            }
        }

        public int MobilityCost { get; set; }

        public int LogisticalCost { get; set; }

        public int LaborCost { get; set; }

        public int MobilityCostSelectedIndex { get; set; }

        public int LaborCostSelectedIndex { get; set; }

        public int LogisticalCostSelectedIndex { get; set; }

        public bool IsConfidential { get; set; }

        private IAllMembers allMembers;
        private IEnumerable<Member> localAllMembers;
        private readonly string[] currency = Enum.GetNames(typeof(Currency)).Select((currency) => currency.Replace('_', ' ')).ToArray();
    }
}
