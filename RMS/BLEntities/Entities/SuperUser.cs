namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class SuperUser : Member
    {
        public SuperUser(Member member)
            : base(new SuperUserRole(), member.FirstName, member.LastName, member.EMail, Member.GetPasswordFromMember(member), member.Tasks)
        {
        }
    }
}
