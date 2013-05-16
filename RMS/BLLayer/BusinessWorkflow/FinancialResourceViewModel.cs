using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAOInterface.DAOInterface;
using ResourceManagementSystem.BusinessLogic.Entities;

namespace BLLayer.BusinessWorkflow
{
    class FinancialResourceViewModel
    {
        IFinancialResources financialResourcesDAO;

        public FinancialResourceViewModel(IFinancialResources financialResourcesDAO)
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
