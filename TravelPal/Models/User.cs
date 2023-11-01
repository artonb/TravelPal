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
        public List<Travel> Travels { get; set; } = new();

        public User(string username, string password, Country location)
        {
            Username = username;
            Password = password;
            Location = location;
        }

        //public void addTravel(Travel travelToAdd)
        //{
        //    Travels.Add(travelToAdd);
        //}

        //public void removeTravel(Travel travelToRemove)
        //{
        //    Travels.Add(travelToRemove);
        //}
    }
}
