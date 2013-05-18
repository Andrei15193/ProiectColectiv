using System;
using System.Text;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class Formation
    {
        public FormationType Type { get; private set; }

        public Specialization Specialization { get; private set; }

        public uint Year { get; private set; }

        public abstract override string ToString();

        protected Formation(FormationType type, Specialization specialization, uint year)
        {
            if (year > 0)
            {
                Type = type;
                Specialization = Specialization.ComputerScience;
                Year = year;
            }
            else
                throw new ArgumentException("The proveded value for year cannot be 0 (zero)!");
        }
    }
}
