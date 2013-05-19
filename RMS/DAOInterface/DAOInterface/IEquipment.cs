using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.DataAccess.DAOInterface
{
    public interface IEquipment
    {
        BusinessLogic.Entities.Equipment getByPK(string serialNumber);

        ISet<BusinessLogic.Entities.Equipment> getAll();

        ISet<BusinessLogic.Entities.Equipment> getByTask(BusinessLogic.Entities.ITask task);

        ISet<BusinessLogic.Entities.Equipment> getByClassRoom(BusinessLogic.Entities.ClassRoom classRoom);

        void Add(ResourceManagementSystem.BusinessLogic.Entities.Equipment equipment);

        void Update(string serialNumber, ResourceManagementSystem.BusinessLogic.Entities.Equipment newEquipment);

        void Delete(string serialNumber);

    }
}
