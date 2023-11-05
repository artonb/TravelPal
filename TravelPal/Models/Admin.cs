using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interface;

namespace TravelPal.Models
{
    public class Admin : IUser
    {
        //Lägg till props
        public string Username { get; set; }
        public string Password { get; set; }

        public Country Location { get; set; }

        public List<Travel> Travels { get; set; } = new();

        //Lägg till constructor
        public Admin(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;

        }
    }
}
