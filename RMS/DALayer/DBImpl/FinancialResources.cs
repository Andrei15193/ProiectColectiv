﻿using ResourceManagementSystem.DataAccess.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.DBImpl
{
    public class FinancialResources : IFinancialResources
    {
        public bool addFinancialResource(ResourceManagementSystem.BusinessLogic.Entities.FinancialResource fr)
        {
            throw new NotImplementedException();
        }

        public bool AddFinancialResource(ResourceManagementSystem.BusinessLogic.Entities.FinancialResource fr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResourceManagementSystem.BusinessLogic.Entities.FinancialResource> All
        {
            get { throw new NotImplementedException(); }
        }
    }
}
