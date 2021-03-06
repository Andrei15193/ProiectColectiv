﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class ResearchProject : AbstractActivity, IEnumerable<ResearchPhase>
    {
        public ResearchProject(string title, string description, DateTime startDate, DateTime endDate, Collections.Team team, int id)
            : base(ActivityType.Research_Project, title, description, startDate, endDate, id)
        {
            if (team != null)
            {
                Team = team;
                phases = new SortedSet<ResearchPhase>(new Collections.Comparer<ResearchPhase>((x, y) => x.StartDate.CompareTo(y.StartDate)));
            }
            else
                throw new ArgumentNullException("The provided value for team collection cannot be null!");
        }

        public ResearchProject(string title, string description, DateTime startDate, DateTime endDate, Collections.Team team)
            : this(title, description, startDate, endDate, team, 0)
        {
        }

        public ResearchPhase Add(string title, string description, DateTime startDate, DateTime endDate)
        {
            ResearchPhase newPhase = new ResearchPhase(this, title, description, startDate, endDate);
            if (phases.Add(newPhase))
                return newPhase;
            else
                return null;
        }

        public bool Contains(string phaseTitle)
        {
            return (phases.Count((phase) => phase.Title == phaseTitle) == 1);
        }

        public ResearchPhase Remove(string phaseTitle)
        {
            ResearchPhase removedPhase = null;
            IEnumerable<ResearchPhase> phasesToRemove = phases.Where((phase) => phase.Title == phaseTitle);
            if (phasesToRemove.Count() == 1)
            {
                removedPhase = phasesToRemove.First();
                phases.Remove(removedPhase);
            }
            return removedPhase;
        }

        public IEnumerator<ResearchPhase> GetEnumerator()
        {
            return phases.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return phases.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return phases.Count;
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
                if (phases != null)
                    foreach (ResearchPhase phase in phases)
                        phase.State = value;
                base.State = value;
            }
        }

        public Collections.Team Team { get; private set; }

        public ISet<ResearchPhase> phases;
    }
}
