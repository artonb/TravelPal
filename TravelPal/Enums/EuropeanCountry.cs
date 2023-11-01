using System.ComponentModel.DataAnnotations;

namespace TravelPal.Enums
{
    public enum EuropeanCountry
    {
        Austria,
        Belgium,
        Bulgaria,
        Croatia,
        [Display(Name = "Republic of Cyprus")]
        Republic_of_Cyprus,
        [Display(Name = "Czech Republic")]
        Czech_Republic,
        Denmark,
        Estonia,
        Finland,
        France,
        Germany,
        Greece,
        Hungary,
        Ireland,
        Italy,
        Latvia,
        Lithuania,
        Luxembourg,
        Malta,
        Netherlands,
        Poland,
        Portugal,
        Romania,
        Slovakia,
        Slovenia,
        Spain,
        Sweden
    }
}
//Alternativa lösningar,


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

//public List<Travel> existingTravels { get; set; } = new()
//{
//    new Vacation("Malmö", Country.Sweden, 2, false),
//    new WorkTrip("Conference", "Stockholm", Country.Sweden, 4),
//};

