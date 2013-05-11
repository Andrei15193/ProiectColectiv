using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Member:User
    {
        private string lastName;
        private string firstName;
        private string email;
        private string password;
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
            if ((inEmail != "" )&&( inEmail .Contains("@")))
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
                this.password=inPassword;
                return true;
            }
            else
                return false;
        }

    }

