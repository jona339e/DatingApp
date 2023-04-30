namespace DatingApp.Interfaces
{
    public interface IUserLogin
    {
        public string GetPassword(int id);
        public string GetSalt(int id);
    }
}
