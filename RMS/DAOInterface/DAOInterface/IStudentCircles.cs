namespace ResourceManagementSystem.DataAccess.DAOInterface
{
    public interface IStudentCircles
    {
        bool addActivity(ResourceManagementSystem.BusinessLogic.Entities.Activity activity);
        ResourceManagementSystem.BusinessLogic.Entities.Activity getActivity(string title);
        bool addTask(string title, ResourceManagementSystem.BusinessLogic.Entities.ITask task);
    }
}
