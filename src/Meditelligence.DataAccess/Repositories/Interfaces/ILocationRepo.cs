using Meditelligence.Models;

namespace Meditelligence.DataAccess.Repositories.Interfaces
{
    public interface ILocationRepo
    {
        /// <summary>
        /// Creates a <see cref="Location"/> record.
        /// </summary>
        /// <param name="location">the location object to pass in.</param>
        void CreateLocation(Location location);

        /// <summary>
        /// Gets all locations currently stored in the database.
        /// </summary>
        /// <returns>A list of <see cref="Location"/>.</returns>
        IEnumerable<Location> GetAllLocations();

        /// <summary>
        /// Gets a location based on the ID provided.
        /// </summary>
        /// <param name="id">The id of the record to obtain.</param>
        /// <returns>A <see cref="Location"/> object of the record with a matching ID.</returns>
        Location GetLocationById(int id);

        /// <summary>
        /// Saves the changes in the database.
        /// </summary>
        /// <returns>A bool showing whether operation was successful or not.</returns>
        bool SaveChanges();
    }
}