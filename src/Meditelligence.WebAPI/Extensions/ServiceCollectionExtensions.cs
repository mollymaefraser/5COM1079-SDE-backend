using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.DataAccess.Seeder;
using Meditelligence.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Meditelligence.WebAPI.Extensions
{
    /// <summary>
    /// A class to provide wrapper extension methods for dependency injecting all services relating to Meditelligence, grouped by their position in the codebase.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all DB services as created in the Meditelligence.DataAccess project area.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        public static void AddMeditelligenceDbServices(this IServiceCollection services)
        {
            // add DB infrastructure
            services.AddSingleton<IMeditelligenceDBSeeder, MeditelligenceDBSeeder>();

            //services.AddDbContext<MeditelligenceDBContext>(options => options.UseInMemoryDatabase("database.db"));
            services.AddDbContext<MeditelligenceDBContext>(options => options.UseSqlite("DataSource=database.db"));

            // add repo classes.
            services.AddScoped<IIllnessRepo, IllnessRepo>();
            services.AddScoped<ISymptomRepo, SymptomRepo>();
            services.AddScoped<ILocationRepo, LocationRepo>();
            services.AddScoped<ILocationToServiceRepo, LocationToServiceRepo>();
            services.AddScoped<IUserLogsToSymptomsRepo, UserLogsToSymptomsRepo>();
            services.AddScoped<IIllnessToSymptomRepo, IllnessToSymptomRepo>();
            services.AddScoped<IUserLogRepo, UserLogRepo>();
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ILocationRepo, LocationRepo>();
            services.AddScoped<ILocationToServiceRepo, LocationToServiceRepo>();
            services.AddScoped<IUserLogsToSymptomsRepo, UserLogsToSymptomsRepo>();
            services.AddScoped<IIllnessToSymptomRepo, IllnessToSymptomRepo>();
        }

        public static void AddPredictiveServices(this IServiceCollection services)
        {
            services.AddTransient<IDiseasePredictionService, DiseasePredictionService>();
        }
    }
}
