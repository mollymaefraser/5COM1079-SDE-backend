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
    public class UserLogRepo : IUserLogRepo
    {
        private readonly ILogger<UserLogRepo> _logger;
        private readonly MeditelligenceDBContext _context;

        public UserLogRepo(MeditelligenceDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public void CreateUserLog(UserLog userLog)
        {
            if (userLog is null)
            {
                throw new ArgumentNullException(nameof(userLog));
            }

            _context.UserLogs.Add(userLog);
        }

        /// <inheritdoc/>
        public IEnumerable<UserLog> GetAllUserLogs()
        {
            return _context.UserLogs.ToList().OrderBy(log => log.LogDate);
        }

        /// <inheritdoc/>
        public UserLog GetUserLogById(int id)
        {
            return _context.UserLogs.FirstOrDefault(u => u.LogID == id);
        }

        /// <inheritdoc/>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
