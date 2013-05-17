using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.DataAccess.DAOInterface
{
    public interface IClassRoom
    {
        void Add(ResourceManagementSystem.BusinessLogic.Entities.ClassRoom classRoom);
        void Update(string building, uint floor, uint number, ResourceManagementSystem.BusinessLogic.Entities.ClassRoom newClassRoom);
        void Delete(string building, uint floor, uint number);
    }
}
