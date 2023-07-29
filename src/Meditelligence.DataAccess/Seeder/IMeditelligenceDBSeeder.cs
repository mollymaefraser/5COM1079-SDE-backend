using Meditelligence.Models;

namespace Meditelligence.DataAccess.Seeder
{
    public interface IMeditelligenceDBSeeder
    {
        IEnumerable<Illness> SeedIllnesses();
        IEnumerable<IllnessToSymptom> SeedIllnessToSymptoms();
        IEnumerable<Symptom> SeedSymptoms();
        IEnumerable<Location> SeedLocations();
        IEnumerable<LocationToService> SeedLocationToServices();
        IEnumerable<Service> SeedServices();
    }
}