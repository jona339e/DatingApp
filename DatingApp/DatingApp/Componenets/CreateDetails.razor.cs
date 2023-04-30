using DatingApp.Models;

namespace DatingApp.Componenets
{
    public partial class CreateDetails
    {
        UserProfile userProfile = new UserProfile();

        public void testBinding()
        {
            List<UserProfile> users = new List<UserProfile>();
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
        }

    }
}
