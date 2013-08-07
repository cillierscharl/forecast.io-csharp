forecast.io-csharp
==================

C# Wrapper Library For [Forecast.io](http://forecast.io/)

------------------

### Install ###

    Install-Package Forecast.io

###Usage###

    using ForecastIO;
    // API Key, Lat, Long, Unit
    
    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f, Unit.si);
    var response = request.Get();
    
Returns the complete object : 

<p align="center">
  <img src="http://i.imgur.com/iVxt1VD.png" alt=""></img>
</p>
    
####Including the date####
    using ForecastIO;
    
    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f, DateTime.Now, Unit.si);
    var response = request.Get();

#####Using date/time extensions#####
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

####Include extra data - (Currently only hourly is supported by the API) Returns hourly data for the next seven days, rather than the next two.####

#####Please note that you cannot specify a date (TimeMachine request) as the extend parameter will be ignored.#####

    using ForecastIO;
    
    var extendBlocks = new Extend[] 
    {
        Extend.hourly
    };

    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f, Unit.si, extendBlocks);
    var response = request.Get();
    
####Exclude certain objects (returned as null)####
    using ForecastIO;
    
    var excludeBlocks = new Exclude[] 
    {
        Exclude.alerts,
        Exclude.currently
    };

    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f, DateTime.Now, Unit.si, null, excludeBlocks);
    var response = request.Get();
    
####Request Metadata####

Once a request has been made with `Get()` two properties namely `ApiResponseTime` and `ApiCallsMade` will be accesible on the request object.
Please note that if a request has not yet been made an exception will be thrown.
    
####Please note:####

 - You will require your own forecast.io [API Key](https://developer.forecast.io/)
 - Not all regions return forecasts by all periods (Daily, Minutely etc.)
 - Not all regions return all flags.
 

###Contributors###
 - f0xy
 - Ryan-Anderson
 - VibertJ
 - jugglingnutcase
 - squdgy
