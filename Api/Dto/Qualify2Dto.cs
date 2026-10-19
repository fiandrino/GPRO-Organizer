#nullable disable
namespace go.Api.Dto
{
    // Answer of the "Qualify2" endpoint, only the fields used by the program.
    // It contains both qualifying sessions of the manager's own car.
    public class Qualify2Dto
    {
        public int trackId { get; set; }

        public QualifyWeatherDto weather { get; set; }

        public QualifyLapDto q1LapData { get; set; }

        public QualifyLapDto q2LapData { get; set; }
    }

    public class QualifyWeatherDto
    {
        public string q1Weather { get; set; }

        public int q1Temp { get; set; }

        public int q1Hum { get; set; }

        public string q2Weather { get; set; }

        public int q2Temp { get; set; }

        public int q2Hum { get; set; }
    }

    // One qualifying lap: the lap time and the setup used on it.
    // Tyres and risk are text, for example "Medium" and "Push the car a little".
    public class QualifyLapDto
    {
        // Lap time in seconds, for example "119.502". Empty when no lap was done.
        public string lapTime { get; set; }

        public string setFWing { get; set; }

        public string setRWing { get; set; }

        public string setEng { get; set; }

        public string setBra { get; set; }

        public string setGear { get; set; }

        public string setSusp { get; set; }

        public string setTyres { get; set; }

        public string setRisk { get; set; }

        // Only present in the Q2 lap.
        public string setFuel { get; set; }
    }
}
