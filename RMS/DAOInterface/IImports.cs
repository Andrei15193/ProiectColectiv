using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOInterface
{
    public interface IImports
    {
        bool Schedule(List<byte[]> files, DateTime semesterStart, DateTime semesterEnd, IEnumerable<KeyValuePair<DateTime, DateTime>> vacations);
    }
}
