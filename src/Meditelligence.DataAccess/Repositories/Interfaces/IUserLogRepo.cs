using Meditelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories.Interfaces
{
    public interface IUserLogRepo
    {
        /// <summary>
        /// Gets all <see cref="UserLog"/> records from the DbContext. 
        /// </summary>
        /// <returns>A list of user logs from the database.</returns>
        IEnumerable<UserLog> GetAllUserLogs();

        /// <summary>
        /// Gets a individual <see cref="UserLog"/> record based on the ID provided.
        /// </summary>
        /// <param name="id">The ID of the record to return.</param>
        /// <returns>An <see cref="UserLog"/> record with the corresponding ID.</returns>
        UserLog GetUserLogById(int id);

        /// <summary>
        /// Adds a <see cref="UserLog"/> record to the database.
        /// </summary>
        /// <param name="userLog">The log record to add.</param>
        void CreateUserLog(UserLog userLog);

        /// <summary>
        /// Saves changes of the database.
        /// </summary>
        /// <returns>A boolean representing success or not of saving the db.</returns>
        bool SaveChanges();
    }
}
