using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class LogisticalResource
    {
        public string Name { get; private set; }

        public string Description { get; private set; }


        public override string ToString()
        {
            return Name;
        }

        protected LogisticalResource(string name, string description)
        {
            if (name != null)
                if (description != null)
                {
                    this.Name = name;
                    this.Description = description;
                   
                }
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            else
                throw new ArgumentNullException("The provided value for name cannot be null!");
        }

        protected LogisticalResource(string name)
            : this(name, string.Empty, null)
        {
        }

        protected LogisticalResource(string name, string description)
            : this(name, description, null)
        {
        }

        protected LogisticalResource(string name)
            : this(name, string.Empty)
        {
        }
    }
}
