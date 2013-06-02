using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;

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
        public void aproveActivity(AbstractActivity a, bool aproved)
        {
            switch(a.Type)
            {
                case ActivityType.Research_Project:
                    {
                        allActivities.aproveActivity(a, aproved);
                        ResearchProject project=a as ResearchProject;
                        foreach(ResearchPhase phase  in project.AsEnumerable())
                        {
                            allActivities.aproveActivity(phase, aproved);
                            foreach (ResearchActivity activ in phase.AsEnumerable())
                            {
                                allActivities.aproveActivity(activ, aproved);
                            }
                        }
                    }
                    break;
                case ActivityType.Research_Phase:
                    {
                        ResearchPhase phase=a as ResearchPhase;
                        allActivities.aproveActivity(a, aproved);
                            allActivities.aproveActivity(phase, aproved);
                            foreach (ResearchActivity activ in phase.AsEnumerable())
                            {
                                allActivities.aproveActivity(activ, aproved);
                            }
                        
                    }
                    break;
                    
                default:
                    allActivities.aproveActivity(a, aproved); 
                    break;
        }
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
                foreach (AbstractActivity a in allActivities.AsEnumerable)
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
        ResearchProject selectedResearchProject = null;

        private IAllActivities allActivities;
        private AbstractActivity activity;
        private int id { get; set; }
        private ActivityType type { get; set; }
        private State state { get; set; }
        private string title { get; set; }
        private string description { get; set; }
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }
        public int mobilityCost { get; set; }
        public int logisticalCost { get; set; }
        public int laborCost { get; set; }
        public int mobilityCostSelectedIndex { get; set; }
        public int laborCostSelectedIndex { get; set; }
        public int logisticalCostSelectedIndex { get; set; }
        private readonly string[] currency = Enum.GetNames(typeof(Currency)).Select((currency) => currency.Replace('_', ' ')).ToArray();
        public bool isConfidential { get; set; }


        public List<AbstractActivity> GetMemberResearchProjects(Member member, out string error)
        {
            List<AbstractActivity> activities = GetMemberActivity(member, out error);
            List<AbstractActivity> researchProjects = null;
            selectedMember = member;
            foreach (AbstractActivity activity in activities)
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
                startDate,
                endDate,
                selectedResearchProject.Team,
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
