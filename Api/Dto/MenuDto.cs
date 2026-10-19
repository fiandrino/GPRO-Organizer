#nullable disable
namespace go.Api.Dto
{
    // Answer of the "Menu" endpoint. Names follow the JSON names of the API.
    public class MenuDto
    {
        public int IDM { get; set; }

        public string fName { get; set; }

        public string lName { get; set; }

        public string group { get; set; }

        public int teamId { get; set; }

        public int driverId { get; set; }

        public int apiRequestsRemaining { get; set; }
    }
}
