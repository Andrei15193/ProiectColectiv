﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.BusinessWorkflow
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