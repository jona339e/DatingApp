namespace DatingApp.Interfaces
{
    public interface IHashing
    {
        public string HashPassword(byte[] salt, string password);
    }
}
