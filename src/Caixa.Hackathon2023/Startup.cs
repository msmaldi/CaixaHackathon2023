namespace Caixa.Hackathon2023;

using Caixa.Hackathon2023.Entities;

public class Startup
{
    public static void ConfigureBuilder(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new Exception("Connection String not configured");

        builder.Services.AddSingleton<HackDb>(new HackDb(connectionString));
        builder.Services.AddSingleton<EventSender>(new EventSender());

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void SetupMiddleware(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
    }
}
