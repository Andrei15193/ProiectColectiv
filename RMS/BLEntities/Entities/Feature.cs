using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Feature
    {
        public Feature(string name)
        {
            if (name != null)
            {
                Name = name;
                Description = string.Empty;
            }
            else
                throw new ArgumentNullException("The provided value for name cannot be null!");
        }

        public Feature(string name, string description)
        {
            if (name != null)
                if (description != null)
                {
                    Name = name;
                    Description = description;
                }
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            else
                throw new ArgumentNullException("The provided value for name cannot be null!");
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}
