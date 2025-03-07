using System.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;

public sealed record WeatherInfo
{
    public string City { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public string Condition { get; set; } = string.Empty;
}

public class WeatherPlugin 
{
    private readonly ILogger<WeatherPlugin> _logger;

    public WeatherPlugin(ILogger<WeatherPlugin> logger)
    {
        _logger = logger;
    }

    [KernelFunction("get_weather")]
    [Description("Retrieves the weather for a given date and city")]
    public Task<WeatherInfo> GetWeather(DateTime dateTime, string city)
    {       
        _logger.LogDebug($"{nameof(GetWeather)} called with {dateTime} and {city}");

        // Mock weather data look up
        return Task.FromResult(new WeatherInfo
        {
            City = city,
            Temperature = 22.5,
            Condition = "Sunny"
        });
    }
}

public sealed record FlightInfo
{
    public string FlightNumber { get; set; } = string.Empty;
    public string Airline { get; set; } = string.Empty;
    public DateTime DepartureDateTime { get; set; }
}

public class FlightsPlugin 
{
    private readonly ILogger<FlightsPlugin> _logger;

    public FlightsPlugin(ILogger<FlightsPlugin> logger)
    {
        _logger = logger;
    }

    [KernelFunction("get_flights")]
    [Description("Retrieves a list of available flights for a given date, origin and destination")]
    public Task<IEnumerable<FlightInfo>> GetFlights(DateTime dateTime, string origin, string destination)
    {
        _logger.LogDebug($"{nameof(GetFlights)} called with date: {dateTime}, origin: {origin}, destination: {destination}");

        // Mock flight look up
        return Task.FromResult(new List<FlightInfo> 
        {            
            new FlightInfo
            {
                FlightNumber = "QF140",
                Airline = "Qantas Airways",
                DepartureDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 6, 0, 0)
            },
            new FlightInfo
            {
                FlightNumber = "UL607",
                Airline = "SriLankan Airlines",
                DepartureDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 17, 10, 0)
            },
            new FlightInfo
            {
                FlightNumber = "SQ468",
                Airline = "Singapore Airlines",
                DepartureDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 22, 10, 0)
            }
        } as IEnumerable<FlightInfo>);
    }
}

public sealed record HotelInfo
{
    public string HotelName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Rating { get; set; }
}

public class HotelsPlugin 
{
    private readonly ILogger<HotelsPlugin> _logger;

    public HotelsPlugin(ILogger<HotelsPlugin> logger)
    {
        _logger = logger;
    }

    [KernelFunction("get_hotels")]
    [Description("Retrieves a list of hotels for a given city")]
    public Task<IEnumerable<HotelInfo>> GetHotels(string city)
    {
        _logger.LogDebug($"{nameof(GetHotels)} called with city: {city}");

        // Mock hotels look up
        return Task.FromResult(new List<HotelInfo> 
        {            
            new HotelInfo
            {
                HotelName = "Hilton Colombo",
                Address = "2 Gardiner Road, Colombo 02",
                Rating = 8.9m
            },
            new HotelInfo
            {
                HotelName = "Shangri-La Hotel, Colombo",
                Address = "1 Galle Face, Colombo 02",
                Rating = 9.9m
            },
            new HotelInfo
            {
                HotelName = "Cinnamon Grand Colombo",
                Address = "77 Galle Road, Colombo 03",
                Rating = 9.2m
            }
        } as IEnumerable<HotelInfo>);
    }
}

public sealed record CurrencyConversionRate
{
    public string SourceCurrency { get; set; } = string.Empty;
    public string TargetCurrency { get; set; } = string.Empty;
    public decimal ConversionRate { get; set; }
}

public class CurrencyPlugin
{
    private readonly ILogger<CurrencyPlugin> _logger;

    public CurrencyPlugin(ILogger<CurrencyPlugin> logger)
    {
        _logger = logger;
    }

    [KernelFunction("get_currency_conversion_rate")]
    [Description("Retrieves the conversion rate for a given source and target currency")]
    public Task<CurrencyConversionRate> GetCurrencyConversionRate(string sourceCurrency, string targetCurrency)
    {
        _logger.LogDebug($"{nameof(GetCurrencyConversionRate)} called with sourceCurrency: {sourceCurrency}, targetCurrency: {targetCurrency}");

        // Mock currency conversion look up
        return Task.FromResult(new CurrencyConversionRate
        {
            SourceCurrency = sourceCurrency,
            TargetCurrency = targetCurrency,
            ConversionRate = 166.85m
        });
    }
}