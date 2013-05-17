using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.DataAccess.DAOInterface
{
    public interface IEquipment
    {
        void Add(ResourceManagementSystem.BusinessLogic.Entities.Equipment equipment);
        void Update(string serialNumber, ResourceManagementSystem.BusinessLogic.Entities.Equipment newEquipment);
        void Delete(string serialNumber);
    }
}
