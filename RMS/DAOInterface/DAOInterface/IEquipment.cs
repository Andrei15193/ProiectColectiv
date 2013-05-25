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

        void SetClassRoom(BusinessLogic.Entities.Equipment equipment, BusinessLogic.Entities.ClassRoom classRoom);

        void Update(BusinessLogic.Entities.Equipment equipment, bool newIsBroken, string newDescription);

        void Delete(BusinessLogic.Entities.Equipment equipment);
    }
}
