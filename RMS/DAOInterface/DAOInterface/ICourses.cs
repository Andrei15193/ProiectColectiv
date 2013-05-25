using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace ResourceManagementSystem.DataAccess.DAOInterface
{
    public interface ICourses
    {
        bool AddCourse(Course course);
        ICollection<Course> GetAllCourses();
    }
}
