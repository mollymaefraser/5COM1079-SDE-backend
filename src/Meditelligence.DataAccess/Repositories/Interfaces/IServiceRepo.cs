using Meditelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories.Interfaces
{
    /// <summary>
    /// An interface for a class that will interact with the <see cref="Service"/> records in the database.
    /// </summary>
    public interface IServiceRepo
    {
        /// <summary>
        /// Gets all <see cref="Service"/> records from the DbContext. 
        /// </summary>
        /// <returns>A list of Services from the database.</returns>
        IEnumerable<Service> GetAllServices();

        /// <summary>
        /// Gets a individual <see cref="Service"/> record based on the ID provided.
        /// </summary>
        /// <param name="id">The ID of the record to return.</param>
        /// <returns>An <see cref="Service"/> record with the corresponding ID.</returns>
        Service GetServiceById(int id);

        /// <summary>
        /// Adds a <see cref="Service"/> record to the database.
        /// </summary>
        /// <param name="Service">The Service record to add.</param>
        void CreateService(Service Service);

        /// <summary>
        /// Saves changes of the database.
        /// </summary>
        /// <returns>A boolean representing success or not of saving the db.</returns>
        bool SaveChanges();
    }
}
