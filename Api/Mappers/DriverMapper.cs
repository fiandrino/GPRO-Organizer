using System.Collections.Generic;
using go.Api.Dto;

#nullable disable
namespace go.Api.Mappers
{
    // Converts the "DriProfile" answer of the API into the Driver5 object used by the program.
    public static class DriverMapper
    {
        public static Driver5 ToDriver5(DriverProfileDto dto, int id)
        {
            Driver5 driver = new Driver5();

            driver.id = id;
            driver.name = dto.driName ?? "";
            driver.nationality = dto.natName ?? "";

            driver.trophies = dto.trophies;
            driver.numberOfGps = dto.races;
            driver.wins = dto.wins;
            driver.podiums = dto.podiums;
            driver.pointsScored = dto.points;
            driver.polePositions = dto.poles;
            driver.fastestLaps = dto.fastLaps;

            // The API does not send the average, so the model works it out.
            driver.avPointsPerrace = driver.CalculateAveragePointsPerRace();

            driver.overall = dto.overall;
            driver.energy = dto.energy;
            driver.concentration = dto.concentration;
            driver.talent = dto.talent;
            driver.aggresiveness = dto.aggressiveness;
            driver.experience = dto.experience;
            driver.technicalInsight = dto.techInsight;
            driver.stamina = dto.stamina;
            driver.charisma = dto.charisma;
            driver.motivation = dto.motivation;
            driver.reputation = dto.reputation;
            driver.weight = dto.weight;
            driver.age = dto.age;

            driver.salary = ApiNumber.ToInt(dto.salary);
            driver.racesLeftOfContract = ApiNumber.ToInt(dto.racesLeft);

            driver.favoriteTracks = FavoriteTracks(dto);

            return driver;
        }

        // Only the tracks that are set (id greater than zero) are kept.
        private static int[] FavoriteTracks(DriverProfileDto dto)
        {
            List<int> tracks = new List<int>();

            AddTrack(tracks, dto.favTrack1);
            AddTrack(tracks, dto.favTrack2);
            AddTrack(tracks, dto.favTrack3);

            return tracks.ToArray();
        }

        private static void AddTrack(List<int> tracks, DriverTrackDto track)
        {
            if (track != null && track.id > 0)
            {
                tracks.Add(track.id);
            }
        }
    }
}
