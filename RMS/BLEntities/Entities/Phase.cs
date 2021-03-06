﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class ResearchPhase : AbstractActivity, IEnumerable<ResearchActivity>
    {
        public ResearchPhase(ResearchProject reserachProject, string title, string description, DateTime startDate, DateTime endDate, int id)
            : base(ActivityType.Research_Phase, title, description, startDate, endDate, id)
        {
            if (reserachProject != null)
                if (reserachProject.StartDate <= startDate && endDate <= reserachProject.EndDate)
                {
                    ResearchProject = reserachProject;
                    researchActivities = new SortedSet<ResearchActivity>(new Collections.Comparer<ResearchActivity>((x, y) => x.StartDate.CompareTo(y.StartDate)));
                }
                else
                    throw new ArgumentException("A phase cannot exceed the research project start date or end date!");
            else
                throw new ArgumentNullException("The provided value for research project cannot be null!");
        }

        public ResearchPhase(ResearchProject reserachProject, string title, string description, DateTime startDate, DateTime endDate)
            : this(reserachProject, title, description, startDate, endDate, 0)
        {
        }

        public ResearchActivity Add(string title, string description, DateTime startDate, DateTime endDate, IEnumerable<Member> assignees, FinancialResource mobilityCost, FinancialResource laborCost, FinancialResource logisticalCost, bool isConfidential)
        {
            ResearchActivity addedResearchActivity = new ResearchActivity(this, title, description, startDate, endDate, assignees, mobilityCost, laborCost, logisticalCost, isConfidential);
            if (researchActivities.Add(addedResearchActivity))
                return addedResearchActivity;
            else
                return null;
        }

        public bool Contains(string researchActivityTitle)
        {
            return (researchActivities.Count((activity) => activity.Title == researchActivityTitle) == 1);
        }

        public ResearchActivity Delete(string researchActivityTitle)
        {
            ResearchActivity removedActivity = null;
            IEnumerable<ResearchActivity> researchActivitiesToRemove = researchActivities.Where((activity) => activity.Title == researchActivityTitle);
            if (researchActivitiesToRemove.Count() == 1)
            {
                removedActivity = researchActivitiesToRemove.First();
                researchActivities.Remove(removedActivity);
            }
            return removedActivity;
        }

        public IEnumerator<ResearchActivity> GetEnumerator()
        {
            return researchActivities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return researchActivities.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return researchActivities.Count;
            }
        }

        public bool HasActivities
        {
            get
            {
                return researchActivities.Count > 0;
            }
        }

        public override State State
        {
            get
            {
                return base.State;
            }
            set
            {
                if (researchActivities != null)
                    foreach (ResearchActivity activity in researchActivities)
                        activity.State = value;
                base.State = value;
            }
        }

        public ResearchProject ResearchProject { get; private set; }

        public ISet<ResearchActivity> researchActivities;
    }
}
