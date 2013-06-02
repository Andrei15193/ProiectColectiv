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

        public IEnumerable<AbstractActivity> GetMemberActivity(Member member, out string error)
        {
            IEnumerable<AbstractActivity> activities = TryGetAll(out error);
            if (activities != null)
            {
                ICollection<AbstractActivity> memberActivities = new LinkedList<AbstractActivity>();
                foreach (AbstractActivity activity in activities)
                {
                    if (activity is DidacticActivity)
                    {
                        DidacticActivity didacticActivity = (DidacticActivity)activity;
                        IEnumerator<Member> membersDA = didacticActivity.GetEnumerator();

                        while (membersDA.MoveNext() == true)
                        {
                            if (membersDA.Current.EMail.Equals(member.EMail))
                            {
                                memberActivities.Add(didacticActivity);
                                break;
                            }
                        }
                    }

                    if (activity is ResearchActivity)
                    {
                        ResearchActivity researchActivity = (ResearchActivity)activity;
                        IEnumerator<Member> membersRA = researchActivity.GetEnumerator();

                        while (membersRA.MoveNext() == true)
                        {
                            if (membersRA.Current.EMail.Equals(member.EMail))
                            {
                                memberActivities.Add(researchActivity);
                                break;
                            }
                        }
                    }
                }
                return memberActivities;
            }
            else
                return null;
        }

        public void aproveActivity(AbstractActivity activity, bool aproved)
        {
            allActivities.aproveActivity(activity, aproved);
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
                errorMessage = exception.Message;
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

        private IAllActivities allActivities;
        private AbstractActivity activity;
        public int id { get; set; }
        public ActivityType type { get; set; }
        public State state { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}