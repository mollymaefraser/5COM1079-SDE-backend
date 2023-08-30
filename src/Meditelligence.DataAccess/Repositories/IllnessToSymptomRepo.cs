using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories
{
    public class IllnessToSymptomRepo : IIllnessToSymptomRepo
    {
        private readonly MeditelligenceDBContext _context;
        private readonly ILogger<IllnessToSymptomRepo> _logger;

        public IllnessToSymptomRepo(MeditelligenceDBContext context, ILogger<IllnessToSymptomRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <inheritdoc/>
        public void CreateIllnessToSymptom(int illnessID, int symptomID)
        {
            if (_context.Illnesses.Find(illnessID) == null)
            {
                throw new ArgumentException("The illness could not be found.");
            }
            else if (_context.Symptoms.Find(symptomID) == null)
            {
                throw new ArgumentException("The symptom could not be found.");
            }
            else
            {
                if (_context.IllnessToSymptoms.Any(i => i.IllnessRefID == illnessID && i.SymptomRefID == symptomID))
                {
                    _logger.LogInformation("Record between Illness with ID {illnessID} & symptom with ID {symptomID} not created as already exists.", illnessID, symptomID);
                    return;
                }
                else
                {
                    _context.IllnessToSymptoms.Add(new IllnessToSymptom()
                    {
                        IllnessRefID = illnessID,
                        SymptomRefID = symptomID,
                    });
                }
            }
        }

        /// <inheritdoc/>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
