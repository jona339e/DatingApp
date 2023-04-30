using DatingApp.Interfaces;
using DatingApp.Models;
using Microsoft.AspNetCore.Components;

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

        public LoginCmp()
        {
            
        }

        User user = new User();

        private void Login()
        {
            if(ValidateLogin())
            {
                IsLoggedIn.LoggedIn = true;
                IsLoggedIn.Id = user.Id;
                navigationManager.NavigateTo($"/userprofile/{IsLoggedIn.Id}");
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
            else if (!LoginMatch())
            {
                return false;
            }



            return true;
        }

        private bool LoginMatch()
        {

            byte[] password = Convert.FromBase64String(userLogin.GetPassword(user.Id));
            byte[] salt = Convert.FromBase64String( userLogin.GetSalt(user.Id) );
            byte[] hashedPassword = hashing.HashPassword(salt, user.Password);

            if (password != hashedPassword) return false;
            else return true;
        }

    }
}
