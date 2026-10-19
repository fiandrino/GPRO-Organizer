using go.Api.Dto;

#nullable disable
namespace go.Api.Mappers
{
    // Converts the "UpdateCar" answer of the API into the Car2 object used by the program.
    public static class CarMapper
    {
        public static Car2 ToCar2(CarDto dto)
        {
            Car2 car = new Car2();

            car.power = dto.carPower;
            car.handling = dto.carHandl;
            car.acceleration = dto.carAccel;

            SetPart(car.chassis, dto.lvlChassis, dto.usaChassis);
            SetPart(car.engine, dto.lvlEngine, dto.usaEngine);
            SetPart(car.frontWing, dto.lvlFWing, dto.usaFWing);
            SetPart(car.rearWing, dto.lvlRWing, dto.usaRWing);
            SetPart(car.underbody, dto.lvlUnderbody, dto.usaUnderbody);
            SetPart(car.sidepods, dto.lvlSidepods, dto.usaSidepods);
            SetPart(car.cooling, dto.lvlCooling, dto.usaCooling);
            SetPart(car.gearBox, dto.lvlGear, dto.usaGear);
            SetPart(car.brakes, dto.lvlBrakes, dto.usaBrakes);
            SetPart(car.suspension, dto.lvlSusp, dto.usaSusp);
            SetPart(car.electronics, dto.lvlElectronics, dto.usaElectronics);

            return car;
        }

        private static void SetPart(CarPart part, int level, int wear)
        {
            part.level = level;
            part.wear = wear;
        }
    }
}
