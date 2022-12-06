using Links_Clients.Helpers;
using Microsoft.EntityFrameworkCore;
using System;

namespace Links_Clients
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("DbSettings.json").Build();
            string connectionStr = configuration.GetConnectionString("ApiDbContext");

            builder.Services.AddDbContext<ClientsDbContext>(o => o.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));

            builder.Services.AddAutoMapper(typeof(ClientsMapper));

            builder.Services.AddSignalR();

            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapHub<SignalR_Hub>("/signalRhub");

            app.UseHttpsRedirection();

            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}