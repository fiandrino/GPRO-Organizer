#nullable disable
namespace go.Api.Dto
{
    // Answer of the "UpdateCar" endpoint.
    // lvl* is the level of each part, usa* is its wear.
    public class CarDto
    {
        public int carPower { get; set; }

        public int carHandl { get; set; }

        public int carAccel { get; set; }

        public int lvlChassis { get; set; }

        public int lvlEngine { get; set; }

        public int lvlFWing { get; set; }

        public int lvlRWing { get; set; }

        public int lvlUnderbody { get; set; }

        public int lvlSidepods { get; set; }

        public int lvlCooling { get; set; }

        public int lvlGear { get; set; }

        public int lvlBrakes { get; set; }

        public int lvlSusp { get; set; }

        public int lvlElectronics { get; set; }

        public int usaChassis { get; set; }

        public int usaEngine { get; set; }

        public int usaFWing { get; set; }

        public int usaRWing { get; set; }

        public int usaUnderbody { get; set; }

        public int usaSidepods { get; set; }

        public int usaCooling { get; set; }

        public int usaGear { get; set; }

        public int usaBrakes { get; set; }

        public int usaSusp { get; set; }

        public int usaElectronics { get; set; }
    }
}
