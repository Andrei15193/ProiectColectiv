using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
   public class FinancialResourcesViewModel
    {
        public FinancialResourcesViewModel(IAllFinancialResources allFinancialResources)
        {
            if (allFinancialResources != null)
            {
                this.allFinancialResources = allFinancialResources;
                CurrencyTypeSelectedIndex = 0;
            }
            else
                throw new ArgumentNullException("The provided value for allFinancialResources cannot be null!");
        }

        public String Value { get; set; }

        public string[] CurrencyTypes { get { return currencyTypes; } }

        public int CurrencyTypeSelectedIndex { get; set; }


        public bool TryAddFinancialResource(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                allFinancialResources.Add(new FinancialResource(Convert.ToInt32(Value), (Currency)CurrencyTypeSelectedIndex));
                return true;
                
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return false;
            }
        }

        public IEnumerable<FinancialResource> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                return allFinancialResources.AsEnumerable;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }

        private IAllFinancialResources allFinancialResources;
        private static readonly string[] currencyTypes = Enum.GetNames(typeof(Currency)).Select((currencyType) => currencyType.Replace('_', ' ')).ToArray();
        

    }
}
