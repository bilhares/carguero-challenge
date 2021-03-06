namespace AddressRegister.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; private set; }

        public User()
        {
        }

        public User(string username)
        {
            Username = username;
        }

        public void UpdateUsername(string username)
        {
            Username = username;
        }
    }
}