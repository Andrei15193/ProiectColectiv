using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Member : User
    {
        public Member(Role role, string firstName, string lastName, string email, string password, IEnumerable<ITask> attendingTasks)
            : base(string.Join(" ", firstName, lastName), role)
        {
            if (attendingTasks != null)
            {
                LastName = lastName;
                FirstName = firstName;
                EMail = email;
                Password = password;
                Tasks = new Collections.AssignedTasksSortedSet(this, attendingTasks);
            }
            else
                throw new ArgumentNullException("The provided value for attending tasks cannot be null!");
        }

        public Member(Role role, string firstName, string lastName, string email, string password)
            : this(role, firstName, lastName, email, password, new ITask[0] as IEnumerable<ITask>)
        {
        }

        public Member(Role role, string firstName, string lastName, string email, string password, params ITask[] tasks)
            : this(role, firstName, lastName, email, password, tasks as IEnumerable<ITask>)
        {
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != null)
                    if (Regex.IsMatch(value, @"\p{Lu}\p{Ll}+((\s|-)\p{Lu}\p{Ll}+)*"))
                        firstName = value;
                    else
                        throw new ArgumentException("The provied value is not a valid first name!");
                else
                    throw new ArgumentNullException("The provided value for first name cannot be null!");
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value != null)
                    if (Regex.IsMatch(value, @"\p{Lu}\p{Ll}+"))
                        lastName = value;
                    else
                        throw new ArgumentException("The provided value is not a valid last name!");
                else
                    throw new ArgumentNullException("The provided value for last name cannot be null!");
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
                                      @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                                      RegexOptions.IgnoreCase))
                        email = value;
                    else
                        throw new ArgumentException("The provided value is not a valid email address!");
                else
                    throw new ArgumentNullException("The provided value for email address cannot be null!");
            }
        }

        public string Password
        {
            set
            {
                if (value != null)
                    if (Regex.IsMatch(value, @"^.{6,}$"))
                        password = value;
                    else
                        throw new ArgumentException("The provided value is not a valid password! It must have at least 6 characters!");
                else
                    throw new ArgumentNullException("The provided value for password cannot be null!");
            }
        }

        //public ICollection<ResearchProject> ResearchProjects { get; private set; }

        public ICollection<ITask> Tasks { get; private set; }

        protected static string GetPasswordFromMember(Member member)
        {
            return member.password;
        }

        private string firstName;
        private string lastName;
        private string email;
        private string password;
    }
}
