using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class LogisticalResource
    {
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != null)
                    description = value;
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            }
        }

        protected LogisticalResource(string desciption)
        {
            Description = desciption;
        }

        protected LogisticalResource()
            : this(string.Empty)
        {
        }

        private string description;
    }
}
