using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Models
{
    public class User : IUser
    {
        //Lägg till props
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
        public List<Travel> Travels { get; set; } = new();

        //Lägg till constructor
        public User(string username, string password, Country location)/*List<Travel> travels*/
        {
            Username = username;
            Password = password;
            Location = location;
            //Travels = travels;
        }
    }
}
