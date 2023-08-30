using Meditelligence.Models;

namespace Meditelligence.DataAccess.Seeder
{
    public interface IMeditelligenceDBSeeder
    {
        IEnumerable<Location> SeedLocations();
        IEnumerable<LocationToService> SeedLocationToServices();
        IEnumerable<Service> SeedServices();
        IEnumerable<User> SeedUsers();
    }
}