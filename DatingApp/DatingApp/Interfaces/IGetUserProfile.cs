namespace DatingApp.Interfaces
{
    public interface IGetUserProfile
    {
        // get user from database
        Models.UserProfile GetCorrectUserProfile(int userId);
    }
}
