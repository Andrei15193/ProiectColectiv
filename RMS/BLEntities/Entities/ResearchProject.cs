using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class ResearchProject
    {
        private String name { get; private set; }
        public String summary { get; set; }
        public String description { get; set; }
        public ApplicationDomain domain { get; private set; }
        public ApplicationState state { get; set; }

        public Member projectDirector { get; private set; }

        private ResearchProjectTeam team;

        public UnemptySortedSet<Activity> phases { get; private set; }

        private FinancialResource estimatedBudget;


        public ResearchProject(String name, String summary, String description, ApplicationDomain domain, ApplicationState state)
        {
            this.name = name;
            this.summary = summary;
            this.description = description;
            this.domain = domain;
            this.state = state;
        }

        public UnemptySet<Member> GetTeam() { return team; }

    }
}
