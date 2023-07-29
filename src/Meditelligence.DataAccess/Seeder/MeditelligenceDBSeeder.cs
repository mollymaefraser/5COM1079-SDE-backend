using Meditelligence.DataAccess.Context;
using Meditelligence.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Seeder
{
    /// <summary>
    /// A seeder class used to populate the database with records.
    /// </summary>
    public class MeditelligenceDBSeeder : IMeditelligenceDBSeeder
    {
        public IEnumerable<Illness> SeedIllnesses()
        {
            return new List<Illness>()
            {
                new Illness()
                {
                    IllnessID = 1,
                    Name = "Test disease 1",
                    Description = "This is a test disease that will be later removed",
                    Advice = "Speak to your GP for further information regarding this"
                },
                new Illness()
                {
                    IllnessID = 2,
                    Name = "Test disease 2",
                    Description = "This is another test disease that will be later removed",
                    Advice = "Speak to a specialist re. this condition, as it could be severe"
                }
            };
        }

        public IEnumerable<Symptom> SeedSymptoms()
        {
            return new List<Symptom>()
            {
                new Symptom()
                {
                    SymptomID = 1,
                    Name = "Symptom 1",
                    Description = "High fever",
                },
                new Symptom()
                {
                    SymptomID = 2,
                    Name = "Symptom 2",
                    Description = "Short bursts of giggling",
                },
                new Symptom()
                {
                    SymptomID = 3,
                    Name = "Symptom 3",
                    Description = "Seeing hallucinations",
                },
                new Symptom()
                {
                    SymptomID = 4,
                    Name = "Symptom 4",
                    Description = "Extreme fits of anger",
                },
                new Symptom()
                {
                    SymptomID = 5,
                    Name = "Symptom 5",
                    Description = "No description",
                }
            };
        }

        public IEnumerable<IllnessToSymptom> SeedIllnessToSymptoms()
        {
            return new List<IllnessToSymptom>()
            {
                new IllnessToSymptom()
                {
                    IllnessRefID = 1,
                    SymptomRefID = 1,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 1,
                    SymptomRefID = 2,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 1,
                    SymptomRefID = 3,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 2,
                    SymptomRefID = 3,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 2,
                    SymptomRefID = 4,
                },
                new IllnessToSymptom()
                {
                    IllnessRefID = 2,
                    SymptomRefID = 5,
                },
            };
        }
    }
}
