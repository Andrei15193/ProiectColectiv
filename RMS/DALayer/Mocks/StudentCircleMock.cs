using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;

namespace ResourceManagementSystem.DataAccess.Mocks
{
    public class StudentCircleMock : IAllStudentCircles
    {
        private ICollection<StudentCircle> circles;
        public StudentCircleMock()
        {
            circles=new LinkedList<StudentCircle>();
        }
  
         public void Add(StudentCircle studentCircle)
         {

             this.circles.Add(studentCircle);
         }

         IEnumerable<StudentCircle> IAllStudentCircles.AsEnumerable
         {
             get
             {
                 return circles;
             } 
         }
    }
}

