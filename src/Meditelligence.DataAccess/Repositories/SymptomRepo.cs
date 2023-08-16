using Meditelligence.DataAccess.Context;
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

        public IEnumerable<Symptom> GetAllSymptoms()
        {
            return _context.Symptoms.ToList();
        }

        public Symptom GetSymptomById(int id)
        {
            return _context.Symptoms.FirstOrDefault(i => i.SymptomID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
