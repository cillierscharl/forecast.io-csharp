forecast.io-csharp
==================

C# Wrapper Library For [Forecast.io](http://forecast.io/)

------------------

###Usage###

    using ForecastIO;
    
    var request = new ForecastIORequest("YOUR API KEY", 37.8267f, -122.423f);
    var response = request.Get();

Returns the complete object : 
<p align="center">
  <img src="http://i.imgur.com/abK2kzi.png" alt=""></img>
</p>

Please note:

 - You will require your own forecast.io [API Key](https://developer.forecast.io/)
 - Not all regions return forecasts by all periods (Daily, Minutely etc.)
 - Not all regions return all flags.
