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
    public class UserLogsToSymptomsRepo : IUserLogsToSymptomsRepo
    {
        private readonly MeditelligenceDBContext _context;
        private readonly ILogger<UserLogsToSymptomsRepo> _logger;

        public UserLogsToSymptomsRepo(MeditelligenceDBContext context, ILogger<UserLogsToSymptomsRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <inheritdoc/>
        public void CreateUserLogToSymptom(int logID, int symptomID)
        {
            if (_context.UserLogs.Find(logID) == null)
            {
                throw new ArgumentException("The log record could not be found.");
            }
            else if (_context.Symptoms.Find(symptomID) == null)
            {
                throw new ArgumentException("The symptom could not be found.");
            }
            else
            {
                if (_context.UserLogToSymptoms.Any(i => i.RefLogID == logID && i.RefSymptomID == symptomID))
                {
                    _logger.LogInformation("Record between Log with ID {logID} & symptom with ID {symptomID} not created as already exists.", logID, symptomID);
                    return;
                }
                else
                {
                    _context.UserLogToSymptoms.Add(new UserLogSymptom()
                    {
                        RefLogID = logID,
                        RefSymptomID = symptomID,
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
