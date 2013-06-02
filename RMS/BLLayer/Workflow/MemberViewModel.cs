using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class MemberViewModel
    {
        private bool authenticationFailed = false;

        public MemberViewModel(IAllMembers allMembers)
        {
            this.allMembers = allMembers;
            Member = null;
        }

        public void Authenticate()
        {
            authenticationFailed = false;
            Member = allMembers.Where(email, password);
            if (Member == null)
            {
                authenticationFailed = true;
            }
        }

        public bool AuthenticationFailed
        {
            get
            {
                return authenticationFailed;
            }
        }

        public void Logout()
        {
            Member = null;
        }

        public string Name
        {
            get
            {
                return Member == null ? string.Empty : Member.Name;
            }
            set
            {
                if (Member != null)
                    Member.Name = value;
                else
                    throw new InvalidOperationException("There is no member authenticated! Cannot set the name of a member if he's unknown!");
            }
        }

        public MemberType MemberType
        {
            get
            {
                if (Member != null)
                    return Member.Type;
                else
                    throw new InvalidOperationException("There is no member authenticated! Cannot set the type of a member if he's unknown!");
            }
        }

        public string EMail
        {
            get
            {
                return Member == null ? string.Empty : Member.EMail;
            }
            set
            {
                if (Member == null)
                    email = value;
                else
                    Member.EMail = value;
            }
        }

        public string Password
        {
            get
            {
                return Member == null ? string.Empty : Member.Password;
            }
            set
            {
                if (Member == null)
                    password = value;
                else
                    Member.Password = value;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return Member != null;
            }
        }

        public IEnumerable<Member> TryGetAll(out string errorMessage)
        {
            try
            {
                errorMessage = null;
                return allMembers.AsEnumerable;
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return null;
            }
        }

        public Member Member { get; private set; }

        private IAllMembers allMembers;
        private string email;
        private string password;
    }
}
