namespace Shared.Interfaces.User
{
    public interface IUser
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
