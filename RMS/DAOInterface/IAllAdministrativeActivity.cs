using ResourceManagementSystem.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.DAOInterface

{
    public interface IAllAdministrativeActivity
    {
        IEnumerable<AdministrativeActivity> AsEnumerable { get; }

        void Add(AdministrativeActivity administrativeActivity);
    }
}
