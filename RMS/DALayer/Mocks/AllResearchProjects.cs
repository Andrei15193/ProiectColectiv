using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ResourceManagementSystem.DataAccess.Mocks
{
    public class AllResearchProjects : IAllResearchProjects
    {
        private ICollection<ResearchProject> lista;

        public AllResearchProjects()
        {
            Member m1 = new Administrator("Popescu Ion", "vasy@cs.ubbcluj.ro", "vasy");
            Member m2 = new Administrator("Popescu Maria", "mary@cs.ubbcluj.ro", "mary");
            Member m3 = new Director("Ionescu Eliza", "ely@cs.ubbcluj.ro", "ely");
            ICollection<Member> members = new HashSet<Member>();
            members.Add(m1);
            members.Add(m2);
            members.Add(m3);
            Team team = new Team(members);

            ResearchProject rp = new ResearchProject("Analiza si optimizare", "Descriere1", DateTime.Now.AddDays(-30), DateTime.Now, team, 1);

            ResearchPhase rph = rp.Add("Articol1", "Prezentare scurta", DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-10));

            FinancialResource mobilityCost = new FinancialResource(100, Currency.EUR);
            FinancialResource laborCost = new FinancialResource(1500, Currency.EUR);
            FinancialResource logisticalCost = new FinancialResource(1000, Currency.EUR);

            rph.Add("Articol1", "Prezentare scurta", DateTime.Now.AddDays(-13), DateTime.Now.AddDays(-11), members, mobilityCost, laborCost, logisticalCost, false);


            ResearchProject rp1 = new ResearchProject("Structuri geometrice", "Descriere2", DateTime.Now.AddDays(-35), DateTime.Now, team, 2);

            ResearchPhase rph1 = rp1.Add("Articol2", "Prezentare scurta", DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-10));

            FinancialResource mobilityCost1 = new FinancialResource(100, Currency.EUR);
            FinancialResource laborCost1 = new FinancialResource(1500, Currency.EUR);
            FinancialResource logisticalCost1 = new FinancialResource(1000, Currency.EUR);

            rph1.Add("Articol2", "Prezentare scurta", DateTime.Now.AddDays(-18), DateTime.Now.AddDays(-12), members, mobilityCost1, laborCost1, logisticalCost1, false);


            ResearchProject rp2 = new ResearchProject("Puncte aciclice", "Descriere3", DateTime.Now.AddDays(-20), DateTime.Now, team, 2);

            ResearchPhase rph2 = rp2.Add("Articol3", "Prezentare scurta", DateTime.Now.AddDays(-15), DateTime.Now.AddDays(-8));

            FinancialResource mobilityCost2 = new FinancialResource(100, Currency.EUR);
            FinancialResource laborCost2 = new FinancialResource(1500, Currency.EUR);
            FinancialResource logisticalCost2 = new FinancialResource(1000, Currency.EUR);

            rph2.Add("Articol3", "Prezentare scurta", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-9), members, mobilityCost2, laborCost2, logisticalCost2, false);
            
            
            lista = new LinkedList<ResearchProject>();
            lista.Add(rp);
            lista.Add(rp1);
            lista.Add(rp2);
        }

        public void Add(ResearchProject researchProject)
        {
            this.lista.Add(researchProject);
        }

        public IEnumerable<ResearchProject> AsEnumerable
        {
            get
            {
                return lista;
            }
        }
    }
}
