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
            new User("user", "password", Country.Sweden)
            {
                Travels = new()
                {
                    new Vacation("Malmö", Country.Sweden, 2, false),
                    new WorkTrip("Conference", "Stockholm", Country.Sweden, 4)
                }
            }
        };


        public static IUser? signedInUser { get; set; }

        public static bool AddUser(string username, string password, Country country /*List<Travel> travels*/)
        {
            if (ValidateUsername(username))
            {
                User newUser = new(username, password, country);
                users.Add(newUser);
                return true;
            }
            return false;
        }

        public static List<Travel> GetAllUserTravels()
        {
            // Returnera alla användares resor

            List<Travel> allUserTravels = new();

            foreach (var user in users)
            {
                if (user is User)
                {
                    User u = (User)user;

                    allUserTravels.AddRange(u.Travels);
                }
            }

            return allUserTravels;
        }

        public static void AdminRemoveTravel(Travel travelToRemove)
        {
            foreach (var user in users)
            {
                if (user is User)
                {
                    foreach (var travel in ((User)user).Travels)
                    {
                        if (travel == travelToRemove)
                        {
                            ((User)user).Travels.Remove(travelToRemove);

                            return;
                        }
                    }
                }
            }
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
