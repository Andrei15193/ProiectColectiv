using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class FinancialResource
    {
        public uint Value { get; private set; }

        public Currency Currency { get; private set; }

        public FinancialResource(uint value, Currency currency)
        {
            if (value > 0)
            {
                Value = value;
                Currency = currency;
            }
            else
                throw new ArgumentException("The provided value for financial resource cannot be 0 (zero)!");
        }
    }
}
