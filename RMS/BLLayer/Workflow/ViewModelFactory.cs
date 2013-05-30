using ResourceManagementSystem.BusinessLogic.Workflow;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.DataAccess.Database;
using ResourceManagementSystem.DataAccess.Mocks;

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


        public static TeamsViewModel TeamsViewModel
        {
            get
            {
                return new TeamsViewModel(Repositories.AllMembers);
            }
        }

        public static MemberViewModel MemberViewModel
        {
            get
            {
                return new MemberViewModel(Repositories.AllMembers);

            }
        }

        public static FinancialResourcesViewModel FinancialResourcesViewModel
        {
            get
            {
                return new FinancialResourcesViewModel(Repositories.AllFinancialResources);
            }
        }
        public static EquipmentsViewModel EquipmentsViewModel
        {
            get
            {
                return new EquipmentsViewModel(Repositories.AllEquipments);
            }
        }

        public static ClassRoomViewModel ClassRoomViewModel
        {
            get
            {
                return new ClassRoomViewModel(Repositories.AllClassRooms);
            }
        }

        private static class Repositories
        {
            public static readonly IAllMembers AllMembers = new AllMembers();

            public static readonly IAllFinancialResources AllFinancialResources = new AllFinancialResources();

            public static readonly IAllEquipments AllEquipments = new AllEquipments();


            public static readonly IAllClassRooms AllClassRooms = new AllClassRooms();
        }
    }
}
