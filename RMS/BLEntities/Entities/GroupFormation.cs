using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class GroupFormation : Formation
    {
        public GroupFormation(Specialization specialization, uint year, uint number)
            : base(FormationType.Group, specialization, year)
        {
            if (number > 0)
            {
                Number = number;
                stringRepresentation = string.Format("{0}{1}{2}", (int)specialization, year, number);
            }
            else
                throw new ArgumentException("The proveded value for group number cannot be 0 (zero)!");
        }

        public override string ToString()
        {
            return stringRepresentation;
        }

        public uint Number { get; private set; }

        private string stringRepresentation;
    }
}
