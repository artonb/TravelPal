using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Models
{
    public class User : IUser
    {
        //Add props from IUser
        public string Username { get; set; }
        public string Password { get; set; }

        public Country Location { get; set; }

        //Add new props
        public List<Travel> Travels { get; set; }

        public User(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;
        }
    }
}
