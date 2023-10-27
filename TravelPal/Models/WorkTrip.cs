using TravelPal.Enums;

namespace TravelPal.Models
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string meetingDetails, string destination, Country countries, int travellers) : base(destination, countries, travellers)
        {
            MeetingDetails = meetingDetails;
        }

        public void Trip()
        {

        }

        public string GetInfo()
        {
            return $"Your worktrip is to {Destination} in the country of {Countries} with a total of {Travellers} people. You are traveling there on the date of {startDate} and you are going home on the date of {endDate}.";
        }
    }
}
