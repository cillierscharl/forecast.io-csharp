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

    
####Exclude certain objects (returned as null)####
    using ForecastIO;
    
    var excludeBlocks = new Exclude[] 
    {
        Exclude.alerts,
        Exclude.currently
    };
    
    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f, DateTime.Now, Unit.si, excludeBlocks);
    var response = request.Get();


Please note:

 - You will require your own forecast.io [API Key](https://developer.forecast.io/)
 - Not all regions return forecasts by all periods (Daily, Minutely etc.)
 - Not all regions return all flags.
 

###Contributors###
 - f0xy
 - Ryan-Anderson
 - VibertJ
