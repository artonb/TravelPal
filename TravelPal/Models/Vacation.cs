using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public bool allInclusive { get; set; }
        public Vacation(string destination, Country countries, int travellers, bool allInclusive) : base(destination, countries, travellers)
        {
            this.allInclusive = allInclusive;
        }
        public string GetInfo()
        {
            return $"Your vacation is to {Destination} in the country of {Countries} with a total of {Travellers} people.";
        }
    }
}
