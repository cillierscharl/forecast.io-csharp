namespace ForecastIO
{
    public enum Unit
    {
        us,
        si,
        ca,
        uk,
        auto
    }

    public enum Exclude
    {
        currently,
        minutely,
        hourly,
        daily,
        alerts,
        flags
    }

    // Keeping this an enum for now to since only hourly is supported (not sure if the devs will allow the other types to be extended).
    public enum Extend
    {
        hourly
    }

    public enum Language
    {
        bs,
        de,
        en,
        es,
        fr,
        it,
        nl,
        pl,
        pt,
        ru,
        tet
    }

}
