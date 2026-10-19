using go.Api.Dto;
using go.Api.Mappers;
using go.Tests.TestData;
using Newtonsoft.Json;
using Xunit;

namespace go.Tests.Api
{
    public class CarMapperTests
    {
        [Fact]
        public void ToCar2_MapsCarCharacter()
        {
            CarDto dto = JsonConvert.DeserializeObject<CarDto>(TestDataLoader.Load("Api.Car.json"));

            var car = CarMapper.ToCar2(dto);

            Assert.Equal(13, car.power);
            Assert.Equal(13, car.handling);
            Assert.Equal(13, car.acceleration);
        }

        [Fact]
        public void ToCar2_MapsLevelAndWearOfEachPart()
        {
            // Values chosen to tell level and wear apart.
            string json = "{ \"lvlEngine\": 7, \"usaEngine\": 18, \"lvlGear\": 6, \"usaGear\": 20 }";
            CarDto dto = JsonConvert.DeserializeObject<CarDto>(json);

            var car = CarMapper.ToCar2(dto);

            Assert.Equal(7, car.engine.level);
            Assert.Equal(18, car.engine.wear);
            Assert.Equal(6, car.gearBox.level);
            Assert.Equal(20, car.gearBox.wear);
        }

        [Fact]
        public void ToCar2_MapsFrontWingAndSuspension()
        {
            string json = "{ \"lvlFWing\": 4, \"usaFWing\": 31, \"lvlSusp\": 5, \"usaSusp\": 28 }";
            CarDto dto = JsonConvert.DeserializeObject<CarDto>(json);

            var car = CarMapper.ToCar2(dto);

            Assert.Equal(4, car.frontWing.level);
            Assert.Equal(31, car.frontWing.wear);
            Assert.Equal(5, car.suspension.level);
            Assert.Equal(28, car.suspension.wear);
        }
    }
}
