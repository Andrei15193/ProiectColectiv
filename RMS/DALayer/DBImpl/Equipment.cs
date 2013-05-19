using ResourceManagementSystem.DataAccess.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.DBImpl
{
    public class Equipment : IEquipment
    {

        public ResourceManagementSystem.BusinessLogic.Entities.Equipment getByPK(string serialNumber)
        {
            throw new NotImplementedException();
        }

        public ISet<ResourceManagementSystem.BusinessLogic.Entities.Equipment> getAll()
        {
            throw new NotImplementedException();
        }

        public ISet<ResourceManagementSystem.BusinessLogic.Entities.Equipment> getByTask(ResourceManagementSystem.BusinessLogic.Entities.ITask task)
        {
            throw new NotImplementedException();
        }

        public ISet<ResourceManagementSystem.BusinessLogic.Entities.Equipment> getByClassRoom(ResourceManagementSystem.BusinessLogic.Entities.ClassRoom classRoom)
        {
            throw new NotImplementedException();
        }

        public void Add(ResourceManagementSystem.BusinessLogic.Entities.Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public void Update(string serialNumber, ResourceManagementSystem.BusinessLogic.Entities.Equipment newEquipment)
        {
            throw new NotImplementedException();
        }

        public void Delete(string serialNumber)
        {
            throw new NotImplementedException();
        }
    }
}
