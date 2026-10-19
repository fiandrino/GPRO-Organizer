using go.Api.Dto;
using go.Utils;
using System;

#nullable disable
namespace go.Api.Mappers
{
    // Converts the "Qualify2" answer of the API into the Qualify objects used by the program.
    public static class QualifyMapper
    {
        public static Qualify ToQualify1(Qualify2Dto dto)
        {
            QualifyWeatherDto weather = dto.weather ?? new QualifyWeatherDto();

            return CreateQualify(
                dto.trackId,
                dto.q1LapData,
                weather.q1Weather,
                weather.q1Temp,
                weather.q1Hum
            );
        }

        public static Qualify ToQualify2(Qualify2Dto dto)
        {
            QualifyWeatherDto weather = dto.weather ?? new QualifyWeatherDto();

            Qualify qualify2 = CreateQualify(
                dto.trackId,
                dto.q2LapData,
                weather.q2Weather,
                weather.q2Temp,
                weather.q2Hum
            );

            if (dto.q2LapData != null)
            {
                qualify2.fuel = ApiNumber.ToInt(dto.q2LapData.setFuel);
            }

            return qualify2;
        }

        private static Qualify CreateQualify(int trackId, QualifyLapDto lap, string skies, int temperature, int humidity)
        {
            Qualify qualify = new Qualify();

            qualify.track = trackId;
            qualify.weather.skies = EnumConvert.String2Skies(skies ?? "");
            qualify.weather.temperature = temperature;
            qualify.weather.humidity = humidity;

            // No lap done in this session: only track and weather are known.
            double seconds = lap == null ? 0 : ApiNumber.ToDouble(lap.lapTime);

            if (seconds <= 0)
            {
                return qualify;
            }

            qualify.time = TimeSpan.FromMilliseconds(Math.Round(seconds * 1000));

            qualify.setup.fWing = ApiNumber.ToInt(lap.setFWing);
            qualify.setup.rWing = ApiNumber.ToInt(lap.setRWing);
            qualify.setup.engine = ApiNumber.ToInt(lap.setEng);
            qualify.setup.brakes = ApiNumber.ToInt(lap.setBra);
            qualify.setup.gear = ApiNumber.ToInt(lap.setGear);
            qualify.setup.susp = ApiNumber.ToInt(lap.setSusp);
            qualify.setup.tyres = EnumConvert.String2Tyres(lap.setTyres ?? "");

            qualify.risk = EnumConvert.String2QualifyRisk(lap.setRisk ?? "");

            return qualify;
        }
    }
}
