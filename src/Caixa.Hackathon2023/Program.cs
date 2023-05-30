using Caixa.Hackathon2023;
using Caixa.Hackathon2023.Api;

var builder = WebApplication.CreateBuilder(args);
Startup.ConfigureBuilder(builder);

var app = builder.Build();
Startup.SetupMiddleware(app);

app.MapPost("/api/Simulacao", SimulacaoApi.ObterSimulacao);

app.Run();
