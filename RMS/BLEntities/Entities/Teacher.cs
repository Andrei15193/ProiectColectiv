using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Teacher : Member
    {
        public Teacher(TeachingPosition position, string name, string email, string password, bool hasPhD, string address, string telephone, string website, string domainsOfInterest)
            : base(MemberType.Teacher, name, email, password)
        {
            Position = position;
            HasPhD = hasPhD;
            Address = address;
            Telephone = telephone;
            Website = website;
            DomainsOfInterest = domainsOfInterest;

        }

        public Teacher(TeachingPosition position, string name, string email, string password, bool hasPhD, string domainsOfInterest)
            : this(position, name, email, password, hasPhD, string.Empty, string.Empty, string.Empty, domainsOfInterest)
        {
        }

        public Teacher(TeachingPosition position, string name, string email, string password, string domainsOfInterest)
            : this(position, name, email, password, true, string.Empty, string.Empty, string.Empty, domainsOfInterest)
        {
        }

        public TeachingPosition Position { get; set; }

        public bool HasPhD { get; set; }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value != null)
                    address = value;
                else
                    throw new ArgumentNullException("The provided value for address cannot be null!");
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                if (value != null)
                    telephone = value;
                else
                    throw new ArgumentNullException("The provided value for telephone cannot be null!");
            }
        }

        public string Website
        {
            get
            {
                return website;
            }
            set
            {
                if (value != null)
                    website = value;
                else
                    throw new ArgumentNullException("The provided value for website cannot be null!");
            }
        }

        public string DomainsOfInterest
        {
            get
            {
                return domainsOfInterest;
            }
            set
            {
                if (value != null)
                    domainsOfInterest = value;
                else
                    throw new ArgumentException("The provided value for damains of interest cannot be null!");
            }
        }

        private string domainsOfInterest;
        private string address;
        private string telephone;
        private string website;
    }
}
