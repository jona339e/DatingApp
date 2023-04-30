using DatingApp.Interfaces;
using DatingApp.Models;
using Konscious.Security.Cryptography;
using System.Text;

namespace DatingApp.Services
{
    public class Hashing : IHashing
    {
        public byte[] HashPassword(byte[] salt, string password)
        {
            Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 4;
            argon2.Iterations = 2;
            argon2.MemorySize = 1024;
            argon2.DegreeOfParallelism = 2;

            byte[] hash = argon2.GetBytes(32);

            return hash;
        }

    }
}
