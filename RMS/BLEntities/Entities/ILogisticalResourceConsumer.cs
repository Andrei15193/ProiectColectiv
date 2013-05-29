using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public interface ILogisticalResourceConsumer
    {
        ICollection<ClassRoom> ClassRooms { get; }

        ICollection<Equipment> Equipments { get; }
    }
}
