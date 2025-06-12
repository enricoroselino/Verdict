using Api;
using Nebx.Verdict.AspNetCore.Extensions;
using Nebx.Verdict.AspNetCore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/weatherforecast", (IHttpContextAccessor accessor, IWeatherRepository weatherRepository) =>
    {
        var forecastResult = weatherRepository.GetWeatherForecast();
        if (!forecastResult.IsSuccess) return forecastResult.ToMinimalApiResult(accessor);

        var response = SuccessDto.Create(forecastResult.Value);
        return response.ToMinimalApiResult();
    })
    .WithName("GetWeatherForecast");

app.Run();