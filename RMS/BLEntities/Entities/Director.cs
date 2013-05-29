namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Director : Member
    {
        public Director(string name, string email, string password)
            : base(MemberType.Director, name, email, password)
        {
        }
    }
}
