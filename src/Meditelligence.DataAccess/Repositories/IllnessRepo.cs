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
    public class IllnessRepo : IIllnessRepo
    {
        private readonly MeditelligenceDBContext _context;

        public IllnessRepo(MeditelligenceDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public void CreateIllness(Illness illness)
        {
            if (illness is null)
            {
                throw new ArgumentNullException(nameof(illness));
            }

            illness.Name = illness.Name.ToLower();

            if (_context.Illnesses.Any(i => i.Name == illness.Name))
            {
                throw new InvalidDataException("Illness already exists.");
            }

            _context.Illnesses.Add(illness);
        }

        /// <inheritdoc/>
        public IEnumerable<Illness> GetAllIllnesses()
        {
            return _context.Illnesses.ToList();
        }

        /// <inheritdoc/>
        public Illness GetIllnessById(int id)
        {
            return _context.Illnesses.FirstOrDefault(i => i.IllnessID == id);
        }

        /// <inheritdoc/>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
