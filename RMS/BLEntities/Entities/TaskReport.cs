using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
    public class TaskReport
    {
        public DateTime date
        {
            get { return date; }
            set { date = value; }
        }

        public string message
        {
            get { return message; }
            set { message = value; }
        }

        public uint cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public TaskReport()
        {
            this.date = new DateTime();
            this.message = "";
            this.cost = 0;
        }

        public TaskReport(DateTime date, string message, uint cost)
        {
            this.date = date;
            this.message = message;
            this.cost = cost;
        }
    }
}
