using Meditelligence.Models;

namespace Meditelligence.DataAccess.Repositories
{
    public interface ISymptomRepo
    {
        void CreateSymptom(Symptom symptom);
        IEnumerable<Symptom> GetAllSymptoms();
        Symptom GetIllnessById(int id);
        bool SaveChanges();
    }
}