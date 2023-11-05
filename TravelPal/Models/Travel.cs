using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Travel
    {
        //Lägg till props
        public string Destination { get; set; }
        public Country Countries { get; set; }
        public int Travellers { get; set; }

        //Lägg till constructor
        public Travel(string destination, Country countries, int travellers)
        {
            Destination = destination;
            Countries = countries;
            Travellers = travellers;
        }

        //Lägg till metoder
        virtual public string GetInfo()
        {
            return $"You are a total of {Travellers} people that are traveling to {Destination} in the country of {Countries}";
        }
    }
}
