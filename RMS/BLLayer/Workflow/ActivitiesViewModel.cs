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

        /*
        public List<AbstractActivity> GetMemberActivity()
        {
            Member m = new Teacher(TeachingPosition.Professor , "Bioan Florian", "biona@cs.ubbcluj.ro", "boian", "struneleNebunele");
            DidacticActivity da1 = new DidacticActivity(CourseType.Course ,"SO", "Sisteme de operare an 1", "an 1", DateTime.Now, DateTime.Now.AddDays(5), m);
            List<Member> assignees = new List<Member>();
            assignees.Add(m);
            Team team = new Team(assignees);
 
            FinancialResource fr = new FinancialResource(100, Currency.RON);
            FinancialResource fr1 = new FinancialResource(200, Currency.RON);
            FinancialResource fr2 = new FinancialResource(300, Currency.RON);
            ResearchProject rp = new ResearchProject("Research project title", "description", DateTime.Now, DateTime.Now.AddDays(3), team, 1);
            ResearchPhase phase = new ResearchPhase(rp, "faza1", "blabla", DateTime.Now, DateTime.Now.AddDays(2));
            ResearchActivity ra = new ResearchActivity(phase, "ResearchActivity 1", "descriere", DateTime.Now, DateTime.Now.AddDays(1), assignees, fr, fr1, fr2, true);

            List<AbstractActivity> gigi = new List<AbstractActivity>();
            gigi.Add(da1);
            gigi.Add(ra);
            return gigi;
        }
        */

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

        private IAllActivities allActivities;
        private AbstractActivity activity;

        private int id;
        private ActivityType type;
        private State state;
        private string title;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        
    }
}
