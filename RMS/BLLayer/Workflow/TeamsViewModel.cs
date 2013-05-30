using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class TeamViewModel
    {
        public TeamViewModel(IAllMembers allMembers)
        {
            if (allMembers != null)
            {
                this.allMembers = allMembers;
                Team = null;
            }
            else
                throw new ArgumentNullException("The provided value for allMembers cannot be null!");
        }

        public void AddMembersToTeam()
        {
            if (SelectedEMails != null)
                Team = new Team(localAllMembers.Where((localMember) => SelectedEMails.Contains(localMember.EMail)));
        }

        public string NextStepLink { get; set; }

        public string TeamName { get; set; }

        public Team Team { get; private set; }

        public IEnumerable<string> SelectedEMails { get; set; }

        public IEnumerable<Member> TryGetAllMembers(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                localAllMembers = allMembers.AsEnumerable;
                return localAllMembers;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }

        private IAllMembers allMembers;
        private IEnumerable<Member> localAllMembers;
    }
}
