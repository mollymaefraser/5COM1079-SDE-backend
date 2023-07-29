using Meditelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories
{
    /// <summary>
    /// An interface for a class that will interact with the <see cref="Illness"/> records in the database.
    /// </summary>
    public interface IIllnessRepo
    {
        /// <summary>
        /// Gets all <see cref="Illness"/> records from the DbContext. 
        /// </summary>
        /// <returns>A list of Illnesses from the database.</returns>
        IEnumerable<Illness> GetAllIllnesses();

        /// <summary>
        /// Gets a individual <see cref="Illness"/> record based on the ID provided.
        /// </summary>
        /// <param name="id">The ID of the record to return.</param>
        /// <returns>An <see cref="Illness"/> record with the corresponding ID.</returns>
        Illness GetIllnessById(int id);

        /// <summary>
        /// Adds a <see cref="Illness"/> record to the database.
        /// </summary>
        /// <param name="illness">The illness record to add.</param>
        void CreateIllness(Illness illness);

        bool SaveChanges();
    }
}
