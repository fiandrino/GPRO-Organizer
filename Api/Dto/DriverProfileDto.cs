#nullable disable
namespace go.Api.Dto
{
    // Answer of the "DriProfile" endpoint, only the fields used by the program.
    // When the account has no driver under contract, most fields are missing.
    public class DriverProfileDto
    {
        public string driName { get; set; }

        public string natName { get; set; }

        public int trophies { get; set; }

        public int races { get; set; }

        public int wins { get; set; }

        public int podiums { get; set; }

        public int points { get; set; }

        public int poles { get; set; }

        public int fastLaps { get; set; }

        public int overall { get; set; }

        public int energy { get; set; }

        public int concentration { get; set; }

        public int talent { get; set; }

        public int aggressiveness { get; set; }

        public int experience { get; set; }

        public int techInsight { get; set; }

        public int stamina { get; set; }

        public int charisma { get; set; }

        public int motivation { get; set; }

        public int reputation { get; set; }

        public int weight { get; set; }

        public int age { get; set; }

        // Text in the API, for example "370000".
        public string salary { get; set; }

        // Text in the API, for example "17".
        public string racesLeft { get; set; }

        public DriverTrackDto favTrack1 { get; set; }

        public DriverTrackDto favTrack2 { get; set; }

        public DriverTrackDto favTrack3 { get; set; }
    }

    public class DriverTrackDto
    {
        public int id { get; set; }
    }
}
