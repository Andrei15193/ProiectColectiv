using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.BusinessWorkflow
{
    class HumanResourcesViewModel
    {
        IHumanResources humanResourcesDAO;

        public HumanResourcesViewModel(IHumanResources humanResourcesDAO)
        {
            this.humanResourcesDAO = humanResourcesDAO;
        }

        public bool addMember(Role role, string firstName, string lastName, string email, string password, IEnumerable<ITask> attendingTasks)
        {
            Member m = new Member(role, firstName, lastName, email, password, attendingTasks);

            return humanResourcesDAO.addMember(m);
        }

        public bool updateMember(Role role, string firstName, string lastName, string email, string password, IEnumerable<ITask> attendingTasks)
        {
            Member m = new Member(role, firstName, lastName, email, password, attendingTasks);

            return humanResourcesDAO.updateMember(email, m);
        }

        public bool deleteMember(string email)
        {
            return humanResourcesDAO.deleteMember(email);
        }
    }
}
