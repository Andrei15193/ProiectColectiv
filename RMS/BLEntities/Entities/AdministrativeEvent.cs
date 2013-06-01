using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class AdministrativeEvent
    {
        public string title { get; set; }
        public DateTime startDate {get;set;}
        public DateTime endDate { get; set; }
        public ICollection<AdministrativeActivity> activities;

        public AdministrativeEvent(DateTime startDate, DateTime endDate)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            activities = new List<AdministrativeActivity>();
        }

        public AdministrativeEvent(DateTime startDate, DateTime endDate, ICollection<AdministrativeActivity> activities)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.activities = activities;
        }

        public AdministrativeActivity Add(string title, string description, DateTime startDate, DateTime endDate, )
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
    }
}
