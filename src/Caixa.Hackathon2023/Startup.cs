using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caixa.Hackathon2023.Entities;

namespace Caixa.Hackathon2023
{
    public class Startup
    {
        public static void ConfigureBuilder(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new Exception("Connection String not configured");

            builder.Services.AddSingleton<HackDb>(new HackDb(connectionString));

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
}