using Meditelligence.Models;

namespace Meditelligence.DataAccess.Repositories.Interfaces
{
    public interface ILocationToServiceRepo
    {
        /// <summary>
        /// Returns a list of records that contain the locationID.
        /// </summary>
        /// <param name="id">the location ID</param>
        /// <returns>A list of records with LocationID specified present.</returns>
        IEnumerable<LocationToService> GetLocationToServiceByLocationID(int id);

        /// <summary>
        /// Returns a list of records that contain the ServiceID.
        /// </summary>
        /// <param name="id">The serviceID to search for.</param>
        /// <returns>A list of records with that service ID.</returns>
        IEnumerable<LocationToService> GetLocationToServiceByServiceID(int id);

        /// <summary>
        /// Adds a join record between location and service.
        /// </summary>
        /// <param name="locationID">the ID of the location record to join.</param>
        /// <param name="serviceID">the ID of the service record to join.</param>
        void CreateLocationToService(int locationID, int serviceID);

        /// <summary>
        /// Saves the changes of the database.
        /// </summary>
        /// <returns>A bool representing whether save was successful or not.</returns>
        bool SaveChanges();
    }
}