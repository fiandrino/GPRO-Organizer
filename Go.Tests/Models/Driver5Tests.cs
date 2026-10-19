using Xunit;

namespace go.Tests.Models
{
    public class Driver5Tests
    {
        [Fact]
        public void CalculateAveragePointsPerRace_RoundsToTwoDecimals()
        {
            // Same numbers as the driver page used in the parser tests: the site shows 1.37.
            Driver5 driver = new Driver5 { pointsScored = 130, numberOfGps = 95 };

            Assert.Equal(1.37, driver.CalculateAveragePointsPerRace());
        }

        [Fact]
        public void CalculateAveragePointsPerRace_RoundsHalfUp()
        {
            Driver5 driver = new Driver5 { pointsScored = 1, numberOfGps = 8 };

            Assert.Equal(0.13, driver.CalculateAveragePointsPerRace());
        }

        [Fact]
        public void CalculateAveragePointsPerRace_NoRaces_ReturnsZero()
        {
            Driver5 driver = new Driver5 { pointsScored = 10, numberOfGps = 0 };

            Assert.Equal(0.0, driver.CalculateAveragePointsPerRace());
        }
    }
}
