using System;
using System.Collections.Generic;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Role
    {
        public Role(string name)
        {
            Name = name;
            Description = string.Empty;
            Features = new Collections.UnemptySet<Feature>();
        }

        public Role(string name, string description)
        {
            Name = name;
            Description = description;
            Features = new Collections.UnemptySet<Feature>();
        }

        public Role(string name, IEnumerable<Feature> features)
        {
            if (features != null)
            {
                Name = name;
                Description = string.Empty;
                Features = new Collections.UnemptySet<Feature>(features);
            }
            else
                throw new ArgumentNullException("The provided features collection cannot be null!");
        }

        public Role(string name, string description, IEnumerable<Feature> features)
        {
            if (features != null)
            {
                Name = name;
                Description = description;
                Features = new Collections.UnemptySet<Feature>(features);
            }
            else
                throw new ArgumentNullException("The provided features collection cannot be null!");
        }

        public Role(string name, params Feature[] features)
        {
            if (features != null)
            {
                Name = name;
                Description = string.Empty;
                Features = new Collections.UnemptySet<Feature>(features);
            }
            else
                throw new ArgumentNullException("The provided features collection cannot be null!");
        }

        public Role(string name, string description, params Feature[] features)
        {
            if (features != null)
            {
                Name = name;
                Description = description;
                Features = new Collections.UnemptySet<Feature>(features);
            }
            else
                throw new ArgumentNullException("The provided features collection cannot be null!");
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                    if (value.Length > 3)
                        name = value;
                    else
                        throw new ArgumentException("The provided value for name is to short to be a role name!");
                else
                    throw new ArgumentNullException("The provided value for name cannot be null!");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            private set
            {
                if (value != null)
                    description = value;
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            }
        }

        public ICollection<Feature> Features { get; private set; }

        private string name;
        private string description;
    }

}
