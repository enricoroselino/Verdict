using Nebx.Verdict;
using Nebx.Verdict.AspNetCore.Extensions;
using Nebx.Verdict.AspNetCore.Models;

namespace Api;

public interface IWeatherRepository
{
    public Verdict<ResponseDto> GetWeatherForecast();
}

public class WeatherRepository : IWeatherRepository
{
    public WeatherRepository()
    {
    }

    public Verdict<ResponseDto> GetWeatherForecast()
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

        if (forecast.Length == 0) return Verdict.Failed("").NotFound();
        var response = ResponseDto.Create(forecast);
        
        return Verdict.Success(response);
    }
}