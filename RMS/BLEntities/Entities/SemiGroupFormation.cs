using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class SemiGroupFormation : Formation
    {
        public SemiGroupFormation(Specialization specialization, uint year, uint groupNumber, bool isFirstSemigroup)
            : base(FormationType.Semigroup, specialization, year)
        {
            IsFirstSemigroup = isFirstSemigroup;
            stringReprestination =  string.Format("{0}/{1}", new GroupFormation(specialization, year, groupNumber).ToString(), isFirstSemigroup ? 1 : 2);
        }

        public override string ToString()
        {
            return stringReprestination;
        }

        public bool IsFirstSemigroup { get; private set; }

        private string stringReprestination;
    }
}
