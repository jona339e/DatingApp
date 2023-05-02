using DatingApp.Interfaces;
using DatingApp.Models;
using Konscious.Security.Cryptography;
using System.Text;

namespace DatingApp.Services
{
    public class Hashing : IHashing
    {
        public string HashPassword(byte[] salt, string password)
        {
            string hashedPassword = string.Empty;
            Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 4;
            argon2.Iterations = 2;
            argon2.MemorySize = 1024;
            argon2.DegreeOfParallelism = 2;

            byte[] hash = argon2.GetBytes(32);

            hashedPassword = Encoding.UTF8.GetString(hash);


            return hashedPassword;
        }

    }
}
