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
        public ResearchProjectViewModel(IAllMembers allMembers, IAllResearchProjects allProjects)
        {
            this.allMembers = allMembers;
            this.allProjects = allProjects;
        }

        public bool TryCreateResearchProject(out string errorMessage)
        {
            try
            {
                ResearchProject = new ResearchProject(Title, Description, DateTime.ParseExact(StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture), new Team(localAllMembers.Where((localMember)=> SelectedTeamEmails.Contains(localMember.EMail))));
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception exception)
            {
                errorMessage = exception.Message;
                return false;
            }
        }
        public IEnumerable<ResearchProject> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = string.Empty;
                localAllResearchProjects = allProjects.AsEnumerable;
                return localAllResearchProjects;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }

        public ResearchProject ResearchProject { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public IEnumerable<string> SelectedTeamEmails { get; set; }

        public IEnumerable<Member> TryGetAllMembers(out string errorMessage)
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
        private IAllResearchProjects allResearchProjects;
        private IEnumerable<ResearchProject> localAllResearchProjects;

        private IAllMembers allMembers;
        private ResearchProject researchProject;
        private IEnumerable<Member> localAllMembers;
        private IAllResearchProjects allProjects;
    }
}
