namespace Meditelligence.DataAccess.Repositories.Interfaces
{
    public interface IIllnessToSymptomRepo
    {
        /// <summary>
        /// Creates a <see cref="IllnessToSymptom"/> record. 
        /// </summary>
        /// <param name="illnessID">The illness ID.</param>
        /// <param name="symptomID">The symptom ID.</param>
        void CreateIllnessToSymptom(int illnessID, int symptomID);

        /// <summary>
        /// Saves the changes made to the database.
        /// </summary>
        /// <returns>a bool representing the success of the operation.</returns>
        bool SaveChanges();
    }
}