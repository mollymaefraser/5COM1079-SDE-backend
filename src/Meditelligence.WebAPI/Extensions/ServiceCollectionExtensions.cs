using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories;
using Meditelligence.DataAccess.Seeder;
using Microsoft.EntityFrameworkCore;

namespace Meditelligence.WebAPI.Extensions
{
    /// <summary>
    /// A class to provide wrapper extension methods for dependency injecting all services relating to Meditelligence, grouped by their position in the codebase.
    /// </summary>
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
            services.AddDbContext<MeditelligenceDBContext>(options => options.UseSqlite("DataSource=database.db"));

            // add repo classes.
            services.AddScoped<IIllnessRepo, IllnessRepo>();
            services.AddScoped<ISymptomRepo, SymptomRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
        }
    }
}
