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
    public class IllnessRepo : IIllnessRepo
    {
        private readonly MeditelligenceDBContext _context;

        public IllnessRepo(MeditelligenceDBContext context)
        {
            _context = context;
        }

        public void CreateIllness(Illness illness)
        {
            if (illness is null)
            {
                throw new ArgumentNullException(nameof(illness));
            }

            _context.Illnesses.Add(illness);
        }

        public IEnumerable<Illness> GetAllIllnesses()
        {
            return _context.Illnesses.ToList();
        }

        public Illness GetIllnessById(int id)
        {
            return _context.Illnesses.FirstOrDefault(i => i.IllnessID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
