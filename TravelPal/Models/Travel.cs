using System;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Travel
    {
        public string Destination { get; set; }
        public Country Countries { get; set; }
        public int Travellers { get; set; }
        //public List<PackingListItem> PackingList { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        //public int travelDays { get; set; }

        public Travel(string destination, Country countries, int travellers)
        {
            Destination = destination;
            Countries = countries;
            Travellers = travellers;
        }

        virtual public string GetInfo()
        {
            return $"You are a total of {Travellers} people that are traveling to {Destination} in the country of {Countries}";
        }

        //private int calculateTravelDays()
        //{

        //}
    }
}
