using ResourceManagementSystem.BusinessLogic.Entities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.DAOInterface
{
    public interface IAllTeams
    {
        IEnumerable<Team> AsEnumerable { get; }
    }
}
