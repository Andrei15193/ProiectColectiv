using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace ResourceManagementSystem.DAOInterface
{
    public interface IAllEquipments
    {
        void Add(Equipment equipment);

        IEnumerable<Equipment> AsEnumerable { get; }
    }
}
