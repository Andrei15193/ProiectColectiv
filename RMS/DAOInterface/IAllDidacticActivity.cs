using ResourceManagementSystem.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOInterface
{
    public interface IAllDidacticActivities
    {
        void Add(DidacticActivity didacticActivity);

        IEnumerable<DidacticActivity> AsEnumerable { get; }
    }
}
