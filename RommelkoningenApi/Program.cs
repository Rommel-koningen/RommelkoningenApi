using Microsoft.EntityFrameworkCore;
using RommelkoningenApi.Models;
using RommelkoningenApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString =
builder.Configuration["connectionstring"];

var apiKey =
builder.Configuration["apikey"];

builder.Services.AddDbContext<AfvalDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();


// Define your constants
const string API_KEY_NAME = "Api-Key-Name";
string API_KEY = apiKey; // Secure this in real apps

// Add API key middleware
app.Use(async (context, next) =>
{
    if (!context.Request.Headers.TryGetValue(API_KEY_NAME, out var extractedApiKey))
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("API Key was not provided.");
        return;
    }

    if (!API_KEY.Equals(extractedApiKey))
    {
        context.Response.StatusCode = 403;
        await context.Response.WriteAsync("Unauthorized client.");
        return;
    }

    await next();
});

// Define a sample endpoint
app.MapGet("/secure-data", () =>
{
    return Results.Ok("You accessed protected data!");
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
