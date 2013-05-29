//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ResourceManagementSystem.BusinessLogic.Entities;
//using ResourceManagementSystem.DataAccess.DAOInterface;

//namespace ResourceManagementSystem.BusinessLogic.Workflow
//{
//    public class FinancialResourceViewModel : Feature
//    {
//        IFinancialResources financialResourcesDAO;

//        public FinancialResourceViewModel(IFinancialResources financialResourcesDAO)
//            : base("Financial Resource manager")
//        {
//            this.financialResourcesDAO = financialResourcesDAO;
//            Value = 0;
//            Currency = Entities.Currency.Unknown;
//        }

//        public bool AddFinancialResource()
//        {
//            FinancialResource fr = new FinancialResource(Value, Currency);
//            return financialResourcesDAO.AddFinancialResource(fr);
//        }

//        public IEnumerable<FinancialResource> All
//        {
//            get
//            {
//                return financialResourcesDAO.All;
//            }
//        }

//        public uint Value { get; set; }

//        public Currency Currency { get; set; }
//    }
//}
