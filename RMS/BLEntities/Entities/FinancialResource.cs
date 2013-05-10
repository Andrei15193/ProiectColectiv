using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class FinancialResource
    {
        public uint value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Currency currency
        {
            get { return this.currency; }
            set { this.currency = value; }
        }

        public Task task
        {
            get { return this.task; }
            set { this.task = value; }
        }

        public FinancialResource(Task task)
        {
            this.value = 0;
            this.currency = Currency.RON;
            this.task = task;
        }

        public FinancialResource(uint value, Task task)
        {
            this.value = value;
            this.currency = Currency.RON;
            this.task = task;
        }
    }
}
