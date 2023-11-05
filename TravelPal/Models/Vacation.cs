using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        //Lägg till props
        public bool allInclusive { get; set; }
        //Lägg till constructor
        public Vacation(string destination, Country countries, int travellers, bool allInclusive) : base(destination, countries, travellers)
        {
            this.allInclusive = allInclusive;
        }
        //Lägg till metoder som overridear Travel
        public override string GetInfo()
        {
            return $"Your vacation is to {Destination} in the country of {Countries} with a total of {Travellers} people. It is {allInclusive} that you have all-inclusive!";
        }
    }
}
