namespace ForecastIO
{
    public interface IForecastIORequest
    {
        ForecastIOResponse Get();

        string ApiCallsMade { get; }

        string ApiResponseTime { get; }
    }
}