using DatingApp.Interfaces;
using DatingApp.Models;
using Konscious.Security.Cryptography;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.Componenets
{
    public partial class LoginCmp
    {
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IUserExist userExist { get; set; }
        [Inject]
        public IUserLogin userLogin { get; set; }
        [Inject]
        public IHashing hashing { get; set; }
        [Inject]
        public IGetId getId { get; set; }


        User user = new User();

        private void Login()
        {
            if(ValidateLogin())
            {
                IsLoggedIn.LoggedIn = true;
                IsLoggedIn.Id = user.Id;
                navigationManager.NavigateTo($"/userprofile");
            }

        }
        private bool ValidateLogin()
        {
            // get username and see if it matches
            // get psw and salt
            // hash password with salt and compare to psw
            // if everything matches return true
            // use services to get data

            if (userExist.UserExists(user.Username) == 1)
            {
                user.Id = getId.GetUserId(user.Username);
            }
            //if (!LoginMatch())
            //{
            //    return false;
            //}



            return true;
        }

        private bool LoginMatch()
        {
            // doesn't work
            string storedPassword = userLogin.GetPassword(user.Id);
            byte[] salt = Encoding.UTF8.GetBytes(userLogin.GetSalt(user.Id));
            string hashedPassword = hashing.HashPassword(salt, user.Password);

            if (storedPassword != hashedPassword) return false;
            else return true;

            // the hashing returns 2 different hashes even though the password is the same
            //"�HP\u001c��6\\�#2u�D�$���\u0016�����\\�x�w�\u001b"
            // "�O�l�\u0016\0�g��BV�.�I��\u001d���_�(��z�\u0016�"
        }

    }
}
