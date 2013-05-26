namespace ResourceManagementSystem.DataAccess.DAOInterface
{
    public interface IActivities
    {
        bool addActivity(ResourceManagementSystem.BusinessLogic.Entities.Activity activity);
        ResourceManagementSystem.BusinessLogic.Entities.Activity getActivity(string title);
    }
}
