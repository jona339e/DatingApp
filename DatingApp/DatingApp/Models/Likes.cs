namespace DatingApp.Models
{
    public class Likes
    {
        public int Id { get; set; }
        public int Liker { get; set; }
        public int Liked { get; set; }
        public bool LikedBack { get; set; }

    }
}
