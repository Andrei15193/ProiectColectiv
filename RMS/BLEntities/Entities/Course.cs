using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Course
    {
        public Course(string name, string description, uint credits, Language language, ApplicationDomain domain)
        {
            if (name != null)
                if (description != null)
                {
                    Name = name;
                    Description = description;
                    Credits = credits;
                    Language = language;
                    Domain = domain;
                }
                else
                    throw new ArgumentNullException("The provided value for description cannot be null!");
            else
                throw new ArgumentNullException("The provided value for name cannot be null!");
        }

        public Course(string name, uint credits, Language language, ApplicationDomain domain)
            : this(name, string.Empty, credits, language, domain)
        {
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public uint Credits { get; private set; }

        public Language Language { get; private set; }

        public ApplicationDomain Domain { get; private set; }
    }
}
