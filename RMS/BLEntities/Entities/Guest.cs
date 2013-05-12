namespace ResourceManagementSystem.BusinessLogic.Entities
{
    public class Guest : User
    {
        public Guest(string guestName) : base(guestName, new GuestRole())
        {
        }
    }
}
