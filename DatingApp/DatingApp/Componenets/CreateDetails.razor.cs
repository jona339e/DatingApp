using DatingApp.Interfaces;
using DatingApp.Models;
using Microsoft.AspNetCore.Components;

namespace DatingApp.Componenets
{
    public partial class CreateDetails
    {
        // since i set the id in the login component, i can use it here so it will always reference the correct user


        [Inject]
        public IUpdateProfile UpdateProfile { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        UserProfile userProfile = new UserProfile();
        public CreateDetails()
        {
            userProfile.Id = IsLoggedIn.Id;
        }

        public void testBinding()
        {

            List<UserProfile> users = new List<UserProfile>();
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
        }

        public void UpdateUserProfile()
        {
            if (UpdateProfile.UpdateUserProfile(userProfile))
            {
                navigationManager.NavigateTo($"/userprofile/{IsLoggedIn.Id}");
            }
            else
            { // do something / route to error page

            }

        }
    }
}
