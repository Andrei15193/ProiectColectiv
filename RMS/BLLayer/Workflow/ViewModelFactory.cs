using ResourceManagementSystem.BusinessLogic.Workflow;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.DataAccess.Database;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public static class ViewModelFactory
    {
        public static HumanResourcesViewModel HumanResourcesViewModel
        {
            get
            {
                return new HumanResourcesViewModel(Repositories.AllMembers);
            }
        }

        public static MemberViewModel MemberViewModel
        {
            get
            {
                return new MemberViewModel(Repositories.AllMembers);
            }
        }

        private static class Repositories
        {
            public static readonly IAllMembers AllMembers = new AllMembers();
        }
    }
}
