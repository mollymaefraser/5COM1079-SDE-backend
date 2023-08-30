using Meditelligence.Models;

namespace Meditelligence.DataAccess.Repositories.Interfaces
{
    public interface ISymptomRepo
    {
        /// <summary>
        /// Creates a <see cref="Symptom"/> record.
        /// </summary>
        /// <param name="symptom">The symptom object to add.</param>
        void CreateSymptom(Symptom symptom);

        /// <summary>
        /// Gets all symptom records from the database.
        /// </summary>
        /// <returns>A list of symptom records.</returns>
        IEnumerable<Symptom> GetAllSymptoms();

        /// <summary>
        /// Gets a symptom record that matches the ID provided.
        /// </summary>
        /// <param name="id">the ID of the record to search for.</param>
        /// <returns>a symptom record that has the ID provided.</returns>
        Symptom GetSymptomById(int id);

        /// <summary>
        /// Saves changes of database.
        /// </summary>
        /// <returns>A bool representing the success of the save operation.</returns>
        bool SaveChanges();
    }
}