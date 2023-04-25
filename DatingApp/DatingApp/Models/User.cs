namespace DatingApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime DeleteDate { get; set; }

    }
}
