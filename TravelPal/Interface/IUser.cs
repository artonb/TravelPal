﻿using TravelPal.Enums;

namespace TravelPal.Interface
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
    }
}
