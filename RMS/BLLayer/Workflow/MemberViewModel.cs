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
            member = null;
        }

        public void Authenticate()
        {
            authenticationFailed = false;
            member = allMembers.Where(email, password);
            if (member == null)
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
            member = null;
        }

        public string Name
        {
            get
            {
                return member == null ? string.Empty : member.Name;
            }
            set
            {
                if (member != null)
                    member.Name = value;
                else
                    throw new InvalidOperationException("There is no member authenticated! Cannot set the name of a member if he's unknown!");
            }
        }

        public MemberType MemberType
        {
            get
            {
                if (member != null)
                    return member.Type;
                else
                    throw new InvalidOperationException("There is no member authenticated! Cannot set the type of a member if he's unknown!");
            }
        }

        public string EMail
        {
            get
            {
                return member == null ? string.Empty : member.EMail;
            }
            set
            {
                if (member == null)
                    email = value;
                else
                    member.EMail = value;
            }
        }

        public string Password
        {
            get
            {
                return member == null ? string.Empty : member.Password;
            }
            set
            {
                if (member == null)
                    password = value;
                else
                    member.Password = value;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return member != null;
            }
        }
        //31.05.2013
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

        private IAllMembers allMembers;
        public Member member { get; private set; }
        private string email;
        private string password;
    }
}
