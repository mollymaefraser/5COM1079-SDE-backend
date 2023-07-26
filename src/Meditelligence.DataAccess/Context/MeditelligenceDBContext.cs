﻿using Meditelligence.DataAccess.Seeder;
using Meditelligence.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Context
{
    /// <summary>
    /// The derived <see cref="DbContext"/> class for specific use within Meditelligence.
    /// </summary>
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
        }
    }
}