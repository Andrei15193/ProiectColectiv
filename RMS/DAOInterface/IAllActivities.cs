using ResourceManagementSystem.BusinessLogic.Entities;
using System.Collections.Generic;

namespace ResourceManagementSystem.DAOInterface
{
    public interface IAllActivities
    {
        IEnumerable<AbstractActivity> AsEnumerable { get; }
        IEnumerable<AbstractActivity> getAllPendingActivities();
        void aproveActivity(AbstractActivity activity);
    }
}
