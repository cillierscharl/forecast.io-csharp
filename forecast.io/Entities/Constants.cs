using System.ComponentModel;
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
        ar,
        az,
        be,
        bs,
        cs,
        de,
        el,
        en,
        es,
        fr,
        hr,
        hu,
        id,
        it,
        @is,
        kw,
        nb,
        nl,
        pl,
        pt,
        ru,
        sk,
        sr,
        sv,
        tet,
        tr,
        uk,
        [Description("x-pig-latin")]
        xpiglatin,
        zh,
        [Description("zh-tw")]
        zhtw
    }
}