using DatingApp.Interfaces;
using DatingApp.Models;
using DatingApp.Services;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.Pages
{
    public partial class CreateAccount
    {

        public CreateAccount()
        {
            
        }

        // remember to inject the interface not the class :facepalm:

        [Inject]
        public IUserExist UserExist { get; set; }
        [Inject]
        public ICreateUser CreateUser { get; set; }
        [Inject]
        public IHashing hashing { get; set; }


        public string pswcheckone { get; set; }
        public string pswchecktwo { get; set; }

        User user = new User();

        private void ValidateAccount()
        {
            if (pswcheckone != pswchecktwo)
            {
                // error message
            }
            else if(UserExist.UserExists(user.Username) > 0)
            {
                // error message (username already exists)
            }
            else
            {
                CreateUserAccount();
            }
        }
        private void CreateUserAccount()
        {
            // creates account and stores it in the database
            // argon2 encrypt
            // salt
            // store encrypted password and salt in database

            user.Password = pswcheckone;

            byte[] salt = new byte[16];

            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);

            // higher values gives safer encryption but takes longer to encrypt


            byte[] hash = hashing.HashPassword(salt, user.Password);

            user.Password = Encoding.UTF8.GetString(hash);
            user.Salt = Encoding.UTF8.GetString(salt);

            CreateUser.AddUser(user);

            // redirect to user profile page
        }

    }
}
