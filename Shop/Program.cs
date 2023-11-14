using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop.Handlers;
using Shop.Notifications;
using Shop.Repository.Base;

namespace Shop
{
    public class Program
    {
       public static void Main(string[] args)
        {                
       

        var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddLogging(builder =>
            {
                builder.AddConsole(); // Add console logging
                builder.AddDebug();   // Add debug output logging
            });
            builder.Services.AddDbContext<DBContextConnection>();
            builder.Services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            // Add services to the container.
            builder.Services.AddTransient<INotificationHandler<FoodNotification>, FoodCreatedNotificationHandler>();
            builder.Services.AddControllers();
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}