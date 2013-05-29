using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public interface IDateTimeBound
    {
        DateTime StartDate { get; }

        DateTime EndDate { get; }
    }
}
