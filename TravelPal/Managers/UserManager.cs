using System.Collections.Generic;
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
            new User("user", "password", Country.Sweden)
        };

        public static IUser signedInUser { get; set; }

        public static bool AddUser(string username, string password, Country location)
        {
            if (ValidateUsername(username))
            {
                User newUser = new(username, password, location);
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
                if (user.Username == username)
                {
                    isValidUsername = false;
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
