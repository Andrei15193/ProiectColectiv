using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class ClassRoom : LogisticalResource
    {
        public ClassRoom(string name, string description)
            : base (description)
        {
            if(name == "")
                throw new ArgumentNullException("The provided value for name cannot be null!");

            if (name != null)
                Name = name;
            else
                throw new ArgumentNullException("The provided value for name cannot be null!");
        }

        public ClassRoom(string name)
            : this(name, string.Empty)
        {
        }

        public string Name { get; private set; }
    }
}
