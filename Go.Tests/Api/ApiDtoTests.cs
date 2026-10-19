using go.Api;
using go.Api.Dto;
using go.Tests.TestData;
using Newtonsoft.Json;
using Xunit;

namespace go.Tests.Api
{
    public class ApiDtoTests
    {
        [Fact]
        public void Menu_ParsesManagerAndTeam()
        {
            MenuDto menu = JsonConvert.DeserializeObject<MenuDto>(TestDataLoader.Load("Api.Menu.json"));

            Assert.Equal(943299, menu.IDM);
            Assert.Equal("Beta", menu.fName);
            Assert.Equal("Tester", menu.lName);
            Assert.Equal("Rookie - 31", menu.group);
            Assert.Equal(66, menu.teamId);
            Assert.Equal(30357, menu.driverId);
        }

        [Fact]
        public void Office_ParsesSeasonAndRace()
        {
            OfficeDto office = JsonConvert.DeserializeObject<OfficeDto>(TestDataLoader.Load("Api.Office.json"));

            Assert.Equal(99, office.Season);
            Assert.Equal(8, office.Race);
        }

        [Fact]
        public void Office_EmptyTechnicalDirectorIdBecomesZero()
        {
            // The API sends an empty string when there is no technical director.
            OfficeDto office = JsonConvert.DeserializeObject<OfficeDto>(TestDataLoader.Load("Api.Office.json"));

            Assert.Equal(0, office.TechnicalDirectorId);
        }

        [Fact]
        public void Office_EndOfSeason_UsesRace18()
        {
            OfficeDto office = new OfficeDto { seasonNb = "99", raceNb = "8", endOfSeason = 1 };

            Assert.Equal(18, office.Race);
        }

        [Fact]
        public void Qualify2_ParsesTrackAndLapTimes()
        {
            Qualify2Dto qualify = JsonConvert.DeserializeObject<Qualify2Dto>(TestDataLoader.Load("Api.Qualify2.json"));

            Assert.Equal(58, qualify.trackId);
            Assert.Equal(119.502, ApiNumber.ToDouble(qualify.q1LapData.lapTime), 3);
            Assert.Equal(122.455, ApiNumber.ToDouble(qualify.q2LapData.lapTime), 3);
            Assert.Equal("Medium", qualify.q2LapData.setTyres);
            Assert.Equal("73", qualify.q2LapData.setFuel);
        }
    }
}
