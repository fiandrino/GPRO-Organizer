using go.Api.Dto;
using go.Tests.TestData;
using Newtonsoft.Json;
using Xunit;

namespace go.Tests.Api
{
    public class DriverDtoTests
    {
        [Fact]
        public void DriverProfile_ParsesTextFields()
        {
            DriverProfileDto dto = JsonConvert.DeserializeObject<DriverProfileDto>(TestDataLoader.Load("Api.DriverProfile.json"));

            Assert.Equal("Maximilian Weidler", dto.driName);
            Assert.Equal("370000", dto.salary);
            Assert.Equal("17", dto.racesLeft);
        }

        [Fact]
        public void DriverProfile_ParsesFavoriteTracks()
        {
            DriverProfileDto dto = JsonConvert.DeserializeObject<DriverProfileDto>(TestDataLoader.Load("Api.DriverProfile.json"));

            Assert.Equal(35, dto.favTrack1.id);
            Assert.Equal(23, dto.favTrack2.id);
            Assert.Equal(57, dto.favTrack3.id);
        }
    }
}
