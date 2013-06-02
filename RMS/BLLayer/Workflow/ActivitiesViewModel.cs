
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using System.Globalization;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class ActivitiesViewModel
    {
        public ActivitiesViewModel(IAllActivities allActivities)
        {
            this.allActivities = allActivities;
            activity = null;
        }

        

        public List<AbstractActivity> GetMemberActivity(Member member, out string error)
        {
            IEnumerable<AbstractActivity> activities = TryGetAll(out error);
            List<AbstractActivity> memberActivities = null;
            DidacticActivity didacticActivity;
            ResearchActivity reasearchActivity;

            foreach (AbstractActivity activity in activities)
            {
                if (activity is DidacticActivity)
                {
                    didacticActivity = (DidacticActivity)activity;
                    if (didacticActivity.Contains(member))
                        memberActivities.Add(didacticActivity);
                            
                }

                if (activity is ResearchActivity)
                {
                    reasearchActivity = (ResearchActivity)activity;
                    if (reasearchActivity.Contains(member))
                        memberActivities.Add(reasearchActivity);
                }
            }

            return memberActivities;
        }
        public void aproveActivity(AbstractActivity a,bool aproved)
        {
            allActivities.aproveActivity(a,aproved);
        }

        public IEnumerable<AbstractActivity> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                return allActivities.AsEnumerable;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }
        public IEnumerable<AbstractActivity> getAllPending(out string errorMessage)
        {
            ICollection<AbstractActivity> toRet = new HashSet<AbstractActivity>();
            try
            {
                errorMessage = null;
                foreach(AbstractActivity a in allActivities.AsEnumerable)
                {
                    if (a.State == State.Proposed)
                    {
                        toRet.Add(a);
                    }
                }
                return toRet;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }

        Member selectedMember = null;
        public ResearchProject selectedResearchProject = null;

        private IAllActivities allActivities;
        private AbstractActivity activity;
        public int id { get; set; }
        public ActivityType type { get; set; }
        public State state { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int mobilityCost { get; set; }
        public int logisticalCost { get; set; }
        public int laborCost { get; set; }
        public int mobilityCostSelectedIndex { get; set; }
        public int laborCostSelectedIndex { get; set; }
        public int logisticalCostSelectedIndex { get; set; }
        public readonly string[] currency = Enum.GetNames(typeof(Currency)).Select((currency) => currency.Replace('_', ' ')).ToArray();
        public bool isConfidential { get; set; }
        public IEnumerable<string> selectedTeamEmails { get; set; }


        public List<ResearchProject> GetMemberResearchProjects(Member member, out string error)
        {
        List<AbstractActivity> activities = GetMemberActivity(member, out error);
        List<ResearchProject> researchProjects = null;
        selectedMember = member;
        foreach (ResearchProject activity in activities)
        {
        if (activity is ResearchProject)
        {
        ResearchProject researchProject = (ResearchProject)activity;
        researchProjects.Add(researchProject);
        }
        }
        return researchProjects;
        }


        public IEnumerator<ResearchPhase> GetPhasesForResearchProject(ResearchProject researchProject)
        {
        selectedResearchProject = researchProject;
        return researchProject.GetEnumerator();
        }


        public bool TryCreateActivity(ResearchPhase researchPhase, out string error)
        {
        try
        {
        ResearchActivity researchActivity = new ResearchActivity(
        researchPhase,
        title,
        description,
       DateTime.ParseExact(
                        startDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddMilliseconds(selectedResearchProject.Count + researchPhase.Count),
                    DateTime.ParseExact(
                        endDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture
                    ).AddMilliseconds(selectedResearchProject.Count + researchPhase.Count + 1),
        selectedResearchProject.Team.Where((teamMember) => selectedTeamEmails.Contains(teamMember.EMail)),
        new FinancialResource(mobilityCost, (Currency)mobilityCostSelectedIndex),
        new FinancialResource(laborCost, (Currency)laborCostSelectedIndex),
        new FinancialResource(logisticalCost, (Currency)logisticalCostSelectedIndex),
        isConfidential
        );
        researchActivity.State = State.Proposed;
        //add the activity
        error = null;
        return true;
        }
        catch (Exception exception)
        {
        error = exception.Message;
        return false;
        }
        }
        
            }
}