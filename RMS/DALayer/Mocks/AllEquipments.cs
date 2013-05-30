using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ResourceManagementSystem.DataAccess.Mocks
{
    public class AllEquipments : IAllEquipments
    {
        private ICollection<Equipment> lista;

        public AllEquipments()
        {
            lista = new LinkedList<Equipment>();
            lista.Add(new Equipment("Lenovo","Yoga", "26C5432", "are bluetooth" ));

        }

        public void Add(Equipment equipment)
        {
            this.lista.Add(equipment);
        }

        public IEnumerable<Equipment> AsEnumerable
        {
            get
            {
                return lista;
            }
        }


    }
}
