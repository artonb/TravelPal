using TravelPal.Enums;

namespace TravelPal.Models
{
    public class WorkTrip : Travel
    {
        //Lägg till props
        public string MeetingDetails { get; set; }
        //Lägg till constructor
        public WorkTrip(string meetingDetails, string destination, Country countries, int travellers) : base(destination, countries, travellers)
        {
            MeetingDetails = meetingDetails;
        }
        //Lägg till metoder som overridear Travel
        public override string GetInfo()
        {
            return $"Your worktrip is to {Destination} in the country of {Countries} with a total of {Travellers} people. The meetings regards to {MeetingDetails}";
        }
    }
}
