#nullable disable
namespace go.Api.Dto
{
    // Answer of the "office" endpoint, only the fields used by the program.
    // The API sends numbers as text, and an empty text when a value is missing.
    public class OfficeDto
    {
        public string seasonNb { get; set; }

        public string raceNb { get; set; }

        // 1 when the season is over, 0 otherwise.
        public int endOfSeason { get; set; }

        public string tdId { get; set; }

        public int Season => ApiNumber.ToInt(seasonNb);

        public int Race => endOfSeason == 1 ? 18 : ApiNumber.ToInt(raceNb);

        public int TechnicalDirectorId => ApiNumber.ToInt(tdId);
    }
}
