namespace Meditelligence.DataAccess.Repositories.Interfaces
{
    public interface IUserLogsToSymptomsRepo
    {
        /// <summary>
        /// Creates a user log to symptom record.
        /// </summary>
        /// <param name="logID">the ID of the log record.</param>
        /// <param name="symptomID">the ID of the symptom record.</param>
        void CreateUserLogToSymptom(int logID, int symptomID);

        /// <summary>
        /// Saves changes of database.
        /// </summary>
        /// <returns>A boolean representing whether the save operation was successful.</returns>
        bool SaveChanges();
    }
}