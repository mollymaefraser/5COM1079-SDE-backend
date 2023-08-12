using Meditelligence.Models;

namespace Meditelligence.DataAccess.Repositories
{
    public interface ILocationRepo
    {
        void CreateLocation(Location location);
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(int id);
        bool SaveChanges();
    }
}