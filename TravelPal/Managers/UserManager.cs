using System.Collections.Generic;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Interface;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class UserManager
    {

        public static List<IUser> users { get; set; } = new()
        {
            new Admin("admin", "password", Country.Sweden),
            new User("user", "password", Country.Sweden),
        };
        public List<Travel> Travels = new List<Travel>()
        {
            new Vacation("Malmö", Country.Sweden, 2, false),
            new WorkTrip("Conference", "Stockholm", Country.Sweden, 4),
        };

        public static IUser? signedInUser { get; set; }

        //public static bool AddUser(IUser userToAdd)
        //{
        //    if (ValidateUsername(userToAdd.Username))
        //    {
        //        User newUser = new(userToAdd.Username, userToAdd.Password, userToAdd.Location);
        //        users.Add(newUser);
        //        return true;
        //    }
        //    return false;
        //}
        public static bool AddUser(string username, string password, Country country)
        {
            if (ValidateUsername(username))
            {
                User newUser = new(username, password, country);
                users.Add(newUser);
                return true;
            }
            return false;
        }

        //public void RemoveUser(string username, string password, Country location)
        //{

        //}

        //public bool UpdateUsername(string username)
        //{

        //}

        private static bool ValidateUsername(string username)
        {
            bool isValidUsername = false;

            if (!string.IsNullOrEmpty(username))
            {
                isValidUsername = true;
            }

            foreach (var user in users)
            {
                if (user.Username.Equals(username))
                {
                    isValidUsername = false;
                    MessageBox.Show("The username is already taken, please try again!");
                    break;
                }
            }
            return isValidUsername;
        }

        public static bool signInUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    signedInUser = user;
                    return true;
                }
            }
            return false;
        }

    }
}
