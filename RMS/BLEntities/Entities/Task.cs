using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace BusinessLogic.Entities
{
    public class Task
    {
        private  PerformersSet performers;
        private DateTime startDate;
        private DateTime endDate;
        private TaskState state;
        private TaskType type;
        private TaskPeriodicity periodicity;
        private sbyte duration;
        private sbyte count;
        private string summary;
        private string description;
        private FinancialResource estimatedBudget;
        private UnemptySet<LogisticalResource> logisticalResources;
       

        public DateTime getEndDate()
        {
            return endDate;
        }
        
        public DateTime getStartDate()
        {
            return startDate;
        }
         public void setEndDate(DateTime d)
        {
            this.endDate=d;
        }
        public void setStartDate(DateTime d)
        {
            this.startDate=d;
        }

        public TaskState getState()
        {
            return state;
        }
        public void setState(TaskState s)
        {
            this.state = s;
        }
        public TaskType getType()
        {
            return type;
        }
        public void setType(TaskType t)
        {
            this.type=t;
        }
        public TaskPeriodicity getPeriodicity()
        {
            return periodicity;
        }
        public void setPeriodicity(TaskPeriodicity p)
        {
            this.periodicity=p;
        }
        public sbyte getCount()
        {
            return count;
        }
        public void setCount(sbyte c)
        {
            this.count=c;
        }
        public sbyte getDuration()
        {
            return duration;
        }
        public void setDuration(sbyte d)
        {
            this.duration = d;
        }
        public string getSummary()
        {
            return this.summary;
        }
        public void setSummary(string s)
        {
            this.summary=s;
        }
        public string getDescription()
        {
            return description;
        }
        public void setDescription(string d)
        {
            this.description=d;
        }
        public PerformersSet  getPerformers()
        {
            return this.performers;
        }
        public void setPerformers(PerformersSet m)
        {
            this.performers = m;
        }
        public void setLogisticalResources(UnemptySet<LogisticalResource> l)
        {
            this.logisticalResources = l;
        }
        public UnemptySet<LogisticalResource> getLogisticalResources()
        {
            return logisticalResources;
        }
        public void setEstimatedBudget(FinancialResource f)
        {
            this.estimatedBudget = f;
        }
        public FinancialResource  getEstimatedBudget()
        {
            return estimatedBudget;
        }


        //public uint getRealizedBudget()
        //{
          //  return estimatedBudget.getValue();
       // }
        public Task(PerformersSet performers,UnemptySet<LogisticalResource> logisticalResources,FinancialResource estimatedBudget)
        
        {
            this.performers = performers;
            this.logisticalResources = logisticalResources;
            this.estimatedBudget = estimatedBudget;
        }
        public Task(DateTime startDate,DateTime endDate,string description,PerformersSet performers, UnemptySet<LogisticalResource> logisticalResources, FinancialResource estimatedBudget)
        {
            this.performers = performers;
            this.logisticalResources = logisticalResources;
            this.estimatedBudget = estimatedBudget;
            this.startDate = startDate;
            this.endDate = endDate;
            this.description = description;
        }
    }

}

