using System;
using System.Text.RegularExpressions;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public abstract class Member
    {
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                    if (Regex.IsMatch(value, Constants.NameCheckRegex))
                        name = value;
                    else
                        throw new ArgumentException("The provied value is not a valid name! Names begin with a capital letter then continue with lowercase letters. Names may be separated by either one space or one dash.");
                else
                    throw new ArgumentNullException("The provided value for first name cannot be null!");
            }
        }

        public string EMail
        {
            get
            {
                return email;
            }
            set
            {
                if (value != null)
                    if (Regex.IsMatch(value,
                                      Constants.EmailCheckRegex,
                                      RegexOptions.IgnoreCase))
                        email = value;
                    else
                        throw new ArgumentException("The provided value is not a valid email address!");
                else
                    throw new ArgumentNullException("The provided value for email address cannot be null!");
            }
        }

        public string Password { get; set; }

        public MemberType Type { get; private set; }

        protected Member(MemberType type, string name, string email, string password)
        {
            if (password != null)
            {
                Type = type;
                Name = name;
                EMail = email;
                Password = password;
            }
            else
                throw new ArgumentException("The provided value for password cannot be null!");
        }

        private string name;
        private string email;
    }
}
