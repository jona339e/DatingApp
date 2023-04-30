using DatingApp.Interfaces;
using DatingApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace DatingApp.Componenets
{
    public  partial class OwnProfileCmp
    {
        [Inject]
        public IGetUserProfile GetUserProfile { get; set; }
        [Inject]
        public IGetCity GetCity { get; set; }
        [Inject] IGetGender GetGender { get; set; }

        UserProfile profile = new UserProfile();
        City city = new City();
        Gender gender = new Gender();
        protected override void OnInitialized()
        {
            //get user from database
            
            profile = GetUserProfile.GetCorrectUserProfile(IsLoggedIn.Id);
            city.Zip = profile.CityID;
            city.CityName = GetCity.GetCityByZip(city.Zip);
            gender.GenderName = GetGender.GetGenderName(profile.GenderID);
            //get profile picture url from database using isloggedin id


        }




    }
}
