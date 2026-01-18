using crud_csharp.Data;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Options;
using crud_csharp.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar servicios



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IAlumnoService, AlumnoService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCORS",
                      builder => builder.WithOrigins(
                                        "http://localhost:8080",
                                        "http://localhost:5500",
                                        "http://127.0.0.1:8080",
                                        "http://127.0.0.1:5500"
                                        ) // Orígenes permitidos
                                        .AllowAnyMethod() // Métodos (GET, POST, etc.)
                                        .AllowAnyHeader()); // Encabezados
});

var app = builder.Build();


// ... luego en el pipeline de ejecución
app.UseCors("PoliticaCORS"); // O app.UseCors(); para usar la política por defecto


// app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
