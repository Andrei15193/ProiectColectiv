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
        public string roleName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string currentEmail { get; set; }
        public string newEmail { get; set; }
        public string password { get; set; }
        public IEnumerable<ITask> attendingTasks { get; set; }
        IHumanResources humanResourcesDAO;

        public HumanResourcesViewModel(IHumanResources humanResourcesDAO)
            : base("Human Resource manager")
        {
            this.humanResourcesDAO = humanResourcesDAO;
        }

        public bool AddMember()
        {
            Member m = new Member(Role.WithName(roleName), firstName, lastName, currentEmail, password, attendingTasks);
            return humanResourcesDAO.addMember(m);
        }

        public bool UpdateMember()
        {
            Member m = new Member(Role.WithName(roleName), firstName, lastName, newEmail, password, attendingTasks);

            bool rez = humanResourcesDAO.updateMember(currentEmail, m);
            currentEmail = newEmail;
            newEmail = string.Empty;
            return rez;
        }

        public bool DeleteMember()
        {
            return humanResourcesDAO.deleteMember(currentEmail);
        }
    }
}
