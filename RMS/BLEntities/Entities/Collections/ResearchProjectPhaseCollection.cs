using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities.Collections
{
    class ResearchProjectPhaseCollection : ICollection<Phase>
    {
        public ResearchProjectPhaseCollection(ResearchProject researchProject)
        {
            ResearchProject = researchProject;
            phases = new UnemptySet<Phase>();
        }

        public void Add(Phase phase)
        {
            if (phase != null)
                if (ResearchProject.StartDate <= phase.StartDate && phase.EndDate <= ResearchProject.EndDate)
                {
                    DateTime phaseStartDate;
                    if (phase.TryGetStartDate(out phaseStartDate))
                    {
                        IEnumerator<Phase> phaseEnumerator = phases.GetEnumerator();
                        DateTime startDate, phaseEndDate = phase.EndDate;
                        if (phaseEnumerator.MoveNext())
                        {
                            bool tryGetResult;
                            do
                                tryGetResult = phase.TryGetStartDate(out startDate);
                            while (tryGetResult && phaseStartDate <= phaseEnumerator.Current.EndDate || phaseEnumerator.MoveNext());
                            if (phaseEnumerator.MoveNext() && phaseEnumerator.Current.TryGetStartDate(out startDate) && phaseEndDate >= startDate)
                                throw new ArgumentException("The given phase time frame overlaps an existing phase time frame! The phase cannot be added!");
                            else
                                phases.Add(phase);
                        }
                        else
                            phases.Add(phase);
                    }
                }
                else
                    throw new ArgumentException("The given phase time frame intersects with an existing phase time frame. The phase cannot be added!");
            else
                throw new ArgumentNullException("The given value for phase cannot be null!");
        }

        public void Clear()
        {
            phases.Clear();
        }

        public bool Contains(Phase phase)
        {
            return phases.Contains(phase);
        }

        public void CopyTo(Phase[] array, int arrayIndex)
        {
            phases.CopyTo(array, arrayIndex);
        }

        public bool Remove(Phase phase)
        {
            return phases.Remove(phase);
        }

        public IEnumerator<Phase> GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ProtectedGetEnumerator();
        }

        public int Count
        {
            get
            {
                return phases.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ResearchProject ResearchProject { get; private set; }

        protected IEnumerator<Phase> ProtectedGetEnumerator()
        {
            return phases.GetEnumerator();
        }

        private UnemptySet<Phase> phases;
    }
}
