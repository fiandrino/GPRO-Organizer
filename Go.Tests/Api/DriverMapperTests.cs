using go.Api.Dto;
using go.Api.Mappers;
using go.Tests.TestData;
using Newtonsoft.Json;
using Xunit;

namespace go.Tests.Api
{
    public class DriverMapperTests
    {
        private DriverProfileDto LoadDto()
        {
            return JsonConvert.DeserializeObject<DriverProfileDto>(TestDataLoader.Load("Api.DriverProfile.json"));
        }

        [Fact]
        public void ToDriver5_MapsNameAndNationality()
        {
            var driver = DriverMapper.ToDriver5(LoadDto(), 42);

            Assert.Equal(42, driver.id);
            Assert.Equal("Maximilian Weidler", driver.name);
            Assert.Equal("Germany", driver.nationality);
        }

        [Fact]
        public void ToDriver5_MapsResults()
        {
            var driver = DriverMapper.ToDriver5(LoadDto(), 42);

            Assert.Equal(26, driver.numberOfGps);
            Assert.Equal(16, driver.pointsScored);
            Assert.Equal(1, driver.podiums);
            Assert.Equal(0, driver.wins);
            Assert.Equal(0.62, driver.avPointsPerrace);
        }

        [Fact]
        public void ToDriver5_MapsAttributesAndContract()
        {
            var driver = DriverMapper.ToDriver5(LoadDto(), 42);

            Assert.Equal(100, driver.energy);
            Assert.Equal(34, driver.experience);
            Assert.Equal(108, driver.technicalInsight);
            Assert.Equal(370000, driver.salary);
            Assert.Equal(17, driver.racesLeftOfContract);
        }

        [Fact]
        public void ToDriver5_KeepsOnlySetFavoriteTracks()
        {
            var driver = DriverMapper.ToDriver5(LoadDto(), 42);

            Assert.Equal(new[] { 35, 23, 57 }, driver.favoriteTracks);
        }

        [Fact]
        public void ToDriver5_NoRaces_HasZeroAveragePoints()
        {
            var dto = new DriverProfileDto { races = 0, points = 0 };

            var driver = DriverMapper.ToDriver5(dto, 42);

            Assert.Equal(0.0, driver.avPointsPerrace);
            Assert.Empty(driver.favoriteTracks);
        }
    }
}
