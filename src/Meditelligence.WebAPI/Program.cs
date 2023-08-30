using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Seeder;
using Meditelligence.Models;
using Meditelligence.WebAPI.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

[ExcludeFromCodeCoverage]
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCors(options => options.AddPolicy("Policy", policy =>
            {
                policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
            })
        );

        builder.Services.AddMeditelligenceDbServices();
        builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        builder.Services.AddPredictiveServices();
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        //app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors();
        app.MapControllers();

        app.Run();
    }
}