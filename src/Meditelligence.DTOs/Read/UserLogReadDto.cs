namespace Meditelligence.DTOs.Read
{
    public class UserLogReadDto
    {
        /// <summary>
        /// The unique identifier of this record.
        /// </summary>
        public int LogID { get; set; }

        /// <summary>
        /// The date this record was created.
        /// </summary>
        public DateTime LogDate { get; set; }

        /// <summary>
        /// The name of the record entered.
        /// </summary>
        public string PredictedIllness { get; set; }

        /// <summary>
        /// The name of the symptoms entered..
        /// </summary>
        public List<string> EnteredSymptoms { get; set; }


    }
}
