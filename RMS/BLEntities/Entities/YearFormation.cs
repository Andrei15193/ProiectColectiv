namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class YearFormation : Formation
    {
        public YearFormation(Specialization specialization, uint year)
            : base(FormationType.Year, specialization, year)
        {
            stringRepresentation = string.Format("{0}{1}", (int)specialization, year);
        }

        public override string ToString()
        {
            return stringRepresentation;
        }

        string stringRepresentation;
    }
}
