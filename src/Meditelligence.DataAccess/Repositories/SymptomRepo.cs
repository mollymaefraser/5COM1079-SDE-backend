using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories
{
    public class SymptomRepo : ISymptomRepo
    {
        private readonly MeditelligenceDBContext _context;

        public SymptomRepo(MeditelligenceDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public void CreateSymptom(Symptom symptom)
        {
            if (symptom is null)
            {
                throw new ArgumentNullException(nameof(symptom));
            }

            symptom.Name = symptom.Name.ToLower();

            if (_context.Symptoms.Any(s => s.Name == symptom.Name))
            {
                throw new InvalidDataException("Symptom already exists");
            }

            _context.Symptoms.Add(symptom);
        }

        /// <inheritdoc/>
        public IEnumerable<Symptom> GetAllSymptoms()
        {
            return _context.Symptoms.ToList();
        }

        /// <inheritdoc/>
        public Symptom GetSymptomById(int id)
        {
            return _context.Symptoms.FirstOrDefault(i => i.SymptomID == id);
        }

        /// <inheritdoc/>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
