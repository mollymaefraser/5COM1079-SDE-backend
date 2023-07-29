using Meditelligence.Models.Models;

namespace Meditelligence.DataAccess.Seeder
{
    public interface IMeditelligenceDBSeeder
    {
        IEnumerable<Illness> SeedIllnesses();
        IEnumerable<IllnessToSymptom> SeedIllnessToSymptoms();
        IEnumerable<Symptom> SeedSymptoms();
    }
}