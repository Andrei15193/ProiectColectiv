using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class HumanResourcesViewModel : Feature
    {
        IHumanResources humanResourcesDAO;

        public HumanResourcesViewModel(IHumanResources humanResourcesDAO)
            : base("Human Resource manager")
        {
            this.humanResourcesDAO = humanResourcesDAO;
        }

        public bool AddMember(Role role, string firstName, string lastName, string email, string password, IEnumerable<ITask> attendingTasks)
        {
            Member m = new Member(role, firstName, lastName, email, password, attendingTasks);

            return humanResourcesDAO.addMember(m);
        }

        public bool UpdateMember(Role role, string firstName, string lastName, string email, string password, IEnumerable<ITask> attendingTasks)
        {
            Member m = new Member(role, firstName, lastName, email, password, attendingTasks);

            return humanResourcesDAO.updateMember(email, m);
        }

        public bool DeleteMember(string email)
        {
            return humanResourcesDAO.deleteMember(email);
        }
    }
}
