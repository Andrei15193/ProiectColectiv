using ResourceManagementSystem.BusinessLogic.Entities;
using ResourceManagementSystem.DAOInterface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace ResourceManagementSystem.BusinessLogic.Workflow
{
    public class HumanResourcesViewModel
    {
        public HumanResourcesViewModel(IAllMembers allMembers)
        {
            if (allMembers != null)
            {
                textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
                this.allMembers = allMembers;
                MemberTypeSelectedIndex = 0;
                TeachingPositionSelectedIndex = 0;
            }
            else
                throw new ArgumentNullException("The provided value for allMembers cannot be null!");
        }

        public string Name { get; set; }

        public string EMail { get; set; }

        public string Password { get; set; }

        public string[] MemberTypes { get { return memberTypes; } }

        public int MemberTypeSelectedIndex { get; set; }


        public string Address { get; set; }

        public string DomainsOfInterest { get; set; }

        public string Telephone { get; set; }

        public string Website { get; set; }

        public bool HasPhD { get; set; }

        public string[] TeachingPositions { get { return teachingPositions; } }

        public int TeachingPositionSelectedIndex { get; set; }

        public bool TryAddMember(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                Name = textInfo.ToTitleCase(Name.ToLower());
                switch ((MemberType)MemberTypeSelectedIndex)
                {
                    case MemberType.Director:
                        allMembers.Add(new Director(Name, EMail, Password));
                        return true;
                    case MemberType.Administrator:
                        allMembers.Add(new Administrator(Name, EMail, Password));
                        return true;
                    case MemberType.Teacher:
                        allMembers.Add(new Teacher((TeachingPosition)TeachingPositionSelectedIndex, Name, EMail, Password, HasPhD, Address, Telephone, Website, DomainsOfInterest));
                        return true;
                    case MemberType.PhD_Student:
                        allMembers.Add(new PhDStudent(Name, EMail, Password, Address, Telephone, Website, DomainsOfInterest));
                        return true;
                    default:
                        errorMessage = "Unknown Type is not allowed!";
                        return false;
                }
            }
            catch (Exception exception)
            {
                errorMessage = exception.ToString();
                return false;
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

        TextInfo textInfo;
        private IAllMembers allMembers;
        private static readonly string[] memberTypes = Enum.GetNames(typeof(MemberType)).Select((memberType) => memberType.Replace('_', ' ')).ToArray();
        private static readonly string[] teachingPositions = Enum.GetNames(typeof(TeachingPosition)).Select((typeName) => typeName.Replace('_', ' ')).ToArray();
    }
}
