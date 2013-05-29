using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    class AdministrativeEventsViewModel : Feature
    {
        private IAllMembers allMemberDAO;

        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        IEnumerable<ITask> tasks;
        IEnumerable<string> assigneeMembers;

        public AdministrativeEventsViewModel(IAllMembers allMembersDAO) :
            base("Administrative Events manager")
        {
            this.allMemberDAO = allMemberDAO;
        }

        void AddAdministrativeEvent()
        {
            if (description == null)
                description = String.Empty;

            Activity activity = new Activity(title, description, new List<String>() { "administrative" }, tasks);
            

        }

        void AddTask()
        {
            ;
        }
    }
}
