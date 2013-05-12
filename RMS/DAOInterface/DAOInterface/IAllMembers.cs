namespace ResourceManagementSystem.DataAccess.DAOInterface
{
    public interface IAllMembers
    {
        BusinessLogic.Entities.Member Where(string email, string password);
    }
}
