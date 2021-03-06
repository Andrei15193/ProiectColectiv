﻿using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class FinancialResource
    {
        public FinancialResource(int value, Currency currency)
        {
            if(Convert.ToString(value) == "")
                throw new ArgumentException("The value of the financial resource cannot be null!");

            if (value >= 0)
            {
                Value = value;
                Currency = currency;
                Status = FinancialResourceStatus.Reserved;
            }
            else
                throw new ArgumentException("The value of the financial resource cannot be negative!");
        }

        public int Value { get; private set; }

        public Currency Currency { get; private set; }

        public FinancialResourceStatus Status { get; set; }
    }
}
