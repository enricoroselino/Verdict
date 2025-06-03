using Nebx.Verdict;
using Nebx.Verdict.AspNetCore.Extensions;

namespace Api;

public interface IWeatherRepository
{
    public Verdict<WeatherForecast[]> GetWeatherForecast();
}

public class WeatherRepository : IWeatherRepository
{
    public WeatherRepository()
    {
    }

    public Verdict<WeatherForecast[]> GetWeatherForecast()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();

        return Verdict
            .Failed("")
            .BadRequest();
    }
}