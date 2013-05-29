using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class ResearchActivity : AbstractAssignableActivity, ILogisticalResourceConsumer
    {
        public ResearchActivity(ResearchPhase researchPhase, string title, string description, DateTime startDate, DateTime endDate, IEnumerable<Member> assignees, FinancialResource mobilityCost, FinancialResource laborCost, FinancialResource logisticalCost)
            : base(ActivityType.Research, title, description, startDate, endDate, assignees)
        {
            if (researchPhase != null)
                if (mobilityCost != null)
                    if (laborCost != null)
                        if (logisticalCost != null)
                            if (researchPhase.StartDate <= startDate && endDate <= researchPhase.EndDate)
                            {
                                MobilityCost = mobilityCost;
                                LaborCost = laborCost;
                                LogisticalCost = logisticalCost;
                                ResearchPhase = researchPhase;
                                ClassRooms = new SortedSet<ClassRoom>(new Collections.Comparer<ClassRoom>((x, y) => x.Name.CompareTo(y.Name)));
                                Equipments = new SortedSet<Equipment>(new Collections.Comparer<Equipment>((x, y) => x.Model.CompareTo(y.Model)));
                            }
                            else
                                throw new ArgumentException("The start date and end date of a research activity cannot exceed the date bounds of the research phase that contains it!");
                        else
                            throw new ArgumentNullException("The provided value for logistical cost cannot be null!");
                    else
                        throw new ArgumentNullException("The provided value for laborcost cannot be null!");
                else
                    throw new ArgumentNullException("The provided value for mobility cost cannot be null!");
            else
                throw new ArgumentNullException("The provided value for research phase cannot be null!");
        }

        public ResearchPhase ResearchPhase { get; private set; }

        public FinancialResource MobilityCost { get; private set; }

        public FinancialResource LaborCost { get; private set; }

        public FinancialResource LogisticalCost { get; private set; }

        public ICollection<ClassRoom> ClassRooms { get; private set; }

        public ICollection<Equipment> Equipments { get; private set; }
    }
}
