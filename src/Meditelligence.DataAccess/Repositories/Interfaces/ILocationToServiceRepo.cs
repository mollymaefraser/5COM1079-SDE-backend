namespace Meditelligence.DataAccess.Repositories.Interfaces
{
    public interface ILocationToServiceRepo
    {
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