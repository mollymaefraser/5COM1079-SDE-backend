using Meditelligence.DataAccess.Seeder;
using Meditelligence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Context
{
    /// <summary>
    /// The derived <see cref="DbContext"/> class for specific use within Meditelligence.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MeditelligenceDBContext : DbContext
    {
        private readonly IMeditelligenceDBSeeder _seeder;

        /// <summary>
        /// Database set for all illness records.
        /// </summary>
        public DbSet<Illness> Illnesses { get; set; }

        /// <summary>
        /// Database set for all symptom records.
        /// </summary>
        public DbSet<Symptom> Symptoms { get; set; }

        /// <summary>
        /// Database set for join table between Symptom and Illness.
        /// </summary>
        public DbSet<IllnessToSymptom> IllnessToSymptoms { get; set; }

        /// <summary>
        /// Database set for all location records.
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Database set for join table between location and service.
        /// </summary>
        public DbSet<LocationToService> LocationToServices { get; set; }

        /// <summary>
        /// Database set for all service records.
        /// </summary>
        public DbSet<Service> Services { get; set; }

        /// <summary>
        /// Database set for all users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Database set for user logs.
        /// </summary>
        public DbSet<History> UserLogs { get; set; }

        /// <summary>
        /// Database set for join table between user log and symptoms.
        /// </summary>
        public DbSet<HistorySymptom> UserLogToSymptoms { get; set; }

        /// <summary>
        /// Initialises DbContext object with options and seeder.
        /// </summary>
        /// <param name="options">The database options to be passed in</param>
        /// <param name="seeder">The seeder class used to populate the database migration.</param>
        public MeditelligenceDBContext(DbContextOptions<MeditelligenceDBContext> options, IMeditelligenceDBSeeder seeder)
            : base(options)
        {
            _seeder = seeder;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Illness>().HasData(_seeder.SeedIllnesses());
            modelBuilder.Entity<Symptom>().HasData(_seeder.SeedSymptoms());
            modelBuilder.Entity<IllnessToSymptom>().HasData(_seeder.SeedIllnessToSymptoms());
            modelBuilder.Entity<Location>().HasData(_seeder.SeedLocations());
            modelBuilder.Entity<LocationToService>().HasData(_seeder.SeedLocationToServices());
            modelBuilder.Entity<Service>().HasData(_seeder.SeedServices());
            modelBuilder.Entity<User>().HasData(_seeder.SeedUsers());
        }
    }
}
