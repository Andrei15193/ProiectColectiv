using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Entities
{
    public class Member : User
    {
        private string lastName;
        private string firstName;
        private string email;
        private string password;

        private SortedSet<Task> tasks;
        private ISet<ResearchProject> directedResearchProjects;
        private ISet<ResearchProject> attendedResearchProjects;

        public Member() { }
        public Member(Role r) : base(r) { }

        public Member(Role r,string firstName, string lastName, string email, string password): base(r)
        {

            this.lastName = lastName;
            this.firstName = firstName;
            this.email = email;
            this.password = password;
        }

        public Member(string username, Role r, string firstName, string lastName, string email, string password):base(username,r)
        {
           
            this.lastName = lastName;
            this.firstName = firstName;
            this.email = email;
            this.password = password;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public string getEmail()
        {
            return email;
        }

        public bool setFirstName(string inFirstName)
        {
            if (inFirstName != "")
            {
                this.firstName = inFirstName;
                return true;
            }
            else
                return false;
        }

        public bool setLastName(string inLastName)
        {
            if (inLastName != "")
            {
                this.lastName = inLastName;
                return true;
            }
            else
                return false;
        }

        public bool setEmail(string inEmail)
        {
            if ((inEmail != "") && (inEmail.Contains("@")))
            {
                this.email = inEmail;
                return true;
            }
            else
                return false;
        }

        public bool setPassword(string inPassword)
        {
            if (inPassword != "")
            {
                this.password = inPassword;
                return true;
            }
            else
                return false;
        }

        public ISet<ResearchProject> getDirectedResearchProjects() { return directedResearchProjects; }
        public ISet<ResearchProject> getAttendedResearchProjects() { return attendedResearchProjects; }
       
    }
}
