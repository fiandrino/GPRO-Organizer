# GPRO API

This folder reads data from the GPRO API instead of the web pages.
Spec: https://api.gpro.net/gpro-public-api.yml

The scraping code in `Parsers/` stays. If the API is off or a call fails, the web page is used.

## Use it

1. In the GPRO app, open **Miscellaneous > API access** and copy the token.
2. In the program, open **Settings > API**, tick the box and paste the token.

The login with username and password is still needed for the pages not migrated yet.

## Files

| Path | What it does |
|---|---|
| `ApiClient.cs` | Sends the request with the token and reads the JSON. |
| `ApiSettings.cs` | Saves the box and the token. `UseApi` is true only with the box ticked **and** a token. |
| `ApiFallback.cs` | Calls the API. Returns `null` if it is off or fails. |
| `ApiNumber.cs` | `ToInt`, `ToDouble`: text to number, 0 if empty or wrong. |
| `Dto/` | Classes that match the JSON. No logic. |
| `Mappers/` | Turn a DTO into the program model (`Car2`, `Driver5`...). |

Tests: `Go.Tests/Api/`. JSON examples: `Go.Tests/TestData/Api/`.

## How a parser uses it

```csharp
Car2 car = ApiFallback.Load<CarDto, Car2>("UpdateCar", CarMapper.ToCar2);

if (car != null)
    return car;

// Old scraping code.
return CarParser.GetCar(Datas.Communications.GetPage("UpdateCar.asp"));
```

Do not add `try/catch` around API calls: `ApiFallback` already does it.

## Add an endpoint

1. **Spec**: find the path, the parameters and the type of each field.
2. **Example**: copy the spec `example` to `Go.Tests/TestData/Api/<Name>.json`.
   Remove only big unused fields (for example SVG images).
3. **DTO** in `Dto/`: same names as the JSON. If a number can arrive as text or empty,
   declare it `string` and convert it with `ApiNumber`.
4. **Mapper** in `Mappers/`: only copy and convert. No calculations.
   If the API does not send a value, add a method to the model
   (example: `Driver5.CalculateAveragePointsPerRace`) and call it.
5. **Parser**: call `ApiFallback.Load`, then the old scraping code.
6. **`Go.csproj`**: add the new files, one line each:
   `<Compile Include="Api\Dto\TechnicalDirectorDto.cs" />`
7. **Tests** in `Go.Tests/Api/`: the DTO reads the example, the mapper gives the expected values.
8. **Table below**: update the status.

## Rules

- Never change the **fields** of the models saved in `go.dat` (`Car2`, `Driver5`...).
  Adding a method is fine.
- Keep the scraping code until the maintainers decide to remove it.
- Never write the token in the log.
- The manager name and the group name still come from the home page, because the group name
  is used in the address of pages not migrated yet. The API values are only written to the log.

## Log

The log is `error.log`, next to the program.

| Line | Meaning |
|---|---|
| `GPRO API OK: Menu` | The endpoint worked (written once per run). |
| `GPRO API <endpoint> failed, using the web page: ...` | The API failed, the web page was used. |
| `GPRO API identity failed, using home page data: ...` | Same, for `Menu` and `office`. |
| `GPRO API differs from home page - <field>: ...` | The API value is different from the home page. |
| `GPRO API requests remaining: N` | Requests left. |

## Build and test

Close the program first (a running `go.exe` blocks the build). Then:

```bash
msbuild Go.Tests/Go.Tests.csproj -t:Build -p:Configuration=Debug
dotnet test Go.Tests/Go.Tests.csproj --no-restore --no-build
```

`dotnet test` alone can fail on recent .NET SDKs, so build with MSBuild first.

## Status

| Data | Endpoint | Parser | Status |
|---|---|---|---|
| Manager id, driver id, technical director id, season, race | `Menu`, `office` | `Communication.LoadIdentityFromApi` | API |
| Car and parts | `UpdateCar` | `CarParser.GetCar` | API |
| Qualifying 1 and 2 | `Qualify2` | `QualifyParser` | API |
| Driver | `DriProfile` | `DriverParser.GetDriver` | API |
| Technical director | `TDProfile` | `TechnicalDirectorParser` | scraping |
| Staff | `StaffAndFacilities` | `StaffParser` | scraping |
| Practice | `Practice` | `PracticeParser` | scraping |
| Testing | `Testing` | `TestingParser` | scraping |
| Race setup | `RaceSetup` | `StrategyParser` | scraping |
| Calendar | `Calendar` | `SeasonParser` | scraping |
| Finances | `EconomyHistory` | `FinanceParser` | scraping |
| Sponsors | `NegOverview` | `SponsorParser` | scraping |
| Race analysis | `RaceAnalysis` | `RaceAnalysisParser` | scraping |
| Race summary | `RaceSummary` | `RaceSummaryParser` | scraping |
| Tracks | `Tracks`, `TrackProfile` | `TrackParser` | scraping |
| Tyre supplier | `TyreSuppliers` | `TyreSupplierParser` | scraping |
| Login | — | `Communication` | still needed for scraping |
