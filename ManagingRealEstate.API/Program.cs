using FluentValidation;
using ManagingRealEstate.API.Common;
using ManagingRealEstate.API.Database;
using ManagingRealEstate.API.Endpoints;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ManagingRealEstate.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register Infrastructure services.
        builder.Services.AddScoped<IDbContext, ApplicationDbContext>();
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("RealEstateDb"));

        // Register MediatR and FluentValidation.
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Services.AddMediatR(cng => cng.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        builder.Services.AddOpenApi();
        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            SeedData.SeedDatabase(app);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RealEstate Api");
                c.DocumentTitle = "RealEstate API documentation";
            });
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        // Map minimal APIs
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRealEstateEndpoints();
        });

        app.Run();
    }
}
