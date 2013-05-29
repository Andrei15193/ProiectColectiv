using System;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class PhDStudent : Member
    {
        public PhDStudent(string name, string email, string password, string address, string telephone, string website, string domainsOfInterest)
            : base(MemberType.PhD_Student, name, email, password)
        {
            Address = address;
            Telephone = telephone;
            Website = website;
            DomainsOfInterest = domainsOfInterest;
        }

        public PhDStudent(string name, string email, string password)
            : this(name, email, password, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

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
