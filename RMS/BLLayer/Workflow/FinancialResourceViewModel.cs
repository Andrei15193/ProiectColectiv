using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class FinancialResourceViewModel : Feature
    {
        IFinancialResources financialResourcesDAO;

        public FinancialResourceViewModel(IFinancialResources financialResourcesDAO)
            : base("Financial Resource manager")
        {
            this.financialResourcesDAO = financialResourcesDAO;
        }

        public bool addFinancialResource(uint value, Currency currency)
        {
            FinancialResource fr = new FinancialResource(value, currency);

            return financialResourcesDAO.addFinancialResource(fr);
        }
    }
}
