namespace DatingApp.Interfaces
{
    public interface IHashing
    {
        public byte[] HashPassword(byte[] salt, string password);
    }
}
