[![.NET](https://github.com/cillierscharl/forecast.io-csharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/cillierscharl/forecast.io-csharp/actions/workflows/dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/Forecast.io.svg)](https://www.nuget.org/packages/Forecast.io/)

forecast.io-csharp
==================

C# Wrapper Library For [Forecast.io](http://forecast.io/)

> [!WARNING]
> **Archived. The Dark Sky API this library wraps was shut down on March 31, 2023, so it no longer works.**
>
> Forecast.io opened its API in 2013 and became Dark Sky in 2016, when this library moved to `api.darksky.net`. Apple bought Dark Sky in 2020 and switched the API off three years later. Neither `api.forecast.io` nor `api.darksky.net` exists any more.
>
> From 2013 to 2022 the library picked up fixes and features from 11 contributors and about 185,000 downloads on NuGet. Thanks to everyone who helped.
>
> For weather data today, try:
>
> - [Apple WeatherKit](https://developer.apple.com/weatherkit/), Dark Sky's official successor. It has a REST API and needs an Apple Developer Program membership.
> - [Pirate Weather](https://pirateweather.net/), which serves a Dark Sky–compatible API.
> - [Open-Meteo](https://open-meteo.com/), which is free for non-commercial use and needs no API key.
>
> The code and the docs below are left as they were, for posterity.

------------------

### Install ###

    Install-Package Forecast.io

### Usage ###

    using ForecastIO;
    // API key, Lat, Long, Unit

    var request = new ForecastIORequest(key, 37.8267f, -122.423f, Unit.si);
    var response = request.Get();

    var request = new ForecastIORequest(key, 43.4499376f, -79.7880999f, Unit.si);
    var response = await request.GetAsync();

Returns the complete object :

<p align="center">
  <img src="https://i.imgur.com/iVxt1VD.png" alt=""></img>
</p>

#### Including the date ####
    using ForecastIO;

    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f, DateTime.Now, Unit.si);
    var response = request.Get();

##### Using date/time extensions #####
    using ForecastIO;
    using ForecastIO.Extensions;

    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f, DateTime.Now, Unit.si);
    var response = request.Get();

    // Date/Time is represented by a Unix Timestamp
    var currentTime = response.currently.time;

    // Return a .NET DateTime object (UTC) using an extension (Notice the additional 'using' statement)
    var _currentTime = currentTime.ToDateTime();

    // Return a local .NET DateTime object
    var _localCurrentTime = currentTime.ToDateTime().ToLocalTime();

#### Include extra data - (Currently only hourly is supported by the API) Returns hourly data for the next seven days, rather than the next two. ####

##### Please note that you cannot specify a date (TimeMachine request) as the extend parameter will be ignored. #####

    using ForecastIO;

    var extendBlocks = new Extend[]
    {
        Extend.hourly
    };

    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f, Unit.si, extendBlocks);
    var response = request.Get();

#### Exclude certain objects (returned as null) ####
    using ForecastIO;

    var excludeBlocks = new Exclude[]
    {
        Exclude.alerts,
        Exclude.currently
    };

    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f, DateTime.Now, Unit.si, null, excludeBlocks);
    var response = request.Get();

#### Request Metadata ####

Once a request has been made with `Get()` two properties namely `ApiResponseTime` and `ApiCallsMade` will be accesible on the request object.
Please note that if a request has not yet been made an exception will be thrown.

#### Please note: ####

 - You will require your own forecast.io [API Key](https://developer.forecast.io/)
 - Not all regions return forecasts by all periods (Daily, Minutely etc.)
 - Not all regions return all flags.
