using go.Api.Dto;
using go.Api.Mappers;
using go.Enums;
using go.Tests.TestData;
using Newtonsoft.Json;
using System;
using Xunit;

namespace go.Tests.Api
{
    public class QualifyMapperTests
    {
        private Qualify2Dto LoadDto()
        {
            return JsonConvert.DeserializeObject<Qualify2Dto>(TestDataLoader.Load("Api.Qualify2.json"));
        }

        [Fact]
        public void ToQualify1_MapsTrackWeatherTimeAndSetup()
        {
            Qualify q1 = QualifyMapper.ToQualify1(LoadDto());

            Assert.Equal(58, q1.track);
            Assert.Equal(Skies.Sunny, q1.weather.skies);
            Assert.Equal(26, q1.weather.temperature);
            Assert.Equal(12, q1.weather.humidity);
            Assert.Equal(TimeSpan.FromMilliseconds(119502), q1.time);
            Assert.Equal(500, q1.setup.fWing);
            Assert.Equal(TyreType.Medium, q1.setup.tyres);
            Assert.Equal(QualifyRisk.PushTheCarALittle, q1.risk);
        }

        [Fact]
        public void ToQualify2_MapsWeatherFuelAndRisk()
        {
            Qualify q2 = QualifyMapper.ToQualify2(LoadDto());

            Assert.Equal(58, q2.track);
            Assert.Equal(21, q2.weather.temperature);
            Assert.Equal(11, q2.weather.humidity);
            Assert.Equal(TimeSpan.FromMilliseconds(122455), q2.time);
            Assert.Equal(73, q2.fuel);
            Assert.Equal(QualifyRisk.PushTheCarALot, q2.risk);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("0")]
        public void ToQualify1_EmptyLapTime_MeansNoLapDone(string lapTime)
        {
            Qualify2Dto dto = new Qualify2Dto
            {
                trackId = 58,
                q1LapData = new QualifyLapDto { lapTime = lapTime, setFWing = "500" }
            };

            Qualify q1 = QualifyMapper.ToQualify1(dto);

            Assert.Equal(58, q1.track);
            Assert.Equal(TimeSpan.Zero, q1.time);
            Assert.Equal(0, q1.setup.fWing);
        }

        [Fact]
        public void ToQualify2_NoLapDone_KeepsOnlyTrack()
        {
            Qualify2Dto dto = new Qualify2Dto { trackId = 58 };

            Qualify q2 = QualifyMapper.ToQualify2(dto);

            Assert.Equal(58, q2.track);
            Assert.Equal(TimeSpan.Zero, q2.time);
        }
    }
}
