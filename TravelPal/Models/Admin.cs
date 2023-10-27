using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Models
{
    public class Admin : IUser
    {
        //Add props from IUser
        public string Username { get; set; }
        public string Password { get; set; }

        public Country Location { get; set; }

        //Add constructor
        public Admin(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;

        }
    }
}
