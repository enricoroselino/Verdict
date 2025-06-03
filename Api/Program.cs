using Api;
using Nebx.Verdict.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/weatherforecast", (IHttpContextAccessor accessor) =>
    {
        var repo = new WeatherRepository();
        var forecastResult = repo.GetWeatherForecast();
        return forecastResult.ToMinimalApiResult(accessor);
    })
    .WithName("GetWeatherForecast");

app.Run();