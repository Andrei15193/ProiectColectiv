using ResourceManagementSystem.DataAccess.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.DBImpl
{
    public class HumanResources : IHumanResources
    {
        public bool addMember(ResourceManagementSystem.BusinessLogic.Entities.Member member)
        {
            throw new NotImplementedException();
        }

        public bool updateMember(string email, ResourceManagementSystem.BusinessLogic.Entities.Member newMember)
        {
            throw new NotImplementedException();
        }

        public bool deleteMember(string email)
        {
            throw new NotImplementedException();
        }
    }
}
