﻿using ResourceManagementSystem.BusinessLogic.Entities;
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
            if (activities != null)
            {
                List<AbstractActivity> memberActivities = new List<AbstractActivity>();
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

        public List<AbstractActivity> GetActivitiesForMember(Member member, out string error)
        {
            IEnumerable<AbstractActivity> activities = TryGetAll(out error);
            List<AbstractActivity> memberActivities = new List<AbstractActivity>();
            try
            {
                foreach (AbstractActivity activ in activities)
                {
                    if (activ is AbstractAssignableActivity)
                    {
                        AbstractAssignableActivity activity = (AbstractAssignableActivity)activ;
                        IEnumerator<Member> team = activity.GetEnumerator();
                        while (team.MoveNext())
                        {
                            if (member.EMail.Equals(team.Current.EMail))
                            {
                                memberActivities.Add(activ);
                            }
                        }
                    }
                    else if (activ is AdministrativeActivity)
                    {
                        AdministrativeActivity activity = (AdministrativeActivity)activ;
                        foreach (Member m in (Team)( activity.Teams ))
                        {
                            if (m.EMail.Equals(member.EMail))
                                memberActivities.Add(activ);
                        }
                    }
                    else if (activ is ResearchProject)
                    {
                        ResearchProject activity = (ResearchProject)activ;
                        foreach (Member m in activity.Team)
                        {
                            if (m.EMail.Equals(member.EMail))
                                memberActivities.Add(activ);
                        }
                    }
                }
                error = null;
                return memberActivities;
            }
            catch (Exception exception)
            {
                error = exception.Message;
                return null;
            }
        }

        public List<AbstractActivity> GetActivitiesByTypeAndMember(Member member, ActivityType type, out string error)
        {
            List<AbstractActivity> filteredActivities = new List<AbstractActivity>();
            List<AbstractActivity> filteredActivitiesForMember = new List<AbstractActivity>();
            try
            {
                switch (type)
                {
                    case ActivityType.Didactic:
                        filteredActivities = GetActivitiesByType(ActivityType.Didactic, out error);
                        foreach (DidacticActivity da in filteredActivities)
                        {

                            if (member.EMail.Equals(da.AsEnumerable().ElementAt(0).EMail))
                            {
                                    filteredActivitiesForMember.Add(activity);
                                }
                            
                        }
                        break;
                    case ActivityType.Administrative:
                        filteredActivities = GetActivitiesByType(ActivityType.Administrative, out error);
                        foreach (AbstractActivity activity in filteredActivities)
                        {
                            foreach (Member m in (Team)( (AdministrativeActivity)activity ).Teams)
                            {
                                if (member.EMail.Equals(m.EMail))
                                {
                                    filteredActivitiesForMember.Add(activity);
                                }
                            }
                        }
                        break;
                    case ActivityType.Research_Project:
                        filteredActivities = GetActivitiesByType(ActivityType.Research_Project, out error);
                        foreach (AbstractActivity activity in filteredActivities)
                        {
                            foreach (Member m in ( (ResearchProject)activity ).Team)
                            {
                                if (member.EMail.Equals(m.EMail))
                                {
                                    filteredActivitiesForMember.Add(activity);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }

                error = null;
                return filteredActivitiesForMember;

            }
            catch (Exception exception)
            {
                error = exception.ToString();
                return null;
            }

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

        public List<AbstractActivity> GetActivitiesByType(ActivityType type, out string error)
        {
            IEnumerable<AbstractActivity> activities = TryGetAll(out error);
            List<AbstractActivity> filteredActivities = new List<AbstractActivity>();

            if (activities == null)
                return new List<AbstractActivity>();
            try
            {
                switch (type)
                {
                    case ActivityType.Administrative:
                        foreach (AbstractActivity activity in activities)
                            if (activity is AdministrativeActivity)
                                filteredActivities.Add(activity);
                        break;
                    case ActivityType.Didactic:
                        foreach (AbstractActivity activity in activities)
                            if (activity is DidacticActivity)
                                filteredActivities.Add(activity);
                        break;
                    case ActivityType.Research_Project:
                        foreach (AbstractActivity activity in activities)
                            if (activity is ResearchProject)
                                filteredActivities.Add(activity);
                        break;
                    default:
                        break;
                }
                error = null;
                return filteredActivities;
            }
            catch (Exception exception)
            {
                error = exception.ToString();
                return new List<AbstractActivity>();
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