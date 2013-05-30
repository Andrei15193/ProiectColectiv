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
    public class AllFinancialResources: IAllFinancialResources
    {
        private ICollection<FinancialResource> lista;

        public AllFinancialResources()
        {
            lista = new LinkedList<FinancialResource>();
            lista.Add(new FinancialResource(100,Currency.RON));

        }

        public void Add(FinancialResource financialResource)
        {
            this.lista.Add(financialResource);
        }

        public IEnumerable<FinancialResource> AsEnumerable 
        {
            get
            {
                return lista;
            }
        }

        
    }
}
