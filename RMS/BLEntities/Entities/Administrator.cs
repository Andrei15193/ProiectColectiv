namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Administrator : Member
    {
        public Administrator(string name, string email, string password)
            : base(MemberType.Administrator, name, email, password)
        {
        }
    }
}
