using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLEntities.Entities
{
    class FinancialResource
    {
        private uint value;
        private Currency currency;
        private Task task;

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

        public uint getValue()
        {
            return this.value;
        }

        public Currency getCurrency()
        {
            return this.currency;
        }

        public Task getTask()
        {
            return this.task;
        }

        public void setValue(uint value)
        {
            this.value = value;
        }

        public void setTask(Task task)
        {
            this.task = task;
        }
    }
}
