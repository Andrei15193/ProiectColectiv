using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResourceManagementSystem.DataAccess.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    class FeaturesFactory
    {
        public static IFinancialResources financialResourcesDAO { get; set; }
        public static IHumanResources humanResourcesDAO { get; set; }
        public static IEquipment equipmentDAO { get; set; }
        public static IClassRoom classRoomDAO { get; set; }

        public static FinancialResourceViewModel financialResourceViewModel
        {
            get
            {
                return new FinancialResourceViewModel(financialResourcesDAO);
            }
            private set;
        }

        public static HumanResourcesViewModel humanResourcesViewModel
        {
            get
            {
                return new HumanResourcesViewModel(humanResourcesDAO);
            }
            private set;
        }

        public static LogisticalResourceViewModel logisticalResourceViewModel
        {
            get
            {
                return new LogisticalResourceViewModel(equipmentDAO, classRoomDAO);
            }
            private set;
        }
    }
}
