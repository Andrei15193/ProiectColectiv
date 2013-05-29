using ResourceManagementSystem.BusinessLogic.Entities;
using System.Collections.Generic;

namespace ResourceManagementSystem.DAOInterface
{
    public interface IAllMembers
    {
        void Add(Director director);

        void Add(Administrator administrator);

        void Add(Teacher teacher);

        void Add(PhDStudent phDStudent);

        IEnumerable<Member> AsEnumerable { get; }
    }
}
