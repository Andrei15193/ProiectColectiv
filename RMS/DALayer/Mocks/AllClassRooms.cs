using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.DAOInterface;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace ResourceManagementSystem.DataAccess.Mocks
{
    public class AllClassRooms : IAllClassRooms
    {
        private ICollection<ClassRoom> lista;

        public AllClassRooms()
        {
            lista = new LinkedList<ClassRoom>();
            lista.Add(new ClassRoom("A301","sala de curs"));
            lista.Add(new ClassRoom("L308", "laborator"));
            lista.Add(new ClassRoom("C335", "sala de curs"));

        }

        public void Add(ClassRoom cls)
        {
            this.lista.Add(cls);
        }

        public IEnumerable<ClassRoom> AsEnumerable 
        {
            get
            {
                return lista;
            }
        }
    }
}
