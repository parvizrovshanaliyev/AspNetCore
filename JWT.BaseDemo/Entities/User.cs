namespace JWT.BaseDemo.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "unnamed";
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
