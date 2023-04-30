namespace DatingApp.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; } = DateTime.Now;
        public decimal Height { get; set; }
        public string About { get; set; }
        public int UserID { get; set; }
        public int CityID { get; set; }
        public int GenderID { get; set; }
    }
}
